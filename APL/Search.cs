using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APL
{
    public partial class Search : Form
    {
        private List<FlightInfo> flights;
        private string token;

        public Search(List<FlightInfo> flights, string token)
        {
            this.flights = flights;
            this.token = token;
            InitializeComponent(); // Sposta questa chiamata prima di DisplayFlights()
            DisplayFlights();
        }

        private void DisplayFlights()
        {
            if (flights.Count == 0)
            {
                Panel flightPanel = new Panel();
                flightPanel.BorderStyle = BorderStyle.FixedSingle;
                flightPanel.Size = new System.Drawing.Size(400, 150);

                Label notflights = new Label();
                notflights.Text = "La ricerca non ha prodotto risultati";
                notflights.Location = new System.Drawing.Point(10, 10);
                flightPanel.Controls.Add(notflights);

                notflights.AutoSize = true;

                flowLayoutPanel1.Controls.Add(flightPanel);
                flowLayoutPanel1.AutoScroll = true;
            }
            else
            {
                foreach (var flight in flights)
                {
                    // Crea un pannello per ogni volo
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

                    Button starButton = new Button();
                    starButton.Text = "Add";
                    starButton.Location = new System.Drawing.Point(300, 40);
                    // Assicurati di gestire l'evento Click del pulsante
                    departureLabel.AutoSize = true;
                    destinationLabel.AutoSize = true;
                    departureDateLabel.AutoSize = true;
                    arrivalDateLabel.AutoSize = true;
                    priceLabel.AutoSize = true;


                    starButton.Click += async (sender, e) =>
                    {
                        using (HttpClient client = new HttpClient())
                        {
                            string apiUrl = "http://127.0.0.1:8080/favourites";
                            try
                            {
                                var dati = new Dictionary<string, string>
                                {
                                { "city_from", flight.DepartureCity },
                                { "city_to", flight.DestinationCity },
                                { "date_from", flight.getFormattedDepartureDate() },
                                { "return_from", flight.getFormattedReturnDate() },
                                { "price", flight.Price }
                                };

                                string jsonData = JsonConvert.SerializeObject(dati);
                                var content = new StringContent(jsonData);

                                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                                if (response.IsSuccessStatusCode)
                                {
                                    //Gestire il fatto che un utente non può aggiungere due voli uguali e quindi tornare errore
                                    
                                    MessageBox.Show("Flight added successfully!");
                                }
                                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                                {
                                    MessageBox.Show("Token expired, please log in again!");
                                    new Form1().Show();
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show($"Error: {response.StatusCode}");
                                }
                            }
                            catch (HttpRequestException ex)
                            {
                                MessageBox.Show($"HTTP request error: {ex.Message}");
                            }
                        }
                    };
                    flightPanel.Controls.Add(starButton);

                    // Aggiungi il pannello dei voli al layout
                    flowLayoutPanel1.Controls.Add(flightPanel);
                    flowLayoutPanel1.AutoScroll = true;
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
