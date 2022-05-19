using SistemaDeMoedaEstudantil.Model;
using System.Collections.Generic;

namespace SistemaDeMoedaEstudantil.Repository
{
    public interface IEmpresaParceiraRepository
    {
        EmpresaParceira Create(EmpresaParceira empresaParceira);
        EmpresaParceira FindByID(long id);
        List<EmpresaParceira> FindAll();
        EmpresaParceira Update(EmpresaParceira empresaParceira);
        void Delete(long id);
        bool Exists(long id);
    }
}
