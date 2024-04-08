namespace E_Commerce.Repository
{
    public class CatalogueRepo:GenericRepo<Catalogue> , ICatalogueRepo
    {
        private readonly StoreContext context;
        public CatalogueRepo(StoreContext context):base(context)
        {
            this.context = context;
        }


    }
}
