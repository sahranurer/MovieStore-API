using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Entities
{
   public class Director{
   
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DirectorID { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string TheMovieDirected { get; set; }

  

   }
}