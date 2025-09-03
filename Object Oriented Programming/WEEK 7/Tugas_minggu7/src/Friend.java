public class Friend {
    Sim friend;
    String status = "Acquaintance"; 
    int point = 10;  


    public Friend(Sim friend) {
        this.friend = friend;
    }


    void addFriendShipPoint(int point) {
        this.point += point;

        if (this.point == 100) {
            this.status = "Best Friend";
        } else if (this.point >= 75) {
            this.status = "Good Friend";
        } else if (this.point >= 50) {
            this.status = "Friend";
        }else if (this.point >= 0) {
            this.status = "Acquaintance";
        }   
    }

    
}
