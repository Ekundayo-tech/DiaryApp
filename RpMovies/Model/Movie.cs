using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RpMovies.Model
{
    public class Movie
    {
        public int Id { get; set; }
        [Display(Name ="ReleasedDate")]
        [DataType(DataType.Date)]
        public DateTime  ReleasedDate { get; set; }
        public string Title { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
