using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace APL
{
    public partial class Form3 : Form
    {
        public Form3()
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
                string apiUrl = "http://127.0.0.1:5000/register";
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
                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        var tokenObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                        if (tokenObject["success"] == false)
                        {
                            MessageBox.Show("Registrazione fallita");
                        }
                        else
                        {
                            string token = tokenObject["token"];
                            Console.WriteLine(tokenObject);
                            // Esegue l'accesso
                            new Home(token).Show();
                            this.Hide();
                            MessageBox.Show("Registrazione effettuato con successo!");
                        }    
                    }
                    else
                    {
                        MessageBox.Show($"Errore durante la registrazione: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Errore nella richiesta HTTP: {ex.Message}");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }
    }
}
