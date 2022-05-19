using SistemaDeMoedaEstudantil.Model;
using System.Collections.Generic;

namespace SistemaDeMoedaEstudantil.Business
{
    public interface IEmpresaParceiraBusiness
    {
        EmpresaParceira Create(EmpresaParceira empresaParceira);
        EmpresaParceira FindByID(long id);
        List<EmpresaParceira> FindAll();
        EmpresaParceira Update(EmpresaParceira empresaParceira);
        void Delete(long id);
    }
}
