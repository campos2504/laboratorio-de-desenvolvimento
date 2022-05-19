using SistemaDeMoedaEstudantil.Model;
using System.Collections.Generic;

namespace SistemaDeMoedaEstudantil.Business
{
    public interface IContaBusiness
    {
        Conta Create(Conta conta);
        Conta FindByID(long id);
        List<Conta> FindAll();
        Conta Update(Conta conta);
        void Delete(long id);
    }
}
