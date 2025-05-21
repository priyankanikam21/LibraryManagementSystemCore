using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemCore.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Title can only contain letters and spaces")]

        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }

        public string Category { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "No book available.")]
        public int CopiesAvailable { get; set; }
    }
}
