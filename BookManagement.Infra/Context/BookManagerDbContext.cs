using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookManagement.Domain.Models;

namespace BookManagement.Infra.Context
{
    public class BookManagerDbContext : DbContext
    {
        public BookManagerDbContext(DbContextOptions<BookManagerDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Writer> Writers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .ToTable("Book")
                .HasOne<Writer>(book => book.Writer)
                .WithMany(writer => writer.Books)
                .HasForeignKey(book => book.WriterId);


            modelBuilder.Entity<Writer>()
                .ToTable("Writer");

            modelBuilder.Entity<Book>().Property(book => book.IsActive).HasColumnName("IS_ACTIVE");

            modelBuilder.Entity<Book>().Property(book => book.WriterId).HasColumnName("WRITER_ID");

            modelBuilder.Entity<Writer>().Property(writer => writer.IsActive).HasColumnName("IS_ACTIVE");
        }
    }
}
