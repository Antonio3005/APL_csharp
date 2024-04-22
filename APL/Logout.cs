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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace APL
{
    public partial class Logout : Form
    {
        private string token;
        private Form home;
        public Logout(string token, Form Home)
        {
            this.token = token;
            this.home = Home;
            InitializeComponent();
        }

        private async void b_logout_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "http://127.0.0.1:5000/logout";
                try
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    // Effettua la richiesta POST all'API (se necessario)
                    HttpResponseMessage response = await client.PostAsync(apiUrl, null);

                    // Verifica se la richiesta è andata a buon fine
                    if (response.IsSuccessStatusCode == true)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        var tokenObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                        if (tokenObject["success"] == false)
                        {
                            MessageBox.Show("Problemi nel server");
                        }
                        else
                        {
                            //string token = tokenObject["token"];
                            new Form1().Show();
                            this.Hide();
                            home.Hide();
                            MessageBox.Show("Logout effettuato con successo!");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Errore durante il logout: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Errore nella richiesta HTTP: {ex.Message}");
                }
            }
        }
    }
}
