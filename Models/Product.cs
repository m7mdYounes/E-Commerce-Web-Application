using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        //public string? image {  get; set; }
       
        //[RegularExpression(@"^\d+\.\d{1}$",ErrorMessage = "must be like 0.0")]
        public int price { get; set; }
        //[RegularExpression(@"^\d+\.\d{1}$",ErrorMessage ="must be like 0.0")]
        public int rating { get; set;}
        public int quantity { get; set; }
        [ForeignKey("catalogue")]
        [Range(1,100000,ErrorMessage ="you have to choose catalogue")]
        public int catalogueID { get; set; }
        public Catalogue? catalogue { get; set; }
        //public List<Order> orders { get; set; }= new List<Order>(); 
        public List<Cart> carts { get; set; }=new List<Cart>();
    }
}
