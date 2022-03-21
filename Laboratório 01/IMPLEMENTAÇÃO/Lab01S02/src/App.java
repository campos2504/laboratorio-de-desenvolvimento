
import java.util.Scanner;


public class App {


    public static void main(String[] args) throws Exception {

        Scanner teclado = new Scanner(System.in);
        MenuSistema.menuSistema(teclado);
        teclado.close();

    }
}
