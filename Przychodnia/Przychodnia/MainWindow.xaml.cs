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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Przychodnia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Przychod przychodnia;
        public MainWindow()
        {
            InitializeComponent();
            przychodnia = new Przychod();
            bUstawLekarza.Focus();
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            gDodajPacjenta.Visibility = Visibility.Hidden;
            gUstawLekarza.Visibility = Visibility.Hidden;
            switch (((Button)sender).Name)
            {
                case "bUstawLekarza":
                    gUstawLekarza.Visibility = Visibility.Visible;
                    tLekarzIN.Focus();
                    break;
                case "bZapiszDoLekarza":
                    gDodajPacjenta.Visibility = Visibility.Visible;
                    tPacjentIN.Focus();
                    break;
                case "bDodajLekarza":
                    gUstawLekarza.Visibility = Visibility.Visible;
                    if (tLekarzIN.Text.Length > 0 && tLekarzS.Text.Length > 0)
                    {
                        przychodnia.UstawLekarza(tLekarzIN.Text, tLekarzS.Text);
                        lKolejka.Content = "Kolejka:\n" + przychodnia.ToString();
                    }
                    else
                        MessageBox.Show("Nieporawne dane");
                    break;
                case "bDodajPacjenta":
                    gDodajPacjenta.Visibility = Visibility.Visible;
                    try
                    {
                        int wiek = Convert.ToInt32(tPacjentW.Text);
                        if(wiek > 0 && wiek < 115 && tPacjentIN.Text.Length > 0 && tPacjentC.Text.Length > 0)
                        {
                            przychodnia.ZapiszDoLekarza(tPacjentIN.Text, wiek, tPacjentC.Text);
                            lKolejka.Content = "Kolejka:\n" + przychodnia.ToString();
                        }
                        else
                            MessageBox.Show("Nieporawne dane");
                    }
                    catch
                    {
                        MessageBox.Show("Nieporawne dane");
                    }
                    break;
                default:
                    MessageBox.Show("Niepoprawna akcja");
                    break;
            }
        }

        private void bWykonajPoradę_Click(object sender, RoutedEventArgs e)
        {
            lKolejka.Content = "Kolejka:\n" + przychodnia.ToString();
            MessageBox.Show(przychodnia.WykonajPorade());
        }

        private void bWykonajBadanie_Click(object sender, RoutedEventArgs e)
        {
            lKolejka.Content = "Kolejka:\n" + przychodnia.ToString();
            MessageBox.Show(przychodnia.WykonajBadanie());
        }

        private void bGenerujRaport_Click(object sender, RoutedEventArgs e)
        {
            przychodnia.GenerujRaport();
            MessageBox.Show("Wygenerowano raport");
        }

        
    }
}
