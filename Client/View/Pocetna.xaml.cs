using Client.ViewModel;
using Common.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for Pocetna.xaml
    /// </summary>
    public partial class Pocetna : Window
    {
        public Pocetna(Korisnik k)
        {
            InitializeComponent();
            DataContext = new PocetnaViewModel { window = this, korisnik = k };
        }
    }
}
