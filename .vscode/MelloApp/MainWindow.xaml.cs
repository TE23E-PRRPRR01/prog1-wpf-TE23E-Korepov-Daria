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

namespace MelloApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    // Variabler för att räkna röster
    private int antalRöd = 0;
    private int antalBlå = 0;
    private int antalGrön = 0;
    private int antalGul = 0;
    private int antalLila = 0;

    public MainWindow()
    {
        InitializeComponent();
    }

    // Metod som anropas när en röstknapp klickas
    private void KlickRösta(object sender, RoutedEventArgs e)
    {
        // Kollar vilken knapp som tryckts och ökar motsvarande röstantal
        if (sender == röd)
        {
            antalRöd++;
        }
        else if (sender == blå)
        {
            antalBlå++;
        }
        else if (sender == grön)
        {
            antalGrön++;
        }
         else if (sender == gul)
        {
            antalGul++;
        }
          else if (sender == lila)
        {
            antalLila++;
        }


        // Uppdaterar resultatet i textfältet
        txbResultat.Text = $"Röd: {antalRöd}, Blå: {antalBlå}, Grön: {antalGrön}, Gul: {antalGul}, Gul: {antalLila}";
    }
}