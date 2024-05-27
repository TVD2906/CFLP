//Doriți să dezvoltați o aplicație care descarcă imagini de pe internet în mod asincron pentru a menține interfața grafică receptivă în timpul procesului de descărcare.

//Cerințe:

//Utilizatorul poate introduce un URL pentru imagine într-un câmp de introducere.
//Aplicația trebuie să ofere feedback instantaneu utilizatorului, indicând că procesul de descărcare a început.
//Procesul de descărcare trebuie să fie asincron pentru a nu bloca interfața grafică.
//După ce imaginea este descărcată, trebuie afișată în interfața grafică.
//Utilizatorul trebuie să primească un mesaj în cazul în care descărcarea eșuează din diverse motive (exemplu: URL-ul invalid, eroare de rețea etc.).


using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

class ImageDownloaderForm : Form
{
    private TextBox urlTextBox;
    private Button downloadButton;
    private PictureBox pictureBox;

    public ImageDownloaderForm()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        urlTextBox = new TextBox();
        urlTextBox.Dock = DockStyle.Top;
        urlTextBox.Text = "Enter image URL here...";

        downloadButton = new Button();
        downloadButton.Dock = DockStyle.Top;
        downloadButton.Text = "Download Image";
        downloadButton.Click += async (sender, e) => await DownloadImageAsync();

        pictureBox = new PictureBox();
        pictureBox.Dock = DockStyle.Fill;
        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

        Controls.Add(pictureBox);
        Controls.Add(downloadButton);
        Controls.Add(urlTextBox);
    }

    private async Task DownloadImageAsync()
    {
        try
        {
            string url = urlTextBox.Text;
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync();
                pictureBox.Image = System.Drawing.Image.FromStream(stream);
            }
        }
        catch (HttpRequestException)
        {
            MessageBox.Show("Failed to download image. Please check the URL and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new ImageDownloaderForm());
    }
}
