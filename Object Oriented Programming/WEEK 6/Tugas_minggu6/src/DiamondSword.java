public class DiamondSword extends Sword {
    public DiamondSword() {
        this.name = "Diamond Sword";
        this.level = 3;
        this.recipe = new char[][] {
            {'-', 'D', '-'},
            {'-', 'D', '-'},
            {'-', 's', '-'}
        };
    }

    public DiamondSword copy(){
        return new DiamondSword();
    }
}
