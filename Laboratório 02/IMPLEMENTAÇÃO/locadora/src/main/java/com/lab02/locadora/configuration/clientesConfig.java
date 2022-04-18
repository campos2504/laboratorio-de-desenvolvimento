package com.lab02.locadora.configuration;



import java.time.LocalDate;

import com.lab02.locadora.model.Automovel;
import com.lab02.locadora.model.Cliente;
import com.lab02.locadora.model.Entidade;
import com.lab02.locadora.model.Pedido;
import com.lab02.locadora.model.StatusPedido;
import com.lab02.locadora.repositorys.AutomovelRepository;
import com.lab02.locadora.repositorys.ClienteRepository;
import com.lab02.locadora.repositorys.PedidoRepository;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class clientesConfig {
    @Autowired
    ClienteRepository clienteRepository;
    @Autowired
    AutomovelRepository automovelRepository;
    @Autowired
    PedidoRepository pedidoRepository;
 

    @Bean
    public void salvarClientes() {

        clienteRepository.save(Cliente.builder()
        .nome("Carlos Enduardo")
        .cpf("12345")
        .rg("12345")
        .endereco("Rua nascimento")
        .profissao("Engenheiro")
        .senha("12345")
        .build());
        Cliente cliente=clienteRepository.findByCpf("12345");
        cliente.addEntidade(Entidade.builder()
        .nome("Fabrica")
        .rendimento(7500)
        .cliente(cliente)
        .build());
        clienteRepository.save(cliente);
        
        clienteRepository.save(Cliente.builder()
        .nome("Joao Maria")
        .cpf("123456")
        .rg("123456")
        .endereco("Rua baixada")
        .profissao("Medico")
        .senha("123456")
        .build());
        cliente=clienteRepository.findByCpf("123456");
        cliente.addEntidade(Entidade.builder()
        .nome("Hospital")
        .rendimento(20000)
        .cliente(cliente)
        .build());
        cliente.addEntidade( Entidade.builder()
        .nome("Clinica")
        .rendimento(10000)
        .cliente(cliente)
        .build());
        clienteRepository.save(cliente);

        automovelRepository.save(Automovel.builder()
        .modelo("Fiat Palio")
        .matricula(111)
        .ano(2010)
        .placa("GGG-2222")
        .locado(false)
        .build());
        automovelRepository.save(Automovel.builder()
        .modelo("Citroen C4")
        .matricula(112)
        .ano(2012)
        .placa("HCD-1321")
        .locado(false)
        .build());
        automovelRepository.save(Automovel.builder()
        .modelo("Peugeut 306")
        .matricula(113)
        .ano(2011)
        .placa("HLG-4325")
        .locado(false)
        .build());
        automovelRepository.save(Automovel.builder()
        .modelo("Ford Ka")
        .matricula(114)
        .ano(2015)
        .placa("GYD-8976")
        .locado(false)
        .build());
        automovelRepository.save(Automovel.builder()
        .modelo("VW Golf")
        .matricula(121)
        .ano(2016)
        .placa("MGH-3452")
        .locado(true)
        .build());
        automovelRepository.save(Automovel.builder()
        .modelo("Reneut Crio")
        .matricula(151)
        .ano(2016)
        .placa("PUW-3246")
        .locado(false)
        .build());
        Automovel automovel=automovelRepository.findByPlaca("MGH-3452");

        pedidoRepository.save(Pedido.builder()
        .automovel(automovel)
        .cliente(cliente)
        .financiamento(true)
        .valor(1200)
        .inicio(LocalDate.of(2022, 1, 8))
        .fim(LocalDate.of(2023, 1, 8))
        .statusPedido(StatusPedido.ANALISE)
        .build());
    }

    
}
