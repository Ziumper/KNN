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
            SystemDecyzyjny trenignowy = new SystemDecyzyjny(ofdSystemTreningowy.FileName);
            Metryka metryka = (Metryka)Delegate.CreateDelegate(typeof(Metryka), cBMetryka.SelectedItem as System.Reflection.MethodInfo);
            MacierzPredykcji macierz = trenignowy.Klasyfikuj(testowy,int.Parse(cBKnn.SelectedItem.ToString()),metryka);
            Wyswietlacz wyniki = new Wyswietlacz(MacierzPredykcji.PrzekonwertujNaNapis(macierz),"Macierz Predykcji");
            wyniki.Show();
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
       

      
    }
}

