using SistemaDeMoedaEstudantil.Model;
using System.Collections.Generic;

namespace SistemaDeMoedaEstudantil.Repository
{
    public interface IContaRepository
    {
        Conta Create(Conta conta);
        Conta FindByID(long id);
        List<Conta> FindAll();
        Conta Update(Conta conta);
        void Delete(long id);
        bool Exists(long id);
    }
}
