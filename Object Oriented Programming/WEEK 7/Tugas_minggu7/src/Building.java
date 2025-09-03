
import java.util.ArrayList;
import java.util.Random; 

public class Building {
    static Random random = new Random();
    ArrayList<Sim> sim = new ArrayList<>();
    String name;
    int residents=0;
    char[][] map = new char[5][13];

    void randomPosisi(){
        //reset map
        for (int i = 0; i < map.length; i++) {
            for (int j = 0; j < map[i].length; j++) {
                map[i][j] = ' ';
            }
        }        
        //random posisi sim
        for(Sim x : sim)
        {
            boolean placed = false;
            while(!placed){
                int xPos = random.nextInt(5);
                int yPos = random.nextInt(13);
                if(map[xPos][yPos] == ' ')
                {
                    map[xPos][yPos] = x.name.charAt(0);
                    x.x = xPos;
                    x.y = yPos;
                    placed = true;
                }
            }
        }
    }

    Building(String name){
        this.name = name;
    }

    int getResidents(){
        residents = sim.size();
        return residents;
    }
    

    void manageHousehold(){
        int menu = 0;
        do {
            System.out.println("+======================+ \r\n" + //
                                this.name +" \r\n" + //
                                "+======================+ \r\n" + //
                                "Residents: "+this.getResidents());
                                if(this.getResidents() == 0)
                                    System.out.println(" - No residents ");
                                else
                                    cetakAllSimName();
            System.out.println("+======================+ \r\n" + //
                                "| 1. See Sim Details   |\r\n" + //
                                "| 2. View Map          | \n" + //
                                "| 0. Exit              | \r\n" + //
                                "+======================+ \r\n" + //
                                ">>");
            menu = Game.scanInt.nextInt();

            switch (menu) {
                case 1:
                    if(this.getResidents() == 0)
                        System.out.println("No Sims available in this Household");
                    else{
                        System.out.println("Select a Sim to View Details: ");
                        int i = 1;
                        for(Sim x : sim)
                        {
                            System.out.println(i+". "+x.name) ;
                            i++;
                        }
                        System.out.print(">> ");
                        int choose = Game.scanInt.nextInt()-1;
                        System.out.println();
                        sim.get(choose).detail();
                        System.out.println();
                    }
                    break;
            
                case 2:
                if(this.getResidents() == 0)
                    System.out.println("No Sims available in this Household");
                else{
                    System.out.println("Select a Sim to control:");
                    int i = 1;
                    for(Sim x : sim)
                    {
                        System.out.println(i+". "+x.name  ) ;
                        i++;
                    }
                    System.out.print(">> ");
                    int choose = Game.scanInt.nextInt()-1;
                    randomPosisi();
                    viewMap(sim.get(choose));
                }
                    break;
            }


            
        } while (menu != 0);
    }


    void cetakAllSimName(){
        for(Sim x : sim)
        {
            System.out.println(" - "+x.name ) ;
        }
    }


    void viewMap(Sim x){
        String input="";

        do{
            System.out.println("+=============+");
            for(char[] y : map)
            {
                System.out.print("|");
                for(char z : y)
                {
                    System.out.print(z);
                }
                System.out.print("|");
                System.out.println();
            }
            System.out.println("+=============+");
            System.out.println("Moving "+ x.name + "...");
            System.out.print("[WASD] - Move Sim \r\n" + //
                                "[E] - Eat \r\n" + //
                                "[L] - Sleep \r\n" + //
                                "[I] - Learn New Skill \r\n" + //
                                "[X] - Exit View Map \r\n" );
            if(x.type.equalsIgnoreCase("Vampire"))
                System.out.println("[R] - Drink Blood \r\n" );
            System.out.print(">> ");
            input = Game.scanStr.nextLine();


            int nextX = x.x;
            int nextY = x.y;
            switch (input) {
                case "W", "w":
                    nextX--;
                    break;
                case "A", "a":
                    nextY--;
                    break;
                case "S", "s":
                    nextX++;
                    break;
                case "D", "d":
                    nextY++;
                    break;
                case "E", "e":
                    x.eat();
                    continue;
                case "L", "l":
                    x.sleep();
                    continue;
                case "I", "i":  
                    x.learnSkill();
                    continue; 
                // default:
                //     continue;
                }

                if((x instanceof VampireSim) && input.equalsIgnoreCase("R"))
                {
                    ((VampireSim) x).drinkBlood();
                }


                if(nextX >= 0 && nextX < map.length && nextY >= 0 && nextY < map[0].length)
                {
                    if(map[nextX][nextY] == ' ')
                    {
                        map[x.x][x.y] = ' ';
                        x.x = nextX;
                        x.y = nextY;
                        map[x.x][x.y] = x.name.charAt(0);
                    }
                    else
                    {
                        for(Sim y : sim)
                        {
                            if(y.x == nextX && y.y == nextY && !y.equals(x))
                            {
                                x.interact(y);
                            }
                        }
                    }
                }


        }while(!input.equalsIgnoreCase("x"));

    }
}