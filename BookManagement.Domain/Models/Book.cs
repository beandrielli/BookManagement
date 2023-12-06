using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Models
{
    public class Book : BaseEntity
    {
        public Book() {
        }   

        public Book(string title, int year, int authorId) {

            this.Year = year;
            this.Title = title;
            this.WriterId = authorId;
            this.IsActive = true;
        }

        public int Year { get;  set; }

        public int WriterId { get;  set; }

        public string Title { get;  set; }

        public bool IsActive { get;  set; }

        public Writer Writer { get; set; }

        public void Update() {
            ValidateBook();
        }

        private void ValidateBook()
        {
            if (this.Year <= 0)
                throw new InvalidOperationException("Invalid year.");

            if(string.IsNullOrEmpty( this.Title))
                throw new InvalidOperationException("Invalid year.");

            if (WriterId <= 0) 
                throw new InvalidOperationException("Invalid Author");

        }

    }
}
