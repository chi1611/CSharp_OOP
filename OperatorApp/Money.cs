using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorApp
{
    public class Money
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }

        public Money(decimal amount, string currency)
        {
            if (amount < 0)
                throw new ArgumentException("So tien khong the am!");
            Amount = amount;
            Currency = currency.ToUpper();
        }

        // Ham kiem tra cung don vi – dung lai trong nhieu toan tu
        private static void KiemTraCungDonVi(Money a, Money b)
        {
            if (a.Currency != b.Currency)
                throw new InvalidOperationException(
                    $"Khong the thuc hien phep toan giua {a.Currency} va {b.Currency}. " +
                    $"Vui long quy doi ve cung don vi truoc.");
        }

        public static Money operator +(Money a, Money b)
        {
            KiemTraCungDonVi(a, b);
            return new Money(a.Amount + b.Amount, a.Currency);
        }

        public static Money operator -(Money a, Money b)
        {
            KiemTraCungDonVi(a, b);
            if (a.Amount < b.Amount)
                throw new InvalidOperationException("Ket qua tru khong duoc am!");
            return new Money(a.Amount - b.Amount, a.Currency);
        }
        // Nhan voi he so (vi du: tinh luong lam them gio)
        public static Money operator *(Money m, decimal heSo)
        {
            if (heSo < 0)
                throw new ArgumentException("He so khong the am!");
            return new Money(m.Amount * heSo, m.Currency);
        }

        public static Money operator *(decimal heSo, Money m) => m * heSo;

        public static bool operator >(Money a, Money b)
        {
            KiemTraCungDonVi(a, b);
            return a.Amount > b.Amount;
        }

        public static bool operator <(Money a, Money b)
        {
            KiemTraCungDonVi(a, b);
            return a.Amount < b.Amount;
        }
        public override string ToString()
            => $"{Amount:N0} {Currency}";
        // Yêu cầu nâng cao:
        //1. cài đặt phương thức QuyDoi để quy đổi giữa các loại tiền tệ khác nhau dựa trên tỷ giá
        public static Money QuyDoi(Money nguon, string donViDich, decimal tyGia)
        {
            if (tyGia <= 0)
                throw new ArgumentException("Ty gia phai lon hon 0!");

            return new Money(nguon.Amount * tyGia, donViDich);
        }
        //2. cài đặt operator == và != để so sánh 2 đối tượng Money có bằng nhau hay không (cùng số tiền và cùng đơn vị tiền tệ)
        public static bool operator ==(Money a, Money b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;

            return a.Amount == b.Amount &&
                   a.Currency == b.Currency;
        }

        public static bool operator !=(Money a, Money b)
        {
            return !(a == b);
        }
        public override bool Equals(object obj)
        {
            if (obj is Money other)
                return this == other;

            return false;
        }

        public override int GetHashCode()
        {
            return Amount.GetHashCode() ^ Currency.GetHashCode();
        }
        //3. cài đặt operator / để chia một đối tượng Money cho một số nguyên (ví dụ: chia tiền cho số người trong một nhóm)
        public static Money operator /(Money m, int soNguoi)
        {
            if (soNguoi <= 0)
                throw new DivideByZeroException("So nguoi phai lon hon 0!");

            return new Money(m.Amount / soNguoi, m.Currency);
        }
    }

}
