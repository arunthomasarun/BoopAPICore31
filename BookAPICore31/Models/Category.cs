using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace BookAPICore31.Models
{
    public class Category
    {
        public Category()
        {
            BookCategories = new List<BookCategory>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Category Name Cannot be More than 100 chars")]
        public string Name { get; set; }

        public virtual ICollection<BookCategory> BookCategories { get; set; }

    }
}
