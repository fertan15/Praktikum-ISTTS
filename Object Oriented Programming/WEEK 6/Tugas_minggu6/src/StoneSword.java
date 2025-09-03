public class StoneSword extends Sword {
    public StoneSword() {
        this.name = "Stone Sword";
        this.level = 1;
        this.recipe = new char[][] {
            {'-', 'S', '-'},
            {'-', 'S', '-'},
            {'-', 's', '-'}
        };

    }
    public StoneSword copy(){
        return new StoneSword();
    }
}
