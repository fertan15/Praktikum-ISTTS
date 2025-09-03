import java.util.ArrayList;
import java.util.Random;
import java.util.Scanner;

public class Player {
    Scanner scan = new Scanner(System.in);
    String name;
    String[] diceName= {"Fire", "Water", "Flora", "Light", "Dark"};
    ArrayList<Character> cards = new ArrayList<>();
    int activeCardindex = 0;
    Character activeCard ;
    ArrayList<String> dice = new ArrayList<>();
    ArrayList<Integer> diceAmount = new ArrayList<>();
    int maxDiceAmount = 10;
    Random random = new Random();

    

    public Player(String name) {
        this.name = name;
    }

    void setActiveCard(int index) {
            this.activeCardindex = index;
            this.activeCard = cards.get(activeCardindex);
        }

        public void printAllCard() {
            System.out.println("+----+ +----+ +----+");
            for (int i = 0; i < cards.size(); i++) {
                System.out.printf("| %-2d | ", cards.get(i).hp);
            }
            System.out.println();
            for (int i = 0; i < cards.size(); i++) {
                System.out.printf("| %s | ", cards.get(i).initial);
            }
            System.out.println();
            for (int i = 0; i < cards.size(); i++) {
                System.out.printf("| %-2d | ", cards.get(i).skillPoint);
            }
            System.out.println();
            System.out.println("+----+ +----+ +----+");
        }

    
        void randomDice(){
            dice.clear();
            diceAmount.clear();
            int[] amount = new int[5];
            int amountLeft = maxDiceAmount-4;

            //fix 4 buat dice elemen active card
            for(int i = 0;i<5;i++)
            {
                if(activeCard.elemen.equalsIgnoreCase(diceName[i]))
                {
                    amount[i] = 4;
                }
            }

            while(amountLeft>0)
            {
                int randomIndex = random.nextInt(0,5);
                int randomAmount = random.nextInt(1,amountLeft+1);        
                amount[randomIndex] += randomAmount;
                amountLeft -= randomAmount;
            }

            for(int i =0;i<5;i++)
            {
                if(amount[i]>0)
                {
                    dice.add(diceName[i]);
                    diceAmount.add(amount[i]);
                }
            }
        }

        
        int countDice(){
            int sum = 0;
            for(int x: diceAmount)
            {
                sum+=x;
            }
            return sum;
        }
    
        void printDice(){
            System.out.println("Dice Left: " + countDice());
            for(int i = 0; i<dice.size();i++)
            {
                System.out.println("- " + diceAmount.get(i)+ " " + dice.get(i));
            }
        }
    
        void checkDice() {
            for (int i = diceAmount.size() - 1; i >= 0; i--) {
                if (diceAmount.get(i) <= 0) {
                    dice.remove(i);
                    diceAmount.remove(i);
                }
            }
        }

        void diceConsumed(int x){
            if(x == 0)
                return;
            else{
                for(int i = 0; i<dice.size();i++)
                {
                    System.out.printf("[%d] %s (%d)\n", i+1, dice.get(i), diceAmount.get(i));
                }
                System.out.print(">> ");
                int chooseDice = scan.nextInt()-1;
    
                if(chooseDice<0 || chooseDice>=dice.size())
                {
                    System.out.println("Invalid Input!");
                    diceConsumed(x);
                }
                else
                {
                    diceAmount.set(chooseDice, diceAmount.get(chooseDice)-1);
                }
    
                checkDice();
                diceConsumed(x-1);

            }
        }

        public int activeCardDiceIndex(){
            for(int i = 0;i<dice.size();i++)
            {
                if(dice.get(i).equalsIgnoreCase(activeCard.elemen))
                    return i;
            }

            return -1;
        }


        boolean isAlive(){
            for(Character x : cards)
            {
                if(x.hp > 0)
                    return true;
            }
            return false;
        }

            
}

