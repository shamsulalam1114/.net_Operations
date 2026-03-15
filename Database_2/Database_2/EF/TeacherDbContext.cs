using System;
using System.Collections.Generic;
using Database_2.EF.Tables;
using Microsoft.EntityFrameworkCore;

namespace Database_2.EF;

public partial class TeacherDbContext : DbContext
{
    public TeacherDbContext()
    {
    }

    public TeacherDbContext(DbContextOptions<TeacherDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=TeacherDbContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teachers__EDF259645854C88F");

            entity.Property(e => e.Department).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
