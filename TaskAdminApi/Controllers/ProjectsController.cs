using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskAdminApi.Models;

namespace TaskAdminApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProjectsController: ControllerBase
{
    private readonly AppDbContext _context;

    public ProjectsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetProjects()
    {
        var projects = await _context.Projects.ToListAsync();
        return Ok(projects);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProject(Project project)
    {
        if (string.IsNullOrEmpty(project.Name))
        {
            return BadRequest("Name is required");
        }

        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        return Ok(project);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProject(int id, Project project)
    {
        var existing = await _context.Projects.FindAsync(id);

        if (existing == null)
            return NotFound();

        existing.Name = project.Name;

        await _context.SaveChangesAsync();

        return Ok(existing);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        var project = await _context.Projects.FindAsync(id);

        if (project == null)
            return NotFound();

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();

        return Ok();
    }
}