using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        //public Movie Movie { get; set; }

        public int? Id { get; set; }

        [Required]
        public String Name { get; set; }


        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? RealseDate { get; set; }

        [Required]
        [Display(Name = "Number In Stock")]
        [Range(1,20)]
        public byte? NumberInStock { get; set; }


        public string Title
        {
            get
            {
                if (Id != 0)
                {
                    return "Edit Movie";
                }

                return "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
            RealseDate = DateTime.MinValue;
            NumberInStock = 0;            
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            RealseDate = movie.RealseDate;
            GenreId = movie.GenreId;
            NumberInStock = movie.NumberInStock;
        }
    }
}