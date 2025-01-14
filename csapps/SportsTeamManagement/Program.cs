using System.Security.Cryptography;
using Creator;

class Program {
    public static void Main(string[] args) {

        Console.Write("Podaj nazwe druzyny: ");
        string? tname = Console.ReadLine();
        Team Team = new(tname);

        while (true) {
            Console.Write("1 - Dodaj zawodnika, 2 - Dodaj punkt, 3 - Dodaj gre, 4 - Wyswietl historie druzyny, 5 - Wyszukaj zawodnika, 6 - Wyswietl punkty zawodnika): ");
            string? c = Console.ReadLine();
            switch (c) {
                case "1":
                    Console.Write("Podaj imie zawodnika: ");
                    string? pname = Console.ReadLine();
                    Console.Write("Podaj pozycje zawodnika: ");
                    string? pposition = Console.ReadLine();
                    Team.NewPlayer(pname, pposition);
                    break;

                case "2":
                    Console.Write("Kto zdobyl punkt? (Podaj imie zawodnika): ");
                    string? pl = Console.ReadLine();
                    Team.PlayerScore(pl);
                    break;

                case "3":
                    Console.Write("Czy twoja druzyna wygrala gre? (T/N): ");
                    string? readWin = Console.ReadLine();
                    bool w;
                    if (readWin == "T") {
                        w = true;
                    } else {
                        w = false;
                    }
                    Team.NewGame(w);
                    break;

                case "4":
                    Console.WriteLine($"Ilosc zagranych meczy: {Team.Games.Count}");
                    Console.WriteLine($"Ilosc wygranych meczy: {Team.Games.Where(game => game.w).Count()}");
                    Console.WriteLine($"Procent wygranych meczy druzyny {Team.Name}: {Math.Round(Team.TeamScore())}%");
                    break;

                case "5":
                    Console.Write("Wyszukiwac po imieniu czy pozycji? (I/P): ");
                    string? choice = Console.ReadLine();
                    switch(choice){
                        case "I":
                            Console.WriteLine("Podaj imie zawodnika: ");
                            string? sn = Console.ReadLine();
                            Team.SearchName(sn);
                            break;
                        
                        case "P":
                            Console.WriteLine("Podaj pozycje zawodnika: ");
                            string? sp = Console.ReadLine();
                            Team.SearchPosition(sp);
                            break;
                    }
                    break;
                    
                case "6":
                    Console.WriteLine("Podaj imie zawodnika: ");
                    string? scoreName = Console.ReadLine();
                    Team.SearchScore(scoreName);
                    break;

                default:
                    break;
            }
        }
    }
}
