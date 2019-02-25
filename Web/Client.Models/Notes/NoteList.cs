namespace Client.Models.Notes
{
    using System.Collections.Generic;

    /// <summary>
    /// Список заметок. Отдельный объект нужен для расширяемости с сохранением обратной совместимости.
    /// </summary>
    public sealed class NoteList
    {
        /// <summary>
        /// Список заметок
        /// </summary>
        public IReadOnlyList<Note> Items { get; set; }
    }
}
