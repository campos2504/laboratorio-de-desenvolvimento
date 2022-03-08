package matricula;

import java.util.List;

import login.Aluno;
import login.Professor;

public abstract class Disciplina {

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
        this.obrigatoria=obrigatoria;
    }
    
    public void addAluno(Aluno aluno) {
        
    }

    public void ativar(){

    }




    
}
