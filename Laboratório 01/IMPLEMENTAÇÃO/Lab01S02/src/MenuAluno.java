import java.util.InputMismatchException;
import java.util.Scanner;

import dados.Data;
import login.Aluno;
import matricula.Disciplina;

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

    public static void opcoesDoAluno(Scanner teclado, Aluno aluno, Data dados) throws InputMismatchException {
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

    private static void matricularDisciplinaObrigatoria(Aluno aluno, Data dados, Scanner teclado)
            throws RuntimeException {

        int op = -1;
        int aux;
        System.out.println("Selecione a disciplina que você quer cursar");

        // Escolha de quatros disciplinas obrigatórias
        for (int i = 0; i < 4; i++) {
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

            aluno.matricular(dados.getDisciplinas().get(aux));

        }
    }

    private static void matricularDisciplinaOptativa(Aluno aluno, Data dados, Scanner teclado)
            throws RuntimeException {

        int op = -1;
        int aux = -1;
        int numMaterias = 0;
        System.out.println("Selecione a disciplina que você quer cursar");

        // Escolha de até disciplinas obrigatórias
        do {
            for (Disciplina disciplina : dados.getCurriculos().get(op).getDisciplinas()) {
                op++;
                if (disciplina.getObrigatoria() == false
                        && disciplina.getCurriculo().getMatriculaAberta() == true) {
                    System.out.println("Opcão: " + op + " " + disciplina);
                }
            }
            teclado.nextLine();
            System.out.println("Digite a opção escolhida da disciplina");
            aux = teclado.nextInt();

            aluno.matricular(dados.getDisciplinas().get(aux));

            System.out.println("Deseja matricular em mais uma disciplina? 1 - Sim / 2 - Não");
            aux = teclado.nextInt();

            if (aux == 1) {
                numMaterias++;
            } else {
                numMaterias = 0;
            }

        } while (aux != 0);

    }

}
