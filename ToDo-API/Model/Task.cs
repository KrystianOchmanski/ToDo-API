namespace ToDo_API.Model
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public bool IsImportant {  get; set; }
        public bool IsCompleted { get; set; }
        public DateOnly CreationDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly? EndDate { get; set; }
    }
}
