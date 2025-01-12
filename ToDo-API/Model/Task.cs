namespace ToDo_API.Model
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public bool IsImportant {  get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
