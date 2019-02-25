namespace Client.Models.Notes
{
    using System;

    /// <summary>
    /// Информация о создании заметки
    /// </summary>
    public sealed class NoteCreationInfo
    {
        public string Id { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
