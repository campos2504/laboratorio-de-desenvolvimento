using SistemaDeMoedaEstudantil.Model;
using System.Collections.Generic;

namespace SistemaDeMoedaEstudantil.Repository
{
    public interface IExtratoRepository
    {
        Extrato Create(Extrato extrato);
        Extrato FindByID(long id);
        List<Extrato> FindAll();
        List<Extrato> GetExtratoConta(long id);
        Extrato Update(Extrato extrato);
        void Delete(long id);
        bool Exists(long id);
    }
}
