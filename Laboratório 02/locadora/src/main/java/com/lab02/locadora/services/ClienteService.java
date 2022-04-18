package com.lab02.locadora.services;

import java.util.List;
import java.util.Optional;

import com.lab02.locadora.dtos.AdicionarEntidadeDto;
import com.lab02.locadora.dtos.AtualizarClienteDto;
import com.lab02.locadora.dtos.CadastroClienteDto;
import com.lab02.locadora.dtos.LoginDto;
import com.lab02.locadora.model.Cliente;


public interface ClienteService {
    

    List<Cliente> listarClientes();
    Cliente salvarCliente(CadastroClienteDto clienteDto);
    Cliente atualizarCliente(AtualizarClienteDto clienteDto);
    Cliente buscarClientePeloId(long id);
    void deletarClientePeloId(long id);
    void adicionarEntidade(AdicionarEntidadeDto entidadeDto, long clienteId);
    void deletarEntidadePeloId(long idCliente, long idEntidade);
    Optional<Cliente> logar(LoginDto login);
}
