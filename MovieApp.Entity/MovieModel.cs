using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MovieApp.Entity
{
    public class MovieModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }


        public string Language { get; set; }
    }
}
