package login;

public abstract class Usuario {
    
    private static long ID=1L;
    private Long id;
    private String nome;
    private String email;
    private String senha;

    public Usuario( String nome, String email, String senha) {
        this.id = ID++;
        this.nome = nome;
        this.email = email;
        this.senha = senha;
    }

    public  abstract void registrar();

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
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

    @Override
    public String toString() {
        return "Usuario [email=" + email + ", id=" + id + ", nome=" + nome + ", senha=" + senha + "]";
    }
    
}
