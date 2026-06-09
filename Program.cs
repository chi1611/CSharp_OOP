using PhanSoApp;
//bai1: test constructor va rut gon
Console.WriteLine(new PhanSo(2, 4));
Console.WriteLine(new PhanSo(1, -3));

try
{
    Console.WriteLine(new PhanSo(1, 0));
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
//bai2: test chồng toán tử
PhanSo ps1 = new PhanSo(1, 2);  // 1/2
PhanSo ps2 = new PhanSo(1, 3);  // 1/3

Console.WriteLine($"ps1 = {ps1}");
Console.WriteLine($"ps2 = {ps2}");
Console.WriteLine($"ps1 + ps2 = {ps1 + ps2}");  // Ket qua: 5/6
Console.WriteLine($"ps1 - ps2 = {ps1 - ps2}");  // Ket qua: 1/6
Console.WriteLine($"ps1 * ps2 = {ps1 * ps2}");  // Ket qua: 1/6
Console.WriteLine($"ps1 / ps2 = {ps1 / ps2}");  // Ket qua: 3/2
//Yêu cầu nâng cao: Thêm operator + nhận một tham số PhanSo và một tham số int để tính ps1 + 2 (cộng phân số với số nguyên).
Console.WriteLine($"ps1 + 2 = {ps1 + 2}");  // Ket qua: 5/2

//bai3: test sap xep
PhanSo ps3 = new PhanSo(1, 2);  // 1/2
PhanSo ps4 = new PhanSo(2, 4);  // 2/4 (= 1/2 sau khi rut gon)
PhanSo ps5 = new PhanSo(1, 3);  // 1/3

Console.WriteLine(ps3 == ps4);  // True  (1/2 == 2/4) vì cả hai đều được rút gọn về 1/2
Console.WriteLine(ps3 != ps5);  // True  (1/2 != 1/3)
Console.WriteLine(ps5 < ps3);   // True  (1/3 < 1/2)
Console.WriteLine(ps3 > ps5);   // True  (1/2 > 1/3)
