package com.lab02.locadora.model;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
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
@Table(uniqueConstraints = @UniqueConstraint(columnNames = { "placa", "matricula" }))
public class Automovel {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public long id;
    public int matricula;
    private int ano;
    private String modelo;
    private String placa;
    private boolean locado;
}
