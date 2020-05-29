using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace BookAPICore31.Models
{
    public class Author
    {
        public Author()
        {
            BookAuthors = new List<BookAuthor>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "First Name Cannot be More than 100 chars")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Last Name Cannot be More than 100 chars")]
        public string LastName { get; set; }

        public virtual Country Country { get; set; }
        
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
