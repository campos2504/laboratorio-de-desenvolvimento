using SistemaDeMoedaEstudantil.Model;
using System.Collections.Generic;

namespace SistemaDeMoedaEstudantil.Business
{
    public interface IUserBusiness
    {
        User Create(User user);
        User FindByID(long id);
        List<User> FindAll();
        User Update(User user);
        void Delete(long id);
    }
}
