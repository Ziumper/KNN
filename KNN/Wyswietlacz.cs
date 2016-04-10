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
    public partial class Wyswietlacz : Form
    {
        public Wyswietlacz()
        {
            InitializeComponent();
        }
        
        public Wyswietlacz(string aDaneZPliku,string aJakieToDane)
        {
            InitializeComponent();
            rtbZawartosc.Text = aDaneZPliku;
            lblOpis.Text = aJakieToDane;
            rtbZawartosc.ReadOnly = true;
        }
    }
}
