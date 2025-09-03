public class AtlanticSiren extends Character {
    public AtlanticSiren(){
        super("Atlantic Siren", "Water", "AS", 10);
        this.requiredSkillPoint = 2;
    }

    @Override
    public AtlanticSiren copy(){
        return new AtlanticSiren();
    }
    @Override
    public void skill(Player currentPlayer,Player x){
        this.skillPoint -=2;
        this.hp-=3;
        
        for(int i=0;i<x.cards.size();i++)
        {
            x.cards.get(i).hp -= 2 ;
            if(x.cards.get(i).hp<0)
                x.cards.get(i).hp = 0;
        }
        System.out.println("Atlantic Siren used its skill");
    }
}
