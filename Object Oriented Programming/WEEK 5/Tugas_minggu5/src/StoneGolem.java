import java.util.Random;

public class StoneGolem extends Character{
    Random random = new Random();
    public StoneGolem(){
        super("Stone Golem", "Flora", "SG", 10);
        this.requiredSkillPoint = 2;
    }
    
    @Override
    public StoneGolem copy(){
        return new StoneGolem();
    }
    @Override
    public void skill(Player currentPlayer, Player x){
        this.skillPoint -=2;
        boolean cardChanged = false;

        while(!cardChanged)
        {
            int changed = random.nextInt(0,3);

            if(!x.cards.get(changed).equals(x.activeCard) && x.cards.get(changed).hp > 0)
                x.setActiveCard(changed);
        }

    
        System.out.println("Stone Golem used its skill");
    }


}
