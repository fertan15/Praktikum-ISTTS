public class Player {
    static int stone = 0;
    static int iron = 0;
    static int diamond = 0;
    static ArrayListSaya<Tools> tools = new ArrayListSaya<>(); 
    static int x;
    static int y;
    static char symbol = 'P';


    static Tools getHighestPickaxe(){
        int highestLevel = -1;
        int highestIndex = -1; 
        for (int i = 0; i < tools.size(); i++) {
            if (tools.get(i) instanceof Pickaxe) {
                if (tools.get(i).level > highestLevel) {
                    highestLevel = tools.get(i).level;
                    highestIndex = i;
                }
            }
        }
        return tools.get(highestIndex);
    }

 

    static Tools getHighestSword(){
        int highestLevel = -1;
        int highestIndex = -1; 
        for (int i = 0; i < tools.size(); i++) {
            if (tools.get(i) instanceof Sword) {
                if (tools.get(i).level > highestLevel) {
                    highestLevel = tools.get(i).level;
                    highestIndex = i;
                }
            }
        }
        return tools.get(highestIndex);
    }


    

}
