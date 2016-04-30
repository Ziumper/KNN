using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN
{
    public class Koncept
    {
        public int decyzja;
        public Dictionary<int, int> pokrycie;

        public Koncept(int decyzja,Dictionary<int,int> pokrycie) {
            this.decyzja = decyzja;
            this.pokrycie = pokrycie; 
            
        }
    }
}
