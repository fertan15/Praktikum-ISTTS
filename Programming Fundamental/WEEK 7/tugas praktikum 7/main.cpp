#include <iostream>
#include <vector>
#include <stdlib.h>
#include <time.h>
#include <conio.h>
#include <windows.h>
using namespace std;

int treasure = 0;
int gold = 0;
bool shovel[4] = {true,false,false,false};
string nama_shovel[4] = {"Wooden Shovel","Stone Shovel", "Iron Shovel", "Diamond Shovel"};
int shovel_price[4] = {0,3,10,25};
int max_dur[4] = {3,10,25,50};
int current_dur[4] = {3,0,0,0};
char randoman[20];
char map_xray_real[4][10][10];
int cheat=0;
int current_map = 1;
int player_pos[4][2] = {{0,0},{1,1},{1,1},{1,1}};
int hp=5;
bool kunci=false;
int current_shovel;
char mapp[4][10][10];
char map_xray[4][10][10];
bool win = false;
bool over = false;

bool ada_shovel()
{
    for(int i=0;i<4;i++)
    {
        if(shovel[i]==true)
            return true;
    }
    return false;
}


char mapp_real[4][10][10] = {{},{
    {'#','#','#','#','#','#','#','#','#','#'},
    {'#','P','#','X',' ','X','#','X','X','#'},
    {'#',' ','#','X',' ',' ','#',' ',' ','#'},
    {'#',' ','#','#',' ',' ','#','X',' ','#'},
    {'#',' ',' ',' ',' ',' ',' ',' ',' ','#'},
    {'#','#','#','#',' ','#','#','#',' ','#'},
    {'#','X',' ',' ',' ','#',' ',' ',' ','#'},
    {'#','X',' ',' ',' ','#',' ','#','#','#'},
    {'#','X',' ',' ',' ','#',' ',' ','S','#'},
    {'#','#','#','#','#','#','#','#','#','#'}
},{
    {'#','#','#','#','#','#','#','#','#','#'},
    {'#','P',' ',' ','X','#','X',' ','X','#'},
    {'#',' ',' ',' ','X','#','X',' ','X','#'},
    {'#','#','#',' ','X','X','X',' ','#','#'},
    {'#','X','#',' ',' ',' ',' ',' ',' ','#'},
    {'#',' ','#',' ','#',' ',' ',' ','X','#'},
    {'#',' ',' ',' ','#',' ',' ','X','#','#'},
    {'#','X','X',' ','#',' ','#','#','#','#'},
    {'#','#','X',' ','#',' ',' ',' ','S','#'},
    {'#','#','#','#','#','#','#','#','#','#'}
},{
    {'#','#','#','#','#','#','#','#','#','#'},
    {'#','P',' ','X','X','X','#',' ','X','#'},
    {'#',' ',' ',' ',' ',' ','#',' ','X','#'},
    {'#',' ',' ',' ',' ',' ',' ',' ','X','#'},
    {'#',' ',' ',' ','X','X',' ',' ',' ','#'},
    {'#',' ',' ',' ','X','X',' ',' ',' ','#'},
    {'#','#','#',' ',' ',' ',' ',' ',' ','#'},
    {'#','X','#',' ',' ',' ',' ','X','X','#'},
    {'#',' ',' ',' ',' ',' ',' ','X','#','#'},
    {'#','#','#','#','#','#','#','#','#','#'}
}
};

void random_map()
{
    int key_1 = rand()%9+1;
    int key_2 = rand()%15+1;
    int treasure_3 = rand()%14+1;
    int c_1 = 0;
    int c_2 = 0;
    int c_3 = 0;
    bool k1 = false;
    bool k2 = false;
    bool k3 = false;
    for(int i=0;i<10;i++)
    {
        for(int j=0;j<10;j++)
        {
            map_xray_real[1][i][j]=mapp_real[1][i][j];
            map_xray_real[2][i][j]=mapp_real[2][i][j];
            map_xray_real[3][i][j]=mapp_real[3][i][j];

            if(map_xray_real[1][i][j]=='X')
            {
                int random = rand()%2;
                if(random == 0)
                {
                   map_xray_real[1][i][j] = 'W';
                    c_1++;
                }
                else if(random == 1)
                {
                    map_xray_real[1][i][j] = 'G';
                    c_1++;
                }
            }
            if(map_xray_real[2][i][j]=='X')
            {
                int random = rand()%2;
                if(random == 0)
                {
                    map_xray_real[2][i][j] = 'W';
                    c_2++;
                }
                else if(random == 1)
                {
                    map_xray_real[2][i][j] = 'G';
                    c_2++;
                }
            }
            if(map_xray_real[3][i][j]=='X')
            {
                int random = rand()%2;
                if(random == 0)
                {
                    map_xray_real[3][i][j]= 'W';
                    c_3++;
                }
                else if(random == 1)
                {
                    map_xray_real[3][i][j] = 'G';
                    c_3++;
                }
            }

            if(c_1 == key_1 && k1 == false)
            {
                map_xray_real[1][i][j] = 'K';
                k1 = true;
            }
            if(c_2 == key_2 && k2 == false)
            {
                map_xray_real[2][i][j] = 'K';
                k2 = true;
            }
            if(c_3 == treasure_3 && k3 == false)
            {
                map_xray_real[3][i][j] = 'T';
                k3 = true;
            }

        }
    }
}

void duplicate()
{
    for(int i=0;i<10;i++)
    {
        for(int j=0;j<10;j++)
        {
            mapp[1][i][j] = mapp_real[1][i][j];
            mapp[2][i][j] = mapp_real[2][i][j];
            mapp[3][i][j] = mapp_real[3][i][j];
            map_xray[1][i][j] = map_xray_real[1][i][j];
            map_xray[2][i][j] = map_xray_real[2][i][j];
            map_xray[3][i][j] = map_xray_real[3][i][j];
        }
    }

}

int eq_menu()
{
    if(!ada_shovel())
    {
        over=true;
        return 0;
    }
    vector<int> choose; //vector but nyimpan index shovel yang dipake
    cout << "=== Equipment Menu ===" << endl;
    int counter = 1;
    int x;

    for(int i=0;i<5;i++)
    {
        if(shovel[i]==true)
        {
            cout << counter << ". " << nama_shovel[i] << " (Durability: " << current_dur[i] <<")" <<endl;
            counter++;
            choose.push_back(i);
        }
    }
        cout << "Enter shovel number to equip: " << endl;
        do{
            cout << ">> "; cin >> x;
        }while(x<1 || x>counter);
        cout << endl;
        return choose[x-1];

}

string item(int x)
{
    if(shovel[x]==true)
        return "Owned";
    else
        return "Not Owned";
}
void mainmenu()
{
    cout << "=== Treasure Hunt ===" << endl;
    cout << "Treasure: " << treasure << endl;
    cout << "Gold: " << gold << endl;
    cout << "1. Play" << endl;
    cout << "2. Shop" << endl;
    cout << "0. Exit" << endl;
}
void shop()
{
    cout << "== Shop ==" << endl;
    cout << "Gold: " << gold << endl;
    cout << "1. Wooden Shovel (Price: 0 Gold | Durability: 3 | " << item(0) << " )"<< endl;
    cout << "2. Stone Shovel (Price: 3 Gold | Durability: 10 | " << item(1) << " )"<< endl;
    cout << "3. Iron Shovel (Price: 10 Gold | Durability: 25 | " << item(2) << " )"<< endl;
    cout << "4. Diamond Shovel (Price: 25 Gold | Durability: 50 | " << item(3) << " )"<< endl;
    cout << "0. Exit" << endl;
}

void print_map()
{
   for(int i = 0; i<10;i++)
    {
        for(int j = 0; j<10;j++)
        {
                if(cheat%2 == 1)
                    cout << map_xray[current_map][i][j] <<" ";
                else
                    cout << mapp[current_map][i][j] <<" ";
        }
        cout << endl;
    }
}

void movement(char key)
{

    int y = player_pos[current_map][0];
    int x = player_pos[current_map][1];

    if (key == 'W' || key == 'w') y--;
    else if (key == 'S' || key == 's') y++;
    else if (key == 'A' || key == 'a') x--;
    else if (key == 'D' || key == 'd') x++;

    if (x >= 0 && x < 10 && y >= 0 && y < 10 && mapp[current_map][y][x] == ' ')
    {
        mapp[current_map][player_pos[current_map][0]][player_pos[current_map][1]] = ' ';
        map_xray[current_map][player_pos[current_map][0]][player_pos[current_map][1]] = ' ';
        player_pos[current_map][0] = y;
        player_pos[current_map][1] = x;
        mapp[current_map][player_pos[current_map][0]][player_pos[current_map][1]] = 'P';
        map_xray[current_map][player_pos[current_map][0]][player_pos[current_map][1]] = 'P';
    }
    else if (x >= 0 && x < 10 && y >= 0 && y < 10 && mapp[current_map][y][x] == 'S')
    {
        if(kunci==true)
        {
            current_map++;
            kunci=false;
        }
        else
        {
            cout << "You don't have the key..." << endl;
            Sleep(1000);
        }
    }


}

void dig(char key)
{
    int y = player_pos[current_map][0];
    int x = player_pos[current_map][1];

    if (key == 'i'|| key == 'I') y--;
    else if (key == 'k'|| key == 'K') y++;
    else if (key == 'j'|| key == 'J') x--;
    else if (key == 'l'|| key == 'L') x++;

    if(mapp[current_map][y][x] == 'X')
    {
        if(map_xray[current_map][y][x]=='K')
        {
            cout << "You've found the key..." << endl;
            Sleep(1000);
            kunci=true;
        }
        else if(map_xray[current_map][y][x]=='G')
        {
            int hadiah = rand()%5+1;
            cout << "You've dug a gold! You found " << hadiah << " gold!!" << endl;
            Sleep(1000);
            gold+=hadiah;
        }
        else if(map_xray[current_map][y][x]=='W')
        {
            cout << "You've dug a trap! Your HP -1 " << endl;
            Sleep(1000);
            hp--;
        }
        else if(map_xray[current_map][y][x]=='T')
        {
            cout << "You've dug a Treasure! Congratulation... " << endl;
            win = true;
            Sleep(1000);
            treasure++;
        }
        //durabiliti shovel dikurangi
        current_dur[current_shovel]--;
        //x diilangin dari map
        mapp[current_map][y][x] = ' ';
        map_xray[current_map][y][x] = ' ';

    }
    else{
        cout << "Nothing to dig..." << endl;
        Sleep(1000);
    }

}


int main()
{
    srand(time(0));
    int menu_choice;
    do{
        system("cls");
        mainmenu(); //cetak tampilan menu

        //input main menu
        do{
            cout << ">> "; cin >> menu_choice;
            if(menu_choice==99)
                break;
        }while(menu_choice<0 || menu_choice>2);


        //menu rahasia if input 99 gold nambah 1000
        if(menu_choice==99)
        {
            cout << "Obtained 1000 gold..." << endl;
            Sleep(1000);
            gold+=1000;
        }

        cout << endl;
        //switch case
        switch(menu_choice)
        {
            //menu play
            case 1 :
            {
                //reset posisi player
                player_pos[1][0]=1;
                player_pos[1][1]=1;
                player_pos[2][0]=1;
                player_pos[2][1]=1;
                player_pos[3][0]=1;
                player_pos[3][1]=1;

                //reset map
                random_map();
                duplicate();

                //reset banyak hal
                over = false;
                win = false;
                cheat=0; //kalo cheat nya GANJIL muncul xray nya
                current_map = 1;
                system("cls");
                current_shovel = eq_menu();
                hp=5;
                kunci=false;


                if(!ada_shovel)
                {
                    cout << "YOU DON'T HAVE ANY SHOVEL.." <<endl;
                    Sleep(1000);
                    break;
                }
                else{
                    while(true)
                    {
                        if(hp==0)
                        {
                            system("cls");
                            cout << "YOU DON'T HAVE LIFE ANYMORE.." <<endl;
                            cout << "GAME OVER!!" <<endl;
                            Sleep(1000);
                            break;
                        }
                        if(current_dur[current_shovel]==0)
                        {
                            system("cls");
                            shovel[current_shovel]=false;
                            current_shovel = eq_menu();
                            if(over)
                            {
                                cout << "YOU DON'T HAVE ANY SHOVEL.." <<endl;
                                cout << "GAME OVER!!" <<endl;
                                Sleep(1000);
                                break;
                            }
                        }
                        system("cls");
                        //header
                        cout << "== Play ==" <<endl;
                        cout << "HP: "<< hp <<endl;
                        cout << "Gold: "<< gold <<endl;
                        cout << "Shovel Durability: "<< current_dur[current_shovel] <<endl;

                        //map
                        print_map();

                        //ket
                        cout << "Press W/A/S/D to move" <<endl;
                        cout << "Press I/J/K/L to dig" <<endl;
                        cout << "Press E to open equipment menu" <<endl;
                        cout << "Press X to exit" <<endl;

                        while(!kbhit()){}
                        char key = getch();

                        if(key == 'x' || key == 'X')
                        {
                            system("cls");
                            break;
                        }
                        if(key == 'E' || key == 'e')
                        {
                            system("cls");
                            current_shovel = eq_menu();
                        }
                        if(key == 'c' || key == 'C')
                            cheat++;
                        if(key == 'w' ||key == 'W' || key == 'a' ||key == 'A' || key == 's' ||key == 'S' || key == 'd' ||key == 'D' )
                            movement(key);
                        if(key == 'i' ||key == 'I' || key == 'j' ||key == 'J' || key == 'k' ||key == 'K' || key == 'l' ||key == 'L' )
                            dig(key);
                        if(win)
                        {
                            system("cls");
                            cout << "Congratulationn!! you've found the treasuree..." << endl;
                            Sleep(1000);
                            if(current_dur[current_shovel]==0)
                            {
                                shovel[current_shovel]=false;
                            }
                            break;
                        }


                    }
                    break;
                }
            }

            //menu shop
            case 2 :
            {
                system("cls");
                int shop_choice;
                while(true){
                    system("cls");
                    shop();
                    do{
                        cout << ">> "; cin >> shop_choice;
                    }while(shop_choice<0 || shop_choice>4);

                    if(shop_choice==0)
                    {
                        cout << endl;
                        break;
                    }

                    int current = shop_choice-1;

                    //cek shovel yang mau dibeli udh ada belom
                    if(shovel[current]==true)
                    {
                        cout << "Shovel already owned!..." << endl;
                        Sleep(1000);
                        cout << endl;
                        continue;
                    }
                    //cek uang cukup ga
                    if(gold < shovel_price[current])
                    {
                        cout << "Gold is not enough!..." << endl;
                        Sleep(1000);
                        cout << endl;
                        continue;
                    }

                    //kalo udh memenuhi smua syarat, beli shovel
                    shovel[current] = true;
                    current_dur[current] = max_dur[current];
                    gold -= shovel_price[current];
                    cout << "Shovel Purchased!..." << endl;
                    Sleep(1000);
                    cout << endl;
                }
                break;
            }
        }

    }while(menu_choice!=0);

    return 0;
}
