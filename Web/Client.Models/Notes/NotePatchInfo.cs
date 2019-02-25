namespace Client.Models.Notes
{
    /// <summary>
    /// Информация для редактирования заметки
    /// </summary>
    public sealed class NotePatchInfo
    {
        public string Title { get; set; }

        public string Text { get; set; }
    }
}
