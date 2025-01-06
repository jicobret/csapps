namespace Creator;

class Player {
    public string Name;
    public string Position;
    public int Score;

    public Player(string name, string position) {
        Name = name;
        Position = position;
        Score = 0;
    }

    public void PScore() {
        Score++;
    }
}
record Game (
    bool Win
);

class Team {
    public string Name;    
    public List<Player> PList;
    public List<Game> Games;

    public Team(string Name) {
        this.Name = Name;  
        PList = new();
        Games = new();
    }    
    public void AddGame(bool Win) {
        Games.Add(new(Win));
    }
    public void AddPlayer(string name, string position) {
        PList.Add(new Player(name, position));
    }
    public double TeamScore() {
        return Games.Count > 0 ? (double)Games.Where(game => game.Win).Count() / Games.Count * 100 : 0;
    }
    public void PlayerScore(string name) {
        PList.First(player => player.Name == name).PScore();
    }
    //katastroficzna redundancja od tego momentu
    public void SearchPosition(string Name) {
        List<Player> filter = PList.Where(pl => pl.Position == Name).ToList();
        foreach (var player in filter) {
            Console.WriteLine($"{player.Name}, {player.Position}, zdobyto {player.Score} pkt.");
        }
    }
    public void SearchName(string Name) {
        List<Player> filter = PList.Where(pl => pl.Name == Name).ToList();
        foreach (var player in filter) {
            Console.WriteLine($"{player.Name}, {player.Position}, zdobyto {player.Score} pkt.");
        }
    }
    public void SearchScore(string Name) {
        List<Player> filter = PList.Where(pl => pl.Name == Name).ToList();
        foreach (var player in filter) {
            Console.WriteLine($"{Name} zdobyl/a {player.Score} pkt.");
        }
    }
}
