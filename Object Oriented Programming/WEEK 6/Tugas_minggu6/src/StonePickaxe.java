public class StonePickaxe extends Pickaxe {
    public StonePickaxe() {
        this.name = "Stone Pickaxe";
        this.level = 1;
        this.recipe = new char[][] {
            {'S', 'S', 'S'},
            {'-', 's', '-'},
            {'-', 's', '-'}
        };

    }

    public StonePickaxe copy(){
        return new StonePickaxe();
    }
}
