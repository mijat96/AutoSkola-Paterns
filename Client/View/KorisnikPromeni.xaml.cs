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
    /// Interaction logic for KorisnikPromeni.xaml
    /// </summary>
    public partial class KorisnikPromeni : Window
    {
        public KorisnikPromeni(Korisnik korisnik)
        {
            InitializeComponent();
            DataContext = new PregledKorisnikaViewModel(korisnik, this);
        }
    }
}
