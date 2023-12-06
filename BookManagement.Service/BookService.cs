using BookManagement.Domain.Interfaces;
using BookManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Service
{
    public class BookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Writer> _writerRepository;
        private readonly WriterService _writerService;

        public BookService(IRepository<Book> bookRepository, IRepository<Writer> writerRepoitory, WriterService writerService)
        {
            _bookRepository = bookRepository;
            _writerRepository = writerRepoitory;
            _writerService = writerService;
        }

        public List<Book> GetBooks()
        {

            return _bookRepository.GetAll().ToList();

        }

        public Book? Get(int id) {

            return _bookRepository.GetById(id);

        }

        public void Save(string Title, string writerName, int year)
        {
            Writer writer = _writerService.GetOrCreateWriter(writerName);

            Book book = new Book()
            {
                WriterId = writer.Id,
                Title = Title,
                Year = year,
                IsActive = true
            };

            _bookRepository.Save(book);

        }

        public void Update(int id, string title, int year, string writerName)
        {

            Book? book = _bookRepository.GetById(id);

            if (book == null) throw new Exception("Book does not exist");

            Writer writer = _writerService.GetOrCreateWriter(writerName);

            book.Title = title;
            book.Year = year;
            book.WriterId = writer.Id;

            _bookRepository.Update(book);

        }

        public void Delete(int id) { 
            
            Book? book = _bookRepository.GetById(id);

            if(book == null) throw new Exception("Book does not exist");
            
            book.IsActive = false;
            _bookRepository.Update(book);
        
        }
    }
}
