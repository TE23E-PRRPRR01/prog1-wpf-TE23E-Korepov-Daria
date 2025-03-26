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
using System.Net.Http;
using System.Net.Http.Json;

namespace Chat_AI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    // Redaskap för att kommunicera över http
    HttpClient klient = new HttpClient();
    string url = "http://10.151.168.5:11434/api/generate";
    public MainWindow()
    {
        InitializeComponent();
    }

    private void KlickSkicka(object sender, RoutedEventArgs e)
    {
        // Läsa av promptexten i rutan
        string prompt = tbxPrompt.Text;

        // Skapa en json-objekt
        object data = new
        {
            model = "phi4:latest",
            prompt = prompt,
            max_tokens = 50
        };

        // Skicka till ollama-ai-servern
        SkickaTillOllama(data);
    }

    public void SkickaTillOllama(object data)
    {
        try
        {
            // Skicka data till servern
            HttpResponseMessage svar = klient.PostAsJsonAsync(url, data).Result;

            // Kontrollera att "requesten" lyckades
            svar.EnsureSuccessStatusCode();

            // Läs innehållet i svaret
            string råtext = svar.Content.ReadAsStringAsync().Result;

            // Dela upp råtexten i rader
            string[] rader = råtext.Split('\n');

            // Gå igenom alla rader
            foreach (string rad in rader)
            {
                // Finns "response"
                if (rad.Contains("response"))
                {
                    tbxSvar.Text+= PlockaUtToken(rad);
                }
            }
        }
        catch (HttpRequestException e)
        {
            tbxSvar.Text = $"Error: {e.Message}";
        }

    }
    private string PlockaUtToken(string rad)
    {
        int start = rad.IndexOf("response") + 11;
        int slut = rad.IndexOf("\"", start);
        
        // PLocka ut token
        return rad.Substring(start, slut -start);
    }
}