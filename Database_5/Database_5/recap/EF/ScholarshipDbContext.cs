using System;
using System.Collections.Generic;
using recap.EF.Tables;
using Microsoft.EntityFrameworkCore;
namespace recap.EF;
public partial class ScholarshipDbContext : DbContext
{
    public ScholarshipDbContext()
    {
    }
    public ScholarshipDbContext(DbContextOptions<ScholarshipDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Student> Students { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ScholarshipDbContext");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC07A1B2C3D4");
            entity.ToTable("Student");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Cgpa).HasColumnType("decimal(4, 2)");
        });
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
