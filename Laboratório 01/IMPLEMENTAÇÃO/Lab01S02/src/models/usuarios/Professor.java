package models.usuarios;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

import models.matricula.Disciplina;

public class Professor implements ICadastravel, Serializable {

    public static final long serialVersionUID = 1L;

    private static long ID = 1L;
    private Long id;
    private String nome;
    private String email;
    private String senha;
    private TipoUsuario tipoUsuario;

    private List<Disciplina> disciplinas;

    public Professor(String nome, String email, String senha) {
        this.id = ID++;
        this.nome = nome;
        this.email = email;
        this.senha = senha;
        this.tipoUsuario = TipoUsuario.PROFESSOR;
        this.disciplinas = new ArrayList<>();

    }

    public Professor() {

    }

    public String listarAlunos() {
        return null;
    }

    @Override
    public boolean login(String email, String password) {
        if (!this.email.equals(email))
            return false;
        else if (!this.senha.equals(password))
            return false;
        else
            return true;
    }

    @Override
    public TipoUsuario getTipoUsuario() {
        return this.tipoUsuario;
    }

    public Long getId() {
        return id;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getSenha() {
        return senha;
    }

    public void setSenha(String senha) {
        this.senha = senha;
    }

    public List<Disciplina> getDisciplinas() {
        return disciplinas;
    }

    @Override
    public String toString() {
        return "Professor [" + " id=" + id + ", nome=" + nome + ", email=" + email +
                ", tipoUsuario=" + tipoUsuario  +"]";
    }

    public void addDisciplina(Disciplina disciplina) {
        this.disciplinas.add(disciplina);
    }

}
