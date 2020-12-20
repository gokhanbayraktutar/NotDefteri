using AutoMapper;
using AutoMapper.QueryableExtensions;
using NotDefteri.Data.Context;
using NotDefteri.Data.Entities.Base;
using NotDefteri.Data.Models.Base;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;


namespace NotDefteri.Service.Repository.Base
{
    public abstract class Service<TEntity, TModel> where TEntity : Entity where TModel : Model
    {
        private readonly DataContext _context;

        private DbSet<TEntity> _dbSet;

        private IQueryable<TModel> mapSet;


        protected Service(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
            mapSet = _dbSet.ProjectTo<TModel>();
        }

        public List<TModel> GetAll()
        {
            return mapSet.ToList();
        }

        public int Add(TModel model)
        {
            var entity = Mapper.Map<TEntity>(model);

            _dbSet.Add(entity);

            return _context.SaveChanges();
        }

        public void AddRange(IEnumerable<TModel> models)
        {
            var entity = Mapper.Map<IEnumerable<TEntity>>(models);

            _dbSet.AddRange(entity);
        }

        public TModel GetById(int id)
        {
            return mapSet.FirstOrDefault(x => x.Id == id);
        }

        public int Update(TModel model)
        {
            var entity = Mapper.Map<TEntity>(model);

            _dbSet.AddOrUpdate(entity);

            return _context.SaveChanges();
        }

        public int Remove(int id)
        {
            var entity = _dbSet.First(e => e.Id == id);

            _context.Entry(entity).State = EntityState.Deleted;

            return _context.SaveChanges();
        }
    }
}
