public class Dragon {
    String jenisDragon, Elemen, namaDragon;
    int level, exp;
    int maxExp = 20;
    boolean HasilPembiakan = false;
    

    public Dragon(String jenisDragon, String elemen, String namaDragon) {
        this.jenisDragon = jenisDragon;
        this.Elemen = elemen;
        this.namaDragon = namaDragon;
        this.level = 1;
        this.exp = 0;
    } 

    public Dragon(String jenisDragon, String elemen, String namaDragon, boolean HasilPembiakan) {
        this.jenisDragon = jenisDragon;
        this.Elemen = elemen;
        this.namaDragon = namaDragon;
        this.level = 1;
        this.exp = 0;
        this.HasilPembiakan = HasilPembiakan;
    } 


    public void addExp(int x)
    {
        this.exp += x;
        if(exp >= maxExp)
        {
            level++;
            System.out.println(namaDragon + " has leveled up to level " + level + "!");
        }
        
        this.maxExp = (int)(Math.pow(2, level) * 10);
        
    }
        

    
}
