package com.lab02.locadora.services;

import java.util.List;

import com.lab02.locadora.dtos.AtualizarPedidoDto;
import com.lab02.locadora.dtos.CriarPedidoDto;
import com.lab02.locadora.model.Pedido;

public interface PedidosService {

    List<Pedido> listarPedidosClientes(long idCliente);
    Pedido salvarPedido(CriarPedidoDto pedidoDto, long clienteId);
    Pedido atualizarPedido(AtualizarPedidoDto pedidoDto);
    Pedido buscarPedidoPeloId(long id);
    void deletarPedidoPeloId(long id);
}
