using Microsoft.EntityFrameworkCore;
using TaskAdminApi.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Project> Projects { get; set; }
    public DbSet<TaskItems> Tasks { get; set; }
}