using System.Linq;
using System.Windows;
using cnTelefonkonyv;

namespace Telefonszamok_Alap
{
    public partial class MainWindow : Window
    {
        TelefonkonyvContext cn = new TelefonkonyvContext();

        public MainWindow()
        {
            InitializeComponent();
            dgSzemelyek.ItemsSource = cn.enSzemelyek.ToList();
        }
    }
}
