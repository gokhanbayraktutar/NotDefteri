using NotDefteri.Abstraction.IRepository.Base;
using NotDefteri.Data.Entities;
using NotDefteri.Data.Models;

namespace NotDefteri.Abstraction.IRepository
{
    public interface IUserService : IService<User, UserModel>
    {
        UserModel FindByUserName(string userName);
    }
}
