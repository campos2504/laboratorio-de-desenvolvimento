package com.lab02.locadora.model;

import java.util.Collection;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.persistence.UniqueConstraint;


import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Entity
@Getter
@Setter
@Builder
@AllArgsConstructor
@NoArgsConstructor
@Table(uniqueConstraints = @UniqueConstraint(columnNames = { "cpf", "rg" }))
public class Cliente {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private long id;

    private String nome;
    private String rg;
    private String cpf;
    private String endereco;
    private String profissao;
    @Column(nullable = false)
    private String senha;

    @OneToMany(cascade = CascadeType.ALL,mappedBy = "cliente",
     orphanRemoval=true, fetch = FetchType.EAGER)
    private Collection<Entidade> entidades;

    public void addEntidade(Entidade entidade) {
        entidade.setCliente(this);
        this.entidades.add(entidade);
    }


    public void removerEntidade(long id) {
        
        this.entidades.removeIf(e->e.getId()==id);
        
    }

   

}
