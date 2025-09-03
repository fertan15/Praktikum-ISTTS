
import java.util.ArrayList;
import java.util.Scanner;

public abstract class Sim implements SimAction {
    int x,y;
    ArrayList<Friend> friend = new ArrayList<>();
    ArrayList<Skill> skills = new ArrayList<>();
    Scanner scan = new Scanner(System.in);
    Scanner scanInt = new Scanner(System.in);
    String name;
    String type;
    int hunger;
    int energy;
    String mood;
    public abstract void interact1(Sim sim);
    Sim(String type) {
        System.out.print("Enter the name of your "+ type +" Sim: ");
        this.name = scan.nextLine();
        System.out.println(this.name + " joined the neighnorhood");
        System.out.println(this.name + " feels fine.");

        this.mood = "Fine";
        this.hunger = 50;
        this.energy = 50;
    }

    @Override
    public void interact(Sim sim){
        
    }
    @Override
    public void eat(){
        
    }
    @Override
    public void sleep(){

    }


    public void detail(){
        
        System.out.println(">> \r\n" + //
                        "+======================+ \r\n" + //
                        "Name: "+this.name+" \r\n" + //
                        "Type: "+this.type+" \r\n" + //
                        "+----------------------+ \r\n" + //
                        "Energy: "+this.energy+" \r\n" + //
                        "Hunger: "+this.hunger+" \r\n" + //
                        "Mood: "+this.mood+" \r\n" + //
                        "+----------------------+ \r\n" + //
                        "Skills: " );
        if(skills.size() > 0){
            for(Skill x : skills)
            {
                System.out.println(x.name + " (" + x.level + "/10)");
            }}
        else 
            System.out.println("No skills yet.");
                       
        System.out.println(
                        "+----------------------+ \r\n" + //
                        "Friends: " );
                        if(friend.size() > 0){
                            for(Friend x : friend)
                            {
                                System.out.println(x.friend.name + " (" + x.status + ")");
                            }}
                        else 
                            System.out.println( "No friends yet.");
        System.out.println("+======================+");
                        }



        int friendAt(Sim sim){
            int i=0;
            for(Friend x : friend){
                if(x.friend.name.equalsIgnoreCase(sim.name)){
                    return i;
                }
                i++;
            }
            return -1;
        }

        void friendcek(Sim sim){
            if(this.friendAt(sim) == -1)
                this.friend.add(new Friend(sim));
            
            this.friend.get(this.friendAt(sim)).addFriendShipPoint(10+this.charismaBoost());
            
        }

        void learnSkill(){
        }

        boolean isSkillLearned(String name){
            for(Skill x : skills){
                if(x.name.equalsIgnoreCase(name)){
                    return true;
                }
            }
            return false;
        }

        int skillAt(String name){
            int i=0;
            for(Skill x : skills){
                if(x.name.equalsIgnoreCase(name)){
                    return i;
                }
                i++;
            }
            return -1;
        }


        int energyReduction(){
            int level = 0;
            if(this.isSkillLearned("Logic Skill"))
             level += this.skills.get(this.skillAt("Logic Skill")).level;

            return level;
        }

        int charismaBoost(){
            if(this.isSkillLearned("Charisma Skill"))
                return this.skills.get(this.skillAt("Charisma Skill")).level*2;
            else
                return 0;
        }
} 
    

