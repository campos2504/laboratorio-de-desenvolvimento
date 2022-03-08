package login;

import java.util.ArrayList;
import java.util.List;

import matricula.Disciplina;

public class Professor extends Usuario {

    private List<Disciplina> disciplinas= new ArrayList<Disciplina>();


    public Professor( String nome, String email, String senha) {
        super( nome, email, senha);
        //TODO Auto-generated constructor stub
    }

    @Override
    public void registrar() {
        // TODO Auto-generated method stub
        
    }

    public String listarAlunos(){
        return null;
    }
    
}
