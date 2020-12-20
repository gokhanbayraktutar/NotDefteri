using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotDefteri.Abstraction.IRepository.Base
{
    public interface IService<TEntity, TModel> where TEntity : class where TModel : class
    {
        TModel GetById(int id);
        List<TModel> GetAll();
        int Add(TModel model);
        int Update(TModel model);
        void AddRange(IEnumerable<TModel> entities);
        int Remove(int id);
    }
}
