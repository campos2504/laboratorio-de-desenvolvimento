package dados;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

import login.Aluno;
import login.Professor;
import login.Secretaria;
import login.ICadastravel;
import matricula.Curriculo;
import matricula.Curso;
import matricula.Disciplina;

public class Data implements Serializable {

    public static final long serialVersionUID = 1L;

    private List<Aluno> alunos;
    private List<Secretaria> secretarias;
    private List<Professor> professores;
    private List<Disciplina> disciplinas;
    private List<Curriculo> curriculos;
    private List<Curso> listaCursos;

    public Data() {

        this.alunos = new ArrayList<>();
        this.secretarias = new ArrayList<>();
        this.professores = new ArrayList<>();
        this.disciplinas = new ArrayList<>();
        this.curriculos = new ArrayList<>();
        this.listaCursos= new ArrayList<>();
        
    }

    public void addAluno(Aluno aluno) {
        this.alunos.add(aluno);
    }
    
    public void removerAluno(long alunoId) {
        int index = -1;
        for (Aluno aluno : alunos) {
            if (alunoId == aluno.getId()) {
                index = this.alunos.indexOf(aluno);
                break;
            }
        }
        if (index != -1)
            this.alunos.remove(index);
    }

    public static long getSerialversionuid() {
        return serialVersionUID;
    }

    public List<Aluno> getAlunos() {
        return alunos;
    }

    public void setAlunos(List<Aluno> alunos) {
        this.alunos = alunos;
    }

    public List<Secretaria> getSecretarias() {
        return secretarias;
    }

    public void setSecretarias(List<Secretaria> secretarias) {
        this.secretarias = secretarias;
    }

    public List<Professor> getProfessores() {
        return professores;
    }

    public void setProfessores(List<Professor> professores) {
        this.professores = professores;
    }

    public List<Disciplina> getDisciplinas() {
        return disciplinas;
    }

    public void setDisciplinas(List<Disciplina> disciplinas) {
        this.disciplinas = disciplinas;
    }

    public List<Curriculo> getCurriculos() {
        return curriculos;
    }

    public void setCurriculos(List<Curriculo> curriculos) {
        this.curriculos = curriculos;
    }

    public void addProfessor(Professor professor) {
        this.professores.add(professor);
    }
    
    public void removerProfessor(long professorId) {
        int index = -1;
        for (Professor professor : this.professores) {
            if (professorId == professor.getId()) {
                index = this.professores.indexOf(professor);
                break;
            }
        }
        if (index != -1)
            this.professores.remove(index);
    }
     
    public void addDisciplina(Disciplina disciplina) {
        this.disciplinas.add(disciplina);
    }

    public void removerDisciplina(long disciplinaId) {
        int index = -1;
        for (Disciplina disciplina : this.disciplinas) {
            if (disciplinaId == disciplina.getId()) {
                index = this.disciplinas.indexOf(disciplina);
                break;
            }
        }
        if (index != -1)
            this.disciplinas.remove(index);
    }

    public void addCurriculo(Curriculo curriculo) {
        this.curriculos.add(curriculo);
    }

    public void removerCurriculo(long curriculoId) {
        int index = -1;
        for (Curriculo curriculo : this.curriculos) {
            if (curriculoId == curriculo.getId()) {
                index = this.curriculos.indexOf(curriculo);
                break;
            }
        }
        if (index != -1)
            this.curriculos.remove(index);
    }
    

    public void addSecretaria(Secretaria secretaria ) {
        this.secretarias.add(secretaria);
    }

    public void removerSecretaria(long secretariaId) {
        int index = -1;
        for (Secretaria secretaria : this.secretarias) {
            if (secretariaId == secretaria.getId()) {
                index = this.secretarias.indexOf(secretaria);
                break;
            }
        }
        if (index != -1)
            this.secretarias.remove(index);
    }

    public void addCurso(Curso curso) {
        this.listaCursos.add(curso);
    }   


    public List<ICadastravel> usuarios() {

        List<ICadastravel>  cadastros = new ArrayList<>();
        cadastros.addAll(this.alunos);
        cadastros.addAll(this.professores);
        cadastros.addAll(this.secretarias);
        return cadastros;
    }

    public List<Curso> getCursos() {
        return listaCursos;
    }



}