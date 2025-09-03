import java.util.ArrayList;

public class User {

    String nama, username, password;
    static ArrayList<User> users = new ArrayList<User>();
    
    //data game player
        int hari = 1, coin = 100, berry = 40;
        boolean incubator = false;
        String incubatorName = null;
        int incubatorDay = -1;
        ArrayList<Dragon> dragons = new ArrayList<Dragon>();
        String incubatorElemen = null;
        Boolean berryForTheDay = false;

    public User(String nama, String username, String password) {
        this.nama = nama;
        this.username = username;
        this.password = password;
        users.add(this);
    }

    public static Boolean cekUserName(String name){
        for (User user : users) {
            if(user.username.equals(name)){
                return true;
            }
        }
        return false;
    }

    public static int cekLogin(String username){
       int i = 0;
        for (User user : users) {
            if(user.username.equals(username)){
                return i;
            }
            i++;
        }
        return -1;
    }

    

    
}
