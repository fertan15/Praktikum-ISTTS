public class GrimReaper extends Character{
       

    public GrimReaper(){
        super("Grim Reaper", "Dark", "GR", 10);
        this.requiredSkillPoint = 3;

    }

    @Override
    public GrimReaper copy(){
        return new GrimReaper();
    }
    @Override
    public void skill(Player currentPlayer,Player x){
        this.skillPoint -=3;
        
        for(int i=0;i<x.cards.size();i++)
        {
            if(x.cards.get(i).hp <= 5)
            {
                x.cards.get(i).hp = 0;
                break;
            }
        }
        System.out.println("Grim Reaper used its skill");
    }
}
