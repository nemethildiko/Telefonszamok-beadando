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
        private void BtnTelefonszamTorles_Click(object sender, RoutedEventArgs e)
        {
            if (dgTelefonszamok.SelectedItem == null)
                return;

            var telefonszam = dgTelefonszamok.SelectedItem as enTelefonszam;

            cn.enTelefonszamok.Remove(telefonszam);
            cn.SaveChanges();

            var szemely = dgSzemelyek.SelectedItem as enSzemely;

            dgTelefonszamok.ItemsSource = cn.enTelefonszamok
                .Where(t => t.enSzemelyid == szemely.id)
                .ToList();
        }
        private void BtnUjSzemely_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbVezeteknev.Text) ||
                string.IsNullOrWhiteSpace(tbUtonev.Text))
                return;
            if (cbHelyseg.SelectedItem == null)
                return;

            enSzemely uj = new enSzemely
            {
                Vezeteknev = tbVezeteknev.Text,
                Utonev = tbUtonev.Text,
                Lakcim = tbLakcim.Text,
                enHelysegid = (int)cbHelyseg.SelectedValue

            };

            cn.enSzemelyek.Add(uj);
            cn.SaveChanges();

            dgSzemelyek.ItemsSource = cn.enSzemelyek.ToList();

            tbVezeteknev.Clear();
            tbUtonev.Clear();
            tbLakcim.Clear();
            cbHelyseg.SelectedIndex = -1;

        }


        public MainWindow()
        {
            InitializeComponent();

            dgSzemelyek.ItemsSource = cn.enSzemelyek
                .Include(x => x.enTelefonszamok)
                .ToList();
            cbHelyseg.ItemsSource = cn.enHelysegek.ToList();
        }

        private void dgSzemelyek_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dgSzemelyek.SelectedItem is enSzemely sz)
            {
                tbVezeteknev.Text = sz.Vezeteknev;
                tbUtonev.Text = sz.Utonev;
                tbLakcim.Text = sz.Lakcim;
                cbHelyseg.SelectedValue = sz.enHelysegid;

                dgTelefonszamok.ItemsSource = sz.enTelefonszamok.ToList();
            }
        }
        private void BtnSzemelyModositas_Click(object sender, RoutedEventArgs e)
        {
            if (dgSzemelyek.SelectedItem == null)
                return;

            if (string.IsNullOrWhiteSpace(tbVezeteknev.Text) ||
                string.IsNullOrWhiteSpace(tbUtonev.Text) ||
                cbHelyseg.SelectedItem == null)
                return;

            var szemely = dgSzemelyek.SelectedItem as enSzemely;

            szemely.Vezeteknev = tbVezeteknev.Text;
            szemely.Utonev = tbUtonev.Text;
            szemely.Lakcim = tbLakcim.Text;
            szemely.enHelysegid = (int)cbHelyseg.SelectedValue;

            cn.SaveChanges();

            dgSzemelyek.ItemsSource = cn.enSzemelyek
                .Include(x => x.enTelefonszamok)
                .ToList();
        }

    }
}
