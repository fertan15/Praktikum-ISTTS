import java.lang.management.PlatformLoggingMXBean;
import java.util.Random;
import java.util.Scanner;

public class Game {
    Scanner scanInt = new Scanner(System.in);
    Scanner scanStr = new Scanner(System.in);
    Random random = new Random();

    public Game(){
        //initial tools awal
        Player.tools.add(new WoodenPickaxe());
        Player.tools.add(new WoodenSword());

        menu();

    }

    void menu(){
        int menu;
        do{
            System.out.println("===========================");
            System.out.println("<<       MINECRAFT       >>");
            System.out.println("===========================");
            System.out.println("| Tools:                  |");
            System.out.printf("|  - %-21s|\n", Player.getHighestPickaxe().name);
            System.out.printf("|  - %-21s|\n", Player.getHighestSword().name);
            System.out.println("===========================");
            System.out.println("| 1. Inventory            |");
            System.out.println("| 2. Crafting Table       |");
            System.out.println("| 3. Go Mining            |");
            System.out.println("| 0. Exit                 |");
            System.out.println("===========================");
            System.out.print(">> ");
            menu = scanInt.nextInt();
            System.out.println();

            switch(menu){
                case 1: inventory(); break;
                case 2: craftingTable(); break;
                case 3: mining(); break;
                case 555: 
                    Player.stone +=5;
                    Player.iron +=5;
                    Player.diamond +=5;
                    System.out.println("Stone +5, Iron +5, Diamond +5");
                    break;
                case 222 : 
                    if(Player.getHighestPickaxe().level == 0)
                        {
                            Player.tools.add(new StonePickaxe());
                            System.out.println("Upgrade Wooden pickaxe to " + Player.getHighestPickaxe().name + "!");
                        }
                    else if(Player.getHighestPickaxe().level == 1)
                        {
                            Player.tools.add(new IronPickaxe());
                            System.out.println("Upgrade Stone pickaxe to " + Player.getHighestPickaxe().name + "!");
                        }
                        else if(Player.getHighestPickaxe().level == 2)
                        {
                            Player.tools.add(new DiamondPickaxe());
                            System.out.println("Upgrade Iron pickaxe to " + Player.getHighestPickaxe().name + "!");
                        }
                        else if(Player.getHighestPickaxe().level == 3)
                            System.out.println("Pickaxe cannot be upgraded anymore!");


                    if(Player.getHighestSword().level == 0)
                       {
                         Player.tools.add(new StoneSword());
                         System.out.println("Upgrade wooden sword to " + Player.getHighestSword().name + "!");

                        }
                    else if(Player.getHighestSword().level == 1)
                        {
                            Player.tools.add(new IronSword());
                            System.out.println("Upgrade stone sword to " + Player.getHighestSword().name + "!");

                        }
                    else if(Player.getHighestSword().level == 2)
                        {
                            Player.tools.add(new DiamondSword());
                            System.out.println("Upgrade iron sword to " + Player.getHighestSword().name + "!");

                        }
                    else if(Player.getHighestSword().level == 3)
                    System.out.println("Sword cannot be upgraded anymore!");



                    break;

            }

            System.out.println();
        }while(menu!=0);
    }

    void inventory(){
        System.out.println("=====================");
        System.out.println("      INVENTORY      ");
        System.out.println("=====================");
        System.out.println("Materials:       ");
        System.out.println(" - Stone:       x" + Player.stone);
        System.out.println(" - Iron:        x" + Player.iron);
        System.out.println(" - Diamond:     x" + Player.diamond);
        System.out.println("=====================");


    }
    
    void craftingTable(){

        //initial table map kalo mau clear all
        char[][] tableOri = {
            {'-','-','-'},
            {'-','-','-'},
            {'-','-','-'}
        };
        //table yang kepake
        char[][] table = new char[3][3];

        for(int i=0;i<3;i++){
            for(int j=0;j<3;j++){
                table[i][j] = tableOri[i][j];
            }
        }



        int input;
        int StoneTemp = Player.stone;
        int IronTemp = Player.iron;
        int DiamondTemp = Player.diamond;
        int Stick = 100000000;

        int[] jumlahMaterial = {Stick,StoneTemp, IronTemp, DiamondTemp};
        char[] symbolMaterial = {Material.getStickSymbol(),Material.getStoneSymbol(), Material.getIronSymbol(), Material.getDiamondSymbol()};
        String[] namaMaterial = {"Stick","Stone", "Iron", "Diamond"};
        do{
            

            System.out.println("=================");
            System.out.println("|     CRAFT     |");
            System.out.println("=================");
            System.out.println("| +---+---+---+ |");
            System.out.println("| | " + table[0][0] + " | " + table[0][1] + " | " + table[0][2] + " | |");
            System.out.println("| +---+---+---+ |");
            System.out.println("| | " + table[1][0] + " | " + table[1][1] + " | " + table[1][2] + " | |");
            System.out.println("| +---+---+---+ |");
            System.out.println("| | " + table[2][0] + " | " + table[2][1] + " | " + table[2][2] + " | |");
            System.out.println("| +---+---+---+ |");
            System.out.println("=================");
            System.out.println("| 1. Place Item |");
            System.out.println("| 2. Clear Grid |");
            System.out.println("| 0. Exit       |");
            System.out.println("=================");
            System.out.print(">> ");
            input = scanInt.nextInt();

            switch(input){
                case 1: 
                    System.out.println("Select material to place:");
                    System.out.println("1. Stick (s)");
                    System.out.println("2. Stone (S): x"+ jumlahMaterial[1]);
                    System.out.println("3. Iron (I): x"+jumlahMaterial[2]);
                    System.out.println("4. Diamond (D): x"+jumlahMaterial[3]);
                    System.out.print(">> ");
                    int material = scanInt.nextInt();

                    if(jumlahMaterial[material-1] <= 0)
                        System.out.println("You don't have any "+ namaMaterial[material-1] +"!");
                    else{
                        String inputCoordinates;
                        int row; 
                        int column;
                        boolean coordinateIsValid = false;
                        do{
                            System.out.print("Enter coordinates (row,column): ");
                            inputCoordinates = scanStr.nextLine();
                            String[] coordinates = inputCoordinates.split(",");
                            row = Integer.parseInt(coordinates[0]);
                            column = Integer.parseInt(coordinates[1]);
                            
                            if(row < 0 || row > 2 || column < 0 || column > 2)
                                System.out.println("Coordinate not Valid!");
                            else{
                                if(table[row][column] != '-'){
                                    System.out.println("There is already a material in this coordinate, please clear the table if you want to change the material!");
                                }
                                else    
                                {
                                    coordinateIsValid = true;
                                }
                            }
                        } while(!coordinateIsValid);

                        table[row][column] = symbolMaterial[material-1];
                        jumlahMaterial[material-1]--;

                        
                        //// dipake kalo misal naruh material bisa overlap trus ngganti
                        // switch(table[row][column]){
                        //     case '-' : //kalo gada apaapa
                        //         table[row][column] = symbolMaterial[material-1];
                        //         jumlahMaterial[material-1]--;
                        //         break;
                        //     case'S' : //kalo ada stone
                        //         if(material != 2){
                        //             table[row][column] = symbolMaterial[material-1];
                        //             jumlahMaterial[material-1]--;
                        //             jumlahMaterial[1]++;
                        //         }
                        //         break;
                        //     case'I' : //kalo ada iron
                        //         if(material != 3){
                        //             table[row][column] = symbolMaterial[material-1];
                        //             jumlahMaterial[material-1]--;
                        //             jumlahMaterial[2]++;
                        //         }
                        //         break;
                        //     case'D' : //kalo ada diamond
                        //         if(material != 4){
                        //             table[row][column] = symbolMaterial[material-1];
                        //             jumlahMaterial[material-1]--;
                        //             jumlahMaterial[3]++;
                        //         }
                        //     }
                                         
                        }
                        break;

                case 2: // clear grid
                    for(int i=0;i<3;i++){
                        for(int j=0;j<3;j++){
                            table[i][j] = tableOri[i][j];
                        }
                    }
                    jumlahMaterial[1] = Player.stone;
                    jumlahMaterial[2] = Player.iron;
                    jumlahMaterial[3] = Player.diamond;
                    break;           
            }

            Tools[] listTools = {new StonePickaxe(), new IronPickaxe(), new DiamondPickaxe(), new StoneSword(), new IronSword(), new DiamondSword()};
            
            //cek apakah recipe jadi
            for(int i=0;i<listTools.length;i++)
            {
                if(listTools[i].checkRecipe(table))
                {
                    System.out.println(listTools[i].name + " crafted!");  
                    Player.tools.add(listTools[i].copy());
                    input = 0;     
                    Player.stone = jumlahMaterial[1];
                    Player.iron = jumlahMaterial[2];
                    Player.diamond = jumlahMaterial[3];   
                }
            }
                    


        }while(input!=0);
    }

    void mining(){
        //miningmap
        char[][] miningMapOri = new char[7][19]; 
        char[][] miningMap = new char[7][19];
        for(int i=0;i<7;i++)
        {
            for(int j=0;j<19;j++)
            {
                miningMapOri[i][j] = ' ';
                miningMap[i][j] = miningMapOri[i][j];
            }
        }
        
        

        int level = 1;
        boolean gameOver = false;
        String[] namaMine = {"(Stone Mine)", "(Iron Mine)", "(Diamond Mine)"};
        
        while(level <= 3 || !gameOver){
            boolean miningEnd = false;
            
            for(int i=0;i<7;i++)
            {
                for(int j=0;j<19;j++)
                {
                    miningMap[i][j] = miningMapOri[i][j];
                }
            }    
            Player.x  = 9;
            Player.y = 3;
            miningMap[Player.y][Player.x] = Player.symbol;
            Monster[] monster = new Monster[5];
            Material[] material = new Material[5];

            //random monster dulu
            for(int i=0;i<5;i++){
                //random posisi
                int rndX = 0;
                int rndY = 0;
                boolean gas = false;
                while(!gas){
                    rndX = random.nextInt(0,19);
                    rndY = random.nextInt(0,7);

                    if(miningMap[rndY][rndX] == ' ')
                        gas = true;
                }

                if(level == 1)
                {
                    //level 1 -> zombie
                    monster[i] = new Monster("Zombie",'Z', rndX, rndY, 0);   
                }
                if(level == 2)
                {
                    int rndMonster = random.nextInt(0,2);
                    if(rndMonster == 0)
                        monster[i] = new Monster("Zombie",'Z', rndX, rndY, 0);   
                    else if(rndMonster == 1)
                        monster[i] = new Monster("Skeleton",'S', rndX, rndY, 1);   


                }
                if(level == 3)
                {
                    int rndMonster = random.nextInt(0,3);
                    if(rndMonster == 0)
                        monster[i] = new Monster("Zombie",'Z', rndX, rndY, 0);   
                    else if(rndMonster == 1)
                        monster[i] = new Monster("Skeleton",'S', rndX, rndY, 1);   
                    else if(rndMonster == 2)
                        monster[i] = new Monster("Creeper", 'C', rndX, rndY, 2);   
                        
                }
                miningMap[monster[i].y][monster[i].x] = monster[i].symbol;
            }

            //random material
            for(int i=0;i<5;i++){

                //random posisi
                int rndX = 0;
                int rndY = 0;
                boolean gas = false;
                while(!gas){
                    rndX = random.nextInt(0,19);
                    rndY = random.nextInt(0,7);

                    if(miningMap[rndY][rndX] == ' ')
                        gas = true;
                }
                

                if(level == 1)
                {
                    material[i] = new Material("Stone",'@', rndX, rndY, 0);
                }
                if(level == 2)
                {
                    material[i] = new Material("Iron",'+', rndX, rndY, 1);
                }
                if(level == 3)
                {
                    material[i] = new Material("Diamond",'*', rndX, rndY, 2);
                }

                miningMap[material[i].y][material[i].x] = material[i].symbol;

            }
            
            //random portal 
            //random posisi
            int rndX = 0;
            int rndY = 0;
            boolean gas = false;
            while(!gas){
                rndX = random.nextInt(0,19);
                rndY = random.nextInt(0,7);

                if(miningMap[rndY][rndX] == ' ')
                    gas = true;
            }
            int portalX = rndX;
            int portalY = rndY;
            miningMap[portalY][portalX] = 'O';
            

           
            while(!miningEnd){
                System.out.println("=====================");
                System.out.println("|     Go Mining     |");
                System.out.println("=====================");
                for(char x[]: miningMap)
                {
                    System.out.print("|");
                    for(char y : x)
                    {
                        System.out.print(y);
                    }
                    System.out.print("|\n");
                }
                System.out.println("=====================");
                System.out.println("Level: " + level+"/3 " + namaMine[level-1]); 
                System.out.println("(WASD): Move Player");
                System.out.println("(E): Exit Mining");
                System.out.println("=====================");
                System.out.print(">> ");
                String input = scanStr.nextLine();

                //Player Movement
                int nextY = Player.y;
                int nextX = Player.x;

                switch (input) {
                    case "E", "e":
                        return;
                    case "W", "w":
                        nextY--;
                        break;
                    case "A", "a":
                        nextX--;
                        break;
                    case "S", "s":
                        nextY++;
                        break;
                    case "d", "D":
                        nextX++;
                        break;
                }

                for(Monster x : monster)
                    {
                        if(x.isAlive){

                            miningMap[x.y][x.x] = ' ';
                            x.monsterMove(miningMap);
                            miningMap[x.y][x.x] = x.symbol;
                            
                        }

                    }


                if(nextY < 7 && nextY >= 0 && nextX < 19 && nextX >= 0 )
                {
                    if(miningMap[nextY][nextX] == ' ')
                    {
                        miningMap[Player.y][Player.x] = ' ';
                        miningMap[nextY][nextX] = Player.symbol;
                        Player.y = nextY;
                        Player.x = nextX;
                    }
                    else{
                        //kalo encounter monster
                        for(Monster x : monster)
                        {
                            if(nextX == x.x && nextY == x.y)
                            {
                                System.out.println("you encountered a " + x.name + "!");
                                
                                if(x.minimalLevelTools > Player.getHighestSword().level)
                                    {
                                        System.out.println("Your " + Player.getHighestSword().name + " isn't enough to defeat " + x.name + "!");
                                        System.out.println("You escape from the mine!");
                                        miningEnd = true;
                                        gameOver = true;
                                        return;
                                    }
                                else{
                                    System.out.println("You defeated the " + x.name + " usinng your " + Player.getHighestSword().name + "!");
                                    miningMap[Player.y][Player.x] = ' ';
                                    miningMap[nextY][nextX] = Player.symbol;
                                    Player.y = nextY;
                                    Player.x = nextX;
                                    x.isAlive = false;
                                }
                            }
                        }

                        //kalo encounter material
                        for(Material x : material)
                        {
                            if(nextX == x.x && nextY == x.y)
                            {
                                System.out.println("You found some stone!");

                                if(x.minimalLevelTools > Player.getHighestPickaxe().level)
                                {
                                    System.out.println("Your " + Player.getHighestPickaxe().name + " isn't strong enough to mine " + x.name + "!");
                                }
                            else{
                                System.out.println("You mined the " + x.name + " using your " + Player.getHighestPickaxe().name + "!");
                                
                                miningMap[Player.y][Player.x] = ' ';
                                miningMap[nextY][nextX] = Player.symbol;
                                Player.y = nextY;
                                Player.x = nextX;

                                if(level == 1)
                                    Player.stone++;
                                else if(level == 2)
                                    Player.iron++;
                                else if(level == 3)
                                    Player.diamond++;
                                
                            }

                            }
                        }

                        if(nextX == portalX && nextY == portalY && level < 3)
                            {
                                level++;
                                miningEnd = true;
                                System.out.println("You've reached level " + level + "!");
                            }
                        else if(nextX == portalX && nextY == portalY && level == 3)
                        {
                            System.out.println("Congrats You've finished the mining succesfully!");
                            return;
                        }
                    }
                    
                }
              

            }
        }
    }
    
}
