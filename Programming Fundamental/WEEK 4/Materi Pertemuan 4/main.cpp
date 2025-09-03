#include <iostream>
using namespace std;

int main()
{
    int tileSize, boardSize;
    cout << "Input board size: ";
    cin >> boardSize;
    cout << "Input tile size: ";
    cin >> tileSize;

    // top border
    for (int i=0; i<boardSize*(tileSize+1)+1; i++) {
        cout << "X ";
    }
    cout << endl;

    // board height
    for (int k = 0; k < boardSize; k++) {
        // tile height
        for (int i = 0; i <= tileSize; i++) {
            // left border
            cout << "X ";
            // board width
            for (int l = 0; l < boardSize; l++) {
                // tile width
                for (int j = 0; j <= tileSize; j++) {
                    if (i == tileSize || j == tileSize) {
                        // right and bottom border
                        cout << "X ";
                    } else if (i+j>=tileSize-1 && k%2==0 && l%2==0) {
                        // top left pattern
                        cout << "* ";
                    } else if (i+j<tileSize && k%2==1 && l%2==0) {
                        // bottom left pattern
                        cout << "* ";
                    } else if (i >= j && k%2==0 && l%2==1) {
                        // top right pattern
                        cout << "* ";
                    } else if (i <= j && k%2==1 && l%2==1) {
                        // bottom right pattern
                        cout << "* ";
                    } else {
                        // spacing
                        cout << "  ";
                    }
                }
            }
            cout << endl;
        }
    }

    return 0;
}
