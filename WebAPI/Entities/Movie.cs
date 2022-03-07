using System;
using System.Collections.Generic;

namespace WebAPI.Entities
{
    public class Movie{
        public int MovieID { get; set; }
        public string Name { get; set; }
        public DateTime MovieYear { get; set; }
        public string MovieType { get; set; }
        public string MoviePrice { get; set; }

        public int DirectorID { get; set; }
        public Director Director { get; set; }

        public IList<MovieActor> MovieActors { get; set; }
        
    }
}