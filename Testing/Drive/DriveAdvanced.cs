using System;
using System.Linq;

namespace Testing
{
    public partial class Drive
    {
        public static bool TryCreate(int length, out Drive drive)
        {
            try
            {
                drive = new Drive(length);
                return true;
            }
            catch (Exception)
            {
                drive = null;
                return false;
            }
        }

        public void Defragmentation()
        {
            if (!this.metas.Any())
            {
                return;
            }

            var offset = 0;
            foreach (var meta in this.metas.Values.OrderBy(x => x.Offset))
            {
                this.ShiftLeft(meta.Offset, meta.Size, meta.Offset - offset);

                this.metas[meta.Filename] = new FileMeta(meta.Filename, offset, meta.Size);

                offset += meta.Size;
            }
        }

        private void ShiftLeft(int offset, int count, int shift)
        {
            if (shift == 0)
            {
                return;
            }

            for (var carret = offset; carret < offset + count; carret++)
            {
                this.storage[carret - shift] = this.storage[carret];
            }
        }
    }
}