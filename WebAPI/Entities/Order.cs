using System;

namespace WebAPI.Entities
{
    public class Order{
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public int MovieID { get; set; }
        public Movie Movie { get; set; }

        public string MoviePrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}