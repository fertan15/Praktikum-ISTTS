#include <iostream>
#include <cmath>
using namespace std;

int main()
{
    const double PI = M_PI;
    int pil;
    char x = 236;

    cout << "=== Welcome to Geometry Land ===" << endl;
    cout << "Pilih dimensi benda:" << endl;
    cout << "1. 2D" << endl;
    cout << "2. 3D" << endl;
    cout << ">> "; cin>>pil;
    switch(pil)
    {
    case 1:
        {
            int pil1;
            cout << "\nPilih sisi benda:" << endl;
            cout << "1. "<< x <<" sisi" << endl;
            cout << "2. 3 sisi" << endl;
            cout << "3. 4 sisi" << endl;
            cout << ">> "; cin>>pil1;
            switch(pil1)
            {
            case 1:
                {
                    int pil1_1;
                    cout << "\nPilih bangun:" << endl;
                    cout << "1. Lingkaran" << endl;
                    cout << "2. Juring" << endl;
                    cout << ">> "; cin>>pil1_1;
                    switch(pil1_1)
                    {
                    case 1:
                        {
                            float r, luas;
                            cout << "\nMasukkan jari-jari lingkaran: "; cin>>r;
                            luas = PI * r * r;
                            cout << "Luas lingkaran: " << luas << " cm2" << endl;
                            break;
                        }
                    case 2:
                        {
                            float r, luas, theta;
                            cout << "\nMasukkan jari-jari juring: "; cin>>r;
                            cout << "Masukkan sudut theta juring: "; cin>>theta;
                            luas = (theta/360) * PI * r * r;
                            cout << "Luas juring: " << luas << " cm2" << endl;
                            break;
                        }
                    default:cout << "\nError : Input tidak valid" << endl; break;
                    }
                    break;
                }
            case 2:
                {
                    int pil1_2;
                    cout << "\nPilih bangun:" << endl;
                    cout << "1. Segitiga siku-siku" << endl;
                    cout << "2. Segitiga sembarang" << endl;
                    cout << ">> "; cin>>pil1_2;
                    switch(pil1_2)
                    {
                    case 1:
                        {
                            float a, t, luas;
                            cout << "\nMasukkan panjang alas segitiga: "; cin>>a;
                            cout << "Masukkan tinggi segitiga: "; cin>>t;
                            luas = (a*t)/2;
                            cout << "Luas segitiga siku-siku: " << luas << " cm2" << endl;
                            break;
                        }
                    case 2:
                        {
                            float a, b, c , luas, s;
                            cout << "\nMasukkan panjang sisi a: "; cin>>a;
                            cout << "Masukkan panjang sisi b: "; cin>>b;
                            cout << "Masukkan panjang sisi c: "; cin>>c;
                            s = (a+b+c)/2;
                            luas = sqrt(s*(s-a)*(s-b)*(s-c));
                            cout << "Luas segitiga sembarang: " << luas << " cm2" << endl;
                            break;
                        }
                    default:cout << "\nError : Input tidak valid" << endl; break;
                    }
                    break;
                }
            case  3:
                {
                    int pil1_3;
                    cout << "\nPilih bangun:" << endl;
                    cout << "1. Persegi/Persegi panjang" << endl;
                    cout << "2. Trapesium" << endl;
                    cout << "3. Layang-layang" << endl;
                    cout << ">> "; cin>>pil1_3;
                    switch(pil1_3)
                    {
                    case 1:
                        {
                            float p, l, luas;
                            cout << "\nMasukkan panjang Persegi/persegi panjang: "; cin>>p;
                            cout << "Masukkan lebar Persegi/persegi panjang: "; cin>>l;
                            luas = p*l;
                            cout << "Luas Persegi/Persegi panjang: " << luas << " cm2" << endl;
                            break;
                        }
                    case 2:
                        {
                            float a, b, t , luas;
                            cout << "\nMasukkan panjang sisi a: "; cin>>a;
                            cout << "Masukkan panjang sisi b: "; cin>>b;
                            cout << "Masukkan tinggi trapesium: "; cin>>t;
                            luas = ((a+b)/2)*t;
                            cout << "Luas trapesium: " << luas << " cm2" << endl;
                            break;
                        }
                    case 3:
                        {
                            float d1, d2, luas;
                            cout << "\nMasukkan panjang sisi d1: "; cin>>d1;
                            cout << "Masukkan panjang sisi d2: "; cin>>d2;
                            luas = (d1*d2)/2;
                            cout << "Luas Layang-layang: " << luas << " cm2" << endl;
                            break;
                        }
                    default:cout << "\nError : Input tidak valid" << endl; break;
                    }
                    break;
                }
            default:cout << "\nError : Input tidak valid" << endl; break;
            }
            break;
        }
    case 2:
        {
            int pil2;
            cout << "\nPilih jenis bangun:" << endl;
            cout << "1. Prisma" << endl;
            cout << "2. Limas" << endl;
            cout << "3. Bangun putar" << endl;
            cout << ">> "; cin>>pil2;
            switch(pil2)
            {
          case 1:
              {
                int pil2_1;
                cout << "\nPilih jenis bangun:" << endl;
                cout << "1. Prisma segitiga" << endl;
                cout << "2. Prisma segiempat " << endl;
                cout << ">> "; cin>>pil2_1;
                switch(pil2_1)
                {
                case 1:
                    {
                        float a, t, h, volume;
                        cout << "\nMasukkan panjang alas segitiga: "; cin>>a;
                        cout << "Masukkan tinggi segitiga: "; cin>>t;
                        cout << "Masukkan tinggi prisma segitiga: "; cin>>h;
                        volume = ((a*t)/2)*h;
                        cout << "volume prisma segitiga: " << volume << " cm3" << endl;
                        break;
                    }
                case 2:
                    {
                        float p, l, h, volume;
                        cout << "\nMasukkan panjang segiempat: "; cin>>p;
                        cout << "Masukkan lebar segiempat: "; cin>>l;
                        cout << "Masukkan tinggi prisma segiempat: "; cin>>h;
                        volume = (p*l)*h;
                        cout << "volume prisma segiempat: " << volume << " cm3" << endl;
                        break;
                    }
                default: cout << "\nError : Input tidak valid" << endl; break;

                }
                break;
              }
          case 2:
              {
                int pil2_2;
                cout << "\nPilih jenis bangun:" << endl;
                cout << "1. Limas segitiga" << endl;
                cout << "2. Limas segiempat " << endl;
                cout << ">> "; cin>>pil2_2;
                switch(pil2_2)
                {
                case 1:
                    {
                        float a, t, h, volume;
                        cout << "\nMasukkan panjang alas segitiga: "; cin>>a;
                        cout << "Masukkan tinggi segitiga: "; cin>>t;
                        cout << "Masukkan tinggi Limas segitiga: "; cin>>h;
                        volume = (1/3.0)*((a*t)/2)*h;
                        cout << "volume Limas segitiga: " << volume << " cm3" << endl;
                        break;
                    }
                case 2:
                    {
                        float p, l, h, volume;
                        cout << "\nMasukkan panjang segiempat: "; cin>>p;
                        cout << "Masukkan lebar segiempat: "; cin>>l;
                        cout << "Masukkan tinggi Limas segiempat: "; cin>>h;
                        volume = (1/3.0)*(p*l)*h;
                        cout << "volume Limas segiempat: " << volume << " cm3" << endl;
                        break;
                    }
                default: cout << "\nError : Input tidak valid" << endl; break;

                }
                break;
              }
          case 3:
              {
                int pil2_3;
                cout << "\nPilih jenis bangun:" << endl;
                cout << "1. Bola" << endl;
                cout << "2. Tabung" << endl;
                cout << "3. Kerucut " << endl;
                cout << ">> "; cin>>pil2_3;
                switch(pil2_3)
                {
                case 1:
                    {
                        float r, volume;
                        cout << "\nMasukkan jari-jari bola: "; cin>>r;
                        volume = (4/3.0)* PI *r * r * r ;
                        cout << "volume bola: " << volume << " cm3" << endl;
                        break;
                    }
                case 2:
                    {
                        float r, h, volume;
                        cout << "\nMasukkan jari-jari alas tabung: "; cin>>r;
                        cout << "Masukkan tinggi tabung: "; cin>>h;
                        volume = (PI * r * r) * h ;
                        cout << "volume tabung: " << volume << " cm3" << endl;
                        break;
                    }
                case 3:
                    {
                        float r, h, volume;
                        cout << "\nMasukkan jari-jari alas kerucut: "; cin>>r;
                        cout << "Masukkan tinggi kerucut: "; cin>>h;
                        volume = (1/3.0) * (PI * r * r) * h ;
                        cout << "volume kerucut: " << volume << " cm3" << endl;
                        break;
                    }
                default: cout << "\nError : Input tidak valid" << endl; break;
                }
                break;
              }
          default: cout << "\nError : Input tidak valid" << endl; break;

            }
            break;
        }
    default: cout << "\nError : Input tidak valid" << endl; break;
    }

    return 0;
}
