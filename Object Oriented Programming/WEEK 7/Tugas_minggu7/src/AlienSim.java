import java.util.Random;

public class AlienSim extends Sim {
    Random random = new Random();
    @Override
    public void interact(Sim sim) {
        if(sim.type.equalsIgnoreCase("human"))
        {
            this.mood = "Curious";
            this.energy-=(30- this.energyReduction());
            System.out.println(this.name + " interacts with "+sim.name+" and feels Curious.\n" +this.name +" is curious about human behavior.");
            sim.interact(this);

        }
        if(sim.type.equalsIgnoreCase("vampire")){
            this.mood = "Intrigued";
            this.energy-=(20- this.energyReduction());
            System.out.println(this.name + "interacts with " + //
                                sim.name + " and feels Curious.\r\n" + //
                                this.name+" is intrigued by the" + //
                                "vampire's abilities.");
            sim.interact1(this);

        }
        if(sim.type.equalsIgnoreCase("alien")){
            this.mood = "Happy";
            this.energy-=(10- this.energyReduction());
            System.out.println(this.name + " interacts with " + //
                                sim.name+" and feels Curious.\r\n" + //
                                this.name+" is happy to see " + //
                                "another alien." + //
                                "");
            sim.interact1(this);

        }
    }
    
    public void interact1(Sim sim) {
        
        sim.friendcek(this);
        System.out.println(sim.name+" friendship points increased by " + (10+sim.charismaBoost()));


        if(sim.type.equalsIgnoreCase("human"))
        {
            this.mood = "Curious";
            this.energy-=(30- this.energyReduction());
            System.out.println(this.name + " interacts with "+sim.name+" and feels Curious.\n" +this.name +" is curious about human behavior.");

        }
        if(sim.type.equalsIgnoreCase("vampire")){
            this.mood = "Intrigued";
            this.energy-=(20- this.energyReduction());
            System.out.println(this.name + "interacts with " + //
                                sim.name + " and feels Curious.\r\n" + //
                                this.name+" is intrigued by the" + //
                                "vampire's abilities.");

        }
        if(sim.type.equalsIgnoreCase("alien")){
            this.mood = "Happy";
            this.energy-=(10- this.energyReduction());
            System.out.println(this.name + " interacts with " + //
                                sim.name+" and feels Curious.\r\n" + //
                                this.name+" is happy to see " + //
                                "another alien." + //
                                "");

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
        if(this.hunger > 50)
            this.hunger=50;

        this.mood = "Satisfied";
        System.out.println(this.name + " eats.\n" + //
                        this.name+" now has a hunger level" + //
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
                        "spaceship to recharge energy.");

    }
    public AlienSim() {
        super("Alien");
        this.type = "Alien";
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
                boolean bonus = random.nextBoolean();

                if(bonus)           
                {
                    this.skills.get(index).level += 2;
                    System.out.println(this.name + "  blends strange ingredients and feels inspired.");
                    this.mood = "Inspired";
                }
                else
                {
                    this.skills.get(index).level += 0;
                    System.out.println(this.name + " tries a new recipe and feels confused.");
                    this.mood = "Confused";
                }



                break;
            case 2:
                if(!this.isSkillLearned("Logic Skill"))
                    this.skills.add(new Skill("Logic Skill"));
                
                int index1 = this.skillAt("Logic Skill");

                if(this.mood.equalsIgnoreCase("Focused"))                
                {
                    this.skills.get(index1).level += 3;
                    System.out.println(this.name + "  deciphers complex patterns and feels focused.  ");
                    System.out.println(this.name + "'s interstellar brain lights up. ");
                }
                else
                {
                    this.skills.get(index1).level += 2;
                    System.out.println(this.name + "  deciphers complex patterns and feels focused.  ");
                }

                this.mood = "Focused";


                
                break;
            case 3:
                if(!this.isSkillLearned("Charisma Skill"))
                    this.skills.add(new Skill("Charisma Skill"));
        
                int index2 = this.skillAt("Charisma Skill");

                if(this.friend.size() >= 2)                
                {
                    this.skills.get(index2).level += 2;
                    System.out.println(this.name + " observes human " + //
                                                "interaction and trains " + //
                                                "charisma. ");
                    System.out.println(this.name + " learns " + //
                                                "something new about human " + //
                                                "behavior.  ");
                }
                else
                {
                    this.skills.get(index2).level += 1;
                    System.out.println(this.name + " observes human " + //
                                                "interaction and trains " + //
                                                "charisma. ");
                }

                this.mood = "Curious";


                break;
        }
    }}
