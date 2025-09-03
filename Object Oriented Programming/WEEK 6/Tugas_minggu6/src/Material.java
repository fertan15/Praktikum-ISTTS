public class Material {
    int x;
    int y;
    char symbol;
    int minimalLevelTools;
    String name;

    public Material(String name, char symbol, int x, int y, int minimalLevelTools)
    {
        this.name = name;
        this.symbol = symbol;
        this.x = x;
        this.y = y;
        this.minimalLevelTools = minimalLevelTools;
    }


    static Character getDiamondSymbol(){
        return 'D';
    }

    static Character getIronSymbol(){
        return 'I';
    }

    static Character getStoneSymbol(){
        return 'S';
    }

    static Character getStickSymbol(){
        return 's';
    }

    static Character getEmptySymbol(){
        return '-';
    }
}
