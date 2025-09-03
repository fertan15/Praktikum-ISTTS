
public class PyroManiac extends Character{
    public PyroManiac(){
        super("Pyro Maniac", "Fire", "PM", 10);
        this.requiredSkillPoint = 1;

    }

    @Override
    public PyroManiac copy(){
        return new PyroManiac();
    }
    @Override
    public void skill(Player currentPlayer, Player x){
        this.skillPoint -=1;
    
        x.activeCard.hp -= 3;
        if(x.activeCard.hp < 0)
            x.activeCard.hp = 0;

        System.out.println("Pyro Maniac used its skill");
    }

}
