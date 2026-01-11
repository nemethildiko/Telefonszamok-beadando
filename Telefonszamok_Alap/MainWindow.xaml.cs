using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using cnTelefonkonyv;
using Models;

namespace Telefonszamok_Alap
{
    public partial class MainWindow : Window
    {
        TelefonkonyvContext cn = new TelefonkonyvContext();

        public MainWindow()
        {
            InitializeComponent();

            dgSzemelyek.ItemsSource = cn.enSzemelyek
                .Include(x => x.enTelefonszamok)
                .ToList();
        }

        private void dgSzemelyek_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dgSzemelyek.SelectedItem is enSzemely sz)
            {
                dgTelefonszamok.ItemsSource = sz.enTelefonszamok.ToList();
            }
        }
    }
}
