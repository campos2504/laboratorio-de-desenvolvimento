package matricula;

public class Curso {

    private static long ID=1L;
    private long id;
    private String nome;
    private long creditos;

    public Curso( String nome, long creditos) {
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

    public long getCreditos() {
        return creditos;
    }

    public void setCreditos(long creditos) {
        this.creditos = creditos;
    }
    
    
}
