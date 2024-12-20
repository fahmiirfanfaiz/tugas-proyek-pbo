using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskClass.Models;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ToDoListDbContext _context;

        public TasksController(ToDoListDbContext context)
        {
            _context = context;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskToDo>>> GetTasks()
        {
            return await _context.TaskToDos.ToListAsync();
        }

        // GET: api/Tasks/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskToDo>> GetTask(int id)
        {
            var task = await _context.TaskToDos.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        // POST: api/Tasks
        [HttpPost]
        public async Task<ActionResult<TaskToDo>> CreateTask(TaskToDo task)
        {
            _context.TaskToDos.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        // PUT: api/Tasks/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskToDo updatedTask)
        {
            if (id != updatedTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(updatedTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Tasks/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.TaskToDos.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.TaskToDos.Remove(task);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool TaskExists(int id)
        {
            return _context.TaskToDos.Any(e => e.Id == id);
        }
    }
}

