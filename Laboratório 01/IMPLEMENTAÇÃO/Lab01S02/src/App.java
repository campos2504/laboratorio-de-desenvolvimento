import java.time.LocalDateTime;
import java.util.Scanner;
import login.Secretaria;
import matricula.Curriculo;

public class App {

    public static void limparTela() {
        System.out.print("\033[H\033[2J");
        System.out.flush();
    }

    public static int menu(Scanner teclado) {
        limparTela();
        System.out.println("Sistema Universidade");
        System.out.println("==========================");
        System.out.println("1 - Cadastrar curriculo");
        System.out.println("2 - xxxx");
        System.out.println("3 - xxxx");

        int opcao = teclado.nextInt();
        teclado.nextLine();
        return opcao;
    }

    static void pausa(Scanner teclado) {
        System.out.println("Enter para continuar.");
        teclado.nextLine();
    }

    public static Curriculo cadastrarCurriculo(){

        Secretaria secretaria = new Secretaria("Maria", "maria@maria.com.br", "123");
        LocalDateTime data1 = LocalDateTime.of(2022, 1, 1, 0, 0, 0);
        LocalDateTime data2 = LocalDateTime.of(2022, 1, 31, 0, 0, 0);

        Curriculo curriculo = new Curriculo(1, "1/2022", data1, data2, secretaria);

        System.out.println(curriculo);

        return curriculo;

    }

    public static void main(String[] args) throws Exception {

        Scanner teclado = new Scanner(System.in);
        int opcao = -1;

        do {
            opcao = menu(teclado);
            limparTela();

            switch (opcao) {
                case 1:
                    cadastrarCurriculo();                    
                    pausa(teclado);                    
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }
        } while (opcao != 0);

        System.out.println("FIM");
        teclado.close();
    }
}
