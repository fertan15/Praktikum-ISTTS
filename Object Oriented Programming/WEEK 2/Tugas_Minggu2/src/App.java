import java.util.ArrayList;
import java.util.Random;
import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        Random random = new Random();
        Scanner scanInt = new Scanner(System.in);
        Scanner scanString = new Scanner(System.in);
        String name;
        int gold = 200;
        boolean isNameValid = true;
        boolean guaranteeDragon = false;
        boolean strengthPotion = false;
        boolean luckyCharm = false;
        //objek karakter playable 
        Player user = new Player(); // user
        Player flint = new Player(); //Flint
        Player maddy = new Player(); // maddy
        Monster musuh = new Monster();
        
        //===================== input name
        do{
            isNameValid = true;
            System.out.println("==== Simple RPG ====");
            System.out.print("Enter Your Name : ");
            name = scanString.nextLine();

            //=================cek validitas nama
            if(name.length() < 5 || name.equalsIgnoreCase("flint") || name.equalsIgnoreCase("maddy"))
                {
                    System.out.println("Invalid name");
                    isNameValid = false;
                }

            }while(!isNameValid);
        System.out.println();

        //======setInfo playable karakter utama
        user.setInfo(name, 120, 20);
     
        //=======================main menu
        int menu;
        do{

            if(user.hp > 0)
            user.isAlive = true;
            if(flint.hp > 0)
                flint.isAlive = true;
            if(maddy.hp > 0)
                maddy.isAlive = true;
            if(user.hp <= 0)
                user.isAlive = false;
            if(flint.hp <= 0)
            flint.isAlive = false;
            if(maddy.hp <= 0)
            maddy.isAlive = false;
            

            boolean partyIsAlive = true;
            boolean isEnemyCharacter = false;
            
            System.out.println("==== Your Party ====");
            System.out.println(user);
            if(flint.isAcquired)
                System.out.println(flint); //kalo ada flint print ini
            if(maddy.isAcquired)
                System.out.println(maddy); //kalo ada maddy
            
            System.out.println("====================");
            System.out.println("Gold: " + gold + "G");
            System.out.println("====================");
            System.out.println("1. Battle");
            System.out.println("2. Shop");
            System.out.println("3. Check Stats");
            System.out.println("4. Exit");
            System.out.print(">> ");
            menu = scanInt.nextInt();
            System.out.println();

            switch (menu) {
                case 1: //battle
                    //kalo semua karakter HP = 0 
                    if(user.hp == 0 && flint.hp == 0 && maddy.hp == 0)
                    {
                        System.out.println("Your Party are wounded");
                        break;
                    }

                    //Random musuh adalah karakter atau monster 
                    //kalo 0 monster, kalo 1 karakter, 2 dragon
                    int EnemyType = 0; //default enemy all
                    if(!maddy.isAcquired || !flint.isAcquired) //kalo semua karakter udah ada
                        EnemyType = random.nextInt(2);
                    if(guaranteeDragon) //kalo guarantee dragon
                        EnemyType = 2;

                    //===================== case 

                    switch (EnemyType) {
                        case 0: //kalo musuh monster

                            //random lagi dia itu minotaur atau goblin
                            int typeMonster = random.nextInt(2);
                            //kalo 0 -> Goblin, 1 -> minotaur

                            switch (typeMonster) {
                                case 0:
                                    musuh.setInfo("Goblin", 40, 10);
                                    break;
                                case 1:
                                    musuh.setInfo("Minotaur", 90, 20);
                                    break;
                            }
                            break;

                        case 1: //kalo musuh karakter
                            isEnemyCharacter = true;
                            
                            //cek sapa yang udah ada
                            //kalo udah ada flint
                            if(flint.isAcquired)
                                musuh.setInfo("Flint", 80, 30);
                            else if(maddy.isAcquired) //kalo ada maddy
                                musuh.setInfo("Maddy", 60, 40);
                            else{ //kalo gaada 22nya
                                int whichCharacter = random.nextInt(2);
                                if(whichCharacter == 0)
                                    musuh.setInfo("Flint", 80, 30);
                                else    
                                    musuh.setInfo("Maddy", 60, 40);
                            }
                            break;

                        case 2: //kalo musuh dragon
                            musuh.setInfo("Dragon", 200, 30);
                            break;
                    
                    }
                    
                    //======cek efek lucky charm
                    if(luckyCharm && (EnemyType == 0 || EnemyType == 2))
                    {
                        int prize = musuh.max_hp - musuh.atk;
                        System.out.println("You used the Lucky Charm! You win the battle. Gained " + prize + " Gold");
                        gold += prize;
                        luckyCharm = false;
                    }
                    else{
                        //masuk ke battle nya
                        boolean battleEnd = false;
                        ArrayList<String> PlayerName = new ArrayList<>();
                        ArrayList<Integer> PlayerHP = new ArrayList<>();
                        ArrayList<Integer> PlayerMaxHP = new ArrayList<>();
                        ArrayList<Integer> PlayerAttack = new ArrayList<>();
                        ArrayList<Boolean> guard = new ArrayList<>();
                        ArrayList<Boolean> alive = new ArrayList<>();
                        int turn = 0;
    
                        if(user.isAcquired) 
                        {
                            guard.add(false);
                            alive.add(user.isAlive);
                            PlayerName.add(user.nama);
                            PlayerHP.add(user.hp);
                            PlayerMaxHP.add(user.max_hp);
                            PlayerAttack.add(user.atk);
                            
                            if(strengthPotion)
                            {
                                PlayerAttack.set(turn, (int) (PlayerAttack.get(0) * 1.5));
                            }
                            turn++;
                        }
                        if(flint.isAcquired)
                        {
                            guard.add(false);
                            alive.add(flint.isAlive);
                            PlayerName.add(flint.nama);
                            PlayerHP.add(flint.hp);
                            PlayerMaxHP.add(flint.max_hp);
                            PlayerAttack.add(flint.atk);
                            if(strengthPotion)
                            {
                                PlayerAttack.set(turn, (int)(PlayerAttack.get(1) * 1.5));
                            }
                            turn++;
                        }
    
                        if(maddy.isAcquired)
                        {
                            guard.add(false);
                            alive.add(maddy.isAlive);
                            PlayerName.add(maddy.nama);
                            PlayerHP.add(maddy.hp);
                            PlayerMaxHP.add(maddy.max_hp);
                            PlayerAttack.add(maddy.atk);
                            if(strengthPotion)
                            {
                                PlayerAttack.set(turn, (int)(PlayerAttack.get(2) * 1.5));
                            }
                            turn++;
                        }
                                
                        boolean acquiredCharacterMaddy = false;
                        boolean acquiredCharacterFlint = false;
                        String action;
                        do {
                            
                            for(int i = 0; i < Player.jumPlayer ; i++){
    
                                //kalo player udh mati skip turn
                                if(alive.get(i) == false)
                                    continue;
    
                                guard.set(i, false);
                                System.out.println("===== Battle =====");
                                System.out.println(musuh);
                                System.out.println("-- vs");
                                for(int j=0;j<Player.jumPlayer;j++)
                                {
                                    System.out.println(PlayerName.get(j) + " [HP:" + PlayerHP.get(j) + "/" + PlayerMaxHP.get(j) + "]");
                                }
    
                                System.out.println("==================");
                                System.out.println("Current turn: " + PlayerName.get(i));
                                System.out.println("<a> attack");
                                System.out.println("<g> guard");
                                System.out.println("<r> run");
                                System.out.print(">> ");
                                action = scanString.nextLine();
    
                                if(action.equalsIgnoreCase("a"))
                                {
                                    System.out.println(PlayerName.get(i) + " attacks " + musuh.nama);
                                    musuh.damage(PlayerAttack.get(i));
                                }
                                else if(action.equalsIgnoreCase("g"))
                                {
                                    System.out.println(PlayerName.get(i) + " guards");
                                    guard.set(i, true);
                                }
                                else if(action.equalsIgnoreCase("r"))
                                {
                                    System.out.println("You ran away!");
                                    
                                    //kalo kalah atau run dari dragon guarantee dragon next battle
                                    if(EnemyType == 2)
                                        guaranteeDragon = true;
                                    
                                    battleEnd = true;   
                                    break;
    
                                }
                                else{
                                    System.out.println(PlayerName.get(i) + " is hesitating");
                                }
    
                                if(musuh.hp == 0){
                                    guaranteeDragon = false;
                                    int prize = musuh.max_hp - musuh.atk;
                                    System.out.println("You defeated " + musuh.nama);                            
                                    System.out.println("Gained " + prize + " Gold"); 
                                    gold += prize;    
                                    battleEnd = true;      
                                    
                                    //kalo menang lawan karakter next battle dragon
                                    if(isEnemyCharacter){
                                        guaranteeDragon = true;
                                        
    
                                        if(musuh.nama.equalsIgnoreCase("Flint"))
                                        {
                                            flint.setInfo("Flint", 80, 30);
                                            System.out.println("Flint has joined your party!");
                                            acquiredCharacterFlint = true;
                                        }
                                        else if(musuh.nama.equalsIgnoreCase("Maddy"))
                                        {
                                            maddy.setInfo("Maddy", 60, 40);
                                            System.out.println("Maddy has joined your party!");
                                            acquiredCharacterMaddy = true;
                                        }
    
                                    }
                                    break;
                                }  
                                
                            }
    
                            //turn musuh
                            if(musuh.hp > 0 && !battleEnd)
                            {
                                // Mencari karakter dengan HP terendah yang masih hidup
                                int lowestHP = Integer.MAX_VALUE;
                                ArrayList<Integer> lowestHPCharacters = new ArrayList<>();
    
                                // Cari nilai HP terendah di antara karakter yang masih hidup
                                for (int i = 0; i < Player.jumPlayer; i++) {
                                    if (alive.get(i) && PlayerHP.get(i) < lowestHP) {
                                        lowestHP = PlayerHP.get(i);
                                    }
                                }
    
                                // Cari indeks dari semua karakter yang memiliki HP terendah
                                for (int i = 0; i < Player.jumPlayer; i++) {
                                    if (alive.get(i) && PlayerHP.get(i) == lowestHP) {
                                        lowestHPCharacters.add(i);
                                    }
                                }
                                
    
                                int targetIndex = -1;
                                if (lowestHPCharacters.size() > 0) {
                                    targetIndex = lowestHPCharacters.get(0);
                                    
                                    if (lowestHPCharacters.size() > 1) {
                                        for (int i : lowestHPCharacters) {
                                            if (PlayerName.get(i).equals(user.nama)) {
                                                targetIndex = i;
                                                break;
                                            }
                                        }
                                        
                                        if (!PlayerName.get(targetIndex).equals(user.nama)) {
                                            for (int i : lowestHPCharacters) {
                                                if (PlayerName.get(i).equals("Flint")) {
                                                    targetIndex = i;
                                                    break;
                                                }
                                            }
                                        }
                                        
                                    }
                                }
                                
                                if (targetIndex != -1) {
                                    System.out.println(musuh.nama + " attacks " + PlayerName.get(targetIndex));
                                    
                                    if(guard.get(targetIndex))
                                        System.out.println(PlayerName.get(targetIndex) + " blocks the attack");
                                    else
                                        PlayerHP.set(targetIndex, PlayerHP.get(targetIndex) - musuh.atk);
                                    
                                    //cek kalo HP < 0 jadi 0
                                    if(PlayerHP.get(targetIndex) < 0)
                                        PlayerHP.set(targetIndex, 0);
                                    
                                    if(PlayerHP.get(targetIndex) <= 0 && alive.get(targetIndex))
                                    {
                                        PlayerHP.set(targetIndex, 0);
                                        System.out.println(PlayerName.get(targetIndex) + " has fallen.");
                                        alive.set(targetIndex, false);
                                    }
                                    
                                    // cek party masih hidup atau tidak
                                    partyIsAlive = false;
                                    for(int i=0;i<Player.jumPlayer;i++)
                                    {
                                        if(alive.get(i))
                                            {
                                                partyIsAlive = true;
                                                break;
                                            }
                                    }
                                    if(!partyIsAlive)
                                    {
                                        System.out.println("Your party is defeated by " + musuh.nama + ".");
                                        battleEnd = true;
                                    }
                                }
                            }
                            
                        } while(!battleEnd);
    
                        int in = 0; // Start from 0 to include all characters
                        //update hp karakter
                        if(user.isAcquired)
                        {
                            user.hp = PlayerHP.get(in);
                            user.isAlive = alive.get(in);
                            in++;
                        }
                        if(flint.isAcquired && !acquiredCharacterFlint)
                        {
                            flint.hp = PlayerHP.get(in);
                            flint.isAlive = alive.get(in);
                            in++;
                        }
                        if(maddy.isAcquired && !acquiredCharacterMaddy)
                        {
                            maddy.hp = PlayerHP.get(in);
                            maddy.isAlive = alive.get(in);
                        }   
                        System.out.println();  
                        
                        //biar kalo ada strength potion dan lucky charm, lucky charm kepake strengh potion ga ilang
                        if(strengthPotion)
                            strengthPotion = false;
                    }

                    break; // end of battle
                case 2: //shop

                    int shopMenu;
                    do {
                        System.out.println("==== Shop ====");
                        System.out.println("1. Healing Potion - 50G");
                        System.out.println("2. Strength Potion - 100G");
                        System.out.println("3. Lucky Charm - 200G");
                        System.out.println("4. Exit");
                        System.out.print(">> ");
                        shopMenu = scanInt.nextInt();

                        switch (shopMenu) {
                            case 1:
                                if(gold < 50)
                                {
                                    System.out.println("Not enough gold");
                                    break;
                                }
                                gold -= 50;
                                int index;
                                int i = 1;
                                System.out.println("You bought Healing Potion.");
                                System.out.println("Choose a character to heal: ");
                                System.out.println(i + ". " + user.nama + " [HP:" + user.hp + "/" + user.max_hp + "]");
                                i++;
                                if(flint.isAcquired){
                                    System.out.println(i + ". " + flint.nama + " [HP:" + flint.hp + "/" + flint.max_hp + "]");
                                    i++;
                                }
                                if(maddy.isAcquired)
                                {
                                    System.out.println(i + ". " + maddy.nama + " [HP:" + maddy.hp + "/" + maddy.max_hp + "]");
                                    i++;
                                }
                                
                                do{
                                    System.out.print(">> ");
                                    index = scanInt.nextInt();
                                }while(index < 0 || index >= i);
                                
                                if(index == 1)
                                {
                                    user.hp = user.max_hp;
                                }
                                else if(index == 2)
                                {
                                    if(!flint.isAcquired)
                                        maddy.hp = maddy.max_hp;
                                    else
                                        flint.hp = flint.max_hp;
                                }
                                else if(index == 3)
                                {
                                    maddy.hp = maddy.max_hp;
                                }

                                System.out.println("Healed!");
                                
                                break;
                            case 2:
                                if(gold < 100)
                                {
                                    System.out.println("Not enough gold");
                                    break;
                                }
                                gold -= 100;
                                System.out.println("You bought Strength Potion.");
                                strengthPotion = true;
                                break;
                            case 3:
                                if(gold < 200)
                                {
                                    System.out.println("Not enough gold");
                                    break;
                                }
                                gold -= 200;
                                System.out.println("You bought Lucky Charm.");
                                luckyCharm = true;
                                break;
    
                            default:
                                break;
                        }
                        System.out.println();
                    } while (shopMenu != 4);
                    
                    break; //end of shop
                case 3: // stats
                    System.out.println("==== Stats ====");
                    System.out.println(user.nama);
                    System.out.println("[HP: " + user.hp + "/" + user.max_hp + "]");
                    if(strengthPotion)
                        System.out.println("[Atk: " + (int)(user.atk*1.5) + " (Strength Potion: Active)]");
                    else
                        System.out.println("[Atk: " + user.atk + "]");
                    if(flint.isAcquired)
                        {
                            System.out.println(flint.nama);
                            System.out.println("[HP: " + flint.hp + "/" + flint.max_hp + "]");
                            if(strengthPotion)
                                System.out.println("[Atk: " + (int)( flint.atk*1.5) + " (Strength Potion: Active)]");
                            else
                                System.out.println("[Atk: " + flint.atk + "]");
                        }
                    if(maddy.isAcquired)
                    {
                        System.out.println(maddy.nama);
                        System.out.println("[HP: " + maddy.hp + "/" + maddy.max_hp + "]");
                        if(strengthPotion)
                            System.out.println("[Atk: " + (int) (maddy.atk*1.5) + " (Strength Potion: Active)]");
                        else
                            System.out.println("[Atk: " + maddy.atk + "]");

                    }
                    System.out.println("==================");
                    break; //end of stats
                    
                //cheat code
                case 888:
                    gold += 300;
                    System.out.println("Code 888 has been used , 300 gold has been added!");
                    break;
                case 111:
                    user.hp = user.max_hp;
                    flint.hp = flint.max_hp;
                    maddy.hp = maddy.max_hp;
                    System.out.println("Code 111 has been used , all party member health is full!");
                    break;
                case 333:
                    user.hp = 20;
                    flint.hp = 20;
                    maddy.hp = 20;
                    System.out.println("Code 333 has been used , all party member health is 20!");
                    break;
                case 444:
                    if(!flint.isAcquired)
                        flint.setInfo("Flint", 80, 30);
                    if(!maddy.isAcquired)
                        maddy.setInfo("Maddy", 60, 40);

                    guaranteeDragon = true;
                    System.out.println("Code 444 has been used , Unlocking all the character and your next battle is guarantee as a dragon!");
                    break;
                    
                    default:
                        break;
            }
            System.out.println();
        }while(menu!=4);

        scanInt.close();
        scanString.close();
    }
}
