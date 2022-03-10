using System;

namespace WebAPI.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

         public string RefreshToken { get; set; }
         public DateTime? RefreshTokenExpireDate { get; set; }

        public int MovieID { get; set; }
        public Movie Movie { get; set; }

    }
}