using SistemaDeMoedaEstudantil.Model;
using SistemaDeMoedaEstudantil.Repository;
using System;
using System.Collections.Generic;

namespace SistemaDeMoedaEstudantil.Business
{
    public class VantagemUserBusinessImplementation : IVantagemUserBusiness
    {
        private readonly IVantagemUserRepository _repository;
        private IAlunoBusiness _alunoUserBusiness;
        private IVantagemBusiness _vantagemUserBusiness;
        private IContaBusiness _contaUserBusiness;
        private readonly IExtratoRepository _extratoUserRepository;

        public VantagemUserBusinessImplementation(IVantagemUserRepository repository, IAlunoBusiness alunoUser, IVantagemBusiness vantagem, IContaBusiness conta, IExtratoRepository extrato)
        {
            _repository = repository;
            _alunoUserBusiness = alunoUser;
            _vantagemUserBusiness = vantagem;
            _contaUserBusiness = conta;
            _extratoUserRepository = extrato;
        }

        public VantagemUser Create(VantagemUser vantagemUser)
        {
            Aluno aluno = new Aluno();
            Vantagem vantagem = new Vantagem();
            Conta contaAluno = new Conta();
            var extratoAluno = new Extrato();

            aluno = _alunoUserBusiness.FindByID(vantagemUser.AlunoId);
            vantagem = _vantagemUserBusiness.FindByID(vantagemUser.VantagemId);
            contaAluno = _contaUserBusiness.FindByID(aluno.ContaId);

            //Atualiza saldo do aluno
            contaAluno.Saldo = contaAluno.Saldo - vantagem.Valor;
            contaAluno.Id = aluno.ContaId;
            _contaUserBusiness.Update(contaAluno);

            //Cria extrato de envio do aluno
            extratoAluno.ContaId = aluno.ContaId;
            extratoAluno.Valor = vantagem.Valor;
            extratoAluno.TransacaoType = TransacaoType.ENVIADO;
            _extratoUserRepository.Create(extratoAluno);


            return _repository.Create(vantagemUser);
        }

        public void Delete(long id)
        {

            _repository.Delete(id);
        }

        public List<VantagemUser> FindAll()
        {

            return _repository.FindAll();
        }

        public VantagemUser FindByID(long id)
        {

            return _repository.FindByID(id);
        }

        public VantagemUser Update(VantagemUser vantagemUser)
        {

            return _repository.Update(vantagemUser);
        }
    }
}
