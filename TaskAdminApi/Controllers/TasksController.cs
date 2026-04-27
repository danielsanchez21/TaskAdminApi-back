using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskAdminApi.Models;

namespace TaskAdminApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly AppDbContext _context;

    public TasksController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetTasks(int? projectId, string? status)
    {
        var query = _context.Tasks.AsQueryable();

        if (projectId.HasValue)
            query = query.Where(t => t.ProjectId == projectId.Value);

        if (!string.IsNullOrWhiteSpace(status))
            query = query.Where(t => t.Status == status);

        var tasks = await query.ToListAsync();

        return Ok(tasks);
    }


    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] TaskItems task)
    {
        if (string.IsNullOrWhiteSpace(task.Title))
            return BadRequest("Title is required");

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return Ok(task);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, TaskItems task)
    {
        var exist = await _context.Tasks.FindAsync(id);

        if (exist == null)
            return NotFound();

        exist.Title = task.Title;
        exist.Description = task.Description;
        exist.Status = task.Status;
        exist.DueDate = task.DueDate;

        await _context.SaveChangesAsync();
        return Ok(exist);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var searchTask = await _context.Tasks.FindAsync(id);

        if (searchTask == null)
            return NotFound();
        _context.Tasks.Remove(searchTask);
        await _context.SaveChangesAsync();
        return Ok();
    }
    
}