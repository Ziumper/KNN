using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN
{
    public class ObiektDecyzyjny
    {
        public int decyzja;
        public Dictionary<int, int> deskryptory = new Dictionary<int, int>();
        public int ?klasyfikacja;
        public int otrzymanaDecyzja;
        public ObiektDecyzyjny(string wiersz)
        {
            string[] miejsceParkingowe = wiersz.Split(' ');
            for(int i = 0; i < miejsceParkingowe.Length-1; i++)
            {
                deskryptory[i] = int.Parse(miejsceParkingowe[i]);
            }
            decyzja = int.Parse(miejsceParkingowe.Last());
            // trzeba napisać, jak z wiersza 1 1 1 1 4 3 1 zrobić obiekt
        }
    }
}
