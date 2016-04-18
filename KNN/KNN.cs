using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KNN
{
    public partial class KNNForm : Form
    {
        int[][] STreningowy;
        int[][] STestowy;
        int[] KlasyDecyzyjne;

        public KNNForm()
        {
            InitializeComponent();

            cBMetryka.DataSource = typeof(Metryki).GetMethods().Where(
                metoda => metoda.IsStatic &&
                          metoda.ReturnType == typeof(double) &&
                          metoda.GetParameters().Length == 2 
            ).ToList();

            cBMetryka.DisplayMember = "Name";


            btnTRN.Enabled = false;
            btnTST.Enabled = false;
            cBKnn.Enabled = false;
            cBMetryka.Enabled = false;
            btnWyniki.Enabled = false;
        }

        private void btnWczytaj_Click(object sender, EventArgs e)
        {
            cBKnn.Items.Clear();
            var wynik = ofdSystemTreningowy.ShowDialog();
            if (wynik != DialogResult.OK) return;
            STreningowy = KonwertujDane(System.IO.File.ReadAllText(ofdSystemTreningowy.FileName));
            btnTRN.Enabled = true;
            wynik = ofdSystemTestowy.ShowDialog();
            if (wynik != DialogResult.OK) return;
            STestowy = KonwertujDane(System.IO.File.ReadAllText(ofdSystemTestowy.FileName));
            btnTST.Enabled = true;
          
            
            cBMetryka.Enabled = true;
            KlasyDecyzyjne = PoliczKlasyDecyzyjne().ToArray<int>();
            int k = PoliczMinK();
            for(int i =1; i <= k; i++)
            {
                cBKnn.Items.Add(i);
            }

        }

        private int PoliczMinK()
        {
            List<int> lista = new List<int>();
            int licznik = 0;
            for(int i = 0; i < KlasyDecyzyjne.Length; i++)
            {
                
                for(int j = 0; j < STreningowy.Length; j++)
                {
                    if (KlasyDecyzyjne[i] == STreningowy[j].Last<int>()) licznik++;
                }
                lista.Add(licznik);
                licznik = 0;
            }
            return lista.Min();
        }

        private int[][] KonwertujDane(string trescPliku)
        {
            string[] poziomy = trescPliku.Split('\n');//dzeli ze względu na \n
            int[][] daneZPliku = new int[poziomy.Length][];

            for (int i = 0; i < poziomy.Length; i++)
            {
                string poziom = poziomy[i].Trim();//kasuje znaki tutaj \r
                string[] miejscaParkingowe = poziom.Split(' ');//dzieli ze względu na ' '
                daneZPliku[i] = new int[miejscaParkingowe.Length];
                for (int j = 0; j < miejscaParkingowe.Length; j++)
                {
                    daneZPliku[i][j] = int.Parse(miejscaParkingowe[j]);
                }
            }
            return daneZPliku;
        }

        private void btnTRN_Click(object sender, EventArgs e)
        {
            Wyswietlacz wysSystemTreningowy = new Wyswietlacz(System.IO.File.ReadAllText(ofdSystemTreningowy.FileName),"System Treningowy");
            wysSystemTreningowy.Show();
        }

        private void btnTST_Click(object sender, EventArgs e)
        {
            Wyswietlacz wysSystemTestowy = new Wyswietlacz(System.IO.File.ReadAllText(ofdSystemTestowy.FileName), "System Testowy");
            wysSystemTestowy.Show();
        }

       
        private void cBKnn_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnWyniki.Enabled = true;
        }

        private void cBMetryka_SelectedIndexChanged(object sender, EventArgs e)
        {
            cBKnn.Enabled = true;       
        }


        //GŁÓWNA FUNKCJA LICZĄCA!
        private void btnWyniki_Click(object sender, EventArgs e)//działamy!
        {
            SystemDecyzyjny testowy = new SystemDecyzyjny(ofdSystemTestowy.FileName);
            var trenignowy = new SystemDecyzyjny(ofdSystemTreningowy.FileName);
            int k = 3;

            Metryka metryka = (Metryka)Delegate.CreateDelegate(typeof(Metryka), cBMetryka.SelectedItem as System.Reflection.MethodInfo);
            //var macierz = trenignowy.Klasyfikuj(testowy, k, );



            List<int> klasyfikacje = new List<int>();
            double[][] metryka = PoliczMetrykę(cBMetryka.SelectedItem.GetHashCode());

            //liczę Klasyfikacje
            for (int x = 0; x < metryka.Length; x++)
            {
                klasyfikacje.Add(PoliczKlasyfikacje(metryka[x]));
            }
            List<Dictionary<int, int>> listaPokryc = new List<Dictionary<int, int>>();
            for (int c = 0; c < KlasyDecyzyjne.Length; c++)
            {
                listaPokryc.Add(PoliczPokrycie(klasyfikacje, KlasyDecyzyjne[c]));
            }

            //liczę Ogólnie chwycone obiekty
            Dictionary<int, int> ogólnieChwycone = PoliczChwycone(klasyfikacje);
            //zaznaczam które są nie poprawne
            klasyfikacje = PoprawKlasyfikacje(klasyfikacje);
            //Liczę te poprawnie chwycone
            Dictionary<int, int> poprawnieSklasyfikowane = PoliczSklasyfikowane(klasyfikacje);
            Dictionary<int, int> błędnieSklasyfikowane = PoliczBłędnieSklasyfikowane(klasyfikacje);
            //liczę ilość obiektów dla każdej klasy decyzyjnej
            Dictionary<int, int> liczbaObiektów = PrzyporządkujIloscObiektówDoDanejKlasyDecyzyjnej();
            //Liczę parametry
            List<Dictionary<string, double>> listaParametrówDlaKlasDecyzyjnych = new List<Dictionary<string, double>>();
            for (int c = 0; c < KlasyDecyzyjne.Length; c++)
            {
                listaParametrówDlaKlasDecyzyjnych.Add(PoliczParametry(KlasyDecyzyjne[c], poprawnieSklasyfikowane, ogólnieChwycone, liczbaObiektów, błędnieSklasyfikowane));
            }
            Dictionary<string, double> listaParametrówGlobalnych = new Dictionary<string, double>();
            listaParametrówGlobalnych["Accuracy"] = PoliczAccuracy(PoliczSumę(poprawnieSklasyfikowane), PoliczSumę(ogólnieChwycone));
            listaParametrówGlobalnych["Coverage"] = PoliczCoverage(PoliczSumę(ogólnieChwycone), STestowy.Length);

            //wyświetlanie.
            string napis = "Klasa Decyzyjna | ";
            for (int c = 0; c < KlasyDecyzyjne.Length; c++)
            {
                napis += " " + KlasyDecyzyjne[c].ToString() + " | ";
            }
            napis += "Liczba Obiektów | Accuracy | Coverage | True Positive Rate\n";

            int klasa = 0;
            foreach (Dictionary<string, double> parametry in listaParametrówDlaKlasDecyzyjnych)
            {
                napis += "          ";
                napis += parametry["Klasa Decyzyjna"].ToString();
                napis += "                  ";
                for (int c = 0; c < KlasyDecyzyjne.Length; c++)
                {
                    napis += listaPokryc[klasa][KlasyDecyzyjne[c]];
                    napis += "   ";
                }
                napis += "       ";
                napis += parametry["Liczba Obiektów"].ToString();
                napis += "                     ";
                napis += parametry["Accuracy"].ToString("F2");
                napis += "                 ";
                napis += parametry["Coverage"].ToString("F2");
                napis += "                ";
                napis += parametry["True Positive Rate"].ToString("F2");
                napis += "                  \n";
                klasa++;
            }
            napis += "\nWyniki globalne\n Accuracy:  ";
            napis += listaParametrówGlobalnych["Accuracy"].ToString("F2") + "\n Coverage:  ";
            napis += listaParametrówGlobalnych["Coverage"].ToString("F2") + "\n";
            
            Wyswietlacz wysWyniki = new Wyswietlacz(napis,"Macierz Predykcji   | Użyta Metryka:"+cBMetryka.SelectedItem+" |    DLA k = " + cBKnn.SelectedItem);
            wysWyniki.Show();
        }

        //To DO Implementacja 
        private Dictionary<int,int> PoliczPokrycie(List<int> aKlasyfikacje,int aKlasaDecyzyjna)
        {
            Dictionary<int, int> pokrycie = new Dictionary<int, int>();
            
            for (int d = 0; d < KlasyDecyzyjne.Length; d++)
            {
                int licznik = 0;
                for (int m = 0; m < STestowy.Length; m++)
                {
                    if (aKlasyfikacje[m] == -1) continue;
                    if (STestowy[m].Last<int>() == aKlasaDecyzyjna && KlasyDecyzyjne[d] == aKlasyfikacje[m]) licznik++;

                }
                pokrycie.Add(KlasyDecyzyjne[d], licznik);
            }
            return pokrycie;

        }
        private Dictionary<string, double> PoliczParametry(int aKlasaDecyzyjna, Dictionary<int, int> aPoprawnieSklasyfikowane, Dictionary<int, int> aOgólnieChwycone, Dictionary<int, int> aLiczbaObiektów,Dictionary<int,int> aBłędnieSklasyfikowane)
        {
            Dictionary<string, double> parametryDlaKlasDecyzyjnych = new Dictionary<string, double>();
            parametryDlaKlasDecyzyjnych["Klasa Decyzyjna"] = aKlasaDecyzyjna;
            parametryDlaKlasDecyzyjnych["Liczba Obiektów"] = PoliczLiczbęObiektów(aKlasaDecyzyjna);
            parametryDlaKlasDecyzyjnych["Accuracy"] = PoliczAccuracy(aPoprawnieSklasyfikowane[aKlasaDecyzyjna], aOgólnieChwycone[aKlasaDecyzyjna]);
            parametryDlaKlasDecyzyjnych["Coverage"] = PoliczCoverage(aOgólnieChwycone[aKlasaDecyzyjna], aLiczbaObiektów[aKlasaDecyzyjna]);
            parametryDlaKlasDecyzyjnych["True Positive Rate"] = PoliczTruePositiveRate(aPoprawnieSklasyfikowane[aKlasaDecyzyjna], aBłędnieSklasyfikowane[aKlasaDecyzyjna]);
            return parametryDlaKlasDecyzyjnych;
        }
        private double PoliczTruePositiveRate(int aLiczbaObiektówPoprawnieSklasyfikownaychWKlasieDecyzyjnej,int aLiczbaObiektówZPozostałychKlasBłednieTrafiającychDoKlasyDecyzyjnej)
        {
            return (double)aLiczbaObiektówPoprawnieSklasyfikownaychWKlasieDecyzyjnej / (aLiczbaObiektówPoprawnieSklasyfikownaychWKlasieDecyzyjnej + aLiczbaObiektówZPozostałychKlasBłednieTrafiającychDoKlasyDecyzyjnej);
        }
        private double PoliczCoverage(int aLiczbaObiektówChwyconych,int aLiczbaObiektów)
        {
            return (double)aLiczbaObiektówChwyconych / aLiczbaObiektów;
        }
     
        private double PoliczAccuracy(int aLiczbaObiektówPoprawnieSklasyfikowanych, int aLiczbaObiektówChwyconych)
        {
            return (double)aLiczbaObiektówPoprawnieSklasyfikowanych/aLiczbaObiektówChwyconych;
        }
       
        //tutaj!
      
        private double[][] PoliczMetrykę(int aRodzajMetryki)
        {
            double[][] Wyniki = null;
            switch (aRodzajMetryki)
            {
                case -1874933663://Euklidesa
                    Wyniki = MetrykaEuklidesa();
                    break;
                case -1384624843://Canbera
                    Wyniki = MetrykaCanbera();
                    break;
                case -874348240://Czebrzyszewa
                    Wyniki = MetrykaCzebrzyszewa();
                    break;
                case 1812290935://Manhattan
                    Wyniki = MetrykaManhattan();
                    break;
                case 435799091: //Bez. współ. korel. Pearsona
                    Wyniki = BezwzględnyWspółczynnikKorelacjiPearsona();
                    break;
            }
            return Wyniki;
        }
        //Liczymy metryki
        private double[][] MetrykaEuklidesa() {
            double[][] wyniki = new double[STestowy.Length][];
            for(int x = 0; x < STestowy.Length; x++)//pętla po obiektach systemu Testowego
            {
                wyniki[x] = new double[STreningowy.Length];
                for (int y = 0; y < STreningowy.Length; y++)//pętla po obiektach systemu Treningowego
                   wyniki[x][y] = EuklidesaWiersz(STestowy[x], STreningowy[y]);
            }
            
            return wyniki;
        }
        private double EuklidesaWiersz(int[] aWierszTestowy, int[] aWierszTreningowy)
        {
            int suma = 0;
            for(int i = 0; i < aWierszTestowy.Length-1; i++)
            {
                    int tmp = (aWierszTestowy[i] - aWierszTreningowy[i]) * (aWierszTestowy[i] - aWierszTreningowy[i]);
                    suma += tmp;
            }
            
            double wynik = Math.Sqrt(suma);
            return wynik;
        }
        private double[][] MetrykaCanbera()
        {
            double[][] wyniki = new double[STestowy.Length][];
            for (int x = 0; x < STestowy.Length; x++)//pętla po obiektach systemu Testowego
            {
                wyniki[x] = new double[STreningowy.Length];
                for (int y = 0; y < STreningowy.Length; y++)//pętla po obiektach systemu Treningowego
                    wyniki[x][y] = CanberaWiersz(STestowy[x], STreningowy[y]);
            }

            return wyniki;
        }

        private double CanberaWiersz(int[] v1, int[] v2)
        {
            double suma = 0;
            for(int i = 0; i < v1.Length-1; i++)
            {
                double tmp =Math.Abs((double)(v1[i] - v2[i])/(v1[i]+v2[i]));
                suma += tmp;
            }
            return suma;
        }

        private double[][] MetrykaCzebrzyszewa()
        {
            double[][] wyniki = new double[STestowy.Length][];
            for (int x = 0; x < STestowy.Length; x++)//pętla po obiektach systemu Testowego
            {
                wyniki[x] = new double[STreningowy.Length];
                for (int y = 0; y < STreningowy.Length; y++)//pętla po obiektach systemu Treningowego
                    wyniki[x][y] = CzebrzyszewaWiersz(STestowy[x], STreningowy[y]);
            }

            return wyniki;
        }

        private double CzebrzyszewaWiersz(int[] v1, int[] v2)
        {
            List<double> lObliczen = new List<double>();
            for (int i = 0; i < v1.Length - 1; i++)
            {
                double tmp = Math.Abs((double)(v1[i] - v2[i]));
                lObliczen.Add(tmp);
            }
            return lObliczen.Max();
        }

        private double[][] MetrykaManhattan()
        {
            double[][] wyniki = new double[STestowy.Length][];
            for (int x = 0; x < STestowy.Length; x++)//pętla po obiektach systemu Testowego
            {
                wyniki[x] = new double[STreningowy.Length];
                for (int y = 0; y < STreningowy.Length; y++)//pętla po obiektach systemu Treningowego
                    wyniki[x][y] = ManhattanaWiersz(STestowy[x], STreningowy[y]);
            }

            return wyniki;
        }

        private double ManhattanaWiersz(int[] v1, int[] v2)
        {
            double suma = 0;
            for (int i = 0; i < v1.Length - 1; i++)
            {
                double tmp = Math.Abs((double)(v1[i] - v2[i]));
                suma += tmp;
            }
            return suma;
        }

        private double[][] BezwzględnyWspółczynnikKorelacjiPearsona()
        {
            double[][] wyniki = new double[STestowy.Length][];
            for (int x = 0; x < STestowy.Length; x++)//pętla po obiektach systemu Testowego
            {
                wyniki[x] = new double[STreningowy.Length];
                for (int y = 0; y < STreningowy.Length; y++)//pętla po obiektach systemu Treningowego
                    wyniki[x][y] = PearsonaWiersz(STestowy[x], STreningowy[y]);
            }

            return wyniki;
        }

        private double PearsonaWiersz(int[] v1, int[] v2)
        {
            double odleglosc_xy = 0;
            int n = v1.Length-1; //moje n
            double sred_x = 0, sred_y = 0, odch_stand_x = 0, odch_stand_y = 0;
            for (int k = 0; k < n; k++)
            {
                sred_x += v1[k];
                sred_y += v2[k];
            }
            sred_x /= n;
            sred_y /= n;
            for(int k=0;k< n; k++)
            {
                odch_stand_x += Math.Pow(v1[k] - sred_x, 2);
                odch_stand_y += Math.Pow(v2[k] - sred_y, 2);
            }
            for(int k =0;k< n;k++)
            {
                odleglosc_xy += (v1[k] - sred_x) * (v2[k] - sred_y);
            }
            odleglosc_xy /= Math.Sqrt(odch_stand_x) * Math.Sqrt(odch_stand_y);
            odleglosc_xy = 1 - Math.Abs(odleglosc_xy);
            return odleglosc_xy;
        }

        //UŻYTKOWE
        private List<int> PoliczKlasyDecyzyjne()
        {
            List<int> klasyDecyzyjne = new List<int>();
            klasyDecyzyjne.Add(STestowy[0].Last<int>());//Pobierz pierwszy element
            for (int i = 1; i < STestowy.Length; i++)
            {
                if (!klasyDecyzyjne.Contains(STestowy[i].Last<int>()))
                    klasyDecyzyjne.Add(STestowy[i].Last<int>());
            }
            klasyDecyzyjne.Sort();
            return klasyDecyzyjne;
        }
       

        //Do policzenia Parametrów
        private int PoliczLiczbęObiektówPoprawnieSklasyfikowanych(List<int> aKlasyfikacje, int aKlasaDecyzyjna)
        {
            int licznik = 0;
            foreach (int x in aKlasyfikacje)
                if (x != -2 && x != -1 && x == aKlasaDecyzyjna) licznik++;
            return licznik;
        }
        private List<int> PoprawKlasyfikacje(List<int> aKlasyfikacje)
        {
            for (int x = 0; x < STestowy.Length; x++)
            {
                if (aKlasyfikacje[x] == -1) continue;
                else if (STestowy[x].Last() != aKlasyfikacje[x]) aKlasyfikacje[x] = -2;
            }
            return aKlasyfikacje;
        }
        private int PoliczKlasyfikacje(double[] aMetrykaWiersz)
        {
            List<double> moce = new List<double>();
            for (int c = 0; c < KlasyDecyzyjne.Length; c++)
                moce.Add(PoliczMoc(aMetrykaWiersz, KlasyDecyzyjne[c]));

            bool niechwytany = true;
            for (int c = 0; c < KlasyDecyzyjne.Length; c++)
            {
                for (int ct = 0; ct < KlasyDecyzyjne.Length; ct++)
                {
                    if (moce[c] != moce[ct]) niechwytany = false;
                }
            }
            if (niechwytany) return -1;
            double min = moce.Min();
            return KlasyDecyzyjne[moce.IndexOf(min)];
        }
        private double PoliczMoc(double[] aWierszMetryki, int aKlasaDecyzyjna)
        {
            List<double> wynik = new List<double>();
            for (int y = 0; y < aWierszMetryki.Length; y++)
            {
                if (aKlasaDecyzyjna == STreningowy[y].Last<int>())
                {
                    wynik.Add(aWierszMetryki[y]);
                }
            }
            wynik.Sort();//najblżsi sąsiedzi sa najbliżej początku ;)
            double moc = 0;
            for (int k = 0; k < int.Parse(cBKnn.SelectedItem.ToString()); k++)
                moc += wynik[k];
            return moc;
        }
        private Dictionary<int,int> PoliczSklasyfikowane(List<int> aKlasyfikacje)
        {
            Dictionary<int, int> schwytane = new Dictionary<int, int>();
            for (int c = 0; c < KlasyDecyzyjne.Length; c++)
            {
                int licz = 0;
                for (int s = 0; s < STestowy.Length; s++)
                    if (aKlasyfikacje[s] != -1 && aKlasyfikacje[s] !=-2 && KlasyDecyzyjne[c] == STestowy[s].Last()) licz++;
                schwytane.Add(KlasyDecyzyjne[c],licz);
            }
            return schwytane;
        }
        private int PoliczSumę(Dictionary<int,int> aListaSchwytanych)
        {
            int suma = 0;
            for(int c = 0; c < KlasyDecyzyjne.Length; c++)
            {
                suma += aListaSchwytanych[KlasyDecyzyjne[c]];
            }
            return suma;
        }
        private Dictionary<int, int> PrzyporządkujIloscObiektówDoDanejKlasyDecyzyjnej()
        {
            Dictionary<int, int> liczbaObiektów = new Dictionary<int, int>();
            for (int c = 0; c < KlasyDecyzyjne.Length; c++)
            {
                liczbaObiektów.Add(KlasyDecyzyjne[c], PoliczLiczbęObiektów(KlasyDecyzyjne[c]));
            }
            return liczbaObiektów;
        }
        private int PoliczLiczbęObiektów(int aKlasaDecyzyjna)
        {
            int licznik = 0;
            for (int i = 0; i < STestowy.Length; i++)
            {
                if (STestowy[i].Last<int>() == aKlasaDecyzyjna) licznik++;
            }
            return licznik;
        }
        private Dictionary<int,int> PoliczChwycone(List<int> aKlasyfikacje)
        {
            Dictionary<int, int> ogólnieChwycone = new Dictionary<int, int>();
            for (int c = 0; c < KlasyDecyzyjne.Length; c++)
            {
                int licz = 0;
                for (int s = 0; s < STestowy.Length; s++)
                    if (aKlasyfikacje[s] != -1 && KlasyDecyzyjne[c] == STestowy[s].Last()) licz++;
                ogólnieChwycone.Add(KlasyDecyzyjne[c], licz);
            }
            return ogólnieChwycone;
        }
        private Dictionary<int, int> PoliczBłędnieSklasyfikowane(List<int> aKlasyfikacje)
        {
            Dictionary<int, int> błędnieSklasyfikowane = new Dictionary<int, int>();
            for(int c = 0; c < KlasyDecyzyjne.Length; c++)
            {
                int licz = 0;
                for (int s = 0; s < STestowy.Length; s++)
                    //!= Stestowy ? TPR może być == ? 
                    if (aKlasyfikacje[s] == -2 && KlasyDecyzyjne[c] != STestowy[s].Last()) licz++;
                błędnieSklasyfikowane.Add(KlasyDecyzyjne[c], licz);
            }
            return błędnieSklasyfikowane;
        }
    }
}

