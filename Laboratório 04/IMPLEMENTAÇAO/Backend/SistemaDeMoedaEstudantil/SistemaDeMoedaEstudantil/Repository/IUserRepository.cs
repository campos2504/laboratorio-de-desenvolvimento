using SistemaDeMoedaEstudantil.Model;
using System.Collections.Generic;

namespace SistemaDeMoedaEstudantil.Repository
{
    public interface IUserRepository
    {
        User Create(User user);
        User FindByID(long id);
        List<User> FindAll();
        User Update(User user);
        void Delete(long id);
        bool Exists(long id);
    }
}
