using System.ComponentModel.DataAnnotations;
using ToDo_API.Model.Attributes;

namespace ToDo_API.Model.DTOs.Task
{
    public class AddEditTaskDTO
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = null!;

        [Range(1, 3, ErrorMessage = "Priority must be between 1 and 3.")]
        public int Priority { get; set; } = 1;

        [FutureDate(ErrorMessage = "EndDate must be in the future.")]
        public DateTime? EndDate { get; set; }

        public bool IsCompleted { get; set; } = false;
    }
}
