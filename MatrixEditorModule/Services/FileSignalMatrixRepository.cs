using DevExpress.Mvvm;
using Newtonsoft.Json;
using SignalMatrixEditor.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.Services
{
    public class FileSignalMatrixRepository : ISignalMatrixRepository
    {
        public FileSignalMatrixRepository(ISaveFileDialogService saveFileDialogService, IOpenFileDialogService openFileDialogService, string defaultFileName = "SignalMatrix")
        {
            saveFileDialogService.Filter = filter;
            saveFileDialogService.FilterIndex = filterIndex;
            saveFileDialogService.Title = exportTitle;
            saveFileDialogService.DefaultExt = defaultExt;
            saveFileDialogService.DefaultFileName = defaultFileName;

            openFileDialogService.Filter = filter;
            openFileDialogService.FilterIndex = filterIndex;
            openFileDialogService.Title = importTitle;

            this.saveFileDialogService = saveFileDialogService;
            this.openFileDialogService = openFileDialogService;
            this.defaultFileName = defaultFileName;
        }

        private ISaveFileDialogService saveFileDialogService;

        private IOpenFileDialogService openFileDialogService;

        private const string filter = "Json Files (.json)|*.json|All Files (*.*)|*.*";

        private const int filterIndex = 1;

        private const string exportTitle = "Экспорт матрицы сигналов в файл";

        private const string importTitle = "Импорт матрицы сигналов из файла";

        private const string defaultExt = "json";

        private string defaultFileName;

        public void Write(SignalMatrix signalMatrix)
        {
            string json = SignalMatrixConverter.ToJson(signalMatrix);

            saveFileDialogService.InitialDirectory = Directory.GetCurrentDirectory();

            if (saveFileDialogService.ShowDialog())
            {
                using (var stream = new StreamWriter(saveFileDialogService.OpenFile()))
                {
                    stream.Write(json);
                }
            }
        }

        public SignalMatrix Read()
        {
            openFileDialogService.InitialDirectory = Directory.GetCurrentDirectory();

            if (openFileDialogService.ShowDialog())
            {
                using (var stream = openFileDialogService.File.OpenText())
                {
                    string json = stream.ReadToEnd();

                    var signalMatrix = SignalMatrixConverter.FromJson(json);

                    return signalMatrix;
                }
            }
            else return null;
        }

        public async Task WriteAsync(SignalMatrix signalMatrix)
        {
            string json = SignalMatrixConverter.ToJson(signalMatrix);

            saveFileDialogService.InitialDirectory = Directory.GetCurrentDirectory();

            if (saveFileDialogService.ShowDialog())
            {
                using (var stream = new StreamWriter(saveFileDialogService.OpenFile()))
                {
                    await stream.WriteAsync(json);
                }
            }
        }

        public async Task<SignalMatrix> ReadAsync()
        {
            openFileDialogService.InitialDirectory = Directory.GetCurrentDirectory();

            if (openFileDialogService.ShowDialog())
            {
                using (var stream = openFileDialogService.File.OpenText())
                {
                    string json = await stream.ReadToEndAsync();

                    var signalMatrix = SignalMatrixConverter.FromJson(json);

                    return signalMatrix;
                }
            }
            else return null;
        }
    }
}
