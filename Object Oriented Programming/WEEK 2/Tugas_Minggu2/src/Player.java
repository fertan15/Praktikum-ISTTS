public class Player {
    String nama;
    int hp=0; 
    int atk;
    int max_hp;
    boolean isAcquired;
    static int jumPlayer = 0;
    boolean isAlive = true ;

    void setInfo(String nama, int max_hp, int atk)
    {
        this.nama = nama;
        this.hp = max_hp;
        this.max_hp = max_hp;
        this.atk = atk;
        jumPlayer++;
        this.isAcquired = true;
    }

    @Override
    public String toString() {
        return nama + " [HP:" + hp + "/" + max_hp + "]";
    }

    
}
