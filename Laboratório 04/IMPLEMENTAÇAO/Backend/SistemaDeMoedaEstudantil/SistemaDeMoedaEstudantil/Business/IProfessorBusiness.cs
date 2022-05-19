using SistemaDeMoedaEstudantil.Model;
using System.Collections.Generic;

namespace SistemaDeMoedaEstudantil.Business
{
    public interface IProfessorBusiness
    {
        Professor Create(Professor professor);
        Professor FindByID(long id);
        List<Professor> FindAll();
        Professor Update(Professor professor);
        void Delete(long id);
    }
}
