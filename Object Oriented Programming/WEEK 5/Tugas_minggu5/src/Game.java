import java.util.Random;
import java.util.Scanner;

public class Game {
    Random random = new Random();
    Scanner scanString = new Scanner(System.in);
    Scanner scanInt = new Scanner(System.in);
    Character pyroManiac = new PyroManiac();
    Character atlanticSiren = new AtlanticSiren();
    Character stoneGolem = new StoneGolem();
    Character holyPaladin = new HolyPaladin();
    Character grimReaper  = new GrimReaper();

    Character[] characterslist = {pyroManiac, atlanticSiren, stoneGolem, holyPaladin, grimReaper};
    
    Player player1 = new Player("Player 1");
    Player player2 = new Player("Player 2");

    Player[] players = {player1, player2}; 
    

    public Game(){
    
        
        int chooseCard = 0;
       while(chooseCard < 2)
       {
            System.out.println("Choose 3 Cards for Player " + (chooseCard+1) + ": ");
            System.out.println("1. Pyro Maniac - Fire");
            System.out.println("2. Atlantic Siren - Water");
            System.out.println("3. Stone Golem - Flora");
            System.out.println("4. Holy Paladin - Light");
            System.out.println("5. Grim Reaper - Dark");
            System.out.print(">> ");
            String choice = scanString.nextLine();
            //pisah koma
            String[] choices = choice.split(",");
            //ganti jadi int
            int[] cardChoices = new int[choices.length];
            for(int i = 0; i < choices.length; i++){
                    cardChoices[i] = Integer.parseInt(choices[i].trim());
            }

            if(choices.length != 3) {
                System.out.println("You must choose 3 cards. No more, no less.");
                continue;
            }
            else if(cardChoices[0] == cardChoices[1] || cardChoices[0] == cardChoices[2] || cardChoices[1] == cardChoices[2]) {
                System.out.println("There are duplicate card choices.");
                continue;
            }
            else if(cardChoices[0] < 1 || cardChoices[0] > 5 || cardChoices[1] < 1 || cardChoices[1] > 5 || cardChoices[2] < 1 || cardChoices[2] > 5) {
                System.out.println("Invalid card choice(s). Please choose card numbers between 1 and 5.");
                continue;
            }
            else
            {
                
                players[chooseCard].cards.add(characterslist[cardChoices[0]-1].copy());
                players[chooseCard].cards.add(characterslist[cardChoices[1]-1].copy());
                players[chooseCard].cards.add(characterslist[cardChoices[2]-1].copy());

                do{
                    System.out.println("Player " + (chooseCard+1) + " Choose your active card: ");
                    for(int i = 0; i < players[chooseCard].cards.size(); i++){
                        System.out.println((i+1) + ". " + players[chooseCard].cards.get(i).name);
                    }
                    System.out.print(">> ");
                    int activeCard = scanInt.nextInt();
                    if(activeCard < 1 || activeCard > players[chooseCard].cards.size()){
                        System.out.println("Invalid choice. Please choose a valid card number.");
                        continue;
                    }
                    else
                    {
                        players[chooseCard].setActiveCard(activeCard-1);
                        break;
                    }
                }while(true);
                chooseCard++;
            }


       }

       System.out.println();
       gameStart();
    }

    void gameStart()
    {
        int round=1;
        boolean endGame = false;

        while(!endGame){
            boolean endRound = false;
            int turn = 0;
            player1.randomDice();
            player2.randomDice();
            Boolean alreadyEndTurned = false;
            Boolean bothEndTurned = false;
            int firstEndTurned = 1;
            boolean kenakContinue = false;
            while(!endRound)
            {
                
                if(!kenakContinue)
                {
                    
                    Player currentPlayer = players[turn%2];
                    Player musuh = players[(turn+1)%2];
                    System.out.println("====================");
                                System.out.printf("%11s %d","Round", round);
                                System.out.println("\n====================");
                                System.out.println("Player 2");
                                System.out.println("Active Card: " + player2.activeCard.name);
                                player2.printAllCard();
                                System.out.println();
                                player1.printAllCard();
                                System.out.println("Player 1");
                                System.out.println("Active Card: " + player1.activeCard.name);
                                System.out.println("====================");
                                System.out.println("Turn: " + currentPlayer.name);
                                currentPlayer.printDice();
                                System.out.println("====================");
                                System.out.println("[1] Switch  [2] Attack");
                                System.out.println("[3] Skill   [4] End Turn");
                                System.out.print(">> ");
                                int action = scanInt.nextInt();
    
                                switch (action) {
                                    case 1:
                                        boolean switchSuccess = false;
                                        while(!switchSuccess)
                                        {
                                            System.out.println("Choose a new active card:");
                                            for(int i = 0; i < currentPlayer.cards.size(); i++){
                                                System.out.print((i+1) + ". " + currentPlayer.cards.get(i).name);

                                                if(currentPlayer.cards.get(i).equals(currentPlayer.activeCard))
                                                    System.out.print(" <active>");

                                                System.out.println();
                                            }
                                            System.out.print(">> "); int newActiveCard = scanInt.nextInt();
                                            if(currentPlayer.activeCardindex == newActiveCard-1){
                                                System.out.println("This is the current active card. Choose again");
                                            }                                    
                                            else if(newActiveCard < 1 || newActiveCard > currentPlayer.cards.size()){
                                                System.out.println("Invalid choice. Please choose a valid card number.");
                                            }
                                            else if(currentPlayer.cards.get(newActiveCard-1).hp<=0)
                                                System.out.println("Cards Cannot be used, HP = 0");
                                            else
                                            {
                                                if(currentPlayer.countDice() >= 1)
                                                {
                                                    currentPlayer.setActiveCard(newActiveCard-1);
                                                    switchSuccess = true;
                                                    currentPlayer.diceConsumed(1);   
                                                }
                                                else{
                                                    System.out.println("You don't have enough dice to switch cards.");
                                                    kenakContinue = true;
                                                    continue;
                                                }
                                            }
                                        }
    
                                        break;
                                    case 2:
                                        if(currentPlayer.activeCardDiceIndex() == -1)
                                            {
                                                System.out.println("You don't have any dice matching the active card's element (" + currentPlayer.activeCard.elemen + ").");
                                                kenakContinue = true;
                                                continue;
                                            }
                                        else{
                                            if(currentPlayer.countDice() < 3)
                                            {
                                                System.out.println("Your dice is not enough!");
                                                kenakContinue = true;
                                                continue;
                                            }
                                            else{
                                                currentPlayer.diceAmount.set(currentPlayer.activeCardDiceIndex(),currentPlayer.diceAmount.get(currentPlayer.activeCardDiceIndex())-1);
                                                System.out.println("Choose 2 dice with any element:");
                                                currentPlayer.diceConsumed(2);
                                                musuh.activeCard.hp -=2; //active card musuh -2
                                                System.out.println(currentPlayer.name + " attacked 2 damage to " + musuh.name);
                                                currentPlayer.activeCard.skillPoint+=1; //active card player +1 skill point
                                                System.out.println(currentPlayer.name + " get 1 skillPoint");
                                            }
                                        }
                                        break;
                                    case 3:
                                        if(currentPlayer.diceAmount.get(currentPlayer.activeCardDiceIndex()) < 2 )
                                        {
                                            System.out.println("You don't have enough dice matching the active card's element (" + currentPlayer.activeCard.elemen + ").");
                                            kenakContinue = true;
                                            continue;
                                        }
                                        else
                                        {
                                            currentPlayer.diceAmount.set(currentPlayer.activeCardDiceIndex(), currentPlayer.diceAmount.get(currentPlayer.activeCardDiceIndex())-2);
                                            System.out.println("Dice " + currentPlayer.dice.get(currentPlayer.activeCardDiceIndex()) + " consumed 2 to use skill");
                                            if(currentPlayer.activeCard.requiredSkillPoint > currentPlayer.activeCard.skillPoint){
                                                System.out.println("Not enough Skill points to use the skill.");
                                                kenakContinue = true;
                                                continue;
                                            }
                                            else{
                                                currentPlayer.activeCard.skill(currentPlayer,musuh);   
                                            }
                                        }
                                        break;
                                    case 4:
                                        System.out.println(currentPlayer.name + " Ended its turn...");
                                        if(alreadyEndTurned)
                                        {
                                            endRound = true;
                                            bothEndTurned = true;
                                            System.out.println("Both Player Already ended their turn, moving to next round...");
                                            if(firstEndTurned==1)
                                            {
                                                changeTurn();
                                            }
            
                                        }
                                        else if(!alreadyEndTurned){
                                            alreadyEndTurned = true;
                                            firstEndTurned = turn%2;
                                            turn++;
                                        }
                                        
                                        continue;
                                    case 22:
                                        currentPlayer.activeCard.skillPoint+=5;
                                        System.out.println("Current Active Card +5 SkillPoint");
                                        kenakContinue = true;
                                        continue;
    
                                    case 11:
                                        boolean done = false;    
                                        while(!done){
                                            int randomCard = random.nextInt(0,3);
                                            if(currentPlayer.cards.get(randomCard).hp>0)
                                            {
                                                currentPlayer.cards.get(randomCard).hp = 0;
                                                System.out.println(currentPlayer.cards.get(randomCard).name + " HP = 0");
                                                done = true;
                                            }
    
                                        }
                                        kenakContinue = true;
    
                                        continue;
                                    case 99:
                                        endGame = true;
                                        endRound = true;
                                        System.out.println("Mengakhiri permaianan, kembali ke mennu utama...");
                                        break;
                                        
                                }
                    }

                    
                    
                    
                    
                    if(!player1.isAlive() || !player2.isAlive())
                            {
                                if(!player1.isAlive())
                                {
                                    System.out.println("Player 1 has died, game over...");
                                }
                                else if(!player2.isAlive())
                                {
                                    System.out.println("Player 2 has died, game over...");
                                }

                                endGame = true;
                                endRound = true;
                            }
                            
                            

                            if(!kenakContinue&&alreadyEndTurned)
                            turn+=2;
                            else if (!kenakContinue&&!alreadyEndTurned) 
                            turn++;
                            
                            kenakContinue = false;
                            
                        }
            round++;



        }
        
        
    }


    void changeTurn(){
        Player temp = players[0];
        this.players[0] = this.players[1];
        this.players[1] = temp;
    }
}
