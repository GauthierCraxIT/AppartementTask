using AppartementTask.Models;
using System.Data.Entity;
using System.Linq.Expressions;

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

        public List<T> Read<T>(Expression<Func<T, bool>> condition) where T : class
        {
            return this.context.Set<T>().Where(condition).ToList();
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

        public T FindByCondition<T>(Expression<Func<T, bool>> condition) where T : class
        {
            return this.context.Set<T>().Where(condition).FirstOrDefault();
        }

        public T FindById<T>(string id) where T : class
        {
            return this.context.Set<T>().Find(id);
        }
    }
}
