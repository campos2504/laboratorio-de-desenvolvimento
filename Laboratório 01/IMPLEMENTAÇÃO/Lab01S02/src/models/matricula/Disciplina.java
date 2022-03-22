package models.matricula;

import java.io.Serializable;
import java.util.ArrayList;
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
    private List<Aluno> alunos;
    private Curriculo curriculo;
    private Professor professor;
    private boolean obrigatoria ;
    private boolean ativa;
    
    public Disciplina(String nome, Curso curso,  Curriculo curriculo,
            Professor professor, boolean obrigatoria) {
        this.id = ID++;
        this.nome = nome;
        this.curso = curso;
        this.curriculo = curriculo;
        this.professor = professor;
        this.obrigatoria = obrigatoria;
        this.alunos=new ArrayList<>();
        this.ativa = true;
    }

    public void desativar(){
        ativa=false;
    }
    public boolean getAtiva(){
        return this.ativa;
    }

    public boolean isObrigatoria() {
        return obrigatoria;
    }

    public boolean temMinimo(){
        if(alunos.size()>=MIN_ALUNOS){
            return true;
        }
        return false;
    }

    public boolean addAluno(Aluno aluno) {
        if(alunos.size()==MAX_ALUNOS){
            System.out.println("Turma cheia");
            return false;
        }
        this.addAluno(aluno);
        return true;
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
        return "Disciplina [" + " curriculo=" + curriculo + ", curso=" + curso
                + ", id=" + id + ", nome=" + nome + ", obrigatoria=" + obrigatoria + ", professor=" + professor +"]";
    }
  

    




    
}
