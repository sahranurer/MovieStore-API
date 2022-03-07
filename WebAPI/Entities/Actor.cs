using System.Collections.Generic;

namespace WebAPI.Entities
{
   public class Actor{
    public int ActorID { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string StarringMovies { get; set; }

    public IList<MovieActor> MovieActors { get; set; }

   }
}