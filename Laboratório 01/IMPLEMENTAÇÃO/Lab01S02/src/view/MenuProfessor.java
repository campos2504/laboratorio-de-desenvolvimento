package view;
import java.util.InputMismatchException;
import java.util.List;
import java.util.Scanner;

import models.matricula.Disciplina;
import models.usuarios.Aluno;
import models.usuarios.Professor;

public class MenuProfessor extends Menu {

    private static int menuProfessor(Scanner teclado) {
        limparTela();
        System.out.println("MENU UNIVERSIDADE:");
        System.out.println("==========================");
        System.out.println("1 - Consulta do aluno");
        System.out.println("0 - Sair");

        int opcao = teclado.nextInt();
        teclado.nextLine();
        return opcao;
    }

    public static void opcoesDoProfessor(Scanner teclado, Professor professor) throws InputMismatchException {

        int opcao = -1;
        do {
            opcao = menuProfessor(teclado);
            if (opcao > 1 || opcao < 0)
                throw new InputMismatchException("Opção Invalida");

            limparTela();
            switch (opcao) {
                case 1:
                    try {
                        imprimirDisciplina(professor.getDisciplinas());

                    } catch (IllegalCallerException e) {
                        System.out.println(e.getMessage());
                    }

                    pausa(teclado);
                    break;
            }
        } while (opcao != 0);

    }

    private static void imprimirDisciplina(List<Disciplina> disciplinas) throws IllegalCallerException {
        if (disciplinas.size() == 0)
            throw new IllegalCallerException("Esse professor não leciona nenhuma disciplina no momento!");

        for (Disciplina disciplina : disciplinas) {
            System.out.println(disciplina.toString());
            System.out.println();
            for (Aluno aluno : disciplina.getAlunos()) {
                System.out.println();
                System.out.println(aluno);
            }
            
        }

    }

}
