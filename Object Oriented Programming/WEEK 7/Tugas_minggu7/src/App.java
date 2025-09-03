import java.util.Scanner;

public class App {
    static Scanner scanInt = new Scanner(System.in);
    static Scanner scanStr = new Scanner(System.in);
    public static void main(String[] args) throws Exception {
        int menu = 0;

        while(menu != 2){
            System.out.print("+===================+ \r\n" + //
                                "|  " + //
                                "The Sims Deluxe  | \r\n" + //
                                "+===================+ \r\n" + //
                                "| 1. Play           " + //
                                "| \r\n" + //
                                "| 2. Exit           " + //
                                "| \r\n" + //
                                "+===================+ \r\n" + //
                                ">> ");
            menu = scanInt.nextInt();
            System.out.println();

            if(menu == 1){
                Game.start();
            }
    }
}
}
