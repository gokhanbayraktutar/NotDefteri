using NotDefteri.Abstraction.IRepository;
using NotDefteri.Data.Context;
using NotDefteri.Data.Entities;
using NotDefteri.Data.Models;
using NotDefteri.Service.Repository.Base;

namespace NotDefteri.Service.Repository
{
    public class CategoryService : Service<Category, CategoryModel>, ICategoryService
    {
        private DataContext _context;

        public CategoryService(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
