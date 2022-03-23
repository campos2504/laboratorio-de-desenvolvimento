package models.matricula;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

public class Curriculo implements Serializable{
    public static final long serialVersionUID = 1L;

    private static long ID=1L;
    private long id;
    private String semestre;
    private boolean matriculaAberta;
    private boolean semestreAtual;
    private List<Disciplina> disciplinas;
   

    public Curriculo(String semestre) {
        this.id = ID++;
        this.semestre = semestre;
        this.matriculaAberta = true;
        this.semestreAtual = true;
        this.disciplinas = new ArrayList<>();
    }


    public void addDisciplina(Disciplina disciplina) {
        
        this.disciplinas.add(disciplina);
        
    }


    public void finalizarSemestre() {
        this.semestreAtual=false;
        this.fecharMatricula();
    }


    public void fecharMatricula() {
        this.matriculaAberta=false;
        
    }

    


    @Override
    public String toString() {
        return "Curriculo [" +", semestre=" + semestre + ", matriculaAberta=" + matriculaAberta
                +  ", semestreAtual=" + semestreAtual+"]";
    }


    public long getId() {
        return id;
    }


    public String getSemestre() {
        return semestre;
    }


    public boolean isMatriculaAberta() {
        return matriculaAberta;
    }


    public boolean isSemestreAtual() {
        return semestreAtual;
    }


    public List<Disciplina> getDisciplinas() {
        return disciplinas;
    }

    public boolean getSemestreAtual(){
        return semestreAtual;
    }

    public boolean getMatriculaAberta(){
        return matriculaAberta;
    }

}
