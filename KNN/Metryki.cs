using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN
{
    class Metryki
    {
        public static double Canbera(ObiektDecyzyjny v1, ObiektDecyzyjny v2)
        {
            double suma = 0;
            foreach (var d in v1.deskryptory) suma += Math.Abs((double)(d.Value - v2.deskryptory[d.Key]) / (d.Value + v2.deskryptory[d.Key]));
            return suma;
        }

        public static double Euklidesa(ObiektDecyzyjny v1, ObiektDecyzyjny v2)
        {
            int suma = 0;
            foreach(var d in v1.deskryptory) suma += (d.Value - v2.deskryptory[d.Key]) * (d.Value - v2.deskryptory[d.Key]);
            double wynik = Math.Sqrt(suma);
            return wynik;
        }
        public static double Czebrzyszewa(ObiektDecyzyjny v1, ObiektDecyzyjny v2)
        {
            List<double> lObliczen = new List<double>();
            for (int i = 0; i < v1.deskryptory.Count; i++)
            {
                double tmp = Math.Abs((double)(v1.deskryptory[i] - v2.deskryptory[i]));
                lObliczen.Add(tmp);
            }
            return lObliczen.Max();
        }
        public static double Manhattana(ObiektDecyzyjny v1, ObiektDecyzyjny v2)
        {
            double suma = 0;
            for (int i = 0; i < v1.deskryptory.Count; i++)
            {
                double tmp = Math.Abs((double)(v1.deskryptory[i] - v2.deskryptory[i]));
                suma += tmp;
            }
            return suma;
        }
        public static double Pearsona(ObiektDecyzyjny v1, ObiektDecyzyjny v2)
        {
            double odleglosc_xy = 0;
            int n = v1.deskryptory.Count; //moje n
            double sred_x = 0, sred_y = 0, odch_stand_x = 0, odch_stand_y = 0;
            for (int k = 0; k < n; k++)
            {
                sred_x += v1.deskryptory[k];
                sred_y += v2.deskryptory[k];
            }
            sred_x /= n;
            sred_y /= n;
            for (int k = 0; k < n; k++)
            {
                odch_stand_x += Math.Pow(v1.deskryptory[k] - sred_x, 2);
                odch_stand_y += Math.Pow(v2.deskryptory[k] - sred_y, 2);
            }
            for (int k = 0; k < n; k++)
            {
                odleglosc_xy += (v1.deskryptory[k] - sred_x) * (v2.deskryptory[k] - sred_y);
            }
            odleglosc_xy /= Math.Sqrt(odch_stand_x) * Math.Sqrt(odch_stand_y);
            odleglosc_xy = 1 - Math.Abs(odleglosc_xy);
            return odleglosc_xy;
        }
    }
}
