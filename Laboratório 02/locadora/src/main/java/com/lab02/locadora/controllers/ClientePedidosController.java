package com.lab02.locadora.controllers;

import java.util.List;

import com.lab02.locadora.dtos.AtualizarPedidoDto;
import com.lab02.locadora.dtos.CriarPedidoDto;
import com.lab02.locadora.model.Automovel;
import com.lab02.locadora.model.Pedido;
import com.lab02.locadora.repositorys.AutomovelRepository;
import com.lab02.locadora.services.ClienteService;
import com.lab02.locadora.services.PedidosService;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
@RequestMapping("/cliente/{id}/pedidos")
public class ClientePedidosController {

    @Autowired
    private ClienteService clienteService;

    @Autowired
    PedidosService pedidosService;

    @Autowired
    AutomovelRepository automovelRepository;

    @GetMapping
    public String listarPedidos(Model model, @PathVariable long id) {
        model.addAttribute("cliente", clienteService.buscarClientePeloId(id));
        model.addAttribute("pedidos", pedidosService.listarPedidosClientes(id));
        return "pedidos";
    }

    @GetMapping("/novo")
    public String criarClienteForm(Model model, @PathVariable long id) {
        CriarPedidoDto pedidoDto = new CriarPedidoDto();
        model.addAttribute("cliente", clienteService.buscarClientePeloId(id));
        model.addAttribute("automoveis", automovelRepository.findByLocado(false));
        model.addAttribute("pedido", pedidoDto);
        return "novoPedido";

    }

    @PostMapping()
    public String salvarCliente(@PathVariable long id, @ModelAttribute("pedido") CriarPedidoDto pedidoDto) {
        pedidosService.salvarPedido(pedidoDto, id);
        String str = "redirect:/cliente/" + id + "/pedidos";
        return str;
    }

    @GetMapping("/edit/{idPedido}")
    public String atualizarCliente(@PathVariable Long id, @PathVariable Long idPedido,
            Model model) {

        
        Pedido pedido = pedidosService.buscarPedidoPeloId(idPedido);
        AtualizarPedidoDto pedidoDto=AtualizarPedidoDto.builder()
        .automovelId(pedido.getAutomovel().getId())
        .valor(pedido.getValor())
        .financiamento(pedido.isFinanciamento())
        .inicio(pedido.getInicio().toString())
        .fim(pedido.getFim().toString())
        .id(pedido.getId())
        .clienteId(id)
        .build();
        model.addAttribute("pedido", pedidoDto);
        List<Automovel> automoveis = automovelRepository.findByLocado(false);
        automoveis.add(pedido.getAutomovel());
        model.addAttribute("automoveis", automoveis);
        model.addAttribute("cliente", clienteService.buscarClientePeloId(id));
        return "atualizarPedido";
    }

    @PostMapping("/{idPedido}")
    public String atualizar(@PathVariable Long id, @PathVariable Long idPedido,
            @ModelAttribute("pedido") AtualizarPedidoDto pedidoDto, Model model) {
        pedidoDto.setId(idPedido);
        pedidosService.atualizarPedido(pedidoDto);
        String str = "redirect:/cliente/" + id + "/pedidos";
        return str;
    }
    @GetMapping("deletar/{idPedido}")
	public String deletar(@PathVariable Long id, @PathVariable Long idPedido) {
		pedidosService.deletarPedidoPeloId(idPedido);
		String str = "redirect:/cliente/" + id + "/pedidos";
        return str;
	}

}
