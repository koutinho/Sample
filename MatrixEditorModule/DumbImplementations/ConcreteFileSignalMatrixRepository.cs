using SignalMatrixEditor.Model;
using SignalMatrixEditor.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.DumbImplementations
{
    public class ConcreteFileSignalMatrixRepository : ISignalMatrixRepository
    {
        public ConcreteFileSignalMatrixRepository(string fileName)
        {
            this.fileName = fileName;
        }

        public SignalMatrix Read()
        {
            if (!File.Exists(fileName))
            {
                return null;
            }

            string json = File.ReadAllText(fileName);

            return SignalMatrixConverter.FromJson(json);
        }

        public void Write(SignalMatrix signalMatrix)
        {
            string json = SignalMatrixConverter.ToJson(signalMatrix);

            File.WriteAllText(fileName, json);
        }

        public async Task WriteAsync(SignalMatrix signalMatrix)
        {
            string json = SignalMatrixConverter.ToJson(signalMatrix);

            using (var stream = new StreamWriter(File.OpenWrite(fileName)))
            {
                await stream.WriteAsync(json);

                await Task.Delay(2000);
            }
        }

        public async Task<SignalMatrix> ReadAsync()
        {
            if (!File.Exists(fileName))
            {
                return null;
            }

            string json;

            using (var stream = new StreamReader(File.OpenRead(fileName)))
            {
                json = await stream.ReadToEndAsync();
            }

            await Task.Delay(2000);

            return SignalMatrixConverter.FromJson(json);
        }

        private string fileName;
    }
}
