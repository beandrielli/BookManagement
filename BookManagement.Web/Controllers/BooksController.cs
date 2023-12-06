using BookManagement.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookManagement.Domain.Models;
using BookManagement.Service;
using BookManagement.Web.DTOs;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BookManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult GetBooks()
        {
            try
            {

                List<Book> books = _bookService.GetBooks();

                List<BookDTO> result = new List<BookDTO>();

                //Best way to translate it would be with mapper, but for timesake I'm doing it mannually
                if (books.Any())
                    result = books.Select(_book => new BookDTO() { Id = _book.Id, Title = _book.Title, Writer = _book.Writer.Name, Year = _book.Year }).ToList();

                return Ok(result);

            }
            catch (Exception ex)
            {
                //Implement log here
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<BookDTO> GetBook(int id)
        {
            try
            {
                
                Book? book = _bookService.Get(id);

                if (book == null)
                {
                    return NotFound(new { message = $"Book {id} not found." });
                }

                BookDTO result = new BookDTO() { Id = book.Id, Title = book.Title, Writer = book.Writer.Name, Year = book.Year };

                return result;

            }
            catch (Exception ex)
            {
                //Implement log here
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        public ActionResult Create(BookDTO book)
        {
            try
            {
                if (book.Year <= 0)
                    return BadRequest("Invalid year.");

                _bookService.Save(book.Title, book.Writer, book.Year);

                return Ok();

            }
            catch (Exception ex)
            {
                //Implement log here
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPatch]
        public ActionResult Update(BookDTO book)
        {
            try
            {

                if (book.Year <= 0)
                    return BadRequest("Invalid year.");

                _bookService.Update(book.Id, book.Title, book.Year, book.Writer);

                return Ok();

            }

            catch (Exception ex)
            {
                //Implement log here
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {

                _bookService.Delete(id);

                return Ok();
           
            }
            catch (Exception ex)
            {
                //Implement log here
                return StatusCode(500, ex.Message);
            }
        }
    }
}
