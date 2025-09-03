import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        Scanner scanInt = new Scanner(System.in);
        Scanner scanString = new Scanner(System.in);

        //akun ku buat
        User init = new User("ferlinda", "ferfer", "123");
        User.users.add(init);
        init.coin = 1000;

        boolean mainMenu = true;
        do {
            int mainMenuOption = menu(scanString);
            switch (mainMenuOption) {
                case 1: //login

                    String username, password;
                    System.out.println("=== Login ===");
                    System.out.print("Username: ");
                    username = scanString.nextLine();
                    System.out.print("Password: ");
                    password = scanString.nextLine();

                    if(User.cekLogin(username) == -1)
                    {
                        System.out.println("Username tidak terdaftar!");
                    }
                    else if(User.users.get(User.cekLogin(username)).password.equals(password) == false)
                    {
                        System.out.println("Password Salah!");
                    }
                    else
                    {
                        System.out.println("Berhasil login!");
                        Game game = new Game(User.users.get(User.cekLogin(username)));
                    }
                    System.out.println();
                    
                    break; //end login
                case 2: //Register
                    String nameReg, usernameReg, passwordReg, confirmPassReg;
                    System.out.println("=== Register ===");
                    System.out.print("Name: ");
                    nameReg = scanString.nextLine();
                    System.out.print("Username: ");
                    usernameReg = scanString.nextLine();
                    System.out.print("Password: ");
                    passwordReg = scanString.nextLine();
                    System.out.print("Confirm Password: ");
                    confirmPassReg = scanString.nextLine();

                    if(nameReg.isEmpty() || usernameReg.isEmpty() || passwordReg.isEmpty() || confirmPassReg.isEmpty())
                    {
                        System.out.println("Data tidak boleh kosong!");
                    }
                    else if(User.cekUserName(usernameReg))
                    {
                        System.out.println("Username sudah terdaftar!");
                    }
                    else if(passwordReg.equals(confirmPassReg))
                    {
                        User user = new User(nameReg, usernameReg, passwordReg);
                        System.out.println("Berhasil Registrasi!");
                    }
                    else
                    {
                        System.out.println("Password harus sama!");
                    }

                    System.out.println();
                    break; //end register
                case 3:
                    mainMenu = false;
                    break;
            }
        } while (mainMenu);


        scanInt.close();
        scanString.close();
    }


    static int menu(Scanner scan)
    {   
        String input;
        int x=1;
        do{
            System.out.println("=== Dragon City ===");
            System.out.println("| " + ((x == 1)? ">" : " ") + " Login\t  |");
            System.out.println("| " + ((x == 2)? ">" : " ") + " Register\t  |");
            System.out.println("| " + ((x == 3)? ">" : " ") + " Exit\t  |");
            System.out.println("===================");
            System.out.print(">> ");
            input = scan.nextLine();
            
            if(input.equalsIgnoreCase("w"))
            {
                if(x > 1)
                    x--;
                else 
                    x = 3;
            }
            else if(input.equalsIgnoreCase("s"))
            {
                if(x < 3)
                    x++;
                else
                    x = 1;
            }
            else if(!input.equalsIgnoreCase("Enter"))
            {
                System.out.println("Invalid Input");
            }

            System.out.println();
        }while(!input.equalsIgnoreCase("Enter"));

        return x;
}

}
