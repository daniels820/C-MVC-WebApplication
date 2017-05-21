using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DAL.EF.Models;

namespace DAL.EF.EntityFrameworkContext
{
    public partial class AteraDevServerForInterviewsContext : DbContext
    {
        public virtual DbSet<Devices> Devices { get; set; }
        public virtual DbSet<Owners> Owners { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=tcp:tky4ecqv9m.database.windows.net,1433;Database=AteraDevServerForInterviews;User ID=TestUser69326@tky4ecqv9m;Password=Password69326;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Devices>(entity =>
            {
                entity.HasKey(e => e.DeviceId)
                    .HasName("PK__Devices__49E123116293F39B");

                entity.Property(e => e.DeviceId).ValueGeneratedNever();

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Devices_ToOwners");
            });

            modelBuilder.Entity<Owners>(entity =>
            {
                entity.HasKey(e => e.OwnerId)
                    .HasName("PK__Owners__819385B86ED0596F");

                entity.Property(e => e.OwnerId).ValueGeneratedNever();

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.ContactId)
                    .HasName("PK_Users");

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__Users__536C85E417D9F76D")
                    .IsUnique();

                entity.Property(e => e.ContactId)
                    .HasColumnName("ContactID")
                    .HasMaxLength(30);

                entity.Property(e => e.HashPassword).HasMaxLength(250);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(150);
            });
        }
    }
}