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

namespace Brännbollsräknaren;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    // Skapa variablerna för lagen
    int poängInne = 0;
    int poängUte = 0;
    
    public MainWindow()
    {
        InitializeComponent();
    }

    private void KlickFrivarv(object sender, RoutedEventArgs e)
    {
        // Lägg till 5 poäng
        poängInne += 5;

        // Skriv ut poängen 
        tbxLagInne.Text = $"{poängInne}";
        // tbxLagInne.Text = (int.Parse(tbxLagInne.Text) + 5).ToString();

        // Skriv ut poängen
        tbxHistorik.Text += $"Lag inne +5, totalt: {poängInne}\n ";

        // Vad är klockan just nu?
        DateTime nu = DateTime.Now;
        
        //Skriv i Historiken
        tbxHistorik.Text += $"{nu.ToString("HH:mm:ss")} Lag inne +5, totalt: {poängInne}\n"; 
    }
    private void KlickBränning(object sender, RoutedEventArgs e)
    {
        // Lägg till 2 poäng
        poängUte += 2;

        // Skriv ut poängen 
        tbxLagUte.Text = $"{poängUte}";

        tbxHistorik.Text += $"Lag ute +2, totalt: {poängUte}\n ";
    }

    private void KlickLyra(object sender, RoutedEventArgs e)
    {
        //Lägg till 3 poäng
        poängUte += 3;

        // Skriv ut poängen 
        tbxLagUte.Text = $"{poängUte}";

        tbxHistorik.Text += $"Lag ute +3, totalt: {poängUte}\n ";
    }

    private void KlickVarv(object sender, RoutedEventArgs e)
    {
        poängInne += 1;
            tbxLagInne.Text = $"{poängInne}";
            UppdateraHistorik("Varv (+1 poäng)");

            tbxHistorik.Text += $"Lag inne +1, totalt: {poängInne}\n ";
    }

    private void UppdateraHistorik(string händelse)
        {
            historik.Add(händelse);
            if (historik.Count > 10)
            {
                historik.RemoveAt(0);
            }
            lstHistorik.ItemsSource = null;
            lstHistorik.ItemsSource = historik;
        }
}