using System;
using System.Collections.Generic;
using midterm_prep_2_new.EF.Tables;
using Microsoft.EntityFrameworkCore;

namespace midterm_prep_2_new.EF;

public partial class ScholarDbContext : DbContext
{
    public ScholarDbContext()
    {
    }

    public ScholarDbContext(DbContextOptions<ScholarDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:ScholarDbContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC07");

            entity.ToTable("Student");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Cgpa).HasColumnType("decimal(4, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}