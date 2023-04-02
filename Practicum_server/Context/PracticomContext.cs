using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repository.Entity;
using Repository.Interfaces;

namespace Context;

public partial class PracticomContext : DbContext,IContext
{
    public PracticomContext()
    {
    }

    public PracticomContext(DbContextOptions<PracticomContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FatherAndChild> FatherAndChildren { get; set; }

    public virtual DbSet<Hmo> Hmos { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-KFF1NP2;Initial Catalog=Practicom;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FatherAndChild>(entity =>
        {
            entity.ToTable("FatherAndChild");

            entity.Property(e => e.ChildId).HasColumnName("childId");
            entity.Property(e => e.FatherId).HasColumnName("fatherId");
            entity.Property(e => e.MotherId).HasColumnName("motherId");

            entity.HasOne(d => d.Child).WithMany(p => p.FatherAndChildChildren)
                .HasForeignKey(d => d.ChildId)
                .HasConstraintName("FK_FatherAndChild_Persons1");

            entity.HasOne(d => d.Father).WithMany(p => p.FatherAndChildFathers)
                .HasForeignKey(d => d.FatherId)
                .HasConstraintName("FK_FatherAndChild_Persons");

            entity.HasOne(d => d.Mother).WithMany(p => p.FatherAndChildMothers)
              .HasForeignKey(d => d.MotherId)
              .HasConstraintName("FK_FatherAndChild_Persons2");
        });

        modelBuilder.Entity<Hmo>(entity =>
        {
            entity.ToTable("HMOs");

            entity.Property(e => e.Hmoid).HasColumnName("HMOId");
            entity.Property(e => e.Hmoname)
                .HasMaxLength(50)
                .HasColumnName("HMOName");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.Property(e => e.PersonId).HasColumnName("personId");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("dateOfBirth");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("firstName");
            entity.Property(e => e.Hmoid).HasColumnName("HMOid");
            entity.Property(e => e.IdNumber)
                .HasMaxLength(9)
                .IsFixedLength()
                .HasColumnName("idNumber");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("lastName");

            entity.HasOne(d => d.Hmo).WithMany(p => p.People)
                .HasForeignKey(d => d.Hmoid)
                .HasConstraintName("FK_Persons_HMOs");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
