package com.lab02mvc.rentacar.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
@RequestMapping("/")
public class indexController {
    

    @GetMapping
    public String index() {
        return "index";
        
    }
}
