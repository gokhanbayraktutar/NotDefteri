using NotDefteri.Abstraction.IRepository;
using NotDefteri.Data.Context;
using NotDefteri.Data.Entities;
using NotDefteri.Data.Models;
using NotDefteri.Service.Repository.Base;
using System.Linq;
namespace NotDefteri.Service.Repository
{
    public class UserService : Service<User, UserModel>, IUserService
    {
        private DataContext _context;

        public UserService(DataContext context) : base(context)
        {
            _context = context;
        }

        public UserModel FindByUserName(string userName)
        {
            var response = _context.Users.Where(x => x.UserName == userName);

            return AutoMapper.Mapper.Map<UserModel>(response);
        }
    }
}
