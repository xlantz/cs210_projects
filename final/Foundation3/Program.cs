using System;

public class Address{
    public string Street {get; set;}
    public string City {get; set;}
    public string State {get; set;}
    public string ZipCode {get; set;}

    public Address(string street, string city, string state, string zipCode){
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    public override string ToString(){
        return $"{Street}, {City}, {State} {ZipCode}";
    }
}

public class Event{
    private string title;
    private string description;
    private DateTime date;
    private string time;
    private Address address;

    public Event(string title, string description, DateTime date, string time, Address address){
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public string GetStandardDetails(){
        return $"Title: {title}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time}\nAddress: {address}";
    }

    public virtual string GetFullDetails(){
        return GetStandardDetails();
    }

    public string GetShortDescription(){
        return $"Type: Generic Event\nTitle: {title}\nDate: {date.ToShortDateString()}";
    }
}

public class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address){
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GetFullDetails(){
        return $"{base.GetStandardDetails()}\nType: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}

public class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address){
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails(){
        return $"{base.GetStandardDetails()}\nType: Reception\nRSVP Email: {rsvpEmail}";
    }
}

public class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, DateTime date, string time, Address address, string weatherForecast)
        : base(title, description, date, time, address){
        this.weatherForecast = weatherForecast;
    }

    public override string GetFullDetails(){
        return $"{base.GetStandardDetails()}\nType: Outdoor Gathering\nWeather Forecast: {weatherForecast}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address address = new Address("846 Jones Ave", "Frunktown", "TX", "17954");

        Event genericEvent = new Event("Whatever Con", "Whatever con is a convention for whatever normal thing you want.", DateTime.Now, "9:00 AM", address);
        Lecture lectureEvent = new Lecture("Dr. Sherman's lecture on hyponitronic induction reverbs", "Join us for this amazing lecture.", DateTime.Now.AddDays(7), "1:00 PM", address, "John Doe", 100);
        Reception receptionEvent = new Reception("Wedding Reception for James and Heidi", "Come and celebrate their bond.", DateTime.Now.AddDays(14), "6:00 PM", address, "rsvp@tietheknot.com");
        OutdoorGathering outdoorEvent = new OutdoorGathering("184th Ward's BBQ", "Games, Food, and Fun!", DateTime.Now.AddDays(21), "10:00 AM", address, "Sunny");

        Console.WriteLine("Generic Event:");
        Console.WriteLine(genericEvent.GetStandardDetails());
        Console.WriteLine(genericEvent.GetFullDetails());
        Console.WriteLine(genericEvent.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("Lecture Event:");
        Console.WriteLine(lectureEvent.GetStandardDetails());
        Console.WriteLine(lectureEvent.GetFullDetails());
        Console.WriteLine(lectureEvent.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("Reception Event:");
        Console.WriteLine(receptionEvent.GetStandardDetails());
        Console.WriteLine(receptionEvent.GetFullDetails());
        Console.WriteLine(receptionEvent.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("Outdoor Event:");
        Console.WriteLine(outdoorEvent.GetStandardDetails());
        Console.WriteLine(outdoorEvent.GetFullDetails());
        Console.WriteLine(outdoorEvent.GetShortDescription());
    }
}