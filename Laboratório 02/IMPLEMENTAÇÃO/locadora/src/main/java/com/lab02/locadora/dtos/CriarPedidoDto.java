package com.lab02.locadora.dtos;


import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;


@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class CriarPedidoDto {
    private boolean financiamento;
    private double valor;
    private long automovelId;
    private String inicio;
    private String fim;
}
