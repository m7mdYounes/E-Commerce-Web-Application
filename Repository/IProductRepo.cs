namespace E_Commerce.Repository
{
    public interface IProductRepo:IGenericRepo<Product>
    {
        public List<Product> GetbyCatId(int catId);
    }
}
