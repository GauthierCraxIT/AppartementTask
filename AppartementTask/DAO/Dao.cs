using AppartementTask.Models;

namespace AppartementTask.CRUD
{
    public class Dao : IDao
    {
        public Context context{ get; set; }

        public Dao(Context context)
        {
            this.context = context;
        }

        public void Create<T>(T t) where T : class
        {
            this.context.Set<T>().Add(t);
            this.context.SaveChanges();
        }

        public void Delete<T>(T t) where T : class
        {
            this.context.Set<T>().Remove(t);
            this.context.SaveChanges();
        }

        public List<T> Read<T>() where T : class
        {
            return this.context.Set<T>().ToList();
        }

        public void Update<T>(T t) where T : class
        {
            this.context.Set<T>().Update(t);
            this.context.SaveChanges();
        }

        public T FindById<T>(int id) where T : class
        {
            return this.context.Set<T>().Find(id);
        }

        public T FindById<T>(string id) where T : class
        {
            return this.context.Set<T>().Find(id);
        }
    }
}
