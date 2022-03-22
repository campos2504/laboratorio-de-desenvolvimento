package view;
import java.util.InputMismatchException;
import java.util.Scanner;

import models.matricula.Disciplina;
import models.usuarios.Aluno;
import repository.DataRepository;

public class MenuAluno extends Menu {

    private static int menuAluno(Scanner teclado) {
        limparTela();
        System.out.println("MENU UNIVERSIDADE:");
        System.out.println("==========================");
        System.out.println("1 - Matricular em disciplina obrigatória");
        System.out.println("2 - Matricular em disciplina optativa");
        System.out.println("3 - Cancelar Matricula de disciplina");
        System.out.println("0 - Sair");

        int opcao = teclado.nextInt();
        teclado.nextLine();
        return opcao;
    }

    public static void opcoesDoAluno(Scanner teclado, Aluno aluno, DataRepository dados) throws InputMismatchException {
        int opcao = -1;
        do {
            opcao = menuAluno(teclado);
            if (opcao > 3 || opcao < 0)
                throw new InputMismatchException("Opção Invalida");

            limparTela();
            switch (opcao) {
                case 1:
                    matricularDisciplinaObrigatoria(aluno, dados, teclado);
                    pausa(teclado);
                    break;
                case 2:
                    matricularDisciplinaOptativa(aluno, dados, teclado);
                    pausa(teclado);
                    break;
                case 3:
                    try {

                    } catch (IllegalCallerException e) {
                        System.out.println(e.getMessage());

                    }

                    pausa(teclado);
                    break;
            }
        } while (opcao != 0);

    }

    private static void matricularDisciplinaObrigatoria(Aluno aluno, DataRepository dados, Scanner teclado)
            throws RuntimeException {

        int op = -1;
        int aux;
        int i=0;
        System.out.println("Selecione a disciplina que você quer cursar");

        // Escolha de quatros disciplinas obrigatórias
        do {
            op=-1;
            aux=dados.getCurriculos().size()-1;

            for (Disciplina disciplina : dados.getCurriculos().get(aux).getDisciplinas()) {
                op++;
                if (disciplina.getObrigatoria() == true && disciplina.getCurriculo().getMatriculaAberta() == true) {
                    System.out.println("Opcão: " + op + " " + disciplina);
                }
            }
            teclado.nextLine();
            System.out.println("Digite a opção escolhida da disciplina");
            aux = teclado.nextInt();

            Disciplina disciplina = dados.getDisciplinas().get(aux);

            aluno.matricular(disciplina);
            disciplina.addAluno(aluno);

        }while(i<=4);
    }

    private static void matricularDisciplinaOptativa(Aluno aluno, DataRepository dados, Scanner teclado)
            throws RuntimeException {

        int op = -1;
        int aux=dados.getCurriculos().size()-1;
        System.out.println("Selecione a disciplina que você quer cursar");

        // Escolha de até disciplinas obrigatórias
            op=-1;
            for (Disciplina disciplina : dados.getCurriculos().get(aux).getDisciplinas()) {
                op++;
                if (disciplina.getObrigatoria() == false
                        && disciplina.getCurriculo().getMatriculaAberta() == true) {
                    System.out.println("Opcão: " + op + " " + disciplina);
                }
            }
            teclado.nextLine();
            System.out.println("Digite a opção escolhida da disciplina");
            op = teclado.nextInt();

            Disciplina disciplina2=dados.getDisciplinas().get(aux);

            aluno.matricular(disciplina2);
            disciplina2.addAluno(aluno);

            System.out.println("Deseja matricular em mais uma disciplina? 1 - Sim / 2 - Não");
            aux = teclado.nextInt();

            if (aux == 1) {
                op=-1;
            for (Disciplina disciplina : dados.getCurriculos().get(aux).getDisciplinas()) {
                op++;
                if (disciplina.getObrigatoria() == false
                        && disciplina.getCurriculo().getMatriculaAberta() == true) {
                    System.out.println("Opcão: " + op + " " + disciplina);
                }
            }
            teclado.nextLine();
            System.out.println("Digite a opção escolhida da disciplina");
            op = teclado.nextInt();

            disciplina2=dados.getDisciplinas().get(aux);

            aluno.matricular(disciplina2);
            disciplina2.addAluno(aluno);
                
            }


    }

}
