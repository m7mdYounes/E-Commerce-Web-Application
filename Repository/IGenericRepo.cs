namespace E_Commerce.Repository
{
    public interface IGenericRepo<T> where T : class
    {
        public List<T> GetAll();
        public T GetbyId(int id);
        public void Add(T item);
        public void Delete(int item);
        public void Update(T item);
        public void save();
    }
}
