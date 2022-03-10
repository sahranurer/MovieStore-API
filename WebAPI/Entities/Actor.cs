using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Entities
{
   public class Actor{
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ActorID { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    
    public int MovieID { get; set; }
    public Movie Movie { get; set; }

    

   }
}