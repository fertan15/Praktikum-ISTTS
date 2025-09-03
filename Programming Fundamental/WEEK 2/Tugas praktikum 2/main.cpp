#include <iostream>

using namespace std;

int main()
{
    //menu + input angka
    int n1,n2,pil;
    cout << "=== Kalkulator Pintar ===" << endl;
    cout << "Masukkan angka pertama (max 3 digit): ";cin>>n1;
    cout << "Masukkan angka kedua (max 3 digit): ";cin>>n2;

    //cek validitas inputan angka
    if(n1<0 || n1>999 || n2<0 || n2>999 )
    {
        cout<<"Input angka tidak valid!"<<endl;
        return 0;
    }

    //menu + input operasi
    cout << "Pilih operasi:" << endl;
    cout << "1. Penjumlahan" << endl;
    cout << "2. Pengurangan" << endl;
    cout << "3. Perkalian" << endl;
    cout << "4. Pembagian" << endl;
    cout << "Pilihan anda: "; cin>>pil;

    //cek validitas inputan pilihan
    if(pil<1 ||  pil>4)
    {
        cout<<"Pilihan tidak valid!"<<endl;
        return 0;
    }

    int num1_1,num1_2,num1_3,num2_1,num2_2,num2_3,carry1=0,carry2=0,carry3=0,hasil=0,js=0,jp=0,jr=0,borrow1=0,borrow2=0,borrow3=0;
    num1_1 = n1/100;
    num1_2 = n1/10%10;
    num1_3 = n1%10;
    num2_1 = n2/100;
    num2_2 = n2/10%10;
    num2_3 = n2%10;

    switch(pil)
    {
        case 1 :
           cout << "\n== Penjumlahan ==" << endl;

            hasil=n1+n2;

            if(hasil>=0)
            {
                js = num1_3 + num2_3;
                if(js>9)
                {
                    carry1 = 1;
                    js-=10;
                }
                else
                    carry1 = 0;
                cout<<"Digit satuan  : "<<num1_3<<" + "<<num2_3<<"     = "<<js<<" (carry: "<<carry1<<")"<<endl;
            }

            if(hasil>9)
            {
                jp = num1_2 + num2_2 + carry1;
                if(jp>9)
                {
                    carry2 = 1;
                    jp-=10;
                }
                else
                    carry2 = 0;
                cout<<"Digit puluhan : "<<num1_2<<" + "<<num2_2<<" + "<<carry1<<" = "<<jp<<" (carry: "<<carry2<<")"<<endl;
            }

            if(hasil>99)
            {
                jr = num1_1 + num2_1 + carry2;
                if(jr>9)
                {
                    carry3 = 1;
                    jr-=10;
                }
                else
                    carry3 = 0;

                cout<<"Digit ratusan : "<<num1_1<<" + "<<num2_1<<" + "<<carry2<<" = "<<jr<<" (carry: "<<carry3<<")"<<endl;
            }

            if(hasil>999)
            {
                cout<<"Digit ribuan  :             1"<<endl;
            }

            cout<<"Hasil penjumlahan: "<<hasil<<endl;
            break;

        case 2 :
            cout << "\n== Pengurangan ==" << endl;

            //cek n1>n2
            if(n2>n1)
            {
                cout<<"Angka kedua harus lebih kecil dari angka pertama!"<<endl;
                return 0;
            }

            if(n1>=0)
            {
                js = num1_3 - num2_3;
                if(js<0)
                {
                    borrow1 = 1;
                    js+=10;
                }
                else
                    borrow1 = 0;


                cout<<"Digit satuan  : "<<num1_3<<" - "<<num2_3<<"     = "<<js<<" (borrow: "<<borrow1<<")"<<endl;
            }
            if(n1>9)
            {
                jp = (num1_2- borrow1) - num2_2;
                if(jp<0)
                {
                    borrow2 = 1;
                    jp+=10;
                }
                else
                    borrow2 = 0;
                cout<<"Digit puluhan : "<<num1_2<<" - "<<num2_2<<" - "<<borrow1<<" = "<<jp<<" (borrow: "<<borrow2<<")"<<endl;
            }
            if(n1>99)
            {
                jr = (num1_1-borrow2) - num2_1;
                if(jr<0)
                {
                    borrow3 = 1;
                    jr+=10;
                }
                else
                    carry3 = 0;

                cout<<"Digit ratusan : "<<num1_1<<" - "<<num2_1<<" - "<<borrow2<<" = "<<jr<<" (borrow: "<<borrow3<<")"<<endl;
            }
            hasil=n1-n2;
            cout<<"Hasil pengurangan: "<<hasil<<endl;

            break;

        case 3 :
            cout << "\n== Perkalian ==" << endl;
            cout << "Hasil perkalian: "<<n1<<" x "<<n2<<" = "<<(n1*n2)<< endl;
            break;

        case 4 :
            cout << "\n== Pembagian ==" << endl;
            if(n2==0)
            {
                cout<<"Tidak terdefinisi"<<endl;
                return 0;
            }
            cout << "Hasil pembagian: "<<n1<<" dibagi "<<n2<<" = "<<(n1/n2)<<" sisa "<<(n1%n2)<< endl;
            break;
    }

    return 0;
}
