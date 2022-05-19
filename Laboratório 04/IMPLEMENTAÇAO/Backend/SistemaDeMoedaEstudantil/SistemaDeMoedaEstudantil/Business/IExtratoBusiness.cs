using SistemaDeMoedaEstudantil.Model;
using SistemaDeMoedaEstudantil.ViewModel;
using System.Collections.Generic;

namespace SistemaDeMoedaEstudantil.Business
{
    public interface IExtratoBusiness
    {
        Extrato Create(ExtratoViewModel extratoViewModel);
        Extrato FindByID(long id);
        List<Extrato> FindAll();
        List<Extrato> GetExtratoConta(long id);
        Extrato Update(Extrato extrato);
        void Delete(long id);
    }
}
