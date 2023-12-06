using BookManagement.Domain.Models;
using BookManagement.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Infra.Repositories
{

    public class BookRepository : Repository<Book>
    {
        public BookRepository(BookManagerDbContext context) : base(context)
        { }

        public override Book? GetById(int id)
        {
            var query = _context.Books
                .Where(_book => _book.Id == id && _book.IsActive)
                .Include(book => book.Writer);

            if (query.Any())
                return query.First();

            return null;
        }

        public override Book? GetByName(string name)
        {
            var query = _context.Set<Book>()
                .Where(_book => _book.Title.Contains(name) && _book.IsActive == true);

            return query.Any() ? query.FirstOrDefault() : null;
        }

        public override IEnumerable<Book> GetAll()
        {
            var query = _context.Books
                .Where(_book => _book.IsActive)
                .Include(book => book.Writer);

            return query.Any() ? query.ToList() : new List<Book>();
        }

        public override void Save(Book book) {

            _context.Books.Add(book);

            _context.SaveChanges();

        }

        public override void Update(Book book)
        {

            book.Update();

            _context.Entry(book).State = EntityState.Modified;

            _context.SaveChanges();

        }

        public override void Delete(Book book)
        {
            _context.Books.Remove(book);

            _context.SaveChanges();

        }
    }
}
