

namespace ClassLibrary
{
    public class Repository<T>
    {
        //generic list containing objects of type T
        private List<T> items;

        public Repository()
        {
            items = new List<T>();
        }
        //Add an item of type T
        public void Add(T item)
        {
            items.Add(item);
        }

        //get all elements of the list
        public List<T> GetAll()
        {
            return items;
        }

        //Count for number of objects stored
        public int Count()
        {
            return items.Count;
        }

    }
}
