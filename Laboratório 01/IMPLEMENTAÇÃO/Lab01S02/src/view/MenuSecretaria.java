package view;

import java.util.Scanner;

import models.matricula.Curriculo;
import models.matricula.Curso;
import models.matricula.Disciplina;
import models.usuarios.Aluno;
import models.usuarios.Professor;
import models.usuarios.Secretaria;
import repository.DataRepository;

public class MenuSecretaria extends Menu {

    private static int menuSecretaria(Scanner teclado) {
        limparTela();
        System.out.println("MENU UNIVERSIDADE:");
        System.out.println("==========================");
        System.out.println("1 - Consulta do aluno");
        System.out.println("2 - Atualiza dados do aluno");
        System.out.println("3 - Cadastra aluno");
        System.out.println("4 - Cadastrar professor");
        System.out.println("5 - Cadastrar disciplina");
        System.out.println("6 - Cadastar curriculo");
        System.out.println("7 - Remove Aluno");
        System.out.println("8 - Cadastrar curso");
        System.out.println("9 - Finalizar matricula");
        System.out.println("0 - Sair");

        int opcao = teclado.nextInt();
        teclado.nextLine();
        return opcao;
    }

    public static void opcoesDaSecretaria(Scanner teclado, Secretaria secretaria) {
        DataRepository dados = secretaria.getDados();
        int opcao = -1;
        do {
            opcao = menuSecretaria(teclado);
            if (opcao > 9 || opcao < 0)
                System.out.println("Opção Invalida");

            limparTela();
            switch (opcao) {
                case 1:
                    try {
                        consultaAluno(dados);
                    } catch (RuntimeException e) {
                        System.out.println(e.getMessage());

                    }

                    pausa(teclado);
                    break;
                case 2:
                    try {
                        atualizarAluno(teclado, secretaria.getDados());
                    } catch (RuntimeException e) {
                        System.out.println(e.getMessage());

                    }
                    pausa(teclado);
                    break;
                case 3:

                    adicionarAluno(teclado, secretaria.getDados());
                    pausa(teclado);
                    break;
                case 4:
                    adicionarProfessor(teclado, secretaria.getDados());
                    pausa(teclado);
                    break;
                case 5:
                    try {
                        adicionarDisciplina(teclado, secretaria.getDados());
                    } catch (RuntimeException e) {
                        System.out.println(e.getMessage());
                    }

                    pausa(teclado);
                    break;
                case 6:
                    cadastrarCurriculo(teclado, secretaria.getDados());
                    pausa(teclado);
                    break;
                case 7:
                    try {
                        removerAluno(teclado, secretaria.getDados());
                    } catch (RuntimeException e) {
                        System.out.println(e.getMessage());

                    }
                    pausa(teclado);
                    break;
                case 8:
                    adicionarCurso(teclado, secretaria.getDados());
                    pausa(teclado);
                    break;
                case 9:
                    finalizarMatricula(secretaria.getDados());
                    pausa(teclado);
                    break;

            }
        } while (opcao != 0);

    }

    private static void finalizarMatricula(DataRepository dados) throws RuntimeException {

        if (dados.getCurriculos().size() == 0)
            throw new RuntimeException("Nao tem curriculo criado");
        Curriculo curriculo = dados.getCurriculos().get(dados.getCurriculos().size() - 1);
        curriculo.fecharMatricula();
        for (Disciplina disciplina : curriculo.getDisciplinas()) {
            if (!disciplina.temMinimo()) {
                disciplina.desativar();
            }
        }
        System.out.println("Matricula encerrada");

    }

    private static void atualizarAluno(Scanner teclado, DataRepository dados) {
        System.out.println("Editar aluno");
        String nome, email, senha;

        teclado.nextLine();
        Aluno aluno = selecionarAluno(dados, teclado);
        System.out.println("Atualize o nome");
        nome = teclado.nextLine();
        aluno.setNome(nome);
        System.out.println("Atualize o email");
        email = teclado.nextLine();
        aluno.setEmail(email);
        System.out.println("Atualize o senha");
        senha = teclado.nextLine();
        aluno.setSenha(senha);
    }

    private static Aluno selecionarAluno(DataRepository dados, Scanner in) throws RuntimeException {

        if (dados.getAlunos().size() == 0)
            throw new RuntimeException("Nao existem professores cadastrados");

        int op = -1;
        System.out.println("Selecione um dos professores da lista");
        for (Aluno aluno : dados.getAlunos()) {
            op++;
            System.out.println("Opcão: " + op + " " + aluno);

        }
        System.out.println("Digite sua opcao");
        op = in.nextInt();

        return dados.getAlunos().get(op);

    }

    private static void removerAluno(Scanner teclado, DataRepository dados) throws RuntimeException {
        Aluno aluno = selecionarAluno(dados, teclado);
        dados.getAlunos().remove(aluno);
        System.out.println("Aluno removido");

    }

    private static void consultaAluno(DataRepository dados) throws RuntimeException {
        if (dados.getAlunos().size() == 0)
            throw new RuntimeException("Não possui nenhum aluno matriculado até o momento!");

        System.out.println(dados.getAlunos());

    }

    private static void adicionarAluno(Scanner teclado, DataRepository dados) {
        limparTela();
        String nome;
        String email;
        String senha;
        teclado.nextLine();
        System.out.println("Digite o nome do aluno");
        nome = teclado.nextLine();
        System.out.println("Digite o email do aluuno");
        email = teclado.nextLine();
        System.out.println("Digite a senha do aluno");
        senha = teclado.nextLine();
        dados.addAluno(new Aluno(nome, email, senha));
        System.out.println("Aluno adicionado com sucesso");
    }

    private static void adicionarProfessor(Scanner teclado, DataRepository dados) {
        limparTela();
        String nome;
        String email;
        String senha;
        teclado.nextLine();
        System.out.println("Digite o nome do professor");
        nome = teclado.nextLine();
        System.out.println("Digite o email do professor");
        email = teclado.nextLine();
        System.out.println("Digite a senha do professor");
        senha = teclado.nextLine();
        dados.addProfessor(new Professor(nome, email, senha));
    }

    private static void adicionarDisciplina(Scanner teclado, DataRepository dados) throws RuntimeException {
        limparTela();
        String nome;
        String resp;

        limparTela();
        System.out.println("Digite o nome da disciplina");
        nome = teclado.nextLine();
        if (dados.getCursos().size() == 0)
            throw new RuntimeException("Nao existem cursos para selecionar");
        Curso curso = selecionarCurso(dados, teclado);
        if (dados.getCurriculos().size() == 0)
            throw new RuntimeException("Nao existem curriculos para selecionar");
        Curriculo curriculo = dados.getCurriculos().get(dados.getCurriculos().size() - 1);
        if (dados.getCurriculos().size() == 0)
            throw new RuntimeException("Nao existem professor para selecionar");
        Professor professor = selecionarProfessor(dados, teclado);
        boolean obrigatoria = true;
        System.out.println("A disciplina é opcional? S/N");
        resp = teclado.nextLine();
        if (resp.equals("S"))
            obrigatoria = false;

        Disciplina disciplina = new Disciplina(nome, curso, curriculo, professor, obrigatoria);
        dados.addDisciplina(disciplina);
        curriculo.addDisciplina(disciplina);
        professor.addDisciplina(disciplina);
    }

    private static Professor selecionarProfessor(DataRepository dados, Scanner in) throws RuntimeException {

        if (dados.getProfessores().size() == 0)
            throw new RuntimeException("Nao existem professores cadastrados");

        int op = -1;
        System.out.println("Selecione um dos professores da lista");
        for (Professor professor : dados.getProfessores()) {
            op++;
            System.out.println("Opcão: " + op + " " + professor);

        }
        System.out.println("Digite sua opcao");
        op = in.nextInt();
        return dados.getProfessores().get(op);

    }

    private static Curso selecionarCurso(DataRepository dados, Scanner in) throws RuntimeException {

        if (dados.getCursos().size() == 0)
            throw new RuntimeException("Nao existem cursos cadastrados");

        int op = -1;
        System.out.println("Selecione um dos cursos da lista");
        for (Curso curso : dados.getCursos()) {
            op++;
            System.out.println("Opcão: " + op + " " + curso);

        }
        System.out.println("Digite sua opcao");
        op = in.nextInt();
        return dados.getCursos().get(op);

    }

    private static void adicionarCurso(Scanner teclado, DataRepository dados) {

        limparTela();
        String nome;
        int creditos;
        teclado.nextLine();
        System.out.println("Digite o nome do Curso");
        nome = teclado.nextLine();
        System.out.println("Digite os créditos do curso");
        creditos = teclado.nextInt();

        Curso curso = new Curso(nome, creditos);
        dados.addCurso(curso);
    }

    private static void cadastrarCurriculo(Scanner teclado, DataRepository dados) {

        limparTela();
        String semestre;
        System.out.println("Digite o semestre do curso");
        semestre = teclado.nextLine();

        if (dados.getCurriculos().size() > 0) {
            dados.getCurriculos().get(dados.getCurriculos().size() - 1).finalizarSemestre();
        }
        dados.addCurriculo(new Curriculo(semestre));
    }

    private static Curriculo selecionarCurriculo(DataRepository dados, Scanner in) throws RuntimeException {

        if (dados.getCurriculos().size() == 0)
            throw new RuntimeException("Nao existem cursos cadastrados");

        int op = -1;
        System.out.println("Selecione um dos curriculos da lista");
        for (Curriculo curriculo : dados.getCurriculos()) {
            op++;
            if (curriculo.getSemestreAtual() == true) {
                System.out.println("Opcão: " + op + " " + curriculo);
            }
        }
        System.out.println("Digite sua opcao");
        op = in.nextInt();
        return dados.getCurriculos().get(op);

    }
}
