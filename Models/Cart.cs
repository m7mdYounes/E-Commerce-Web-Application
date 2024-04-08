using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class Cart
    {
        public int Id { get; set; }
        //[ForeignKey("customer")]
        //public int customerID { get; set; }
        //public Customer customer { get; set; }

        [ForeignKey("User")]
        public string userid { get; set; }
        public ApplicationUser User { get; set; }

        [ForeignKey("product")]
        public int productID { get; set; }
        public Product product { get; set; }
    }
}
