public class Monster {
        String nama;
        int hp;
        int atk;
        int max_hp;
    
        void setInfo(String nama, int max_hp, int atk)
        {
            this.nama = nama;
            this.hp = max_hp;
            this.max_hp = max_hp;
            this.atk = atk;
        }

        public String toString() {
            return nama + " [HP:" + hp + "/" + max_hp + "]";
        }

        public void damage(int damage){
            this.hp -= damage;

            if(this.hp<0)
                this.hp = 0;
        }
    
    
}
