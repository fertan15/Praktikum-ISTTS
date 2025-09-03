#include <iostream>
#include <iomanip>

using namespace std;


int main()
{
    int jumlah,uang;
    int u100rb, u50rb,u20rb,u10rb,u5rb,u2rb,u1rb,u500,u200,u100;
    int k100rb, k50rb,k20rb,k10rb,k5rb,k2rb,k1rb,k500,k200,k100;
    int sisa_uang, sisa_kembalian;

    //output part 1
    cout << "=========================================" << endl;
    cout << "|" << setw(28) << "CHANGE CALCULATOR" << setw(12) << "|" << endl;
    cout << "|=======================================|" << endl;
    cout << "|" << setw(30) << "Jumlah yang harus dibayar: Rp"; cin >> jumlah;
    cout << "|" << setw(24) << "Jumlah yang dibayar: Rp"; cin >> uang;
    cout << "|=======================================|" << endl;

    //proses uang
    u100rb = uang/100000;
    sisa_uang = uang%100000;

    u50rb = sisa_uang/50000;
    sisa_uang = sisa_uang%50000;

    u20rb = sisa_uang/20000;
    sisa_uang = sisa_uang%20000;

    u10rb = sisa_uang/10000;
    sisa_uang = sisa_uang%10000;

    u5rb = sisa_uang/5000;
    sisa_uang = sisa_uang%5000;

    u2rb = sisa_uang/2000;
    sisa_uang = sisa_uang%2000;

    u1rb = sisa_uang/1000;
    sisa_uang = sisa_uang%1000;

    u500 = sisa_uang/500;
    sisa_uang = sisa_uang%500;

    u200 = sisa_uang/200;
    sisa_uang = sisa_uang%200;

    u100 = sisa_uang/100;
    sisa_uang = sisa_uang%100;


    //prosess kembalian

    int kembalian = uang-jumlah;

    k100rb = kembalian/100000;
    sisa_kembalian = kembalian%100000;

    k50rb = sisa_kembalian/50000;
    sisa_kembalian = sisa_kembalian%50000;

    k20rb = sisa_kembalian/20000;
    sisa_kembalian = sisa_kembalian%20000;

    k10rb = sisa_kembalian/10000;
    sisa_kembalian = sisa_kembalian%10000;

    k5rb = sisa_kembalian/5000;
    sisa_kembalian = sisa_kembalian%5000;

    k2rb = sisa_kembalian/2000;
    sisa_kembalian = sisa_kembalian%2000;

    k1rb = sisa_kembalian/1000;
    sisa_kembalian = sisa_kembalian%1000;

    k500 = sisa_kembalian/500;
    sisa_kembalian = sisa_kembalian%500;

    k200 = sisa_kembalian/200;
    sisa_kembalian = sisa_kembalian%200;

    k100 = sisa_kembalian/100;
    sisa_kembalian = sisa_kembalian%100;



    //output part 2
    cout << "|" << setw(22) << "Uang yang anda bayar:" << setw(18) << "|" << endl;
    cout << "|" << setw(10) << "Rp100.000" << setw(5) << ":" << setw(16)<< u100rb << setw(7) << "lembar" << setw(2) << "|" << endl;
    cout << "|" << setw(9) << "Rp50.000" << setw(6) << ":" << setw(16)<< u50rb << setw(7) << "lembar" << setw(2) << "|" << endl;
    cout << "|" << setw(9) << "Rp20.000" << setw(6) << ":" << setw(16)<< u20rb << setw(7) << "lembar" << setw(2) << "|" << endl;
    cout << "|" << setw(9) << "Rp10.000" << setw(6) << ":" << setw(16)<< u10rb << setw(7) << "lembar" << setw(2) << "|" << endl;
    cout << "|" << setw(8) << "Rp5.000" << setw(7) << ":" << setw(16)<< u5rb << setw(7) << "lembar" << setw(2) << "|" << endl;
    cout << "|" << setw(8) << "Rp2.000" << setw(7) << ":" << setw(16)<< u2rb << setw(7) << "lembar" << setw(2) << "|" << endl;
    cout << "|" << setw(8) << "Rp1.000" << setw(7) << ":" << setw(16)<< u1rb << setw(7) << "lembar" << setw(2) << "|" << endl;
    cout << "|" << setw(6) << "Rp500" << setw(9) << ":" << setw(18)<< u500 << setw(5) << "koin" << setw(2) << "|" << endl;
    cout << "|" << setw(6) << "Rp200" << setw(9) << ":" << setw(18)<< u200 << setw(5) << "koin" << setw(2) << "|" << endl;
    cout << "|" << setw(6) << "Rp100" << setw(9) << ":" << setw(18)<< u100 << setw(5) << "koin" << setw(2) << "|" << endl;
    cout << "|=======================================|" << endl;

    //output kembalian
    cout << "|" << setw(10) << "Kembalian" << setw(5) << ":" << setw(3)<< "Rp" << setw(20)<< kembalian << setw(2) << "|" << endl;
    cout << "|" << setw(10) << "Rp100.000" << setw(5) << ":" << setw(16)<< k100rb << setw(7) << "lembar" << setw(2) << "|" << endl;
    cout << "|" << setw(9) << "Rp50.000" << setw(6) << ":" << setw(16)<< k50rb << setw(7) << "lembar" << setw(2) << "|" << endl;
    cout << "|" << setw(9) << "Rp20.000" << setw(6) << ":" << setw(16)<< k20rb << setw(7) << "lembar" << setw(2) << "|" << endl;
    cout << "|" << setw(9) << "Rp10.000" << setw(6) << ":" << setw(16)<< k10rb << setw(7) << "lembar" << setw(2) << "|" << endl;
    cout << "|" << setw(8) << "Rp5.000" << setw(7) << ":" << setw(16)<< k5rb << setw(7) << "lembar" << setw(2) << "|" << endl;
    cout << "|" << setw(8) << "Rp2.000" << setw(7) << ":" << setw(16)<< k2rb << setw(7) << "lembar" << setw(2) << "|" << endl;
    cout << "|" << setw(8) << "Rp1.000" << setw(7) << ":" << setw(16)<< k1rb << setw(7) << "lembar" << setw(2) << "|" << endl;
    cout << "|" << setw(6) << "Rp500" << setw(9) << ":" << setw(18)<< k500 << setw(5) << "koin" << setw(2) << "|" << endl;
    cout << "|" << setw(6) << "Rp200" << setw(9) << ":" << setw(18)<< k200 << setw(5) << "koin" << setw(2) << "|" << endl;
    cout << "|" << setw(6) << "Rp100" << setw(9) << ":" << setw(18)<< k100 << setw(5) << "koin" << setw(2) << "|" << endl;
    cout << "=========================================" << endl;



    return 0;
}
