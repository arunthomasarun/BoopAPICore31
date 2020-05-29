using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPICore31.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Headline Cannot be More than 100 chars")]
        public string HeadLine { get; set; }

        [Required]
        [MaxLength(2000, ErrorMessage = "Review Text Cannot be More than 2000 chars")]
        public string ReviewText { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        public virtual Reviewer Reviewer{ get; set; }
        public virtual Book Book { get; set; }

    }
}
