using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DigitalBook.Models
{
    public partial class BookDBContext : DbContext
    {
        public BookDBContext()
        {
        }

        public BookDBContext(DbContextOptions<BookDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CreateBook> CreateBooks { get; set; }
        public virtual DbSet<LogIn> LogIns { get; set; }
        public virtual DbSet<SearchBook> SearchBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CTSDOTNET841;Initial Catalog=BookDB;User ID=sa;password=pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CreateBook>(entity =>
            {
                entity.ToTable("CreateBook");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active).IsUnicode(false);

                entity.Property(e => e.Category).IsUnicode(false);

                entity.Property(e => e.Content).IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Price).IsUnicode(false);

                entity.Property(e => e.Publisher).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);
            });

            modelBuilder.Entity<LogIn>(entity =>
            {
                entity.ToTable("LogIn");

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);
            });

            modelBuilder.Entity<SearchBook>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Author).IsUnicode(false);

                entity.Property(e => e.Publisher).IsUnicode(false);

                entity.Property(e => e.ReleasedDate)
                    .IsUnicode(false)
                    .HasColumnName("Released Date");

                entity.Property(e => e.Title).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
