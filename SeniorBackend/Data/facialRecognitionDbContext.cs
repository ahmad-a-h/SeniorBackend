
using Microsoft.EntityFrameworkCore;
using SeniorBackend.Controllers;
using SeniorBackend.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace facialRecognitionBackend.Data;
public class facialRecognitionDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
        optionsBuilder.UseSqlServer( configuration.GetConnectionString("AzureConnection")) ;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //M to M Sub_Category <==> App_User
        builder.Entity<CourseStudent>().HasOne(key => key.Student)
            .WithMany(key => key.Courses).HasForeignKey(key => key.StudentsId);
        builder.Entity<CourseStudent>().HasOne(key => key.Course)
            .WithMany(key => key.Students).HasForeignKey(key => key.Coursesid);
    }

    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Class> Classes { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<CourseStudent> CourseStudent { get; set; } = null!;
    public DbSet<Session> Session { get; set; } = null!;
    public DbSet<Attendance> Attendance { get; set; } = null!;
    public DbSet<Attendended> Attendanded { get; set; } = null!;

    public DbSet<Face> FaceEncoding { get; set; } = null!;




}

