using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Bài tập 1: Vector2D
            Vector2D v1 = new Vector2D(3, 4);
            Vector2D v2 = new Vector2D(1, 2);

            Console.WriteLine($"v1 = {v1}");             // (3.00, 4.00)
            Console.WriteLine($"v2 = {v2}");             // (1.00, 2.00)
            Console.WriteLine($"v1 + v2 = {v1 + v2}");  // (4.00, 6.00)
            Console.WriteLine($"v1 - v2 = {v1 - v2}");  // (2.00, 2.00)
            Console.WriteLine($"v1 * 2  = {v1 * 2}");   // (6.00, 8.00)
            Console.WriteLine($"3 * v2  = {3 * v2}");   // (3.00, 6.00)
            Console.WriteLine($"-v1    = {-v1}");        // (-3.00, -4.00)
            Console.WriteLine($"|v1|   = {v1.DoDai:F4}"); // 5.0000

            //yc1: == và !=
            Vector2D v3 = new Vector2D(3, 4);

            Console.WriteLine($"\nv1 == v3 : {v1 == v3}");
            Console.WriteLine($"v1 != v2 : {v1 != v2}");

            //2: Tích vô hướng
            double dot = v1 * v2;
            Console.WriteLine($"v1 * v2 (dot product) = {dot}");

            //3: implicit tuple -> Vector2D
            Vector2D v4 = (3.0, 4.0);

            Console.WriteLine($"v4 = {v4}");

            // bài tập 2: Money
            Money luong = new Money(15_000_000, "VND");
            Money thuong = new Money(3_000_000, "VND");
            Money lamThemGio = luong * 1.5m;  // Luong lam them = 1.5x luong

            Console.WriteLine($"\nLuong co ban:   {luong}");
            Console.WriteLine($"Thuong thang:   {thuong}");
            Console.WriteLine($"Luong lam them: {lamThemGio}");
            Console.WriteLine($"Tong thu nhap:  {luong + thuong}");
            Console.WriteLine($"Luong > Thuong: {luong > thuong}");  // True

            // Kiem tra bep logic – khac don vi
            try
            {
                Money usd = new Money(100, "USD");
                Money tong = luong + usd;  // Nem ngoai le!
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Loi: {ex.Message}");
                // In: Loi: Khong the thuc hien phep toan giua VND va USD...
            }

            // nâng cao
            Money usd100 = new Money(100, "USD");

            // Quy đổi
            Money vnd = Money.QuyDoi(usd100, "VND", 25500);
            Console.WriteLine($"\nQuy doi: {vnd}");

            // ==
            Money m1 = new Money(100, "USD");
            Money m2 = new Money(100, "USD");
            Money m3 = new Money(100, "VND");

            Console.WriteLine($"m1 == m2: {m1 == m2}");
            Console.WriteLine($"m1 != m3: {m1 != m3}");

            // Chia hóa đơn
            Money tongHoaDon = new Money(800000, "VND");
            Money moiNguoi = tongHoaDon / 4;

            Console.WriteLine("\nNhan phim bat ky de thoat..."); ;
            Console.ReadKey();
        }
    }
}
