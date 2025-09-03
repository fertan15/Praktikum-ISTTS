public class HolyPaladin extends Character{
       
    public HolyPaladin(){
        super("Holy Paladin", "Light", "HP", 10);
        requiredSkillPoint = 2;
    }

    @Override
    public HolyPaladin copy(){
        return new HolyPaladin();
    }
    @Override
    public void skill(Player currentPlayer, Player x){
        this.skillPoint -=2;
    
        int minHpIndex = 0;
        for(int i=1;i<currentPlayer.cards.size();i++)
        {
            if(currentPlayer.cards.get(i).hp < currentPlayer.cards.get(minHpIndex).hp)
                minHpIndex = i;
        }
        currentPlayer.cards.get(minHpIndex).hp += 5;
        System.out.println("HolyPaladin used its skill");
    }

}
