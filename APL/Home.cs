using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace APL
{
    public partial class Home : Form
    {
        private string token;
        private HttpClient client;
        public Home(string token)
        {
            this.token = token;
            InitializeComponent();
            client = new HttpClient();
            DisplayPop();
        }

        private async void search_Click(object sender, EventArgs e)
        {
            string city_from = txtFrom.Text;
            string city_to = txtTo.Text;
            string date_from = DataFrom.Value.ToString("dd/MM/yyyy");
            string date_to = DataTo.Value.ToString("dd/MM/yyyy");
            string return_from = ReturnFrom.Value.ToString("dd/MM/yyyy");
            string return_to = ReturnTo.Value.ToString("dd/MM/yyyy");
            string price_min = priceMin.Text;
            string price_max = priceMax.Text;

            
            {
                string apiUrl = "http://127.0.0.1:8080/search";
                try
                {
                    var dati = new Dictionary<string, string>
                    {
                        { "city_from", city_from },
                        { "city_to", city_to },
                        { "date_from", date_from },
                        { "date_to", date_to },
                        { "return_from", return_from },
                        { "return_to", return_to },
                        { "price_min", price_min },
                        { "price_max", price_max }
                    };
                    
                    string jsonData = JsonConvert.SerializeObject(dati);
                    //var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var content = new StringContent(jsonData);
                    Console.WriteLine(jsonData);
                    
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    Console.WriteLine(client.DefaultRequestHeaders.Authorization.ToString());

                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    // Verifica se la richiesta è andata a buon fine
                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        var flightData = JsonConvert.DeserializeObject<dynamic>(responseContent);
                        //Console.WriteLine(flightData);
                        var flights = new List<FlightInfo>();

                        foreach (var flight in flightData["data"])
                        {
                            var flightInfo = new FlightInfo
                            {
                                Price = flight["price"],
                                DepartureCity = flight["cityFrom"],
                                DestinationCity = flight["cityTo"],
                                DepartureDate = flight["route"][0]["local_departure"],
                                ReturnDate = flight["route"][1]["local_departure"]
                            };
                            Console.WriteLine(flightInfo.DepartureCity);

                            flights.Add(flightInfo);
                        }
                        new Search(flights,token).Show();
                        this.Hide();
                        MessageBox.Show("Ricerca effettuata con successo!");
                    } 
                    else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        MessageBox.Show($"{response.StatusCode}, ritenta l'accesso!");
                        new Form1().Show();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show($"Errore durante la ricerca: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Errore nella richiesta HTTP: {ex.Message}");
                }

            }
        }

        private async void DisplayPop() 
        {
            string apiUrl = "http://127.0.0.1:8080/show_pop";
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await client.PostAsync(apiUrl, null);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var popData = JsonConvert.DeserializeObject<dynamic>(responseContent);

                    var pops = new List<FlightInfo>();
                    if (popData == null)
                    {
                        Panel flightPanel = new Panel();
                        flightPanel.BorderStyle = BorderStyle.FixedSingle;
                        flightPanel.Size = new System.Drawing.Size(400, 150);

                        Label notflights = new Label();
                        notflights.Text = "Non hai voli tra i preferiti";
                        notflights.Location = new System.Drawing.Point(10, 10);
                        flightPanel.Controls.Add(notflights);

                        notflights.AutoSize = true;

                        flowLayoutPanel1.Controls.Add(flightPanel);
                        flowLayoutPanel1.AutoScroll = true;
                    }
                    else
                    {
                        foreach (var pop in popData)
                        {
                            var popInfo = new FlightInfo
                            {
                                DestinationCity = pop["city_to"],
                                DepartureCity = pop["city_from"]
                            };
                            pops.Add(popInfo);

                        }
                        if (pops.Count != 0)
                        {
                            foreach (var pop in pops)
                            {
                                Panel flightPanel = new Panel();
                                flightPanel.BorderStyle = BorderStyle.FixedSingle;
                                flightPanel.Size = new System.Drawing.Size(400, 80);

                                // Aggiungi etichette per visualizzare le informazioni del volo
                                Label departureLabel = new Label();
                                departureLabel.Text = "Departure City: " + pop.DepartureCity + " ";
                                departureLabel.Location = new System.Drawing.Point(10, 10);
                                flightPanel.Controls.Add(departureLabel);

                                Label destinationLabel = new Label();
                                destinationLabel.Text = "Destination City: " + pop.DestinationCity + " ";
                                Console.WriteLine(destinationLabel.Text);
                                destinationLabel.Location = new System.Drawing.Point(10, 40);
                                flightPanel.Controls.Add(destinationLabel);

                                Button sButton = new Button();
                                sButton.Text = "Search";
                                sButton.Location = new System.Drawing.Point(300, 40);

                                departureLabel.AutoSize = true;
                                destinationLabel.AutoSize = true;

                                sButton.Click += async (sender, e) =>
                                {
                                    txtFrom.Text = pop.DepartureCity;
                                    txtTo.Text = pop.DestinationCity;
                                };

                                flightPanel.Controls.Add(sButton);

                                // Aggiungi il pannello dei voli al layout
                                flowLayoutPanel1.Controls.Add(flightPanel);
                                flowLayoutPanel1.AutoScroll = true;
                            }
                        }
                    }


                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show($"{response.StatusCode}, ritenta l'accesso!");
                    new Form1().Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show($"Errore durante la ricerca: {response.StatusCode}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        private void account_Click(object sender, EventArgs e)
        {
            new Logout(token,this).Show();
        }

        private void favourites_Click(object sender, EventArgs e)
        {
            new Favourites(token).Show();
            this.Hide();
        }

       
    }
}
