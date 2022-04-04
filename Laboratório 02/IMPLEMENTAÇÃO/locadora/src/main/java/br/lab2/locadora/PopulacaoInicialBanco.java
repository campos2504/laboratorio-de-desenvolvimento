package br.lab2.locadora;

import java.time.LocalDate;

import javax.transaction.Transactional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import br.lab2.locadora.rh.dominio.Pessoa;
import br.lab2.locadora.rh.dominio.PessoaRepositorio;

@Component
@Transactional
public class PopulacaoInicialBanco implements CommandLineRunner {

	@Autowired
	private PessoaRepositorio pessoaRepo;

	@Override
	public void run(String... args) throws Exception {

		Pessoa p1 = new Pessoa("Joao");
		p1.setDataNascimento(LocalDate.of(1990, 4, 1));
		p1.setEmail("joao@gmail.com");
		p1.setRg("MG1111");
		p1.setEndereco("Rua A, Belo Horizonte");
		p1.setEntidadeEmpregadora("Empresa A");
		p1.setRendimentoAuferido("4000");
		p1.setProfissao("Contador");
		p1.setCpf("012345678");
		p1.setTelefone("3133333333");
		Pessoa p2 = new Pessoa("Maria");
		p2.setDataNascimento(LocalDate.of(1900, 1, 1));
		p2.setEmail("maria@gmail.com");
		p2.setRg("MG222");
		p2.setEndereco("Rua B, Belo Horizonte");
		p2.setEntidadeEmpregadora("Empresa B");
		p2.setProfissao("Advogado");
		p2.setRendimentoAuferido("3000");
		p2.setCpf("987654321");
		p2.setTelefone("3144444444");

		pessoaRepo.save(p1);
		pessoaRepo.save(p2);
	}
}
