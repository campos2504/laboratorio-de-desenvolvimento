package com.lab02.locadora.dtos;


import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class AtualizarClienteDto {
    private long id;
    private String nome;
    private String rg;
    private String cpf;
    private String endereco;
    private String profissao;
    private String senha;
    
}
