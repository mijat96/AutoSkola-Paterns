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
    /// Interaction logic for IzmeniSkoluProzor.xaml
    /// </summary>
    public partial class IzmeniSkoluProzor : Window
    {
        public IzmeniSkoluProzor(AutoSkola skola)
        {
            InitializeComponent();
            DataContext = new IzmeniSkoluViewModel() { Window = this, Skola = skola };
        }
    }
}
