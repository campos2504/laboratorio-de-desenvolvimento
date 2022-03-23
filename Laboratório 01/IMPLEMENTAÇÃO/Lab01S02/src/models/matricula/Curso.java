package models.matricula;

import java.io.Serializable;

public class Curso implements Serializable{

    public static final long serialVersionUID = 1L;

    private static long ID=1L;
    private long id;
    private String nome;
    private int creditos;

    public Curso(String nome, int creditos) {
        this.id = ID++;
        this.nome = nome;
        this.creditos = creditos;
    }

    public long getId() {
        return id;
    }


    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public int getCreditos() {
        return creditos;
    }

    public void setCreditos(int creditos) {
        this.creditos = creditos;
    }

    @Override
    public String toString() {
        return "Curso [ nome=" + nome + "]";
    }    
}
