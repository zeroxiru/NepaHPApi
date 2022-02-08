using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NepaHPApi.Models
{
    public partial class HPDBContext : DbContext
    {
        public HPDBContext()
        {
        }

        public HPDBContext(DbContextOptions<HPDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<House> Houses { get; set; }
        public virtual DbSet<Occupation> Occupations { get; set; }
        public virtual DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                  //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-R3CFU5T;Initial Catalog=HPDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<House>(entity =>
            {
                entity.ToTable("House");
            });

            modelBuilder.Entity<Occupation>(entity =>
            {
                entity.ToTable("Occupation");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.HasIndex(e => e.HouseId)
                    .HasName("IX_Persons_HouseId");

                entity.HasIndex(e => e.OccupationId)
                    .HasName("IX_Persons_OccupationId");

                entity.Property(e => e.LastName).HasColumnName("lastName");

                entity.HasOne(d => d.House)
                    .WithMany(p => p.Persons)
                    .HasForeignKey(d => d.HouseId)
                    .HasConstraintName("FK_Persons_Houses_HouseId");

                entity.HasOne(d => d.Occupation)
                    .WithMany(p => p.Persons)
                    .HasForeignKey(d => d.OccupationId)
                    .HasConstraintName("FK_Persons_Occupations_OccupationId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
