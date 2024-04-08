
namespace E_Commerce.Repository
{
    public class ProductRepo : GenericRepo<Product>, IProductRepo
    {
        private readonly StoreContext context;

        public ProductRepo(StoreContext context):base(context)
        {
            this.context = context;
        }

        public List<Product> GetbyCatId(int catId)
        {
            return context.Products.Where(i => i.catalogueID == catId).ToList();    
        }
    }
}
