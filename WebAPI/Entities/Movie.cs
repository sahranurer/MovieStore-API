using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Entities
{
    public class Movie{
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieID { get; set; }
        public string Name { get; set; }
        public string MovieYear { get; set; }
        public string MovieType { get; set; }
        public string MoviePrice { get; set; }

        public int DirectorID { get; set; }
        public Director Director { get; set; }

        public List<Actor> Actors {get;set;}

     
        
    }
}