using SistemaDeMoedaEstudantil.Model;
using System.Collections.Generic;

namespace SistemaDeMoedaEstudantil.Repository
{
    public interface IProfessorRepository
    {
        Professor Create(Professor professor);
        Professor FindByID(long id);
        List<Professor> FindAll();
        Professor Update(Professor professor);
        void Delete(long id);
        bool Exists(long id);
    }
}
