using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.DbOperations
{
    public class MovieDbContext : DbContext,IMovieDbContext{
        
      public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }  
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
          
      }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
    }

       public DbSet<Actor> Actors { get; set; }
       public DbSet<Director> Directors { get; set; }
       public DbSet<Movie> Movies { get; set; }

      public DbSet<Customer> Customers { get; set; }
      

        public override int SaveChanges(){
         return base.SaveChanges();       
   }
       

    } 
    
}