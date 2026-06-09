using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanSoApp
{
    public class PhanSo
    {
        public int TuSo { get; private set; }
        public int MauSo { get; private set; }
        public PhanSo(int tuSo, int mauSo)
        {
            if (mauSo == 0)
            {
                throw new ArgumentException("Mau so khong duoc bang 0. vidu:(1;0)");
            }
            // Đưa dấu âm lên tử số
            if (mauSo < 0)
            {
                tuSo = -tuSo;
                mauSo = -mauSo;
            }
            int ucln = UCLN(Math.Abs(tuSo), Math.Abs(mauSo));
            TuSo = tuSo / ucln;
            MauSo = mauSo / ucln;
        }
        private static int UCLN(int a, int b)
        {
            while (b != 0)
            {
                int t = b;
                b = a % b;
                a = t;
            }
            return a;
        }
        public PhanSo RutGon()
        {
            return new PhanSo(TuSo, MauSo); // Constructor da tu dong rut gon
        }

        public override string ToString()
        {
            if (MauSo == 1) return TuSo.ToString();
            return $"{TuSo}/{MauSo}";
        }
        //bai2: them chồng toán tử operator: + - x /
        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            int tuSo = a.TuSo * b.MauSo + b.TuSo * a.MauSo;
            int mauSo = a.MauSo * b.MauSo;
            return new PhanSo(tuSo, mauSo);
        }
        public static PhanSo operator -(PhanSo a, PhanSo b)
        {
            int tuSo = a.TuSo * b.MauSo - b.TuSo * a.MauSo;
            int mauSo = a.MauSo * b.MauSo;
            return new PhanSo(tuSo, mauSo);
        }
        public static PhanSo operator *(PhanSo a, PhanSo b)
        {
            int tuSo = a.TuSo * b.TuSo;
            int mauSo = a.MauSo * b.MauSo;
            return new PhanSo(tuSo, mauSo);
        }
        public static PhanSo operator /(PhanSo a, PhanSo b)
        {
            if (b.TuSo == 0)
            {
                throw new ArgumentException("Khong the chia tu so neu co mau so bang 0");
            }
            int tuSo = a.TuSo * b.MauSo;
            int mauSo = a.MauSo * b.TuSo;
            return new PhanSo(tuSo, mauSo);
        }
        //Yêu cầu nâng cao: Thêm operator + nhận một tham số PhanSo
        //và một tham số int để tính ps1 + 2 (cộng phân số với số nguyên).
        //Gợi ý: đổi số nguyên 2 thành phân số 2/1.
        public static PhanSo operator +(PhanSo a, int b)
        {
            return a + new PhanSo(b, 1);
        }
        //baitap3: nap chồng toán tử so sánh: ==, !=, <, >, <=, >=

        public static bool operator ==(PhanSo a, PhanSo b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
            return a.TuSo == b.TuSo && a.MauSo == b.MauSo;
        }
        public static bool operator !=(PhanSo a, PhanSo b)
        {
            return !(a == b);
        }
        public static bool operator <(PhanSo a, PhanSo b)
        {
            return a.TuSo * b.MauSo < b.TuSo * a.MauSo;
        }
        public static bool operator >(PhanSo a, PhanSo b)
        {
            return a.TuSo * b.MauSo > b.TuSo * a.MauSo;
        }
        public override bool Equals(object obj)
        {
            if (obj is PhanSo other)
            {
                return this == other;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(TuSo, MauSo);
        }


    }
}
