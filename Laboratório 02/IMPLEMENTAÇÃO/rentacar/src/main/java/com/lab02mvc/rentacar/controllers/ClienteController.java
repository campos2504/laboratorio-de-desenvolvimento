package com.lab02mvc.rentacar.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;


@Controller
@RequestMapping("/cliente")
public class ClienteController {

    @GetMapping("/cadastrar")
    public String form(){
        return "cliente/formCliente";
    }
    
}
