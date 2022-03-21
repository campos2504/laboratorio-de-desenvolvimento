import java.io.EOFException;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.util.ArrayList;
import java.util.Scanner;

import dados.Data;
import login.Aluno;
import login.Professor;
import login.Secretaria;

public class MenuSistema extends Menu {

    private static Data cadastroDeDados() {

        System.out.println("Cadastrando dados login padrão....");
        Data baseDados = new Data();
        Secretaria loginPadrao = new Secretaria("SecretariaPadrao", "secretaria@puc.com", "123", baseDados);
        baseDados.addSecretaria(loginPadrao);
        System.out.println("Secretaria padrão criada!");

        try {
            gravarDados(baseDados);
        } catch (IOException e) {
            System.out.println(e.getMessage());
        }

        return baseDados;

    }

    public static void gravarDados(Data dados) throws IOException {

        System.out.println("Gravando........");
        ObjectOutputStream arquivoSaida = new ObjectOutputStream(
                new FileOutputStream("src/dados/baseDadosUniversidade.bin"));

        arquivoSaida.writeObject(dados);

        arquivoSaida.close();
        System.out.println("Dados gravados!");

    }

    public static ArrayList<Data> lerBaseDados() {

        ArrayList<Data> dados = new ArrayList<>();
        Data leitura;
        ObjectInputStream arquivoEntrada;
        System.out.println("Acessando Dados........");
        try {
            arquivoEntrada = new ObjectInputStream(new FileInputStream("src/dados/baseDadosUniversidade.bin"));
            do {
                leitura = (Data) arquivoEntrada.readObject();
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

        Data baseDados = lerBaseDados().get(0);
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

            System.out.print("Digite seus email: ");
            email = teclado.nextLine();

            System.out.print("Digite sua senha: ");
            senha = teclado.nextLine();
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
