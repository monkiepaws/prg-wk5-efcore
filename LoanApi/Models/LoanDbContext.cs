using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LoanApi.Models
{
    public partial class LoanDbContext : DbContext
    {
        public LoanDbContext()
        {
        }

        public LoanDbContext(DbContextOptions<LoanDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Loan> Loan { get; set; }
        public virtual DbSet<Student> Student { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.AuthorId).ValueGeneratedNever();

                entity.Property(e => e.AuthorFirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AuthorLastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AuthorTfn)
                    .IsRequired()
                    .HasColumnName("AuthorTFN")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Isbn)
                    .HasName("PK__Book__447D36EB93D641EF");

                entity.Property(e => e.Isbn)
                    .HasColumnName("ISBN")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_To_Author");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasKey(e => e.Isbn);

                entity.Property(e => e.Isbn)
                    .HasColumnName("ISBN")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.StudentId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IsbnNavigation)
                    .WithOne(p => p.Loan)
                    .HasForeignKey<Loan>(d => d.Isbn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Loan_To_Book");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Loan)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Loan_To_Student");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
