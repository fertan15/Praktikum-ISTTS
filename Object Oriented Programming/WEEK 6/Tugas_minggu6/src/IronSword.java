public class IronSword extends Sword {
    public IronSword() {
        this.name = "Iron Sword";
        this.level = 2;
        this.recipe = new char[][] {
            {'-', 'I', '-'},
            {'-', 'I', '-'},
            {'-', 's', '-'}
        };
    }

    public IronSword copy(){
        return new IronSword();
    }
    
}
