using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo_API.Model.DTOs.Task;

namespace ToDo_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : Controller
    {
        private readonly AppDbContext _context;
        public TaskController(AppDbContext appDbContext) 
        { 
            _context = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            try
            {
                var allTasks = await _context.Tasks.OrderByDescending(t => t.Id).ToListAsync();
                return Ok(allTasks);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            try
            {
                var task = await _context.Tasks.FindAsync(id);
                if (task == null)
                    return NotFound();
                return Ok(task);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(AddEditTaskDTO addTaskDTO)
        {
            try
            {
                var newTask = new Model.Task
                {
                    Title = addTaskDTO.Title,
                    IsImportant = addTaskDTO.IsImportant,
                    EndDate = addTaskDTO.EndDate,
                    IsCompleted = addTaskDTO.IsCompleted,
                };

                _context.Tasks.Add(newTask);
                await _context.SaveChangesAsync();
                return Ok(newTask);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditTask(int id, [FromBody] AddEditTaskDTO editTaskDTO)
        {
            try
            {
                var task = await _context.Tasks.FindAsync(id);
                if (task == null) return NotFound();

                task.CreationDate = DateOnly.FromDateTime(DateTime.Now);
                task.Title = editTaskDTO.Title;
                task.IsImportant = editTaskDTO.IsImportant;
                task.EndDate = editTaskDTO.EndDate;
                task.IsCompleted = editTaskDTO.IsCompleted;

                _context.Tasks.Update(task);
                await _context.SaveChangesAsync();
                return Ok(task);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                var task = await _context.Tasks.FindAsync(id);
                if(task == null) return NotFound();
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
