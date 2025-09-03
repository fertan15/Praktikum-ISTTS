public class IronPickaxe extends Pickaxe{
    public IronPickaxe() {
        this.name = "Iron Pickaxe";
        this.level = 2;
        this.recipe = new char[][] {
            {'I', 'I', 'I'},
            {'-', 's', '-'},
            {'-', 's', '-'}
        };
    }

    public IronPickaxe copy(){
        return new IronPickaxe();
    }
}
