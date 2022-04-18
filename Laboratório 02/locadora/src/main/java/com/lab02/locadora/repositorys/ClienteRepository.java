package com.lab02.locadora.repositorys;




import com.lab02.locadora.model.Cliente;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;




@Repository
public interface ClienteRepository extends JpaRepository<Cliente, Long>{

    public Cliente findByCpf(String cpf);

}
