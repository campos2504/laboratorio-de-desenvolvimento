package com.lab02.locadora.services.Impl;

import java.util.List;
import java.util.Optional;

import com.lab02.locadora.dtos.AdicionarEntidadeDto;
import com.lab02.locadora.dtos.AtualizarClienteDto;
import com.lab02.locadora.dtos.CadastroClienteDto;
import com.lab02.locadora.dtos.LoginDto;
import com.lab02.locadora.model.Cliente;
import com.lab02.locadora.model.Entidade;
import com.lab02.locadora.repositorys.ClienteRepository;
import com.lab02.locadora.services.ClienteService;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class ClienteServiceImpl implements ClienteService {

    @Autowired
    ClienteRepository clienteRepository;


    @Override
    public List<Cliente> listarClientes() {
        return clienteRepository.findAll();
    }

    @Override
    public Cliente salvarCliente(CadastroClienteDto clienteDto) {

        Cliente cliente = Cliente.builder()
                .nome(clienteDto.getNome())
                .rg(clienteDto.getRg())
                .cpf(clienteDto.getCpf())
                .endereco(clienteDto.getEndereco())
                .profissao(clienteDto.getProfissao())
                .senha(clienteDto.getSenha())
                .build();

        return clienteRepository.save(cliente);
    }

    @Override
    public Cliente buscarClientePeloId(long id) {
        return clienteRepository.findById(id).get();
    }

    @Override
    public void deletarClientePeloId(long id) {
        clienteRepository.deleteById(id);
    }

    @Override
    public Cliente atualizarCliente(AtualizarClienteDto clienteDto) {
        Cliente cliente = clienteRepository.findById(clienteDto.getId()).get();
        cliente.setCpf(clienteDto.getCpf());
        cliente.setNome(clienteDto.getNome());
        cliente.setRg(clienteDto.getRg());
        cliente.setEndereco(clienteDto.getEndereco());
        cliente.setProfissao(clienteDto.getProfissao());
        cliente.setSenha(clienteDto.getSenha());
        
        return clienteRepository.save(cliente);
    }

    @Override
    public void adicionarEntidade(AdicionarEntidadeDto entidadeDto, long clienteId) {
        Cliente cliente = clienteRepository.findById(clienteId).get();

        Entidade entidade = Entidade.builder()
                .nome(entidadeDto.getNome())
                .rendimento(entidadeDto.getRendimento())
                .build();
        System.out.println(cliente.getEntidades().size());
        if (cliente.getEntidades().size() < 3) {
            cliente.addEntidade(entidade);
            clienteRepository.save(cliente);

        }

    }

    @Override
    public void deletarEntidadePeloId(long idCliente, long idEntidade) {
       Cliente cliente= clienteRepository.findById(idCliente).get();
       cliente.removerEntidade(idEntidade);
       clienteRepository.save(cliente);

    }

    @Override
    public Optional<Cliente> logar(LoginDto login) {
        Optional<Cliente> clienteOp;

        Cliente cliente = clienteRepository.findByCpf(login.getCpf());
        if(cliente.getSenha().equals(login.getSenha())){
            clienteOp=Optional.of(cliente);
        }
        else{
            clienteOp=Optional.empty();
        }
        

        return clienteOp;
    }

}
