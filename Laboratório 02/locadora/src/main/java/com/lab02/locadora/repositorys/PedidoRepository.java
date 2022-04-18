package com.lab02.locadora.repositorys;


import java.util.List;

import com.lab02.locadora.model.Pedido;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;



@Repository
public interface PedidoRepository extends JpaRepository<Pedido, Long>{

    List<Pedido> findByClienteId(long clienteId);
    
}
