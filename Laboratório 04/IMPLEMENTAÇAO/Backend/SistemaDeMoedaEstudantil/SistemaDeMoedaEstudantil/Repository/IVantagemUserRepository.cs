using SistemaDeMoedaEstudantil.Model;
using System.Collections.Generic;

namespace SistemaDeMoedaEstudantil.Repository
{
    public interface IVantagemUserRepository
    {
        VantagemUser Create(VantagemUser vantagemUser);
        VantagemUser FindByID(long id);
        List<VantagemUser> FindAll();
        VantagemUser Update(VantagemUser vantagemUser);
        void Delete(long id);
        bool Exists(long id);
    }
}
