using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.DbOperations
{
    public interface IMovieDbContext{
         public DbSet<Actor> Actors { get; set; }
       public DbSet<Director> Directors { get; set; }
       public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }

       

           int SaveChanges();
    }
}