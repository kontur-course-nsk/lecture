using System.IO;

namespace CleanCode.Examples
{
    class Example9
    {
        public void Do(string file1, string file2)
        {
            var data = File.ReadAllBytes(file1);

            if (data.Length == 0 || data.Length > 1024 * 1024 * 10)
            {
                throw new InvalidDataException();
            }

            if (data.Length % 20 != 0)
            {
                throw new InvalidDataException();
            }

            Compress(data, file2);
        }

        private void Compress(byte[] data, string file)
        {
            var compressed = new byte[data.Length / 20];
            var j = 0;
            for (int i = 0; i < data.Length; i += 20)
            {
                compressed[j++] = data[i];
            }

            File.WriteAllBytes(file, compressed);
        }

    }
}
