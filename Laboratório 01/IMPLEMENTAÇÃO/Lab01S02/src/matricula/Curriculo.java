package matricula;

import java.time.LocalDateTime;

import login.Secretaria;


public class Curriculo {

    private static long ID=1L;
    private long id;
    private String semestre;
    private LocalDateTime inicioMatricula;
    private LocalDateTime fimMatricula;
    private Secretaria secretaria;


    public Curriculo(long id, String semestre, LocalDateTime inicioMatricula, LocalDateTime fimMatricula,
            Secretaria secretaria) {
                
        this.id = ID++;
        this.semestre = semestre;
        this.inicioMatricula = inicioMatricula;
        this.fimMatricula = fimMatricula;
        this.secretaria = secretaria;
    }

    public void addDisciplina(Disciplina disciplina) {
        
    }

    public long getId() {
        return id;
    }

    public String getSemestre() {
        return semestre;
    }

    public void setSemestre(String semestre) {
        this.semestre = semestre;
    }

    public LocalDateTime getInicioMatricula() {
        return inicioMatricula;
    }

    public void setInicioMatricula(LocalDateTime inicioMatricula) {
        this.inicioMatricula = inicioMatricula;
    }

    public LocalDateTime getFimMatricula() {
        return fimMatricula;
    }

    public void setFimMatricula(LocalDateTime fimMatricula) {
        this.fimMatricula = fimMatricula;
    }

    public Secretaria getSecretaria() {
        return secretaria;
    }

    public void setSecretaria(Secretaria secretaria) {
        this.secretaria = secretaria;
    }

    @Override
    public String toString() {
        return "Curriculo [fimMatricula=" + fimMatricula + ", id=" + id + ", inicioMatricula=" + inicioMatricula
                + ", secretaria=" + secretaria + ", semestre=" + semestre + "]";
    }
    

}
