namespace Client.Models.Notes
{
    using System;

    /// <summary>
    /// Запрос поиска заметок
    /// </summary>
    public sealed class NoteSearchQuery
    {
        /// <summary>
        /// Количество заметок, которое нужно пропустить. Нужно для организации постраничного вывода.
        /// </summary>
        public int? Skip { get; set; }

        /// <summary>
        /// Количество заметок, которое нужно взять. Нужно для организации постраничного вывода.
        /// </summary>
        public int? Take { get; set; }

        /// <summary>
        /// Сортировка выполняется по дате создания. Если true, то сортировать в обратном порядке.
        /// </summary>
        public bool? Descending { get; set; }

        /// <summary>
        /// Фильтр по дате. Брать заметки, дата создания которых больше или равна FromDate.
        /// </summary>
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// Фильтр по дате. Брать заметки, дата создания которых меньше ToDate.
        /// </summary>
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// Фильтр по Favorite. Брать заметки, которые отмечены как любимые.
        /// </summary>
        public bool? Favorite { get; set; }
    }
}
