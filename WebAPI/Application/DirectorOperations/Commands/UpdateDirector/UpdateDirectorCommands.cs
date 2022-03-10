using System;
using System.Linq;
using WebAPI.DbOperations;

namespace WebAPI.Application.DirectorOperations.Commands
{
    public class UpdateDirectorCommands
    {
        private readonly IMovieDbContext _context;

        public int DirectorID { get; set; }

        public UpdateDirectorViewModel Model { get; set; }


        public UpdateDirectorCommands(IMovieDbContext context)
        {
            _context = context;
        }

        public void Handle(){
            var director = _context.Directors.SingleOrDefault(x=>x.DirectorID == DirectorID);
            if (director is null)
            {
                throw new InvalidOperationException("Böyle bir director yok :)");
            }
            //tabloda bulunan director name eşitlenmesi için 
            // Dışarıdan gelen Model.Name boş veya null değilse Model.Name eşitle
            //Eğer gelen veri boş ise direk var olan veriye eşitle
            director.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? director.Name : Model.Name;
            director.Surname = string.IsNullOrEmpty(Model.Surname.Trim()) ? director.Surname : Model.Surname;
            
            _context.SaveChanges();
        }



    }
    public class UpdateDirectorViewModel
    {

    public string Name { get; set; }
    public string Surname { get; set; }
   
    }
}