import java.util.ArrayList;

public class HumanSim extends Sim {


    public HumanSim() {
        super("Human");
        this.type = "Human";
    }
    @Override
    public void interact(Sim sim) {
        if(sim.type.equalsIgnoreCase("human"))
        {
            this.mood = "Happy";
            this.energy-=(20- this.energyReduction());
            System.out.println(this.name + " interacts with " +sim.name + " and feels Happy");
            sim.interact1(this);

        }
        if(sim.type.equalsIgnoreCase("vampire")){
            this.mood = "Happy";
            this.energy-=(20- this.energyReduction());
            System.out.println(this.name + " interacts with " +sim.name + " and feels Happy");
            sim.interact1(this);

        }
        if(sim.type.equalsIgnoreCase("alien")){
            this.mood = "Happy";
            this.energy-=(20- this.energyReduction());
            System.out.println(this.name + " interacts with " +sim.name + " and feels Happy");
            sim.interact1(this);

        }

        
    }
    
    public void interact1(Sim sim) {
        sim.friendcek(this);
        System.out.println(sim.name+" friendship points increased by " + (10+sim.charismaBoost()));
        if(sim.type.equalsIgnoreCase("human"))
        {
            this.mood = "Happy";
            this.energy-=(20- this.energyReduction());
            System.out.println(this.name + " interacts with " +sim.name + " and feels Happy");
           

        }
        if(sim.type.equalsIgnoreCase("vampire")){
            this.mood = "Happy";
            this.energy-=(20- this.energyReduction());
            System.out.println(this.name + " interacts with " +sim.name + " and feels Happy");
         

        }
        if(sim.type.equalsIgnoreCase("alien")){
            this.mood = "Happy";
            this.energy-=(20- this.energyReduction());
            System.out.println(this.name + " interacts with " +sim.name + " and feels Happy");
            

        }

        this.friendcek(sim);
        System.out.println(this.name+" friendship points increased by " + (10+this.charismaBoost()));
    }


    @Override
    public void eat() {
        int total = 20;
        if(this.isSkillLearned("Cooking Skill"))
            total += 20 + (skills.get(skillAt("Cooking Skill")).level * 2);

        this.hunger+=total;


        if(this.hunger > 50)
            this.hunger=50;

        this.mood = "Satisfied";
        System.out.println(this.name + " eats.\n" + //
                        this.name+" now has a hunger level " + //
                        "of "+this.hunger+".");
        
    }

    @Override
    public void sleep() {
        this.energy = 50;
        this.hunger -=30;

        if(this.hunger<0)
            this.hunger = 0;

        this.mood = "Rested";

        System.out.println(this.name+" sleeps in a" + //
                        "bed to recharge energy.");
    }
    

    void learnSkill(){
        System.out.print("Choose a skill to enhance: \r\n" + //
                            "1. Cooking Skill \r\n" + //
                            "2. Logic Skill \r\n" + //
                            "3. Charisma Skill \r\n" + //
                            ">> ");
        int choose = scanInt.nextInt();

        switch (choose) {
            case 1:
                if(!this.isSkillLearned("Cooking Skill"))
                    this.skills.add(new Skill("Cooking Skill"));
                
                int index = this.skillAt("Cooking Skill");

                if(this.mood.equalsIgnoreCase("Inspired"))                
                {
                    this.skills.get(index).level += 2;
                    System.out.println(this.name + " learns to cook " + //
                                                "and feels inspired. ");
                    System.out.println(this.name + " feels creative " + //
                                                "in the kitchen.");
                }
                else
                {
                    this.skills.get(index).level += 1;
                    System.out.println(this.name + " learns to cook " + //
                                                "and feels inspired. ");
                }

                this.mood = "Inspired";


                break;
            case 2:
                if(!this.isSkillLearned("Logic Skill"))
                    this.skills.add(new Skill("Logic Skill"));
                
                int index1 = this.skillAt("Logic Skill");

                if(this.mood.equalsIgnoreCase("Focused"))                
                {
                    this.skills.get(index1).level += 2;
                    System.out.println(this.name + " learns to "+
                                                "solve problems and feels "+ 
                                                "focused. ");
                    System.out.println(this.name + " feels creative " + //
                                                "in the kitchen.");
                }
                else
                {
                    this.skills.get(index1).level += 1;
                    System.out.println(this.name + " learns to "+
                                                "solve problems and feels "+ 
                                                "focused. ");
                }

                this.mood = "Focused";


                
                break;
            case 3:
                if(!this.isSkillLearned("Charisma Skill"))
                    this.skills.add(new Skill("Charisma Skill"));
        
                int index2 = this.skillAt("Charisma Skill");

                if(this.mood.equalsIgnoreCase("Inspired"))                
                {
                    this.skills.get(index2).level += 2;
                    System.out.println(this.name + " trains their charisma skill and feels confident. ");
                    System.out.println(this.name + " shines brightly in social situations. ");
                }
                else
                {
                    this.skills.get(index2).level += 1;
                    System.out.println(this.name + " trains their charisma skill and feels confident. ");
                }

                this.mood = "Confident";


                break;
        }
    }
}
