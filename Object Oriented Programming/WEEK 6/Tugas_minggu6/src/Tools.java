import java.util.Arrays;

public class Tools {
    char[][] recipe;
    String name;
    int level;

    Boolean checkRecipe(char[][] arr){
        for(int i=0;i<3;i++){
            for(int j=0;j<3;j++){
                if(recipe[i][j] != arr[i][j]){
                    return false;
                }
            }
        }
        return true;
    }

    Tools copy(){
        return new Tools();
    }

}
