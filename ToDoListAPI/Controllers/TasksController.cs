using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TaskClass; // Import untuk menggunakan DbContext dan model TaskToDo

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
    public ActionResult<IEnumerable<TaskToDo>> GetTasks()
    {
        return _context.Tasks.ToList();
    }

    // GET: api/Tasks/{id}
    [HttpGet("{id}")]
    public ActionResult<TaskToDo> GetTask(int id)
    {
        var task = _context.Tasks.Find(id);

        if (task == null)
        {
            return NotFound();
        }

        return task;
    }

    // POST: api/Tasks
    [HttpPost]
    public ActionResult<TaskToDo> CreateTask(TaskToDo task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }

    // PUT: api/Tasks/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateTask(int id, TaskToDo updatedTask)
    {
        if (id != updatedTask.Id)
        {
            return BadRequest();
        }

        var task = _context.Tasks.Find(id);
        if (task == null)
        {
            return NotFound();
        }

        task.NameTask = updatedTask.NameTask;
        task.Description = updatedTask.Description;
        task.DueDate = updatedTask.DueDate;
        task.Category = updatedTask.Category;
        task.IsComplete = updatedTask.IsComplete;

        _context.SaveChanges();
        return NoContent();
    }

    // DELETE: api/Tasks/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task == null)
        {
            return NotFound();
        }

        _context.Tasks.Remove(task);
        _context.SaveChanges();
        return NoContent();
    }
}
