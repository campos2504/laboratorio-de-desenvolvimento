package com.lab02.locadora.services.Impl;

import java.time.LocalDate;
import java.util.List;

import com.lab02.locadora.dtos.AtualizarPedidoDto;
import com.lab02.locadora.dtos.CriarPedidoDto;
import com.lab02.locadora.model.Automovel;
import com.lab02.locadora.model.Pedido;
import com.lab02.locadora.model.StatusPedido;
import com.lab02.locadora.repositorys.AutomovelRepository;
import com.lab02.locadora.repositorys.PedidoRepository;
import com.lab02.locadora.services.ClienteService;
import com.lab02.locadora.services.PedidosService;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class PedidoServiceImpl implements PedidosService {

    @Autowired
    PedidoRepository pedidoRepository;

    @Autowired
    AutomovelRepository automovelRepository;

    @Autowired
    ClienteService clienteService;

    @Override
    public List<Pedido> listarPedidosClientes(long idCliente) {
        return pedidoRepository.findByClienteId(idCliente);
    }

    @Override
    public Pedido salvarPedido(CriarPedidoDto pedidoDto, long clienteId) {
        Automovel automovel = automovelRepository.findById(pedidoDto.getAutomovelId()).get();
        automovel.setLocado(true);
        automovelRepository.save(automovel);
        return pedidoRepository.save(Pedido.builder()
        .automovel(automovel)
        .cliente(clienteService.buscarClientePeloId(clienteId))
        .financiamento(pedidoDto.isFinanciamento())
        .inicio(LocalDate.parse(pedidoDto.getInicio()))
        .fim(LocalDate.parse(pedidoDto.getFim()))
        .statusPedido(StatusPedido.ANALISE)
        .build());
    }

    @Override
    public Pedido atualizarPedido(AtualizarPedidoDto pedidoDto) {
        Automovel automovel = automovelRepository.findById(pedidoDto.getAutomovelId()).get();
        if(!automovel.isLocado()){
            automovel.setLocado(true);
            Pedido pedido=pedidoRepository.findById(pedidoDto.getId()).get();
            Automovel deslocado= pedido.getAutomovel();
            deslocado.setLocado(false);
            automovelRepository.save(deslocado) ;
        }
        automovelRepository.save(automovel);
        return pedidoRepository.save(Pedido.builder()
        .automovel(automovel)
        .cliente(clienteService.buscarClientePeloId(pedidoDto.getClienteId()))
        .financiamento(pedidoDto.isFinanciamento())
        .inicio(LocalDate.parse(pedidoDto.getInicio()))
        .fim(LocalDate.parse(pedidoDto.getFim()))
        .statusPedido(StatusPedido.ANALISE)
        .build());
    }

    @Override
    public Pedido buscarPedidoPeloId(long id) {
        return pedidoRepository.findById(id).get();
    }

    @Override
    public void deletarPedidoPeloId(long id) {
        Pedido pedido=pedidoRepository.findById(id).get();
        Automovel automovel = pedido.getAutomovel();
        automovel.setLocado(false);
        pedidoRepository.delete(pedido);
    }



   

}
