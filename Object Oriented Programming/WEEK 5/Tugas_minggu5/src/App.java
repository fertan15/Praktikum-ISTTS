import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        Scanner scan = new Scanner(System.in);
        int currentMenu = 0;
        String input = null;
        Boolean programOver = false;
        do{
            System.out.println("== Dummy Invoc TCG ==" );
            System.out.println( (currentMenu==0 ? "> " : "" ) + "Play");
            System.out.println( (currentMenu==1 ? "> " : "" ) + "Exit");
            input = scan.nextLine();

            if(input.equalsIgnoreCase("w")){
                currentMenu--;
                if(currentMenu < 0){
                    currentMenu = 1;
                }
            }
            else if(input.equalsIgnoreCase("s")){
                currentMenu++;
                if(currentMenu > 1){
                    currentMenu = 0;
                }
            }
            else if(input.isEmpty())
                {
                    Game game = null;
                    if(currentMenu == 0)
                        game = new Game();
                    else if(currentMenu == 1)
                        programOver = true;
                }
                System.out.println();
        }while(!programOver);
        


    }
}
