using System.Windows;

namespace Telefonszamok_Alap
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtLogin_Click(object sender, RoutedEventArgs e)
        {
            if (tbUser.Text == "admin" && pbPass.Password == "admin")
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Hibás felhasználónév vagy jelszó!",
                    "Bejelentkezési hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }
    }
}
