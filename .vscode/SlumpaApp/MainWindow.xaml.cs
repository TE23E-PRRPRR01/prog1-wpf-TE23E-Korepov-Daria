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

namespace SlumpaApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void KlickSlumpa(object sender, RoutedEventArgs e)
    {
        if (int.TryParse(txbMaxVärdet.Text, out int MaxVärde) && MaxVärde > 0)
        {
            // Slumpa ett tal 1-100
            int slumptal = Random.Shared.Next(1, MaxVärde + 1);
            //Skriv ut slumptalet i textboxen
            txbResultat.Text = slumptal.ToString();
        }
        else
        {
            txbResultat.Text = "False!";
        }
    }
}
