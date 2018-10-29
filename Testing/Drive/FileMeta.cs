using System.Text;

namespace Testing
{
    /// <summary> Этот класс тестировать не нужно. </summary>
    public sealed class FileMeta
    {
        public FileMeta(string filename, int offset, int size)
        {
            this.Filename = filename;
            this.Offset = offset;
            this.Size = size;
        }

        public string Filename { get; }

        public int Offset { get; }

        public int Size { get; }

        #region Overriding members

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.Append($"filename:{this.Filename}; ");
            builder.Append($"offset:{this.Offset}; ");
            builder.Append($"size:{this.Size}; ");

            return builder.ToString();
        }

        #endregion

        #region EqualityMembers

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is FileMeta other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (this.Filename != null ? this.Filename.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ this.Offset;
                hashCode = (hashCode * 397) ^ this.Size;
                return hashCode;
            }
        }

        private bool Equals(FileMeta other)
        {
            return string.Equals(this.Filename, other.Filename) &&
                   this.Offset == other.Offset &&
                   this.Size == other.Size;
        }

        #endregion
    }
}