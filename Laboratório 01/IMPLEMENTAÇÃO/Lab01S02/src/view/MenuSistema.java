package view;
import java.io.EOFException;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.util.ArrayList;
import java.util.Scanner;

import models.matricula.Curriculo;
import models.matricula.Curso;
import models.matricula.Disciplina;
import models.usuarios.Aluno;
import models.usuarios.Professor;
import models.usuarios.Secretaria;
import repository.DataRepository;

public class MenuSistema extends Menu {

    private static DataRepository cadastroDeDados() {

        System.out.println("Cadastrando dados login padrão....");
        DataRepository baseDados = new DataRepository();
        Secretaria loginPadrao = new Secretaria("SecretariaPadrao", "sec@gmail.com", "123", baseDados);
        Professor professor = new Professor("Carlos", "carlos@gmail.com", "123");
        baseDados.addProfessor(professor);
        Professor professor2 = new Professor("Ana", "ana@gmail.com", "123");
        baseDados.addProfessor(professor2);
        Professor professor3 = new Professor("Antonio", "tonho@gmail.com", "123");
        baseDados.addProfessor(professor3);
        Curso curso = new Curso("Engenharia", 100);
        baseDados.addCurso(curso);
        Curso curso2 = new Curso("Compputacao", 120);
        baseDados.addCurso(curso2);
        Curriculo curriculo = new Curriculo("2022/2");
        baseDados.addCurriculo(curriculo);
        String string1, string2, string3;
        Disciplina disciplina1, disciplina2, disciplina3;
        for (int i = 0; i < 3; i++) {
            string1="TIS "+i;
            string2="Optativa "+i;
            string3="Calculo"+i;
            disciplina1=new Disciplina(string2, curso, curriculo, professor2, true);
            professor2.addDisciplina(disciplina1);
            disciplina2= new Disciplina(string1, curso, curriculo, professor, false);
            professor.addDisciplina(disciplina2);
            disciplina3 = new Disciplina(string3, curso2, curriculo, professor3, true);
            professor3.addDisciplina(disciplina3);
            curriculo.addDisciplina(disciplina1);
            baseDados.addDisciplina(disciplina1);
            curriculo.addDisciplina(disciplina2);
            baseDados.addDisciplina(disciplina2);
            curriculo.addDisciplina(disciplina3);
            baseDados.addDisciplina(disciplina3);     
        }
        for (int i = 0; i < 60; i++) {
            string1="User"+i;
            string2="user"+i+"@gmail.com";
            baseDados.addAluno(new Aluno(string1, string2, "123"));
        }
        
        baseDados.addSecretaria(loginPadrao);
        System.out.println("Secretaria padrão criada!");

        try {
            gravarDados(baseDados);
        } catch (IOException e) {
            System.out.println(e.getMessage());
        }

        return baseDados;

    }

    public static void gravarDados(DataRepository dados) throws IOException {

        System.out.println("Gravando........");
        ObjectOutputStream arquivoSaida = new ObjectOutputStream(
                new FileOutputStream("baseDadosUniversidade.bin"));

        arquivoSaida.writeObject(dados);

        arquivoSaida.close();
        System.out.println("Dados gravados!");

    }

    public static ArrayList<DataRepository> lerBaseDados() {

        ArrayList<DataRepository> dados = new ArrayList<>();
        DataRepository leitura;
        ObjectInputStream arquivoEntrada;
        System.out.println("Acessando Dados........");
        try {
            arquivoEntrada = new ObjectInputStream(new FileInputStream("baseDadosUniversidade.bin"));
            do {
                leitura = (DataRepository) arquivoEntrada.readObject();
                if (leitura != null) {
                    dados.add(leitura);
                }
            } while (leitura != null);
            arquivoEntrada.close();
        } catch (ClassNotFoundException e) {
            System.out.println(e.getMessage());
        } catch (FileNotFoundException e) {
            System.out.println(e.getMessage());
            cadastroDeDados();
            dados = lerBaseDados();
        } catch (EOFException e) {
            System.out.println(e.getMessage());
        } catch (IOException e) {
            System.out.println(e.getMessage());
        }
        System.out.println("Dados recuperados com sucesso!");
        return dados;
    }

    public static void menuSistema(Scanner teclado) {

        DataRepository baseDados = lerBaseDados().get(0);
        String email ;
        String senha ;
        int opt;

        do {
            opt=-1;
            email=null;
            senha=null;
            System.out.println("MENU UNIVERSIDADE:");
            System.out.println("==========================");
            System.out.println("Escolha seu tipo de login:");
            System.out.println("1- Aluno");
            System.out.println("2- Secretaria");
            System.out.println("3- Professor");
            System.out.println("0- Sair");

            opt = teclado.nextInt();
            limparTela();
            teclado.nextLine();


            if(opt!=0){
                System.out.print("Digite seus email: ");
            email = teclado.nextLine();

            System.out.print("Digite sua senha: ");
            senha = teclado.nextLine();

            }
            
            limparTela();

            switch (opt) {
                case 1:
                    for (Aluno aluno : baseDados.getAlunos()) {
                        if (aluno.login(email, senha)) {
                            MenuAluno.opcoesDoAluno(teclado, aluno, baseDados);
                            break;
                        }
                    }
                    break;
                case 2:
                    for (Secretaria secretaria : baseDados.getSecretarias()) {

                        if (secretaria.login(email, senha)) {
                            System.out.println("logado");
                            MenuSecretaria.opcoesDaSecretaria(teclado, secretaria);
                            break;
                        }
                    }

                    break;
                case 3:
                    for (Professor professor : baseDados.getProfessores()) {

                        if (professor.login(email, senha)) {
                            MenuProfessor.opcoesDoProfessor(teclado, professor);
                            break;
                        }
                    }

                    break;
                default:
                    try {
                        gravarDados(baseDados);
                    } catch (IOException e) {
                        System.out.println(e.getMessage());
                    }
            }
            pausa(teclado);
            limparTela();
        } while (opt != 0);

    }
}
