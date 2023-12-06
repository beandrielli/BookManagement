using System.ComponentModel.DataAnnotations;

namespace BookManagement.Web.DTOs
{
    public class BookDTO
    {

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Writer { get; set; }

        [Required]
        public int Year { get; set; }
    }
}
