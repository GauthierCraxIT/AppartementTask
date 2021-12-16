using System.Linq.Expressions;

namespace AppartementTask.CRUD
{
    public interface IDao
    {

        void Create<T>(T t) where T : class; 
        List<T> Read<T>() where T : class;
        List<T> Read<T>(Expression<Func<T, bool>> condition) where T : class;
        void Update<T>(T t) where T : class;
        void Delete<T>(T t) where T : class;
        T FindById<T>(int id) where T : class;
        T FindById<T>(string id) where T : class;
        T FindByCondition<T>(Expression<Func<T, bool>> condition) where T : class;

    }
}
