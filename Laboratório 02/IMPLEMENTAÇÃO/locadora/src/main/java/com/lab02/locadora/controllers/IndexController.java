package com.lab02.locadora.controllers;

import java.util.Optional;

import com.lab02.locadora.dtos.LoginDto;
import com.lab02.locadora.model.Cliente;
import com.lab02.locadora.services.ClienteService;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
@RequestMapping("/")
public class IndexController {

    @Autowired
    private ClienteService clienteService;

    @GetMapping()
    public String index() {
        return "index";
    }

    @GetMapping("/login")
    public String login(Model model) {
        LoginDto login = new LoginDto();
        model.addAttribute("login", login);
        return "login";

    }

    @PostMapping("/login")
    public String logar(@ModelAttribute("login") LoginDto login) {

        Optional<Cliente> cliente = clienteService.logar(login);
        if (cliente.isPresent()){
            long id= cliente.get().getId();
            String str="redirect:/cliente/"+id+"/pedidos/";
            return str;
        } else 
        return "index";
    }

}
