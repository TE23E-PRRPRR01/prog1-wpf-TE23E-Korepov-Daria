using System.Text;
using System.Windows;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmailApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    // Hantera klick på knappen Skicka
private void KlickSkicka(object sender, RoutedEventArgs e)
{
    // Läs av inmatningen
    string epost = tbxEpost.Text;
    string text = tbxText.Text;

    // Koppla upp på en mail-server
    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
    smtp.EnableSsl = true;
    smtp.Credentials = new NetworkCredential("user", "pass");

    // Kontrollera att användaren har skrivit in en epostadress
    if (epost !="" && text !="")
    {
        smtp.Send(id, epost, "Meddelande från appen(WPF)", text);
        lblStatus.Content = "Meddelandet skickades!";
    }
    else
    {
        // Visa felmeddelande
        lblStatus.Content = "Error! Du måste ange epostadressen och text!";
    }
}

private void ChangedEpost(object sender, RoutedEventArgs e)
{
    string epost = tbxEpost.Text;
    string regexEpost = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
    if (!Regex.IsMatch(epost, regexEpost))
    {
        // Visa felmeddelande
        lblStatus.Content = "Du måste ange en giltig epostadress!";
    }
    else
    {
    
    }
}

}