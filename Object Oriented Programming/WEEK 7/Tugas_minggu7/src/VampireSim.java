public class VampireSim extends Sim {

    VampireSim(){
        super("Vampire");
        this.thirst = 50;
        this.type = "Vampire";
    }

    int thirst;
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
        System.out.println(this.name+" friendship points increased by " + (10+sim.charismaBoost()));

    }


    @Override
    public void eat() {
        int total = 20;
        if(this.isSkillLearned("Cooking Skill"))
            total += 20 + (skills.get(skillAt("Cooking Skill")).level * 2);
            
        this.hunger+=total;
        this.thirst -=20;
        if(this.thirst<0)
            this.thirst = 0;
        if(this.hunger > 50)
            this.hunger=50;

        this.mood = "Thirsty";
        System.out.println(this.name + "  eats and starts to feel" + //
                        "thirsty.\n" + //
                        this.name+" now has a hunger level" + //
                        "of "+this.hunger+".");
    }

    @Override
    public void sleep() {
        this.energy = 50;
        this.hunger -=30;
        this.thirst-=30;

        if(this.thirst<0)
            this.thirst = 0;
        if(this.hunger<0)
            this.hunger = 0;

        this.mood = "Rested";

        System.out.println(this.name+" sleeps in a" + //
                        "coffin to recharge energy.");
    }
    
    public void drinkBlood(){
        this.mood = "Satisfied";
        this.thirst+=30;
        if(this.thirst>50)
            this.thirst = 50;
        
        System.out.println(this.name+ " drinks blood and now has a thirst level of s" + //
                        this.thirst);
    }


    public void detail(){
        
        System.out.println(">> 1 \r\n" + //
                        "+======================+ \r\n" + //
                        "Name: "+this.name+" \r\n" + //
                        "Type: "+this.type+" \r\n" + //
                        "+----------------------+ \r\n" + //
                        "Energy: "+this.energy+" \r\n" + //
                        "Hunger: "+this.hunger+" \r\n" + //
                        "Thirst: "+this.thirst+" \r\n" + //
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
                    
                                    if(this.mood.equalsIgnoreCase("Uncomfortable"))                
                                    {
                                        this.skills.get(index).level += 0;
                                        System.out.println(this.name + " reluctantly practices cooking and feels uncomfortable. ");

                                    }
                                    else
                                    {
                                        this.skills.get(index).level += 1;
                                        System.out.println(this.name + " reluctantly practices cooking and feels uncomfortable. ");

                                    }
                                    
                                    this.mood = "Uncomfortable";
                    
                    
                                    break;
                                case 2:
                                    if(!this.isSkillLearned("Logic Skill"))
                                        this.skills.add(new Skill("Logic Skill"));
                                    
                                    int index1 = this.skillAt("Logic Skill");
                    
                                    if(this.hunger < 30)                
                                    {
                                        this.skills.get(index1).level += 2;
                                        System.out.println(this.name + "  studies ancient knowledge and feels focused.  ");
                                        System.out.println(this.name + "'s thirst fuels their intellect.");
                                    }
                                    else
                                    {
                                        this.skills.get(index1).level += 1;
                                        System.out.println(this.name + "  studies ancient knowledge and feels focused.  ");
                                    }
                    
                                    this.mood = "Focused";
                    
                    
                                    
                                    break;
                                case 3:
                                    if(!this.isSkillLearned("Charisma Skill"))
                                        this.skills.add(new Skill("Charisma Skill"));
                            
                                    int index2 = this.skillAt("Charisma Skill");
                    
                                        this.skills.get(index2).level += 2;
                                        System.out.println(this.name + " charms " + //
                                                                                        "everyone effortlessly and " + //
                                                                                        "feels confident. ");
                                    
                    
                                    this.mood = "Confident";
                    
                    
                                    break;
                            }
                        }}
