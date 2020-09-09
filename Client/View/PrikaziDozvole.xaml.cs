using Client.ViewModel;
using Common;
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
    /// Interaction logic for PrikaziDozvole.xaml
    /// </summary>
    public partial class PrikaziDozvole : Window
    {
        public PrikaziDozvole(AutoSkola skola)
        {
            InitializeComponent();
            DataContext = new DozvoleWievModel(skola) { Window = this, Skola = skola };
        }
    }
}
