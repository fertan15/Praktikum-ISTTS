#include <iostream>
#include <ctime>
#include <cmath>
using namespace std;

int main()
{
    srand(time(0));
    int lp=0, de=0, as=0;
    int menu;
    int coins=0;
    int item;
    //loop game menu
    do{
    int coins_round=0;
    //menu awal
    cout << "=== Welcome to Arithmetic Arena ===" << endl;
    cout << "1. Play" << endl;
    cout << "2. Shop" << endl;
    cout << "0. Quit" << endl;
    //cek input
    do{
    cout << ">> "; cin >> menu;
    }while(menu < 0 || menu > 2);

    switch(menu)
    {
    case 1:
        {
            bool over = false;

            //loop play
            int diff;
            cout << endl;
            cout << "== Play ==" << endl;
            //minta difficulty
            cout << "Choose your difficulty:" << endl;
            cout << "1. Easy" << endl;
            cout << "2. Medium" << endl;
            cout << "3. Hard" << endl;
            //cek input
            do{
            cout << ">> "; cin >> diff;
            }while(diff < 1 || diff > 3);
            cout << endl;
            //jumlah item
            cout << "= Items =" << endl;
            cout << "Lucky Pendant: " << lp << endl;
            cout << "Devil's Eye: " << de << endl;
            cout << "Angel's Shield: " << as << endl;
            cout << endl;
            int round = 1;
            int increase=10;
            while(true){
                cout << "= Rounds " << round << " =" << endl;
                if(round==1)
                    cout << "Each round gives " << increase << " gold." << endl;
                else if((round%5)+1==2){
                    increase+=10;
                    cout << "Gold reward increased! Each round now gives " << increase << " gold" << endl;
                    }
                float angka1 = rand()%10+1;
                float angka2 = rand()%10+1;
                int op1 = rand()%4+1;
                float angka3 = rand()%10+1;
                int op2 = rand()%4+1;
                float angka4 = rand()%10+1;
                int op3 = rand()%4+1;

                float hasil = 0;

                cout << angka1;
                switch(op1){
                case 1:
                    {
                        cout <<" + ";
                        hasil+=(angka1 + angka2);
                        break;
                    }
                case 2:
                    {
                        cout <<" - ";
                        hasil+=(angka1 - angka2);
                        break;
                    }
                case 3:
                    {
                        cout <<" * ";
                        hasil+=(angka1 * angka2 * 1.0);
                        break;
                    }
                case 4:
                    {
                        cout <<" / ";
                        hasil+=(angka1 / (angka2 * 1.0));
                        break;
                    }
                }

                cout << angka2;

                if(diff>1)
                {
                    switch(op2){
                    case 1:
                        {
                            cout <<" + ";
                            hasil+=angka3;
                            break;
                        }
                    case 2:
                        {
                            cout <<" - ";
                            hasil-=angka3;
                            break;
                        }
                    case 3:
                        {
                            cout <<" * ";
                            hasil*=angka3;
                            break;
                        }
                    case 4:
                        {
                            cout <<" / ";
                            hasil/=angka3;
                            break;
                        }
                    }
                    cout << angka3;
                }
                if(diff>2)
                {
                    switch(op3){
                    case 1:
                        {
                            cout <<" + ";
                            hasil+=angka4;
                            break;
                        }
                    case 2:
                        {
                            cout <<" - ";
                            hasil-=angka4;
                            break;
                        }
                    case 3:
                        {
                            cout <<" * ";
                            hasil*=angka4;
                            break;
                        }
                    case 4:
                        {
                            cout <<" / ";
                            hasil/=angka4;
                            break;
                        }
                    }
                    cout << angka4;
                }

                cout << " = ?" <<endl;
                float ans;
                cout << ">> ";cin >> ans;
                int bonus=1;
                while(true){
                    if(ans == 777 && lp>0){
                        cout << "You prayed using your lucky pendant This round's gold reward is tripled" << endl;
                        cout << "Lucky pendant remaining: " << --lp << endl << endl;
                        bonus*=3;
                    }
                    else if(ans == 666 && de>0){
                        cout << "Through the devil's eye, you see through the answer: " << hasil << endl;
                        cout << "Devil's eye remaining: " << --de << endl << endl;
                    }

                    else if(ans==hasil || fabs(ans-hasil)<=0.001)
                    {
                        cout << "Correct!" << endl << endl;
                        coins_round+=increase*bonus;
                        break;
                    }
                    else
                    {
                        cout << "Incorrect. The correct answer was " << hasil <<endl;
                        if(as>0)
                        {
                            cout << "Saved by an angel's shield" << endl;
                            cout << "Angel's shield remaining: " << --as << endl << endl;
                            coins_round+=increase*bonus;
                            break;
                        }
                        else{
                            over = true;
                            cout << "Rounds completed: " << --round <<endl;
                            cout << "Gold earned: " << coins_round <<endl;
                            break;
                        }

                    }
                    cout << angka1;
                    switch(op1){
                    case 1: cout <<" + "; break;
                    case 2: cout <<" - "; break;
                    case 3: cout <<" * "; break;
                    case 4: cout <<" / "; break;
                    }

                    cout << angka2;

                    if(diff>1)
                    {
                        switch(op2){
                        case 1: cout <<" + "; break;
                        case 2: cout <<" - "; break;
                        case 3: cout <<" * "; break;
                        case 4: cout <<" / "; break;
                        }
                        cout << angka3;
                    }
                    if(diff>2)
                    {
                        switch(op3){
                        case 1: cout <<" + "; break;
                        case 2: cout <<" - "; break;
                        case 3: cout <<" * "; break;
                        case 4: cout <<" / "; break;
                        }
                        cout << angka4;
                    }

                    cout << " = ?" <<endl;

                    cout << ">> ";cin >> ans;
                    }

                if(over)
                    break;

                round++;
            }
            coins +=coins_round;
            cout << "Current gold: " << coins <<endl;
            cout << endl;
            break;
    }
    case 2:
    {
        do{
            //shop
            cout << endl;
            cout << "== Shop ==" << endl;
            cout << "Gold: " << coins << endl;
            cout << "1. Lucky Pendant (Price: 50 | Owned: " << lp << ")" << endl;
            cout << "2. Devil's eye (Price: 100 | Owned: " << de << ")" << endl;
            cout << "3. Angel's shield (Price: 200 | Owned: " << as << ")" << endl;
            cout << "0. Exit" << endl;
            do{
            cout << ">> "; cin >> item;
            }while(item < 0 || item > 3);
            cout << endl;
            if(item == 0)
                break;
            int amount;
            cout << "Amount:" << endl;
            do{
            cout << ">> "; cin >> amount;
            }while(amount < 0);

            if(amount == 0)
                cout << "Cancel Purchase"<<endl;
            else
            {
                switch(item)
                {
                case 1:
                    {
                        int harga = amount*50;
                        if(coins < harga)
                            cout << "Gold is Not Enough" << endl;
                        else
                        {
                            cout << "Purchased " << amount << " lucky pendant" << endl;
                            coins-=harga;
                            lp+=amount;
                        }
                        break;
                    }
                case 2:
                    {
                        int harga = amount*100;
                        if(coins < harga)
                            cout << "Gold is Not Enough" << endl;
                        else
                        {
                            cout << "Purchased " << amount << " devil's eye" << endl;
                            coins-=harga;
                            de+=amount;
                        }
                        break;
                    }
                case 3:
                    {
                        int harga = amount*200;
                        if(coins < harga)
                            cout << "Gold is Not Enough" << endl;
                        else
                        {
                            cout << "Purchased " << amount << " angel's shield" << endl;
                            coins-=harga;
                            as+=amount;
                        }
                        break;
                    }
                }
            }

        }while(item!=0);
    }
    //buat quit kalo menu=0
    default: break;
    }

    }while(menu!=0);
    return 0;
}
