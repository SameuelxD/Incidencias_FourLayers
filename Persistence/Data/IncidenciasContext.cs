using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entitites;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;
public class IncidenciasContext : DbContext
{
    public IncidenciasContext(DbContextOptions options) : base(options) { }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<TrainerCourse> TrainerCourses { get; set; }
    public DbSet<Tuition> Tuitions { get; set; }
    public DbSet<TypePerson> TypePeople { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
