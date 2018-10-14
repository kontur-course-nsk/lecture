using System.IO;

namespace CleanCode.Examples
{
    class Example9_Result
    {
        public void CompressFile(string source, string destination)
        {
            var data = ReadFromFile(source);

            ValidateData(data);

            var compressed = Compress(data);

            WriteToFile(destination, compressed);
        }

        private void ValidateData(byte[] data)
        {
            if (data.Length == 0 || data.Length > 1024 * 1024 * 10)
            {
                throw new InvalidDataException();
            }

            if (data.Length % 20 != 0)
            {
                throw new InvalidDataException();
            }
        }

        private byte[] ReadFromFile(string path)
        {
            return File.ReadAllBytes(path);
        }

        private void WriteToFile(string path, byte[] data)
        {
            File.WriteAllBytes(path, data);
        }

        private byte[] Compress(byte[] data)
        {
            var compressed = new byte[data.Length / 20];
            var j = 0;
            for (int i = 0; i < data.Length; i += 20)
            {
                compressed[j++] = data[i];
            }

            return compressed;
        }
    }
}
