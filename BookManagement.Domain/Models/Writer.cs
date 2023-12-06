using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Models
{
    public class Writer : BaseEntity
    {
        public Writer() { 
        
        }

        public Writer(string Name)
        {
            this.Name = Name;
            this.IsActive = true;

        }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<Book> Books { get; set; }

        public void Update()
        {
            ValidateBook();
        }

        private void ValidateBook()
        {
            if (string.IsNullOrEmpty(this.Name))
                throw new InvalidOperationException("Invalid writer name.");
        }
    }
}
