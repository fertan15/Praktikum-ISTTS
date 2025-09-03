import java.util.ArrayList;
import java.util.Random;
import java.util.Scanner;

public class Game {
    Random random = new Random();
    int day = 1, coin = 100, berry=40;
    String username = "";
    Boolean incubator = false;
    String incubatorName = null;
    int incubatorDay = -1;
    String incubatorElemen = null;
    ArrayList<Dragon> dragons = new ArrayList<Dragon>();
    Scanner scanString = new Scanner(System.in);
    Scanner scanInt = new Scanner(System.in);
    boolean berryForTheDay = false;
    User now = null;

    //posisi dragon
    ArrayList<Integer> DragonPosX = new ArrayList<Integer>();
    ArrayList<Integer> DragonPosY = new ArrayList<Integer>();


    char[][] map = {
        {'=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','='},
        {'|',' ',' ',' ',' ','|',' ','B',' ','|',' ','S',' ','|',' ','H',' ','|',' ',' ',' ',' ','|'},
        {'|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|'},
        {'|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|'},
        {'|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','P',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|'},
        {'|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|'},
        {'|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|'},
        {'|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|'},
        {'=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','='},
    };

    

    public Game(User x) {
        this.username = x.username;
        this.berry = x.berry;
        this.coin = x.coin;
        this.day = x.hari; 
        this.incubator = x.incubator;
        this.dragons = x.dragons;
        this.now = x;
        this.incubatorName = x.incubatorName;
        this.incubatorDay = x.incubatorDay;
        this.incubatorElemen = x.incubatorElemen;
        this.berryForTheDay = x.berryForTheDay;
        startGame();


    
    }

    public void startGame(){ 
        Random random = new Random();
        

        int posX = 11, posY = 4;
        char player = 'P';

       //placement posisi dragon initial
        for(Dragon x : dragons){
                boolean placed = false;
                while(!placed){
                    int rndX = random.nextInt(1,22);
                    int rndY = random.nextInt(2,8);
                    
                    if(map[rndY][rndX] == ' '){
                        map[rndY][rndX] = x.jenisDragon.charAt(0);
                        DragonPosX.add(rndX);
                        DragonPosY.add(rndY);
                        placed = true;
                    }
                }
        }

        


        Boolean gameOver= false;
        do{

            if(incubatorDay == 4)
            {
                boolean mixRace = true;

                if(incubatorName != null && incubatorName.equalsIgnoreCase("Infernos") || incubatorName.equalsIgnoreCase("Azurith") || incubatorName.equalsIgnoreCase("Verdalis"))
                {
                    mixRace = false;
                }


                System.out.println("Your " + incubatorName + " Egg Hatched!");
                boolean namedone = false;
                String nama = "";
                while(!namedone){
                    System.out.print("Name your " + incubatorName + " (Max 10 chars): ");
                    nama = scanString.nextLine();

                    for(Dragon x : dragons)
                    {
                        if(x.namaDragon.equalsIgnoreCase(nama))
                        {
                            System.out.println("Name already used!");
                            namedone = false;
                            break;
                        }
                        else
                        {
                            namedone = true;
                        }
                    }
                }
                dragons.add(new Dragon(incubatorName, incubatorElemen, nama ,mixRace));
                incubator = false;
                incubatorDay = 0;
                incubatorName = null;

                //placement posisi dragon habis hatched
                boolean placed = false;
                while(!placed){
                    int rndX = random.nextInt(1,22);
                    int rndY = random.nextInt(2,8);
                    
                    if(map[rndY][rndX] == ' '){
                        map[rndY][rndX] = dragons.get(dragons.size()-1).jenisDragon.charAt(0);
                        DragonPosX.add(rndX);
                        DragonPosY.add(rndY);
                        placed = true;
                    }
                }


            }

            System.out.println("=======================");
            System.out.println("Day "+ day + ", Welcome "+ username);
            System.out.println("=======================");
            //incubator
            if(!incubator){
                System.out.println("Incubator\n - empty -");
            }
            else{

                System.out.println("Incubator");
                System.out.println(incubatorName + " (" + incubatorDay + "/4)");
            }
            System.out.println("=======================");
            System.out.println("Coin : " + coin + " G");
            System.out.println("Berry : " + berry );

            for(char x[] : map){
                for(char y : x){
                    System.out.print(y);
                }
                System.out.println();
            }

        System.out.print(">> ");
        String input = scanString.nextLine();

        int nextX = posX, nextY = posY;
        boolean move = false;
        //input movement
        if(input.equalsIgnoreCase("w")){
            nextX = posX;
            nextY = posY - 1;
            move = true;
        }
        if(input.equalsIgnoreCase("s")){
            nextX = posX;
            nextY = posY + 1;
            move = true;
        }
        if(input.equalsIgnoreCase("a")){
            nextX = posX - 1;
            nextY = posY;
            move = true;
        }
        if(input.equalsIgnoreCase("d")){
            nextX = posX + 1;
            nextY = posY;
            move = true;
        }
        if(input.equalsIgnoreCase("l"))
            gameOver = true;


        //check movement
        if(move){
            if(map[nextY][nextX] == ' '){
                map[nextY][nextX] = player;
                map[posY][posX] = ' ';
                posX = nextX;
                posY = nextY;
            }
            else if(map[nextY][nextX] == 'B'){
                farm();
            }
            else if(map[nextY][nextX] == 'S'){
                shop();
            }
            else if(map[nextY][nextX] == 'H'){
                house();
            }
            else if(map[nextY][nextX] != '|' && map[nextY][nextX] != '='){
                for(int i=0;i<dragons.size();i++)
                {
                    if(DragonPosX.get(i) == nextX && DragonPosY.get(i) == nextY)
                    {
                        detailDragon(dragons.get(i));
                    }
                }
            }

            //kurang detail dragon
           
        }            

        //edit detail akun -> di save
        if(gameOver)
            saveGame();
      
    
    } while (!gameOver);
}
    

    public void saveGame(){
        now.username = this.username;
        now.berry = this.berry;
        now.coin = this.coin;
        now.hari = this.day;
        now.incubator = this.incubator;
        now.dragons = this.dragons;
        now.incubatorName = this.incubatorName;
        now.incubatorDay = this.incubatorDay;
        now.incubatorElemen = this.incubatorElemen;
        now.berryForTheDay = this.berryForTheDay;
    }

    public void shop(){
        int input;
        do{
            System.out.println("== Choose a Dragon ==");
            System.out.println("Your Coin: " + coin + " G");
            System.out.println("1. Infernos - Fire");
            System.out.println("2. Azurith - Water");
            System.out.println("3. Verdalis - Flora");
            System.out.println("0. Exit");
            System.out.print(">> ");
            input = scanInt.nextInt();

            if(input!=0 && input < 4 && input > 0) 
            {
                if(coin<50)
                {
                    System.out.println("Your Coin aren't enough!");
                }
                else
                {
                    coin -= 50;
                    System.out.println("You bought a dragon!");
                    String jenis = "";
                    String elemen = "";
                    if(input == 1)
                    { 
                        jenis = "Infernos";
                        elemen = "Fire";
                    }
                    else if(input == 2)
                    {
                        jenis = "Azurith";
                        elemen = "Water";
                    }
                    else if(input == 3)
                    {
                        jenis = "Verdalis";
                        elemen = "Flora";
                    }
                    System.out.println(jenis + " acquired");

                    String nama;
                    boolean namedone1 = false;
                    
                    do{
                        System.out.print("Name your " + jenis + " (Max 10 chars): ");
                        nama = scanString.nextLine();

                        int check = -1;
                        for(Dragon x : dragons)
                        {
                            if(x.namaDragon.equalsIgnoreCase(nama))
                            {
                                check = 1;
                                break;
                            }
                            
                        }
                        if(nama.length() > 10)
                            System.out.println("Name max 10 char!");
                        if(check == 1)
                            System.out.println("Name already used!");
                        else
                            namedone1 = true;
 
                    }while(!namedone1);


                    dragons.add(new Dragon(jenis, elemen, nama));

                    //placement posisi dragon habis beli di map
                    boolean placed = false;
                    while(!placed){
                        int rndX = random.nextInt(1,22);
                        int rndY = random.nextInt(2,8);
                        
                        if(map[rndY][rndX] == ' '){
                            map[rndY][rndX] = dragons.get(dragons.size()-1).jenisDragon.charAt(0);
                            DragonPosX.add(rndX);
                            DragonPosY.add(rndY);
                            placed = true;
                        }
                    }
                    
        

                    System.out.println();
                }
            }

        }while(input != 0);

    }

    public void farm(){

        if(!berryForTheDay)
        {
            System.out.println("Obtained 50 Berries");
            berry += 50;
            berryForTheDay = true;
        }
        else
        {
            System.out.println("You already harvested the berries today!");
        }
        
    }

    public void house(){
        System.out.println("You rest for the day.");
        day++;
        berryForTheDay = false;
        incubatorDay++;
    }

    public void detailDragon(Dragon x){
        int pil;
        do{
            System.out.println("=======================");
            System.out.println(x.namaDragon + " ("+ x.jenisDragon +")");
            System.out.println("=======================");
            System.out.println("Level: " + x.level);
            System.out.println("EXP  : " + x.exp + "/" + x.maxExp);
            System.out.println("=======================");
            System.out.println("1. Feed");
            System.out.println("2. Match this Dragon");
            System.out.println("0. Exit");
            System.out.print(">> ");
            pil = scanInt.nextInt();
            System.out.println();

            if(pil == 1)
            {
                int amount = 10;
                char current = '+';
                String inputAmount;

                do{
                    System.out.println("Choose an amount to feed");
                    System.out.println("===============");
                    System.out.println("| " + amount + " |"+ ((current == '+') ? "<" : " ") +"+"+ ((current == '+') ? ">" : " ") + ((current == '-') ? "<" : " ")+ "-"+ ((current == '-') ? ">" : " ")+"| ");
                    System.out.println("===============");
                    System.out.print(">> ");
                    inputAmount = scanString.nextLine();

                    if(inputAmount.equalsIgnoreCase("a"))
                    {
                        current = '+';                   
                    }
                    if(inputAmount.equalsIgnoreCase("d"))
                    {
                        current = '-';                    
                    }
                    if(inputAmount.equalsIgnoreCase("enter"))
                    {
                        if(amount <90 && current == '+')
                            amount += 10;
                        else if(amount > 10 && current == '-')
                            amount -= 10;
                    }

                }while(!inputAmount.equalsIgnoreCase("e"));

                if(berry>=amount){
                    System.out.println(x.namaDragon + " acquired " + amount + " EXP!");
                    x.addExp(amount);
                    berry -= amount;
                }
                else{
                    System.out.println("Your berry aren't enough!");
                }

                System.out.println();
            }

            if(pil == 2)
            {
                int choiceMatch = -1;
                Dragon selectedMatch = null;
                boolean done = false;
                while(!done){
                    System.out.println("======================================");
                    System.out.printf("|%s|\n", centerAlign("Select Two Dragons", 38 - 2));                    
                    System.out.println("======================================");
                    System.out.printf("|%-15s | %-15s   |\n", "1st Dragon", "2nd Dragon");
                    System.out.printf("|%-15s | %-15s   |\n", x.namaDragon, (selectedMatch == null ? "-" : selectedMatch.namaDragon));
                    System.out.println("======================================");
                    
                    int i=1;
                    for(Dragon y : dragons)
                    {
                        System.out.println(i + ". " + y.namaDragon + " ("+ y.jenisDragon +") " + ((y == x || y==selectedMatch)? "<Selected>" : ""));
                        i++;
                    }
                    System.out.println("0. Exit");

                    if(selectedMatch == null)
                    {
                    
                        do{
                            System.out.print(">> ");
                            choiceMatch = scanInt.nextInt();

                        }while(choiceMatch < 0 || choiceMatch > dragons.size());
                        
    
                        if(choiceMatch == 0)
                            done = true;
                        else if(dragons.get(choiceMatch-1) == x)
                            System.out.println("You already selected this dragon!");
                        else if ((x.HasilPembiakan || dragons.get(choiceMatch-1).HasilPembiakan) && !x.jenisDragon.equalsIgnoreCase(dragons.get(choiceMatch-1).jenisDragon)) 
                            System.out.println("You cannot match this dragon!"); 
                        else
                        {
                            selectedMatch = dragons.get(choiceMatch-1);
                        }
            
                     }
                    else{
                        System.out.print("Confirm your selection? (Y/N) : ");
                        String confirm = scanString.nextLine();
                        if(confirm.equalsIgnoreCase("y"))
                        {
                            if(incubator == true)
                            {
                                System.out.println("The incubator is occupied, come back later.");
                                
                            }
                            else{

                                //random dominan dragon
                                int randomDominan = random.nextInt(2);
                                Dragon dominan = null;
                                Dragon notDominan = null;


                                if(randomDominan == 0)
                                    {
                                        dominan = x;
                                        notDominan = dragons.get(choiceMatch-1);
                                    }
                                else{
                                    dominan = dragons.get(choiceMatch-1);
                                    notDominan = x;
                                }

                                char[] incubatorNameChars = dominan.jenisDragon.toCharArray(); 

                                incubatorNameChars[incubatorNameChars.length - 1] = notDominan.jenisDragon.charAt(notDominan.jenisDragon.length() - 1);
                                incubatorNameChars[incubatorNameChars.length - 2] = notDominan.jenisDragon.charAt(notDominan.jenisDragon.length() - 2);
                                incubatorNameChars[incubatorNameChars.length - 3] = notDominan.jenisDragon.charAt(notDominan.jenisDragon.length() - 3);
                                
                                incubatorName = new String(incubatorNameChars);


                                System.out.println("New Dragon Created!");
                                

                                System.out.println("Incubating " + incubatorName);                                

                                incubator = true;
                                incubatorDay = 0;
                                incubatorElemen = dominan.Elemen;
                            }
                            done = true;
                        }
                        else if(confirm.equalsIgnoreCase("n"))
                        {
                            selectedMatch = null;
                        }
                    }
                }
            }
            


        }while(pil!=0);
    }
     
    




    private String centerAlign(String text, int width) {
    int padding = (width - text.length()) / 2;
    String pad = " ".repeat(Math.max(0, padding));
    return pad + text + pad + (text.length() % 2 == 0 ? "" : " ");
}

}
