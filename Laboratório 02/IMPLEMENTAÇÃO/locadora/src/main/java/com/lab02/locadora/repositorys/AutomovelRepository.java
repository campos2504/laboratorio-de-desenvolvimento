package com.lab02.locadora.repositorys;


import java.util.List;

import com.lab02.locadora.model.Automovel;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;


@Repository
public interface AutomovelRepository extends JpaRepository<Automovel, Long>{
    public Automovel findByPlaca(String placa);
    public List<Automovel> findByLocado(boolean locado);
    
}
