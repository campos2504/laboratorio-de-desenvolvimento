using SistemaDeMoedaEstudantil.Model;
using SistemaDeMoedaEstudantil.ViewModel;
using System.Collections.Generic;

namespace SistemaDeMoedaEstudantil.Business
{
    public interface IVantagemBusiness
    {
        Vantagem Create(VantagemViewModel vantagem);
        Vantagem FindByID(long id);
        List<Vantagem> FindAll();
        Vantagem Update(VantagemViewModel vantagem);
        void Delete(long id);
    }
}
