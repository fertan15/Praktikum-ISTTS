import java.util.ArrayList;
import java.util.Random;

public class Character {
    String name, elemen, initial;
    int hp=10,skillPoint =0;
    int requiredSkillPoint;

    public Character(String name, String elemen, String initial, int hp){
        this.name = name;
        this.elemen = elemen;
        this.initial = initial;
        this.hp = hp;
    }

    public Character copy(){
        return new Character(this.name, this.elemen, this.initial, this.hp);
    }

    public void skill(Player currentPlayer, Player x){
        
    }
  

    

  


    
}
