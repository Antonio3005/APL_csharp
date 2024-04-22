using System;

public class FlightInfo
{
    public string Price { get; set; }
    public string DepartureCity { get; set; }
    public string DestinationCity { get; set; }
    public string DepartureDate { get; set; }
    public string ReturnDate { get; set; }

    public string getFormattedDepartureDate()
    {
        DateTime dateTime = DateTime.ParseExact(DepartureDate, "MM/dd/yyyy HH:mm:ss", null);
        return dateTime.ToString("dd/MM/yyyy");
    }

    public string getFormattedReturnDate()
    {
        DateTime dateTime = DateTime.ParseExact(ReturnDate, "MM/dd/yyyy HH:mm:ss", null);
        return dateTime.ToString("dd/MM/yyyy");
    }

}

