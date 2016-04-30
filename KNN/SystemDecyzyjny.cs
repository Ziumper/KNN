using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN
{
    public delegate double Metryka(ObiektDecyzyjny obiektX, ObiektDecyzyjny obiektY);

    public class SystemDecyzyjny
    {
        public List<ObiektDecyzyjny> obiekty = new List<ObiektDecyzyjny>();
        public List<int> koncepty = new List<int>();

        public SystemDecyzyjny(string sciezkaDoPliku)
        {
            var daneZPliku = System.IO.File.ReadAllLines(sciezkaDoPliku);
            foreach (var wiersz in daneZPliku)
                if (wiersz.Trim() != "")
                    obiekty.Add(new ObiektDecyzyjny(wiersz));

           
            foreach (ObiektDecyzyjny o in obiekty)
            {
                if (!koncepty.Contains(o.decyzja)) koncepty.Add(o.decyzja);
            }
            koncepty.Sort();
        }


        public MacierzPredykcji Klasyfikuj(SystemDecyzyjny testowy, int k, Metryka metryka)
        {
            //int[] a = { 1, 1, 1 }, b = { 1, 1, 1 };
            //double wynik = metryka(a, b);
            foreach(ObiektDecyzyjny o in testowy.obiekty)
            {
                o.klasyfikacja = Klasyfikuj(o, k, metryka);
            }


            return new MacierzPredykcji(testowy,koncepty);
        }

        public int? Klasyfikuj(ObiektDecyzyjny testowy, int k, Metryka metryka)
        {
            // tu ma być opisane jak sklasyfikować jeden obiekt
            // gdy nie mogę sklasyfikować, to zwracam null
            Dictionary<int, double> moce = PoliczMoc(testowy, k, metryka);//moce każdej klasy decyzyjnej
            List<double> mojeMoce = new List<double>();

            //mojeMoce będą listą od razu po sortowaną, wartości w niej odpowiadają danemu konceptowi, czyli
            //nie muszę się bać, że coś się stanie
            foreach (var d in moce)
            {
                mojeMoce.Add(d.Value);
            }

            //sprwadzam czy została schwytana
            //przypadek kiedy wszystkie moce są sobie równe!
            bool niechwycona = true;
            for(int i = 0; i < koncepty.Count(); i++)
            {
                for(int j = 0; j < koncepty.Count(); j++)
                {
                    if (mojeMoce[i] != mojeMoce[j]) niechwycona = false;
                }
            }
            if (niechwycona) return null;

            
            //nie są równe!
            double minimum = mojeMoce.Min();//liczę minimum skoro nie są równe!
            if (koncepty[mojeMoce.IndexOf(minimum)] == testowy.decyzja) {// warunek na to czy dobrze sklasyfikowane czy też źle.
                testowy.otrzymanaDecyzja = koncepty[mojeMoce.IndexOf(minimum)];//otrzymana decyzja w wyniku klasyfikacji
                return 1;
            }

            testowy.otrzymanaDecyzja = koncepty[mojeMoce.IndexOf(minimum)];
            return 0;
            //przepiusje do listy, sortuje listy, zwracam najmniejsza możliwa :) w przeciwnym wypadku nie ma co się męczyć
            
        }

        private Dictionary<int,double> PoliczMoc(ObiektDecyzyjny testowy,int k ,Metryka metryka)
        {
            Dictionary<int, double> moc = new Dictionary<int, double>();
            List<List<double>> policzoneMetrykiDanegoKonceptu = new List<List<double>>();
         

            //rozdzielenie wartości metryk na koncpety !!
            for (int i = 0; i < koncepty.Count(); i++)
            {
                List<double> listaWartosci = new List<double>();
                foreach (ObiektDecyzyjny o in obiekty)
                {
                    if (koncepty[i] == o.decyzja)
                    {
                       
                        listaWartosci.Add(metryka(testowy, o));
                    }
                }
                policzoneMetrykiDanegoKonceptu.Add(listaWartosci);
            }
            for(int i = 0; i < koncepty.Count; i++)
            {
                moc[koncepty[i]] = 0;
            }
            //liczę sume najbliższych
            int licznik = 0;
            foreach (List<double> lista in policzoneMetrykiDanegoKonceptu)
            {
                
                lista.Sort();
                for(int i = 0; i < k; i++)
                {
                    moc[koncepty[licznik]] = moc[koncepty[licznik]] + lista[i];
                }
                licznik++;
            }
            return moc;
        }
    }
}
