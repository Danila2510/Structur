using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp21
{
    internal class Rabota
    {
        #region Первая задача : 


        static void Main(string[] args)
        {
            Vector vec = new Vector(2, 3, 4);
            vec.MultNum(2);
            vec.Show();
            Vector vec1 = new Vector(1, 2, 3);
            vec1.SumVector(vec);
            vec1.Show();
            Console.WriteLine();
            Decyatichnoe dec = new Decyatichnoe(31);
            int bin = dec.ToBin();
            int oct = dec.ToOct();
            int sixt = dec.ToOct();
            Console.WriteLine(bin + "\n " + oct + "\n " + sixt + "\n ");
            RGB rgb = new RGB(255, 122, 0);
            rgb.ToHSL();
            rgb.ToHEX();
            rgb.ToCMYK();
        }
          struct Vector
        {
            public int a;
            public int b;
            public int c;
            public Vector(int a, int b, int c)
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }
            public void Show() => Console.WriteLine($" -A {a}\n -B {b}\n -C {c}\n");
            public void MultNum(int d)
            {
                a *= a;
                b *= a;
                c *= a;
            }
            public void SumVector(Vector q)
            {
                this.a += q.a;
                this.b += q.b;
                this.c += q.c;
            }
            public void SubVector(Vector v)
            {
                this.a -= v.a;
                this.b -= v.b;
                this.c -= v.c;
            }
        }
        #endregion
    }
}
#region Вторая задача : 
struct Decyatichnoe
{
    public int nomer;
    public Decyatichnoe(int nomer) => this.nomer = nomer;
    public int Get()
    {
        return this.nomer;
    }
    public int ToBin()
    {
        int bin = 0, k = 1;
        while (Convert.ToBoolean(nomer))
        {
            bin += (nomer % 2) * k;
            k *= 10;
            nomer /= 2;
        }
        return bin;
    }
    public int ToOct()
    {
        int count = 1, k = 1;
        int copy_num = nomer;
        while (nomer > 7)
        {
            count++;
            copy_num /= 8;
        }
        int buf = 0;
        for (int i = 0; i < count - 1; i++)
        {
            buf += (nomer % 8) * k;
            k *= 10;
            nomer /= 8;
        }
        return buf;
    }
    public int ToSixt()
    {
        string buf = Convert.ToString(nomer, 16).ToUpper();
        return Convert.ToInt32(buf);
    }
}
#endregion

#region Третья задача :
struct RGB
{
    public int red;
    public int green;
    public int blue;
    public RGB(int red, int green, int blue)
    {
        this.red = red;
        this.green = green;
        this.blue = blue;
    }
    public void ToHSL()
    {
        float _Read = (red / 255f);
        float _Grean = (green / 255f);
        float _Blue = (blue / 255f);

        float _Minimum = Math.Min(Math.Min(_Read, _Grean), _Blue);
        float _Maximum = Math.Max(Math.Max(_Read, _Grean), _Blue);
        float _Delta = _Minimum - _Maximum;

        float H = 0;
        float S = 0;
        float L = (float)((_Minimum + _Maximum) / 2.0f);

        if (_Delta != 0)
        {
            if (L < 0.5f)
            {
                S = (float)(_Delta / (_Minimum + _Maximum));
            }
            else
            {
                S = (float)(_Delta / (2.0f - _Minimum - _Maximum));
            }


            if (_Read == _Minimum)
            {
                H = (_Grean - _Blue / _Delta);
            }
            else if (_Grean == _Minimum)
            {
                H = 2f + (_Blue - _Read) / _Delta;
            }
            else if (_Blue == _Minimum)
            {
                H = 4f + (_Read - _Grean) / _Delta;
            }
        }
        Console.WriteLine($"{H}\n{S}\n{L}");
    }
    public void ToHEX()
    {
        Console.WriteLine("{0:X2}{1:X2}{2:X2}\n", red, green, blue);
    }
    public void ToCMYK()
    {
        double dr = (double)red / 255;
        double dg = (double)green / 255;
        double db = (double)blue / 255;
        double k = 1 - Math.Max(Math.Max(dr, dg), db);
        double c = (1 - dr - k) / (1 - k);
        double m = (1 - dg - k) / (1 - k);
        double y = (1 - db - k) / (1 - k);
        Console.WriteLine($"{c:F1}\n{m:F1}\n{y:F1}\n{k:F1}\n");
    }

}
#endregion