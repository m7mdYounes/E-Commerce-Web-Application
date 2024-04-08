namespace E_Commerce.Models
{
    public class Catalogue
    {
        public int Id { get; set; }
        public string Name { get; set; }
         public List<Product> Products { get; set; } = new List<Product>();
    }
}
