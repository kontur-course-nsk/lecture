namespace Models.Notes
{
    using System;

    public class NoteNotFoundException : Exception
    {
        public NoteNotFoundException(Guid id) : base($"Note \"{id}\" not found.")
        {
        }
    }
}
