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

namespace Julklappslista;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    // Våra variabler
    int maxJulklappar = 0;
    List<string> listaJulklappar = [];
    public MainWindow()
    {
        InitializeComponent();

        //Koppla List till ListBox
        lstJulklappar.ItemsSource = listaJulklappar;

        // Inaktivera gränsnittet för att lägga till juklappar 
        inmatning.isEnable = false;
        listan.isEnable = false;

    // private void KlickMaxKlappar(object sender, RoutedEventArgs e)
    // {
    //     // Kontroller att inmatningen är ett positivt tal
    //     if (int.TryParse(txbAntalJulklappar.Text, out int antal) && antal > 0)
    //     {
    //         // Spara antalet julklappar
    //         maxJulklappar = antal;


    //         lstJulklappar.ItemsSource = juklappar;
    //     }
    // }
    }

    private void KlickAnge(object sender, RoutedEventArgs e)
    {
        // Läs av rutan
        string antal = txbAntalJulklappar.Text;

        // Försök enkel kontroll
        if (antal == "")
        {
            txbStatus.Text = "Vg ange ett heltal";
        }
        else
        {
            bool lyckas = int.TryParse(antal, out int talet);
            if (lyckas)
            {
                maxJulklappar = talet;
                txbStatus.Text = $"Max julklappar är {maxJulklappar}";

                // Lås
                limit.isEnable = false;
                inmatning.isEnable = true;
                listan.isEnable = true;
            }
            else
            {
                txbStatus.Text = "Vg ange ett heltal";
            }
        }
    }

    private void KlickLäggTill(object sender, RoutedEventArgs e)
    {
        // Läs av textrutorna
        string julklapp = txbJulklapp.Text;
        string mottagare = txbMottagare.Text;

        listaJulklappar.Add($"{julklapp} till {mottagare}");
        lstJulklappar.Items.Refresh();
    }

    private void KlickBytUt(object sender, RoutedEventArgs e)
    {
        
    }
}