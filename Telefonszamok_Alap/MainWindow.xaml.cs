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
        private void BtnTelefonszamHozzaadas_Click(object sender, RoutedEventArgs e)
        {
            if (dgSzemelyek.SelectedItem == null)
                return;

            if (string.IsNullOrWhiteSpace(tbUjTelefonszam.Text))
                return;

            var szemely = dgSzemelyek.SelectedItem as enSzemely;

            enTelefonszam uj = new enTelefonszam
            {
                Szam = tbUjTelefonszam.Text,
                enSzemelyid = szemely.id
            };

            cn.enTelefonszamok.Add(uj);
            cn.SaveChanges();

            dgTelefonszamok.ItemsSource = cn.enTelefonszamok
                .Where(t => t.enSzemelyid == szemely.id)
                .ToList();

            tbUjTelefonszam.Clear();
        }


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
