using SistemaDeMoedaEstudantil.Model;
using System.Collections.Generic;

namespace SistemaDeMoedaEstudantil.Business
{
    public interface IAlunoBusiness
    {
        Aluno Create(Aluno aluno);
        Aluno FindByID(long id);
        List<Aluno> FindAll();
        List<Aluno> GetAlunoIe(long ie);
        Aluno Update(Aluno aluno);
        void Delete(long id);
    }
}
