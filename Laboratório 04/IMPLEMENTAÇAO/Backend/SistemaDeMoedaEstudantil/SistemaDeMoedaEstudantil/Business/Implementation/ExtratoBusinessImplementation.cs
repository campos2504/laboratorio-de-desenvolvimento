using SistemaDeMoedaEstudantil.Model;
using SistemaDeMoedaEstudantil.Repository;
using SistemaDeMoedaEstudantil.ViewModel;
using System;
using System.Collections.Generic;

namespace SistemaDeMoedaEstudantil.Business
{
    public class ExtratoBusinessImplementation : IExtratoBusiness
    {
        private readonly IExtratoRepository _repository;
        private IContaBusiness _contaBusiness;

        public ExtratoBusinessImplementation(IExtratoRepository repository, IContaBusiness conta)
        {
            _repository = repository;
            _contaBusiness = conta;
        }

        public Extrato Create(ExtratoViewModel extratoViewModel)
        {
            Conta contaAluno = new Conta();
            Conta contaProfessor = new Conta();
            var extratoProfessor = new Extrato();

            contaAluno = _contaBusiness.FindByID(extratoViewModel.ContaAlunoId);
            contaProfessor = _contaBusiness.FindByID(extratoViewModel.ContaProfessorId);

            double saldoAtualProfessor = contaProfessor.Saldo;


            if (!(saldoAtualProfessor < extratoViewModel.Valor))
            {
                saldoAtualProfessor = saldoAtualProfessor - extratoViewModel.Valor;
                contaProfessor.Saldo = saldoAtualProfessor;
                contaProfessor.Id = extratoViewModel.ContaProfessorId;
                _contaBusiness.Update(contaProfessor);
            }
            else
            {
                return extratoProfessor;
            }

            //Atualiza saldo aluno
            double saldoAtualAluno = contaAluno.Saldo;
            saldoAtualAluno = saldoAtualAluno + extratoViewModel.Valor;
            contaAluno.Saldo = saldoAtualAluno;
            contaAluno.Id = extratoViewModel.ContaAlunoId;
            _contaBusiness.Update(contaAluno);

            //Novo extrato professor            
            extratoProfessor.ContaId = extratoViewModel.ContaProfessorId;
            extratoProfessor.Valor = extratoViewModel.Valor;
            extratoProfessor.TransacaoType = TransacaoType.ENVIADO;
            _repository.Create(extratoProfessor);

            //Novo extrato aluno
            var extratoAluno = new Extrato();
            extratoAluno.ContaId = extratoViewModel.ContaAlunoId;
            extratoAluno.Valor = extratoViewModel.Valor;
            extratoAluno.TransacaoType = TransacaoType.RECEBIDO;
            _repository.Create(extratoAluno);


            return extratoProfessor;
        }

        public void Delete(long id)
        {

            _repository.Delete(id);
        }

        public List<Extrato> FindAll()
        {

            return _repository.FindAll();
        }

        public Extrato FindByID(long id)
        {

            return _repository.FindByID(id);
        }

        public List<Extrato> GetExtratoConta(long id)
        {
            return _repository.GetExtratoConta(id);
        }

        public Extrato Update(Extrato extrato)
        {

            return _repository.Update(extrato);
        }
    }
}
