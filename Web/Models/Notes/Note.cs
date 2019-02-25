namespace Models.Notes
{
    using System;

    /// <summary>
    /// Заметка
    /// </summary>
    public sealed class Note
    {
        /// <summary>
        /// Идентификатор заметки
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Заголовок заметки
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Текст заметки
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Отмечена ли заметка как любимая
        /// </summary>
        public bool Favorite { get; set; }

        /// <summary>
        /// Дата создания заметки
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Дата последнего изменения заметки
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}
