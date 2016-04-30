using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN
{
    public class MacierzPredykcji
    {
        public List<Koncept> listaKonceptow = new List<Koncept>();
        public Dictionary<int, double> accuracy = new Dictionary<int, double>();
        public Dictionary<int, double> coverage = new Dictionary<int, double>();
        public Dictionary<int, double> trupePositiveRate = new Dictionary<int, double>();
        public Dictionary<int, int> liczbaObiektówPoprawnieSklasyfikowanych = new Dictionary<int, int>();
        public Dictionary<int, int> liczbaObiektówChwyconych = new Dictionary<int, int>();
        public Dictionary<int, int> liczbaObiektów = new Dictionary<int, int>();
        public Dictionary<int, int> liczbaObiektówZPozostałychKlasBłędnieTrafiających = new Dictionary<int, int>();
        public int liczbaWszystkichPoprawnieSklasyfikowanych = 0;
        public int liczbaWszystkichChwyconych = 0;
        public int liczbaWszystkichObiektowWCalymSystemie = 0;
        //ilosc wszystkich obiektow to testowy.obiekty.count
        double accuracyGlobal; 
        double coverageGlobal;
        //ilość obiektów konkretnej klasy decyzyjnej (konceptu) 
        public MacierzPredykcji(SystemDecyzyjny testowy,List<int> koncepty)
        {
            testowy.koncepty = koncepty;
            PoliczPokrycie(testowy);
            foreach(Koncept koncept in listaKonceptow)
            {
                PoliczParametryDlaKonceptu(koncept,testowy.obiekty);
                PoliczParametryDlaKonceptu(koncept,listaKonceptow);
                liczbaWszystkichPoprawnieSklasyfikowanych += liczbaObiektówPoprawnieSklasyfikowanych[koncept.decyzja];
                liczbaWszystkichChwyconych += liczbaObiektówChwyconych[koncept.decyzja];
            }
            liczbaWszystkichObiektowWCalymSystemie = testowy.obiekty.Count;
            accuracyGlobal = (double)liczbaWszystkichPoprawnieSklasyfikowanych / liczbaWszystkichChwyconych;
            coverageGlobal = (double)liczbaWszystkichChwyconych / liczbaWszystkichObiektowWCalymSystemie;
            
        }

        private void PoliczParametryDlaKonceptu(Koncept koncept, List<Koncept> listaKonceptow)
        {
            liczbaObiektówZPozostałychKlasBłędnieTrafiających[koncept.decyzja] = 0;

           
            foreach(Koncept konceptDLTPR in listaKonceptow)
            {
                liczbaObiektówZPozostałychKlasBłędnieTrafiających[koncept.decyzja] += konceptDLTPR.pokrycie[koncept.decyzja]; 
            }
            trupePositiveRate[koncept.decyzja] = (double)liczbaObiektówPoprawnieSklasyfikowanych[koncept.decyzja] / (liczbaObiektówPoprawnieSklasyfikowanych[koncept.decyzja] + liczbaObiektówZPozostałychKlasBłędnieTrafiających[koncept.decyzja]);

        }

        private void PoliczParametryDlaKonceptu(Koncept koncept, List<ObiektDecyzyjny> obiekty)
        {
            liczbaObiektówPoprawnieSklasyfikowanych[koncept.decyzja] = 0;
            liczbaObiektówChwyconych[koncept.decyzja] = 0;
            liczbaObiektów[koncept.decyzja] = PoliczLiczbęObiektów(koncept.decyzja,obiekty);
            
            
            foreach(var d in koncept.pokrycie)
            {
                if (koncept.decyzja == d.Key) liczbaObiektówPoprawnieSklasyfikowanych[koncept.decyzja] += d.Value;
                liczbaObiektówChwyconych[koncept.decyzja] += d.Value;
            }
            accuracy[koncept.decyzja] = (double)liczbaObiektówPoprawnieSklasyfikowanych[koncept.decyzja] / liczbaObiektówChwyconych[koncept.decyzja];
            coverage[koncept.decyzja] = (double)liczbaObiektówChwyconych[koncept.decyzja] / liczbaObiektów[koncept.decyzja];
          
        }
        private int PoliczLiczbęObiektów(int aKlasaDecyzyjna,List<ObiektDecyzyjny> obiekty)
        {
            int licznik = 0;
            for (int i = 0; i < obiekty.Count; i++)
            {
                if (obiekty[i].decyzja == aKlasaDecyzyjna) licznik++;
            }
            return licznik;
        }


        private Dictionary<int,int> WypełnijZerami(SystemDecyzyjny a , Dictionary<int,int> moj)
        {
            foreach(int koncept in a.koncepty)
            {
                moj[koncept] = 0; 
            }
            return moj;
        }
        private void PoliczPokrycie (SystemDecyzyjny testowy)
        {
            Dictionary<int, int> p = new Dictionary<int, int>();
            p = WypełnijZerami(testowy, p);
            foreach (int koncept in testowy.koncepty)
            {
                foreach (ObiektDecyzyjny obiekt in testowy.obiekty)
                {
                    if ((obiekt.klasyfikacja == 1 || obiekt.klasyfikacja == 0) && (obiekt.decyzja == koncept))
                        p[obiekt.otrzymanaDecyzja] += 1;
                }

                Koncept pMojKoncept = new Koncept(koncept, p);
                p = new Dictionary<int, int>();
                p = WypełnijZerami(testowy, p);
                listaKonceptow.Add(pMojKoncept);
            }
        } 

        public static string PrzekonwertujNaNapis(MacierzPredykcji macierz)
        {
            string napis="Klasy Decyzyjne |";
            napis += "          ";
            foreach(Koncept koncept in macierz.listaKonceptow)
            {
                napis += "      "; //odstęp
                napis += koncept.decyzja;
                napis += "           |      "; //odstęp
            }
            napis += "Liczba Obiektów  | Accuracy | Coverage\n";

            foreach(Koncept koncept in macierz.listaKonceptow)
            {
                napis += "             ";
                napis += koncept.decyzja.ToString();
                napis += "                            ";
                foreach(var d in koncept.pokrycie)
                {
                    napis += d.Value;
                    napis += "                        ";
                }
                napis += "  "; //odstęp
                napis += macierz.liczbaObiektów[koncept.decyzja];
                napis += "                      "; //odstęp
                napis += macierz.accuracy[koncept.decyzja].ToString("F2");
                napis += "          "; //odstęp
                napis += macierz.coverage[koncept.decyzja].ToString("F2");
                napis += "\n"; //nowa linia

            }
            napis += "==============================================================================\n";
            napis += "True Positive Rate:         ";
            foreach(Koncept koncept in macierz.listaKonceptow)
            {
                napis += macierz.trupePositiveRate[koncept.decyzja].ToString("F2");
                napis += "                   ";
            }
            napis += "\n\n";
            napis += "Wyniki Globalne \n";
            napis += "Accuracy: " + macierz.accuracyGlobal.ToString("F2")+"\n";
            napis += "Coberage: " + macierz.coverageGlobal.ToString("F2") + "\n";
            return napis;
        }
    }
}