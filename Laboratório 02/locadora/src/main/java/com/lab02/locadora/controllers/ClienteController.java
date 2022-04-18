package com.lab02.locadora.controllers;

import com.lab02.locadora.dtos.AdicionarEntidadeDto;
import com.lab02.locadora.dtos.AtualizarClienteDto;
import com.lab02.locadora.dtos.CadastroClienteDto;
import com.lab02.locadora.model.Cliente;
import com.lab02.locadora.services.ClienteService;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
@RequestMapping("/clientes")
public class ClienteController {

    @Autowired
    private ClienteService clienteService;

    @GetMapping
    public String listarClientes(Model model) {
        model.addAttribute("clientes", clienteService.listarClientes());

        return "clientes";
    }

    @GetMapping("/novo")
    public String criarClienteForm(Model model) {

        // create student object to hold student form data
        CadastroClienteDto cliente = new CadastroClienteDto();
        model.addAttribute("cliente", cliente);
        return "novoCliente";

    }

    @PostMapping()
    public String salvarCliente(@ModelAttribute("cliente") CadastroClienteDto clienteDto) {
        clienteService.salvarCliente(clienteDto);
        return "redirect:/clientes";
    }

    @GetMapping("/edit/{id}")
    public String atualizarCliente(@PathVariable Long id, Model model) {
        model.addAttribute("cliente", clienteService.buscarClientePeloId(id));
        return "atualizarCliente";
    }

    @PostMapping("/{id}")
    public String atualizar(@PathVariable Long id,
            @ModelAttribute("cliente") AtualizarClienteDto clienteDto,
            Model model) {
                clienteDto.setId(id);
        clienteService.atualizarCliente(clienteDto);
        return "redirect:/clientes";
    }
    @GetMapping("deletar/{id}")
	public String deletar(@PathVariable Long id) {
		clienteService.deletarClientePeloId(id);
		return "redirect:/clientes";
	}

    @GetMapping("/{id}/entidades")
    public String listarEntidades(@PathVariable Long id, Model model) {

        Cliente cliente= clienteService.buscarClientePeloId(id);
        model.addAttribute("cliente", cliente);
        model.addAttribute("entidades", cliente.getEntidades());
        return "entidades";
    }

    @GetMapping("/{id}/entidades/adicionar")
    public String adicionarEntidade(@PathVariable Long id, Model model) {

        Cliente cliente= clienteService.buscarClientePeloId(id);
        AdicionarEntidadeDto entidadeDto = new AdicionarEntidadeDto();
        model.addAttribute("cliente", cliente);
        model.addAttribute("entidade", entidadeDto);
        return "adicionarEntidade";
    }

    @PostMapping("/{id}/entidades/adicionar")
    public String salvarCliente(@PathVariable Long id,
        @ModelAttribute("entidade") AdicionarEntidadeDto entidadeDto) {
        clienteService.adicionarEntidade(entidadeDto, id);
        return "redirect:/clientes/{id}/entidades";
    }

    @GetMapping("/{id}/entidades/deletar/{idEntidade}")
	public String deletarEntidade(@PathVariable long id
    ,@PathVariable Long idEntidade) {
		clienteService.deletarEntidadePeloId(id, idEntidade);;
		return "redirect:/clientes/{id}/entidades/";
	}

  

}
