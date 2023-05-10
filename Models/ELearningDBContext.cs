﻿
// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Microsoft.EntityFrameworkCore;


public partial class ELearningDBContext : DbContext
{
    public ELearningDBContext()
    {
    }

    public ELearningDBContext(DbContextOptions<ELearningDBContext> options)
        : base(options)
    {
    }


    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Admin> Admins { get; set; }
    public virtual DbSet<Instructor> Instructors { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("UserDB"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

		modelBuilder.Entity<Course>(entity =>
		{
			entity.HasKey(c => c.Id);
		});

		modelBuilder.Entity<Admin>(entity =>
		{
			entity.HasKey(a => a.Id);
		});

		modelBuilder.Entity<User>(entity =>
		{
			entity.HasKey(i => i.Id);
		});

		OnModelCreatingPartial(modelBuilder);
    }

    

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}