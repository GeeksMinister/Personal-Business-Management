using Microsoft.EntityFrameworkCore;
using PersonalBusinessManagement.Models;

namespace PersonalBusinessManagement.Data;

#pragma warning disable CS8618
public class PersonalBusinessManagementContext : DbContext
{
    public PersonalBusinessManagementContext(
        DbContextOptions<PersonalBusinessManagementContext> options) :base(options) { }

    public DbSet<Project> Project { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<Currency>();
        modelBuilder.Ignore<ErrorViewModel>();
        modelBuilder.Ignore<GithubRepo>();
    }

    public DbSet<PersonalBusinessManagement.Models.Todo>? Todo { get; set; }


}
