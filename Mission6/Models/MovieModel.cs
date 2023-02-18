using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Models
{
    public class MovieModel
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Year is required")]
        public ushort Year { get; set; }
        [Required(ErrorMessage = "Director is required")]
        public string Director { get; set; }
        [Required(ErrorMessage = "Rating is required")]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [StringLength(25)]
        public string Notes { get; set; }


        // Foreign Key
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }
        public MovieCategory Category { get; set; }
    }
}
