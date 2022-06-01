using SistemaDeMoedaEstudantil.Model;
using System.Collections.Generic;

namespace SistemaDeMoedaEstudantil.Business
{
    public interface IVantagemUserBusiness
    {
        VantagemUser Create(VantagemUser vantagemUser);
        VantagemUser FindByID(long id);
        List<VantagemUser> FindAll();
        VantagemUser Update(VantagemUser vantagemUser);
        void Delete(long id);
    }
}
