import java.util.Random;

public class Monster {
    Random random = new Random();
    char symbol;
    int x;
    int y;
    int minimalLevelTools;
    String name;
    boolean isAlive = true;

    public Monster(String name,char symbol, int x, int y, int minimalLevelTools)
    {
        this.name = name;
        this.symbol = symbol;
        this.x = x;
        this.y = y;
        this.minimalLevelTools = minimalLevelTools;
    }

    public void monsterMove(char[][] arr){
        boolean done = false;

        while(!done){
            int randomArah = random.nextInt(0,4);
            int nextX = this.x;
            int nexty = this.y;

            switch (randomArah) {
                case 0:
                    nextX++;
                    break;
                case 1:
                    nextX--;
                    break;
                case 2:
                    nexty++;
                    break;
                case 3:
                    nexty--;
                    break;
            }

            if(nextX >= 19 || nexty >= 7 || nextX < 0 || nexty < 0)
                continue;
            else if(arr[nexty][nextX] != ' ')
                continue;
            else{
                done = true;
                this.x = nextX;
                this.y = nexty;
            }
            
        }

    }
    
}
