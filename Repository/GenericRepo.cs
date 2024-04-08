namespace E_Commerce.Repository
{
    public class GenericRepo<T>:IGenericRepo<T> where T : class
    {
        private readonly StoreContext context;

        public GenericRepo(StoreContext _context)
        {
            context = _context;
        }
        public List<T> GetAll()
        {
           return context.Set<T>().ToList();
        }
        public T GetbyId(int id)
        {
            return context.Set<T>().Find(id);  
        }
        public void Add(T item)
        {
            context.Set<T>().Add(item);
        }
        public void Delete(int item)
        {
            T i =  this.GetbyId(item);
            context.Set<T>().Remove(i);
        }
        public void Update(T item)
        {
            context.Set<T>().Update(item);  
        }
        public void save()
        {
            context.SaveChanges();
        }
    }
}
