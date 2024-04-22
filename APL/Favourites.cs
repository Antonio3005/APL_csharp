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

namespace APL
{
    public partial class Favourites : Form
    {
        private string token;
        private HttpClient client;
        public Favourites(string token)
        {
            this.token = token;
            InitializeComponent();
            client = new HttpClient();
            DisplayFavourites();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)

        {
            base.OnFormClosing(e);
            client.Dispose();
            
        }

        private async void DisplayFavourites()
        {
            {
                string apiUrl = "http://127.0.0.1:8080/selectfav";
                try
                {

                    //string jsonData = JsonConvert.SerializeObject(dati);
                    //var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    //var content = new StringContent(jsonData);
                    //Console.WriteLine(jsonData);

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    Console.WriteLine(client.DefaultRequestHeaders.Authorization.ToString());

                    try
                    {
                        HttpResponseMessage response = await client.PostAsync(apiUrl, null);
                        if (response.IsSuccessStatusCode)
                        {
                            string responseContent = await response.Content.ReadAsStringAsync();
                            var flightData = JsonConvert.DeserializeObject<dynamic>(responseContent);
                            
                            var flights = new List<FlightInfo>();

                            if (flightData == null)
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

                                foreach (var flight in flightData)
                                {
                                    var flightInfo = new FlightInfo
                                    {
                                        Price = flight["price"],
                                        DepartureCity = flight["city_from"],
                                        DestinationCity = flight["city_to"],
                                        DepartureDate = flight["date_from"],
                                        ReturnDate = flight["return_from"]
                                    };
                                    Console.WriteLine(flightInfo.DepartureCity);

                                    flights.Add(flightInfo);
                                }

                                if (flights.Count != 0)
                                {
                                    foreach (var flight in flights)
                                    {
                                        Panel flightPanel = new Panel();
                                        flightPanel.BorderStyle = BorderStyle.FixedSingle;
                                        flightPanel.Size = new System.Drawing.Size(400, 150);

                                        // Aggiungi etichette per visualizzare le informazioni del volo
                                        Label departureLabel = new Label();
                                        departureLabel.Text = "Departure City: " + flight.DepartureCity + " ";
                                        departureLabel.Location = new System.Drawing.Point(10, 10);
                                        flightPanel.Controls.Add(departureLabel);

                                        Label destinationLabel = new Label();
                                        destinationLabel.Text = "Destination City: " + flight.DestinationCity + " ";
                                        Console.WriteLine(destinationLabel.Text);
                                        destinationLabel.Location = new System.Drawing.Point(10, 40);
                                        flightPanel.Controls.Add(destinationLabel);

                                        Label departureDateLabel = new Label();
                                        departureDateLabel.Text = "Departure Date: " + flight.DepartureDate + " ";
                                        departureDateLabel.Location = new System.Drawing.Point(10, 70);
                                        flightPanel.Controls.Add(departureDateLabel);

                                        Label arrivalDateLabel = new Label();
                                        arrivalDateLabel.Text = "Return Date: " + flight.ReturnDate + " ";
                                        arrivalDateLabel.Location = new System.Drawing.Point(10, 100);
                                        flightPanel.Controls.Add(arrivalDateLabel);

                                        Label priceLabel = new Label();
                                        priceLabel.Text = "Price: " + flight.Price + " €";
                                        priceLabel.Location = new System.Drawing.Point(10, 130);
                                        flightPanel.Controls.Add(priceLabel);

                                        Button rmButton = new Button();
                                        rmButton.Text = "Remove";
                                        rmButton.Location = new System.Drawing.Point(300, 40);
                                        // Assicurati di gestire l'evento Click del pulsante
                                        departureLabel.AutoSize = true;
                                        destinationLabel.AutoSize = true;
                                        departureDateLabel.AutoSize = true;
                                        arrivalDateLabel.AutoSize = true;
                                        priceLabel.AutoSize = true;


                                        rmButton.Click += async (sender, e) =>
                                        {
                                            {
                                                string apiUrl_rm = "http://127.0.0.1:8080/deletefav";
                                                try
                                                {
                                                    var dati = new Dictionary<string, string>
                                                {
                                                { "city_from", flight.DepartureCity },
                                                { "city_to", flight.DestinationCity },
                                                { "date_from", flight.DepartureDate },
                                                { "return_from", flight.ReturnDate },
                                                { "price", flight.Price }
                                                };

                                                    string jsonData = JsonConvert.SerializeObject(dati);
                                                    var content = new StringContent(jsonData);

                                                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                                                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                                                    try
                                                    {
                                                        HttpResponseMessage response_rm = await client.PostAsync(apiUrl_rm, content);
                                                        if (response_rm.IsSuccessStatusCode)
                                                        {
                                                            flowLayoutPanel1.Controls.Clear();
                                                            DisplayFavourites();
                                                            MessageBox.Show("Flight removed successfully!");
                                                        }
                                                        else if (response_rm.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                                                        {
                                                            MessageBox.Show("Token expired, please log in again!");
                                                            new Form1().Show();
                                                            this.Close();
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show($"Error: {response_rm.StatusCode}");
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine(ex.ToString());
                                                    }


                                                }
                                                catch (HttpRequestException ex)
                                                {
                                                    MessageBox.Show($"HTTP request error: {ex.Message}");
                                                }
                                            }
                                        };
                                        flightPanel.Controls.Add(rmButton);

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
                    } catch(Exception ex) {
                        Console.WriteLine(ex.ToString());
                    }
                    // Verifica se la richiesta è andata a buon fine
                    
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Errore nella richiesta HTTP: {ex.Message}");
                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new Home(token).Show();
            this.Hide();
        }
    }
}
