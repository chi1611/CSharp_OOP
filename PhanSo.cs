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
                throw new ArgumentException("Mẫu số không được bằng 0.");
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

    }
}
