package models.matricula;

import java.io.Serializable;
import java.util.List;

import models.usuarios.Aluno;
import models.usuarios.Professor;

public  class Disciplina  implements Serializable{
    
    public static final long serialVersionUID = 1L;

    private static final int MIN_ALUNOS= 3;
    private static final int MAX_ALUNOS=60;
    private static long ID=1L;


    private long id;
    private String nome;
    private Curso curso;
    private boolean ativo;
    private List<Aluno> alunos;
    private Curriculo curriculo;
    private Professor professor;
    private boolean obrigatoria ;
    
    public Disciplina(String nome, Curso curso,  Curriculo curriculo,
            Professor professor, boolean obrigatoria) {
        this.id = ID++;
        this.nome = nome;
        this.curso = curso;
        this.ativo = false;
        this.curriculo = curriculo;
        this.professor = professor;
        this.obrigatoria = obrigatoria;
    }

    public boolean isAtivo() {
        return ativo;
    }

    public boolean isObrigatoria() {
        return obrigatoria;
    }

    public void ativar(){
        this.ativo=true;

    }

    public void addAluno(Aluno aluno) {
        this.addAluno(aluno);
    }
    
    public static int getMinAlunos() {
        return MIN_ALUNOS;
    }

    public static int getMaxAlunos() {
        return MAX_ALUNOS;
    }


    public long getId() {
        return id;
    }

    public String getNome() {
        return nome;
    }


    public Curso getCurso() {
        return curso;
    }

    public List<Aluno> getAlunos() {
        return alunos;
    }

    public Curriculo getCurriculo() {
        return curriculo;
    }

    public void setCurriculo(Curriculo curriculo) {
        this.curriculo = curriculo;
    }

    public Professor getProfessor() {
        return professor;
    }

    public void setProfessor(Professor professor) {
        this.professor = professor;
    }
    
    public boolean getObrigatoria(){
        return this.obrigatoria;
    }

    @Override
    public String toString() {
        return "Disciplina [ativo=" + ativo + ", curriculo=" + curriculo + ", curso=" + curso
                + ", id=" + id + ", nome=" + nome + ", obrigatoria=" + obrigatoria + ", professor=" + professor +"]";
    }
  

    




    
}
