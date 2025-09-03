import java.util.Scanner;

public class Game {
    static Scanner scanInt = new Scanner(System.in);
    static Scanner scanStr = new Scanner(System.in);

    static Building WillowCreek = new Building("Willow Creek");
    static Building OasisSprings = new Building("Oasis Springs");
    static Building Newcrest = new Building("Newcrest");
    static Building[] neighborhood = {WillowCreek, OasisSprings, Newcrest};



    static void start() {
        int menu = 0;

        while(menu!=3){

            System.out.print("+================ SIMS ================+ \r\n" + //
                            "|        NEIGHBORHOOD HOUSEHOLDS       | \r\n" + //
                            "+--------------------------------------+ \r\n" + //
                            "| 1. Willow Creek - Residents: "+WillowCreek.getResidents()+"       | \r\n" + //
                            "| 2. Oasis Springs - Residents: "+OasisSprings.getResidents()+"      | \r\n" + //
                            "| 3. Newcrest - Residents: "+Newcrest.getResidents()+"           | \r\n" + //
                            "+======================================+ \r\n" + //
                            "| 1. Create a Sim                      | \r\n" + //
                            "| 2. Manage a Household                | \r\n" + //
                            "| 3. Exit Game                         | \r\n" + //
                            "+======================================+ \r\n" + //
                            ">> ");
            menu = scanInt.nextInt();
            System.out.println();
                if(menu == 1){
                    System.out.print("+=================+ \r\n" + //
                                        "Select a household: \r\n" + //
                                        "1. Willow Creek \r\n" + //
                                        "2. Oasis Springs \r\n" + //
                                        "3. Newcrest \r\n" + //
                                        "+=================+ \r\n" + //
                                        ">> ");
                    int household = scanInt.nextInt()-1;
                    System.out.println();
                    System.out.print("+===================+ \r\n" + //
                                    "Choose a Sim to play: \r\n" + //
                                    "1. Human Sim \r\n" + //
                                    "2. Vampire Sim \r\n" + //
                                    "3. Alien Sim \r\n" + //
                                    "+===================+ \r\n" + //
                                    ">> ");
                    int simType = scanInt.nextInt();

                    switch (simType) {
                        case 1:
                            neighborhood[household].sim.add(new HumanSim());
                            break;
                        case 2:
                            neighborhood[household].sim.add(new VampireSim());
                            break;
                        case 3:
                            neighborhood[household].sim.add(new AlienSim());
                            break;
                    }

                }
                else if(menu == 2){
                    System.out.print("+=================+ \r\n" + //
                    "Select a household: \r\n" + //
                    "1. Willow Creek \r\n" + //
                    "2. Oasis Springs \r\n" + //
                    "3. Newcrest \r\n" + //
                    "+=================+ \r\n" + //
                    ">> ");
                    int household = scanInt.nextInt()-1;
                    System.out.println();

                    neighborhood[household].manageHousehold();



                }

                System.out.println();

        }

    }
}
