using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace APL
{
    public partial class Form2 : Form
    {
        //public static string Token { get; set; }
        public Form2()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Esegui la richiesta all'API
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "http://127.0.0.1:5000/login"; 
                try
                {
                    var dati = new Dictionary<string, string>
                    {
                        { "username", username },
                        { "password", password }
                    };

                    string jsonData = JsonConvert.SerializeObject(dati);
                    var content = new StringContent(jsonData);
                    Console.WriteLine(jsonData);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    // Effettua la richiesta POST all'API (se necessario)
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    // Verifica se la richiesta è andata a buon fine
                    if (response.IsSuccessStatusCode == true)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        var tokenObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                        if (tokenObject["success"] == false) {
                            MessageBox.Show("Credenziali non valide");
                        } else { 
                            string token = tokenObject["token"];
                            Console.WriteLine(tokenObject);
                            new Home(token).Show();
                            this.Hide();
                            MessageBox.Show("Login effettuato con successo!");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Errore durante il login: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Errore nella richiesta HTTP: {ex.Message}");
                }
            }
        }


        private async void button2_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }
    }
}
