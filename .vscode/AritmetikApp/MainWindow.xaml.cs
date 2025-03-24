using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AritmetikApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void KlickBeräkna(object sender, RoutedEventArgs e)
    {
        // Läs in talen och operatorn från textrutorna 
        string tal1Text = txbTal1.Text.Trim();
        string tal2Text = txbTal2.Text.Trim();

        // Läs in operatorn från textrutan 
        string op = txbOperator.Text.Trim();

        // Konvertera till heltal
        // Om konverteringen lyckas, spara talen i variabler 
        if (double.TryParse(tal1Text, out double tal1) && double.TryParse(tal2Text, out double tal2))
        {
            // Deklarera variabel för resultatet 
            double resultat;

            // Utför beräkningen
            if (op == "+")
            {
                resultat = tal1 + tal2;
                lblResultat.Content = $"{tal1} + {tal2} = {resultat}";
            }
            else if (op == "-")
            {
                resultat = tal1 - tal2;
                lblResultat.Content = $"{tal1} - {tal2} = {resultat}";
            }
            else if (op == "*")
            {
                resultat = tal1 * tal2;
                lblResultat.Content = $"{tal1} * {tal2} = {resultat}";
            }
            else if (op == "/")
            {
                if (tal2 != 0)
                {
                    resultat = tal1 / tal2;
                    lblResultat.Content = $"{tal1} / {tal2} = {resultat}";
                }
                else
                {
                    lblResultat.Content = "Fel: Kan inte dividera med 0.";
                }
            }
            else
            {
                lblResultat.Content = "Fel: Ogiltig operator.";
            }
        }
        else
        {
            lblResultat.Content = "Fel: Ogiltigt tal.";
        }
    }
}