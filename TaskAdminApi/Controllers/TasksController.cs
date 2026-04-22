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
    public async Task<IActionResult> GetTasks(string? status)
    {
        var sql = _context.Tasks.AsQueryable();
        if (!string.IsNullOrEmpty(status))
        
            sql = sql.Where(t => t.Status == status);
        return Ok(await sql.ToListAsync());

    }


    [HttpPost]
    public async Task<IActionResult> CreateTask(TaskItems task)
    {
        if (string.IsNullOrEmpty(task.Title))
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