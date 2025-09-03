#include <iostream>
#include <cstdlib>
#include <time.h>

using namespace std;

int main()
{
    srand(time(0));

    int dif, lives, round, win = 0, score = 0, range = 50;

    //menu
    cout << "=== Play Guess the Number ===" << endl;
    cout << "Choose your difficulty:" << endl;
    cout << "1. Easy" << endl;
    cout << "2. Medium" << endl;
    cout << "3. Hard" << endl;
    cout << ">> ";
    cin >> dif;

    //pilihan difficulty
    switch(dif)
    {
    case 1:
        lives = 10;
        round = 3;
        break;
    case 2:
        lives = 7;
        round = 5;
        break;
    case 3:
        lives = 5;
        round = 8;
        break;
    default:
        cout << "Error: Input tidak valid" << endl;
        return 0;
    }

    // loop ronde
    for(int i = 1; i <= round; i++)
    {
        int sisa_lives;
        int live = lives; // Reset lives untuk tiap ronde
        int angka = rand() % range + 1;
        bool status = false;

        cout << "\n== Round " << i << " ==" << endl;

        // Loop nebak angka
        for(int j = live; j >= 1; j--)
        {
            cout << "Lives: " << j << " | Range: 1-" << range << endl;
            int guess;
            cout << "Guess: ";
            cin >> guess;

            if(guess == angka)
            {
                cout << "Correct!" << endl;
                status = true;
                sisa_lives = j;
                win++;
                break;
            }

            if(guess < angka)
                cout << "-- Higher" << endl;
            else
                cout << "-- Lower" << endl;
        }

        //score
        if(status)
        {
            score += (sisa_lives * 10);
        }
        else
        {
            cout << "Out of lives! The number was: " << angka << endl;
        }

        cout << "Score after round " << i << ": " << score << endl;

        // nambah range
        range += 10;
    }

    // Bonus round
    if(win == round)
    {
        int sisa_lives = 0;
        range += 40; //soalnya 10 nya dah ditambah diatas
        int live = 3;
        bool status = false;

        cout << "\n== Bonus Round! ==" << endl;

        int angka = rand() % range + 1;

        // Bonus round dengan hanya 3 lives
        for(int j = live; j >= 1; j--)
        {
            cout << "Lives: " << j << " | Range: 1-" << range << endl;
            int guess;
            cout << "Guess: ";
            cin >> guess;

            if(guess == angka)
            {
                cout << "Correct!" << endl;
                status = true;
                sisa_lives = j;
                break;
            }

            if(guess < angka)
                cout << "-- Higher" << endl;
            else
                cout << "-- Lower" << endl;
        }

        //skor bonus
        if(status)
        {
            score += (sisa_lives * 30);
        }
        else
        {
            cout << "Out of lives! The number was: " << angka << endl;
        }
    }

    //skor akhir
    cout << "\nCongratulations! You completed the game!" << endl;
    cout << "Your final score is: " << score << endl;

    return 0;
}
