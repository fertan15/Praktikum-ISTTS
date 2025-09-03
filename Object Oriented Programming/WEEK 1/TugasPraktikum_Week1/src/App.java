
import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        char[][] map_ori = {
            {'=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '='},
            {'|', ' ', ' ', 'C', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ']', '[', ' ', '|'},
            {'=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', ' ', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '='},
            {'|', ' ', ' ', ' ', ' ', ' ', 'E', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
            {'=', '=', ' ', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', ' ', '=', '='},
            {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'C', ' ', ' ', ' ', ' ', '|'},
            {'=', '=', '=', 'W', 'W', 'W', 'W', 'W', '=', '=', '-', '-', '-', '=', '=', '=', '=', '=', '=', '=', '=', '=', '='},
            {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'T', ' ', '|'},
            {'=', '=', '=', '=', ' ', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', '=', ' ', '=', '=', '=', '='},
            {'|', 'G', 'B', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},                    
            {'=', '=', '=', '=', '=', '=', '=', '=', '=', 'L', 'L', 'L', 'L', 'L', '=', '=', '=', '=', '=', '=', '=', '=', '='}         
        };



        Scanner scan = new Scanner(System.in);
        Scanner scanInt = new Scanner(System.in);

        String[] turn = {"Current Turn: Fire Boy","Current Turn: Water Girl"};
        int mainMenu, coin=0;
        boolean isFinished = false;
        char nextChar=' ';
        boolean changePlayer = false;
        do {
            
            char[] player = {'B', 'G'};
            mainMenu = menu(scanInt); //menu utama
            boolean exit = false;
            
            switch (mainMenu) {
                case 1: //play
                    boolean fireBoyFinish = false;
                    boolean waterGirlFinish = false;
                    int[][] pos = {{9,2},{9,1}};
                    char[][] map = copyMap(map_ori);

                    String input;
                    int i=0;
                    do{
                        System.out.println(turn[i%2]);
                        printMap(map);
                        System.out.println("Coin: "+ coin +"/2 ");
                        System.out.println("A = Left");
                        System.out.println("D = Right");
                        System.out.println("Q = Jump to Left Platform");
                        System.out.println("E = Jump to Right Platform");
                        System.out.print("Input Move: ");
                        input = scan.nextLine();
                        System.out.println();

                        int nextY = pos[i%2][0];
                        int nextX = pos[i%2][1] + 1;    

                        if(input.equalsIgnoreCase("A")) //kiri
                            {
                                nextY = pos[i%2][0];
                                nextX = pos[i%2][1] - 1;
                            }
                        else if(input.equalsIgnoreCase("D")) //kanan
                            {
                                nextY = pos[i%2][0];
                                nextX = pos[i%2][1] + 1;
                            }
                        else if(input.equalsIgnoreCase("Q")) //kiri atas
                            {
                                if(map[pos[i%2][0]-1][pos[i%2][1]] == ' ')
                                {
                                    nextY = pos[i%2][0] - 2;
                                    nextX = pos[i%2][1] - 1;

                                    if(pos[i%2][0] == 7 && pos[i%2][1] == 11)
                                    {
                                        nextX --;
                                    }
                                    else if(pos[i%2][0] == 7 && pos[i%2][1] == 12)
                                    {
                                        nextX -=2;
                                    }

                                }
                                else
                                    continue;
                            }
                        else if(input.equalsIgnoreCase("E")) //kanan atas
                            {
                                if(map[pos[i%2][0]-1][pos[i%2][1]] == ' ')
                                {
                                    nextY = pos[i%2][0] - 2;
                                    nextX = pos[i%2][1] + 1;

                                    if(pos[i%2][0] == 7 && pos[i%2][1] == 11)
                                    {
                                        nextX ++;
                                    }
                                    else if(pos[i%2][0] == 7 && pos[i%2][1] == 10)
                                    {
                                        nextX +=2;
                                    }

                                }
                                else
                                    continue;
                            }
                        else if(input.equalsIgnoreCase("0")) //kanan
                            {
                                exit = true;
                            }
                        else
                            continue;
                        
                        
                        char destination = map[nextY][nextX];
                        char printedChar = ' ';

                        //logic jalannya
                                
                        if(map[nextY+1][nextX] == 'L' && i%2==1) //cek lava 
                        {
                            System.out.println();
                            System.out.println("== GAME OVER ==");
                            System.out.println();
                            break;
                        }

                        if(map[nextY+1][nextX] == 'W' && i%2==0) //cek water
                        {
                            System.out.println();
                            System.out.println("== GAME OVER ==");
                            System.out.println();
                            break;
                        }

                        if(map[nextY+1][nextX] == ' ') //cek bolong -> udh bisa jatuh kalo lubang
                        {
                            nextY+=2; 
                        }

                        if(destination == '|' || destination == ']')
                            continue;


                        if(destination == 'C')
                        {
                            coin++;
                            map_ori[nextY][nextX] = ' ';
                        }
                        else if(destination == '[' )
                        {
                            if(map[3][6] != 'E')
                                {

                                    if(i%2==0)
                                    {
                                        fireBoyFinish = true;
                                        player[i%2] = '[';
                                        changePlayer = true;
                                    }
                                    else
                                    {
                                        waterGirlFinish = true;
                                        player[i%2] = '[';
                                        changePlayer = true;
                                    }


                                    if(fireBoyFinish && waterGirlFinish)
                                    {
                                        map[pos[i%2][0]][pos[i%2][1]] = printedChar;
                                        printMap(map);
                                        System.out.println("\n== You Win! ==");
                                        System.out.println();
                                        System.out.println();
                                        isFinished = true;
                                        break;


                                    }
                                }
                        }
                        else if(destination == 'E')
                        {
                            map[1][19] = '[';
                            map[1][20] = ']';
                        }
                        else if(destination == 'T')
                        {
                            map[6][10] = ' ';
                            map[6][11] = ' ';
                            map[6][12] = ' ';
                        }


                       
                        printedChar = ' ';
                        
                      

                        //hapus
                        map[pos[i%2][0]][pos[i%2][1]] = printedChar;

            
                        //ganti posisi
                        pos[i%2][0] = nextY;
                        pos[i%2][1] = nextX;
                        //masukin ulang player
                        map[pos[0][0]][pos[0][1]] = player[0];
                        map[pos[1][0]][pos[1][1]] = player[1];


                        if(changePlayer)
                        {
                            i++;
                            changePlayer = false;
                        }
                        
                             
                        if(fireBoyFinish || waterGirlFinish)
                            i+=2;
                        else
                            i++;

                    }while((!isFinished && !exit) );

                    break; // end play
                case 2: //Progress
                    String progress = isFinished == true ? "Exit Reached!" : "Exit Not Reached Yet!";
                    System.out.println();
                    System.out.println("= Your Progress =");
                    System.out.println("Coin: " + coin + "/2");
                    System.out.println(progress);
                    System.out.println();
                    System.out.println();
                    break; //end progress
                case 3: //exit
                    //KLUAR DARI LOOPINGAN LGSNG
                    break;
            
            }

        } while (mainMenu!=3);

        System.out.println("== THANK YOU FOR PLAYING ==");
        System.out.println();
        
        scan.close();
        scanInt.close();
    }

    static int menu(Scanner scanInt){
            int pilihan;
            System.out.println("== Fire Boy & Water Girl ==");
            System.out.println("1. Play");
            System.out.println("2. Your Progress");
            System.out.println("3. Exit");
            do{
                System.out.print(">> ");
                pilihan = scanInt.nextInt();
            }while(pilihan<1 || pilihan>3);
            System.out.println();
        return pilihan;
    }

    static void printMap(char[][] map){

        for(char[] row : map) 
            {
                for(char c : row) 
                {
                    System.out.print(c);
                }
                System.out.println();
            }
    }

    static char[][] copyMap(char[][] original) {
        char[][] copy = new char[original.length][original[0].length];
        
        for (int i = 0; i < original.length; i++) {
            for (int j = 0; j < original[i].length; j++) {
                copy[i][j] = original[i][j];
            }
        }
        
        return copy;
    }
    


}
