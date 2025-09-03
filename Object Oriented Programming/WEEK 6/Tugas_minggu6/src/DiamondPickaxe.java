public class DiamondPickaxe extends Pickaxe {
    public DiamondPickaxe() {
        this.name = "Diamond Pickaxe";
        this.level = 3;
        this.recipe = new char[][] {
            {'D', 'D', 'D'},
            {'-', 's', '-'},
            {'-', 's', '-'}
        };
    }

    public DiamondPickaxe copy(){
            return new DiamondPickaxe();
    }

    
}
