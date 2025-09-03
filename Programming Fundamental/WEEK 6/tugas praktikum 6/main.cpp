#include <iostream>
#include <vector>
#include <string>
#include <algorithm>
#include <cctype>
#include <time.h>



using namespace std;

int main()
{
    srand(time(0));
    int main_menu;
    vector<string> word;
    vector<string> word_up;
    do{
    cout << "=== Wurdle ===" << endl;
    cout << "1. Play" << endl;
    cout << "2. Add Word" << endl;
    cout << "0. Exit" << endl;
    do{
    cout << ">> "; cin >> main_menu;
    }while(main_menu < 0 || main_menu > 2);
    cout << endl;

    switch(main_menu)
    {
        case 1 :
        {
            if(word.empty()){
                cout << "No words in the word list!" << endl << endl;
                break;
                }
            else
            {


                int num_tebak = rand()%word_up.size();
                string tebak = word_up[num_tebak];
                int live=6;
                bool win = false;
                int used_live=1;
                while(live>0)
                {
                    string guess;
                    bool alpha = true;
                    cout << live << " guesses left" << endl;
                    do{
                        cout << ">> "; cin >> guess;
                        //cek smua huruf bukan?
                        for(int i = 0; i<guess.size();i++)
                        {
                            alpha = isalpha(guess[i]);
                            if(!alpha)
                            break;
                        }
                        if(guess.size()!=5)
                            cout << "Invalid guess length! Guess must be 5 characters long." << endl;
                        if(alpha == false)
                            cout << "Invalid characters! Guess must consist of alphabetics characters only." <<endl;

                    }while(guess.size()!=5 || alpha == false);
                   //nge uppercase smua huruf
                    transform(guess.begin(), guess.end(), guess.begin(), ::toupper);

                    vector<bool> used(5, false);
                    string temp = tebak;
                    string inf = "XXXXX";
                    for (int i = 0; i < 5; i++) {
                        if (guess[i] == temp[i]) {
                            inf[i] = '0';
                            temp[i] = '0';
                            used[i] = true;
                        }
                    }

                    for (int i = 0; i < 5; i++) {
                        if (inf[i] == '0') continue;
                        for (int j = 0; j < 5; j++) {
                            if (!used[j] && guess[i] == temp[j]) {
                                inf[i] = 'V';
                                temp[j] = '0';
                                used[j] = true;
                                break;
                            }
                        }
                    }

                    cout << "   ";
                    //cetak informasi tebakan
                    for(int i=0;i<5;i++)
                        cout << inf[i];
                    cout << endl;

                    if(inf=="00000")
                    {
                        win=true;
                        break;
                    }


                    live--;
                    used_live++;
                }

                if(win)
                {
                    cout<< "You Win!!!" << endl;
                    cout<< "You used up " << used_live << " guesses" << endl << endl;
                }
                else
                {
                    cout<< "Game Over!!!" << endl;
                    cout<< "The word is: " << tebak << endl<<endl;

                }
            }
            break;
        }
        case 2 :
        {
            cout << "== Word List ==" << endl;
            if(word.empty())
                cout << "*No words in the list yet" << endl << endl;
            else
            {
                for(int i = 0 ; i < word.size() ; i++)
                {
                    cout << ">> " << word_up[i] << endl;
                }
            }
            cout << endl << "Add New word:" << endl;
            string input_word;

            //input word
            while(true)
            {
                cout << ">> "; cin >> input_word;
                //biar saat di save word nya gajadi uppercase smua jadi buat var baru
                string check = input_word;
                //nge uppercase smua huruf
                transform(check.begin(), check.end(), check.begin(), ::toupper);
               //ngecek alphabet
                bool alpha = true;
                for(int i = 0; i<check.size();i++)
                {
                    alpha = isalpha(check[i]);

                    if(!alpha)
                        break;
                }
                // ngecek udh ada blom wordnya
                bool same = false;
                for(int i = 0; i<word_up.size();i++)
                {
                    if(word_up[i]==check)
                        {
                            same = true;
                            break;
                        }
                }

                //parameter exit
                if(check == "EXIT")
                {
                    cout << endl;
                    break;
                }
                //kalo kata bukan 5 huruf
                if(input_word.size() != 5)
                {
                    cout << "Invalid word length! Words must be 5 characters long." << endl;
                }
                if(!alpha)
                {
                    cout << "Invalid characters! Words must consist of alphabetic characters only." << endl;
                }
                if(same)
                {
                    cout << "Invalid word! Words already exist." << endl;
                }

                if(input_word.size() != 5 || !alpha || same)
                    continue;

                word.push_back(input_word);
                word_up.push_back(check);
                cout << "*Word Saved" << endl << endl;
                break;
            }
            break;
        }
    }
    }while(main_menu!=0);
    return 0;
}

