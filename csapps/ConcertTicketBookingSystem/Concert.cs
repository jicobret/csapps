namespace ConcertCreator;
abstract class Concert
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public int AvailableSeats { get; protected set; }

    public Concert(string name, DateTime date, string location, int availableSeats)
    {
        Name = name;
        Date = date;
        Location = location;
        AvailableSeats = availableSeats;
    }

    public abstract decimal GetTicketPrice();
}
class RegularConcert : Concert
{
    public decimal TicketPrice { get; private set; }

    public RegularConcert(string name, DateTime date, string location, int availableSeats, decimal ticketPrice)
        : base(name, date, location, availableSeats)
    {
        TicketPrice = ticketPrice;
    }

    public override decimal GetTicketPrice()
    {
        return TicketPrice;
    }
}
class VIPConcert : Concert
{
    public decimal VIPPrice { get; private set; }

    public VIPConcert(string name, DateTime date, string location, int availableSeats, decimal vipPrice)
        : base(name, date, location, availableSeats)
    {
        VIPPrice = vipPrice;
    }

    public override decimal GetTicketPrice()
    {
        return VIPPrice;
    }
}
class OnlineConcert : Concert
{
    public string Platform { get; private set; }
    public decimal StreamingPrice { get; private set; }

    public OnlineConcert(string name, DateTime date, string platform, decimal streamingPrice)
        : base(name, date, "Online", int.MaxValue)
    {
        Platform = platform;
        StreamingPrice = streamingPrice;
    }

    public override decimal GetTicketPrice()
    {
        return StreamingPrice;
    }
}
class PrivateConcert : Concert
{
    public decimal PrivateBookingCost { get; private set; }

    public PrivateConcert(string name, DateTime date, string location, decimal privateBookingCost)
        : base(name, date, location, 0)
    {
        PrivateBookingCost = privateBookingCost;
    }

    public override decimal GetTicketPrice()
    {
        return PrivateBookingCost;
    }
}
