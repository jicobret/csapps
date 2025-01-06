using ConcertCreator;
class Ticket
{
    public Concert Concert { get; private set; }
    public decimal Price { get; private set; }
    public string SeatNumber { get; private set; }

    public Ticket(Concert concert, decimal price, string seatNumber)
    {
        Concert = concert;
        Price = price;
        SeatNumber = seatNumber;
    }
}
class BookingSystem
{
    private List<Concert> concerts;
    private List<Ticket> tickets;

    public BookingSystem()
    {
        concerts = new List<Concert>();
        tickets = new List<Ticket>();
    }

    public void AddConcert(Concert concert)
    {
        concerts.Add(concert);
    }

    public void BookTicket(Concert concert, string seatNumber)
    {
        if (concert.AvailableSeats > 0 && !(concert is OnlineConcert))
        {
            concert.GetType().GetProperty("AvailableSeats").SetValue(concert, concert.AvailableSeats - 1);
            tickets.Add(new Ticket(concert, concert.GetTicketPrice(), seatNumber));
            Console.WriteLine($"Kupiono bilet na {concert.Name}, {concert.Date} na miejsce {seatNumber}.");
        }
        else if (concert is OnlineConcert)
        {
            tickets.Add(new Ticket(concert, concert.GetTicketPrice(), "Online"));
            Console.WriteLine($"Kupiono PPV na {concert.Name}, {concert.Date} na platformie {((OnlineConcert)concert).Platform}.");
        }
        else
        {
            Console.WriteLine("Brak wolnych miejsc na koncert.");
        }
    }

    public List<Concert> ShowConcerts(Func<Concert, bool> filter)
    {
        return concerts.Where(filter).ToList();
    }

    public void GenerateReport()
    {
        var report = tickets.GroupBy(t => t.Concert.Name)
                            .Select(g => new { ConcertName = g.Key, TicketsSold = g.Count() });

        Console.WriteLine("Raport sprzedazy:");
        foreach (var entry in report)
        {
            Console.WriteLine($"Sprzedano {entry.TicketsSold} miejsc na {entry.ConcertName}.");
        }
    }
}

// Program główny
class Program
{
    static void Main(string[] args)
    {
        BookingSystem bookingSystem = new BookingSystem();
        while(true){
            Console.Write("1 - Dodaj koncert, 2 - Wyswietl wszystkie koncerty, 3 - Kup bilet, 4 - Wygeneruj raport ze sprzedazy biletow\n");
            string? c = Console.ReadLine();
            switch(c){
                case "1":
                    Console.Write("Wybierz typ koncertu: 1 - Regular, 2 - VIP, 3 - Online, 4 - Private\n");
                    string? cType = Console.ReadLine();
                    switch(cType){ //to na pewno mozna zrobic lepiej
                        case "1":
                            Console.WriteLine("Wprowadz nazwe koncertu: ");
                            string? rcName = Console.ReadLine();
                            Console.WriteLine("Za ile dni odbedzie sie koncert?: ");
                            int rcDate = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Wprowadz miejsce koncertu: ");
                            string? rcPlace = Console.ReadLine();
                            Console.WriteLine("Wprowadz ilosc dostepnych miejsc: ");
                            int rcSeats = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Wprowadz cene biletu: ");
                            int rcPrice = Convert.ToInt32(Console.ReadLine());

                            bookingSystem.AddConcert(new RegularConcert(rcName, DateTime.Now.AddDays(rcDate), rcPlace, rcSeats, rcPrice));
                            break;
                        
                        case "2":
                            Console.WriteLine("Wprowadz nazwe koncertu: ");
                            string? vcName = Console.ReadLine();
                            Console.WriteLine("Za ile dni odbedzie sie koncert?: ");
                            int vcDate = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Wprowadz miejsce koncertu: ");
                            string? vcPlace = Console.ReadLine();
                            Console.WriteLine("Wprowadz ilosc dostepnych miejsc: ");
                            int vcSeats = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Wprowadz cene biletu: ");
                            int vcPrice = Convert.ToInt32(Console.ReadLine());

                            bookingSystem.AddConcert(new VIPConcert(vcName, DateTime.Now.AddDays(vcDate), vcPlace, vcSeats, vcPrice));
                            break;

                        case "3":
                            Console.WriteLine("Wprowadz nazwe koncertu: ");
                            string? ocName = Console.ReadLine();
                            Console.WriteLine("Za ile dni odbedzie sie koncert?: ");
                            int ocDate = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Wprowadz platforme streamingowa koncertu: ");
                            string? ocPlace = Console.ReadLine();
                            Console.WriteLine("Wprowadz cene PPV: ");
                            int ocPrice = Convert.ToInt32(Console.ReadLine());

                            bookingSystem.AddConcert(new OnlineConcert(ocName, DateTime.Now.AddDays(ocDate), ocPlace, ocPrice));
                            break;

                        case "4":
                            Console.WriteLine("Wprowadz nazwe koncertu: ");
                            string? pcName = Console.ReadLine();
                            Console.WriteLine("Za ile dni odbedzie sie koncert?: ");
                            int pcDate = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Wprowadz miejsce koncertu: ");
                            string? pcPlace = Console.ReadLine();
                            Console.WriteLine("Wprowadz cene biletu: ");
                            int pcPrice = Convert.ToInt32(Console.ReadLine());

                            bookingSystem.AddConcert(new PrivateConcert(pcName, DateTime.Now.AddDays(pcDate), pcPlace, pcPrice));
                            break;
                    }
                    break;

                case "2":
                    Console.WriteLine("Wszystkie koncerty:");
                    var allConcerts = bookingSystem.ShowConcerts(c => true);

                    foreach (var concert in allConcerts)
                    {
                        Console.WriteLine($"{concert.Name} - {concert.Date} - {concert.Location} - {concert.AvailableSeats} miejsc.");
                    }
                    break;

                case "3":
                    Console.WriteLine("Podaj nazwe koncertu: ");
                    string? bcName = Console.ReadLine();
                    Console.WriteLine("Podaj numer miejsca (w przypadku koncertu Online zostaw puste pole): ");
                    string? bcSeat = Console.ReadLine();


                    var bc = bookingSystem.ShowConcerts(c => c.Name == bcName).FirstOrDefault();
                    if (bc != null)
                    {
                        bookingSystem.BookTicket(bc, bcSeat);
                    }else{
                        Console.WriteLine("Nie ma takiego koncertu!");
                    }
                    break;
                
                case "4":
                    bookingSystem.GenerateReport();
                    break;
            }
        }
    }
}
