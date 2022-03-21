package login;

public interface ICadastravel {
    public boolean login(String email, String password);
    public TipoUsuario getTipoUsuario();
}
