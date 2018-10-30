using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Testing
{
    public partial class Drive
    {
        private readonly IDictionary<string, FileMeta> metas = new Dictionary<string, FileMeta>();

        private readonly char[] storage;

        public Drive(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Drive length should be greater than zero.", nameof(length));
            }

            this.storage = new char[length];
        }

        public int Size => this.storage.Length;

        public FileMeta Save(string filename, string content, int offset)
        {
            if (filename == null)
            {
                throw new ArgumentNullException(nameof(filename));
            }

            if (this.metas.ContainsKey(filename))
            {
                throw new AlreadyExistsException("Filename already exists.");
            }

            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            var size = content.Length;

            if (this.IsMemoryCollisionsExists(offset, size))
            {
                throw new InvalidOperationException("Found possible violation of memory consistency.");
            }

            var meta = new FileMeta(filename, offset, size);
            this.metas.Add(meta.Filename, meta);

            if (!this.IsValidBounds(offset, size))
            {
                throw new ArgumentOutOfRangeException(nameof(offset), "Found violation of storage boundaries.");
            }

            this.WriteContent(content, offset);
            
            return meta;
        }

        public string Load(string filename)
        {
            if (filename == null)
            {
                throw new ArgumentNullException(nameof(filename));
            }

            if (!this.metas.TryGetValue(filename, out var meta))
            {
                throw new FileNotFoundException("File not found on Drive.", filename);
            }

            return this.ReadContent(meta.Offset, meta.Size);
        }

        public void Delete(string filename)
        {
            if (filename == null)
            {
                throw new ArgumentNullException(nameof(filename));
            }

            if (!this.metas.ContainsKey(filename))
            {
                throw new FileNotFoundException("File not found on Drive.", filename);
            }

            this.metas.Remove(filename);
        }

        public IReadOnlyList<FileMeta> GetFiles()
        {
            return this.metas.Values.ToList();
        }

        private void WriteContent(string content, int offset)
        {
            for (int i = 0, carriage = offset; i < content.Length; i++, carriage++)
            {
                this.storage[carriage] = content[i];
            }
        }

        private string ReadContent(int offset, int length)
        {
            var builder = new StringBuilder();

            for (int carriage = offset; carriage < offset + length; carriage++)
            {
                builder.Append(this.storage[carriage]);
            }

            return builder.ToString();
        }

        private bool IsMemoryCollisionsExists(int offset, int size)
        {
            foreach (var meta in this.metas.Values)
            {
                var isLeftBorderInsideAnyOtherSegment = meta.Offset <= offset &&
                                                        (meta.Offset + meta.Size) > offset;

                var isRightBorderInsideAnyOtherSegment = meta.Offset < (offset + size) &&
                                                         (meta.Offset + meta.Size) > (offset + size);

                if (isLeftBorderInsideAnyOtherSegment || isRightBorderInsideAnyOtherSegment)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsValidBounds(int offset, int size)
        {
            return offset >= 0 && offset + size <= this.storage.Length;
        }
    }
}