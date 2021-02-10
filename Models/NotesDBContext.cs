using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace NotesAPP.Models
{
    public partial class NotesDBContext : DbContext
    {
        public NotesDBContext()
        {
        }

        public NotesDBContext(DbContextOptions<NotesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(e => e.NotesId)
                    .HasName("PK__Notes__35AB5B4AE2252FF9");

                entity.Property(e => e.NotesId).HasColumnName("NotesID");

                entity.Property(e => e.NoteColor)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NoteDescription)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.NotesName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tag)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Notes__UserID__267ABA7A");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
