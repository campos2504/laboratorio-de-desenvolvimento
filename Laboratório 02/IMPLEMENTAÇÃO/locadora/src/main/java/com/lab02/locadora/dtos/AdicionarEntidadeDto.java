package com.lab02.locadora.dtos;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class AdicionarEntidadeDto {
    private long id;
    private String nome;
    private double rendimento;
}
