using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace BookAPICore31.Models
{
    public class Book
    {
        public Book()
        {
            Reviews = new List<Review>();
            BookAuthors = new List<BookAuthor>();
            BookCategories = new List<BookCategory>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id  { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "ISBN should be between 3 and 10 chars")]
        public string Isbn { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Title Cannot be More than 100 chars")]
        public string Title { get; set; }

        public DateTime? PublishedDate { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
        public virtual ICollection<BookCategory> BookCategories { get; set; }
    }
}
