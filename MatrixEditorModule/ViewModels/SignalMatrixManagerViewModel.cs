using DevExpress.Mvvm;
using SignalMatrixEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalMatrixEditor.Services;
using DevExpress.DirectX.Common.Direct2D;
using Common.Logging;
using SignalMatrixEditor.Report;
using SignalMatrixEditor.ViewModels.Nodes;
using System.IO;
using Common.Interfaces;
using SignalMatrixEditor.Model.Device;
using SignalMatrixEditor.Model.Verifiers;
using System.IO.Packaging;

namespace SignalMatrixEditor.ViewModels
{
    public class SignalMatrixManagerViewModel : ViewModelBase
    {
        public SignalMatrixManagerViewModel(SignalMatrixDescriptor signalMatrixDescriptor)
        {
            this.signalMatrixDescriptor = signalMatrixDescriptor;

            SignalMatrixEditorViewModel = new SignalMatrixEditorViewModel(signalMatrixDescriptor);

            ExportToFileCommand = new DelegateCommand(ExportToFile);
            ImportFromFileCommand = new DelegateCommand(ImportFromFile);
            WriteToDeviceCommand = new AsyncCommand(WriteToDeviceAsync);
            ReadFromDeviceCommand = new AsyncCommand(ReadFromDeviceAsync);
            ExportReportCommand = new AsyncCommand(ExportReport);
            VerifyMatrixCommand = new DelegateCommand(VerifyMatrix);
        }
        
        public SignalMatrixEditorViewModel SignalMatrixEditorViewModel { get; private set; }

        public DelegateCommand ExportToFileCommand { get; set; }

        public DelegateCommand ImportFromFileCommand { get; set; }

        public DelegateCommand VerifyMatrixCommand { get; set; }

        public AsyncCommand ExportReportCommand { get; set; }

        public AsyncCommand WriteToDeviceCommand { get; set; }

        public AsyncCommand ReadFromDeviceCommand { get; set; }

        public bool HeavyProccessBeingExecuted
        {
            get
            {
                return _heavyProccessBeingExecuted;
            }

            set
            {
                SetValue(ref _heavyProccessBeingExecuted, value);
            }
        }
        private bool _heavyProccessBeingExecuted;

        public string OutputFileName
        {
            get
            {
                return $"{device.DeviceInformation.DeviceSeries} {device.DeviceInformation.DeviceName} {toolName} {DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss")}";
            }
        }

        public ISaveFileDialogService SaveFileDialogService
        {
            get
            {
                return GetService<ISaveFileDialogService>();
            }
        }

        public IOpenFileDialogService OpenFileDialogService
        {
            get
            {
                return GetService<IOpenFileDialogService>();
            }
        }

        IMessageBoxService MessageBoxService
        {
            get
            {
                return GetService<IMessageBoxService>();
            }
        }

        public ISignalMatrixRepository ProjectDbSignalMatrixRepository
        {
            get;
            set;
        }

        public event EventHandler SignalMatrixReadFromDevice;

        public event EventHandler SignalMatrixWrittenToDevice;

        public void UseDevice(IDevice device)
        {
            this.device = device;
            deviceSignalMatrixRepository = new DeviceSignalMatrixRepository(device, signalMatrixDescriptor);
        }

        public void Configure(Action<SignalMatrixManagerConfigurator> configureDelegate)
        {
            configureDelegate(new SignalMatrixManagerConfigurator(this));
        }

        public void Initialize()
        {
            logger.Info("Чтение матрицы из проекта");

            SignalMatrix signalMatrix = null;

            try
            {
                signalMatrix = ProjectDbSignalMatrixRepository.Read();
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка при чтении матрицы из проекта", ex);
                throw;
            }

            if (signalMatrix != null)
            {
                logger.Info("Инициализация редактора матрицой");

                SignalMatrixEditorViewModel.Initialize(signalMatrix);

                SignalMatrixEditorViewModel.Commit();
            }
        }

        public void DeInitialize()
        {
            if (SignalMatrixEditorViewModel.IsMatrixChanged)
            {
                MessageResult dialogResult = MessageBoxService.ShowMessage("Есть несохраненные изменения. Сохранить изменения перед выходом?", "Сохранение перед выходом",
                    MessageButton.YesNo, MessageIcon.Question);

                if (dialogResult == MessageResult.Yes)
                {
                    SaveMatrixToProjectDb();
                }
            }
        }

        public async Task DeInitializeAsync()
        {
            logger.Info("Ожидание завершения работы с устройством");

            await WaitForReadFromDeviceCommandExecuted();

            await WaitForWriteToDeviceCommandExecuted();

            DeInitialize();
        }

        private SignalMatrixDublicateVerifier DublicateVerifier
        {
            get
            {
                if (dublicateVerifier == null)
                    dublicateVerifier = new SignalMatrixDublicateVerifier();

                return dublicateVerifier;
            }
        }
        private SignalMatrixDublicateVerifier dublicateVerifier;

        private SignalMatrixDescriptor signalMatrixDescriptor;

        private IDevice device;

        private DeviceSignalMatrixRepository deviceSignalMatrixRepository;

        private const string toolName = "Матрица входов и выходных реле";

        private ISignalMatrixRepository FileRepository
        {
            get
            {
                return new FileSignalMatrixRepository(SaveFileDialogService, OpenFileDialogService, OutputFileName);
            }
        }

        private async Task WaitForReadFromDeviceCommandExecuted()
        {
            await WaitForCommandExecuted(ReadFromDeviceCommand);
        }

        private async Task WaitForWriteToDeviceCommandExecuted()
        {
            await WaitForCommandExecuted(WriteToDeviceCommand);
        }

        private async Task WaitForCommandExecuted(AsyncCommand asyncCommand)
        {
            while (asyncCommand.IsExecuting)
            {
                await Task.Delay(100);
            }
        }

        private void ExportToFile()
        {
            SignalMatrix signalMatrix = SignalMatrixEditorViewModel.BuildSignalMatrix();

            try
            {
                logger.Info("Экспорт матрицы в файл");

                FileRepository.Write(signalMatrix);
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка при экспорте матрицы в файл");
            }
        }

        private void ImportFromFile()
        {
            logger.Info("Импорт матрицы из файла");

            SignalMatrix signalMatrix = null;

            try
            {
                signalMatrix = FileRepository.Read();
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка при импорте матрицы из файла.", ex);
            }

            if (signalMatrix != null)
            {
                SignalMatrixEditorViewModel.Initialize(signalMatrix);
            }
        }

        private async Task ExportReport()
        {
            var saveFileDialogService = SaveFileDialogService;

            saveFileDialogService.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialogService.Filter = "Файлы xls|*.xls";
            saveFileDialogService.FilterIndex = 1;
            saveFileDialogService.Title = "Сохранение матрицы сигналов в XLS-формате";
            saveFileDialogService.DefaultExt = "xls";
            saveFileDialogService.DefaultFileName = OutputFileName;

            if (saveFileDialogService.ShowDialog())
            {
                HeavyProccessBeingExecuted = true;

                SignalMatrixReport report = new SignalMatrixReport(signalMatrixDescriptor,
                    SignalMatrixEditorViewModel.NodeViewModels,
                    device.DeviceInformation.DeviceName,
                    device.DeviceInformation.DeviceSeries);

                try
                {
                    logger.Info("Формирование отчета");
                    await report.CreateDocumentAsync();
                }
                catch (Exception ex)
                {
                    logger.Error("Ошибка при формировании отчета.", ex);
                    HeavyProccessBeingExecuted = false;
                    throw;
                }

                try
                {
                    logger.Info("Сохранение отчета");
                    string path = saveFileDialogService.File.GetFullName();
                    await report.ExportToXlsAsync(path);
                }
                catch (Exception ex)
                {
                    logger.Error("Ошибка при сохранении отчета.", ex);
                    HeavyProccessBeingExecuted = false;
                    throw;
                }

                HeavyProccessBeingExecuted = false;
            }
        }

        private void SaveMatrixToProjectDb()
        {
            SignalMatrix signalMatrix = SignalMatrixEditorViewModel.BuildSignalMatrix();

            logger.Info("Сохранение матрицы в проект");

            try
            {
                ProjectDbSignalMatrixRepository.Write(signalMatrix);
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка при сохранении матрицы в проект", ex);
                throw;
            }
        }

        private async Task WriteToDeviceAsync()
        {
            HeavyProccessBeingExecuted = true;

            SignalMatrix signalMatrix = SignalMatrixEditorViewModel.BuildSignalMatrix();

            try
            {
                logger.Info("Запись матрицы на устройство.");
                await deviceSignalMatrixRepository.WriteAsync(signalMatrix);
            }
            catch (Exception ex)
            {
                HeavyProccessBeingExecuted = false;

                logger.Error("Ошибка при записи матрицы на устройство.", ex);
                throw;
            }

            try
            {
                logger.Info("Сохранение матрицы в проект.");

                ProjectDbSignalMatrixRepository.Write(signalMatrix);
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка при сохранении матрицы в проект.", ex);
                HeavyProccessBeingExecuted = false;

                throw;
            }

            OnSignalMatrixWrittenToDevice(EventArgs.Empty);

            SignalMatrixEditorViewModel.Commit();

            HeavyProccessBeingExecuted = false;
        }

        private async Task ReadFromDeviceAsync()
        {
            if (SignalMatrixEditorViewModel.IsMatrixChanged)
            {
                MessageResult dialogResult = MessageBoxService.ShowMessage("Чтение матрицы из устройства приведет к потере несохраненных данных. Сохранить изменения перед чтением?",
                    "Импорт матрицы из устройства.", MessageButton.YesNo, MessageIcon.Warning);

                if (dialogResult == MessageResult.Yes)
                {
                    SaveMatrixToProjectDb();
                }
            }

            HeavyProccessBeingExecuted = true;

            SignalMatrix signalMatrix = null;

            try
            {
                logger.Info("Чтение матрицы из изделия");
                signalMatrix = await deviceSignalMatrixRepository.ReadAsync();
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка при записи матрицы на устройство.", ex);
                HeavyProccessBeingExecuted = false;
                throw;
            }

            OnSignalMatrixReadFromDevice(EventArgs.Empty);

            if (signalMatrix != null)
            {
                SignalMatrixEditorViewModel.Initialize(signalMatrix);
            }

            HeavyProccessBeingExecuted = false;
        }

        private void OnSignalMatrixReadFromDevice(EventArgs e)
        {
            EventHandler handler = SignalMatrixReadFromDevice;
            handler?.Invoke(this, e);
        }

        private void OnSignalMatrixWrittenToDevice(EventArgs e)
        {
            EventHandler handler = SignalMatrixWrittenToDevice;
            handler?.Invoke(this, e);
        }

        private void VerifyMatrix()
        {
            string errorMessage;

            if (!DublicateVerifier.Verify(signalMatrixDescriptor, out errorMessage))
            {
                MessageBoxService.ShowMessage(errorMessage, "Некорректная матрица", MessageButton.OK, MessageIcon.Warning);
            }
        }

        private ILog logger = LogManager.GetLogger<SignalMatrixManagerViewModel>();
    }
}
