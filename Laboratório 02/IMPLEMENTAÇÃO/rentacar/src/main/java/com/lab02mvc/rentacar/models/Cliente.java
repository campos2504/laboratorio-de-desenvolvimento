package com.lab02mvc.rentacar.models;

import java.math.BigDecimal;

import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class Cliente {

    private long id;

    private String nome;

    private String cpf;

    private String rg;

    private String endereco;

    private String proficao;

    private String entidadeEmpregadora1;
    
    private BigDecimal rendimento1;

    private String entidadeEmpregadora2;
    
    private BigDecimal rendimento2;

    private String entidadeEmpregadora3;
    
    private BigDecimal rendimento3;
    
}
