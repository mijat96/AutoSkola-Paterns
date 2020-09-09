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
    /// Interaction logic for DodajDozvolu.xaml
    /// </summary>
    public partial class DodajDozvolu : Window
    {
        public DodajDozvolu(int idpl)
        {
            InitializeComponent();
            DataContext = new DodajDozvoleViewModel() { Window = this, IdInstruktora = idpl };
        }
    }
}
