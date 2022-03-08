package login;

import java.util.ArrayList;
import java.util.List;

import matricula.Disciplina;

public class Aluno extends Usuario {

    private static final int DISCIPLINAS_OBG=4;
    private static final int MAX_DISCIPLINAS_OPT=2;

    private List<Disciplina> disciplinas= new ArrayList<Disciplina>();
    
    public Aluno(String nome, String email, String senha) {
        super(nome, email, senha);
        //TODO Auto-generated constructor stub
    }

    @Override
    public void registrar() {
        // TODO Auto-generated method stub
        
    }

    
}
