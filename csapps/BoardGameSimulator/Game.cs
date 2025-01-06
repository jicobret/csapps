namespace GameCreator;
using PlayerCreator;
using BoardCreator;
    public class Game
    {
        private readonly Board board;
        private readonly List<Player> players;
        private int currentPlayerIndex = 0;

        public Game(int boardSize, List<Player> players)
        {
            board = new Board(boardSize);
            this.players = players;
        }

        public void Start()
        {
            Console.WriteLine("Rozpoczeto gre!");
            while (!IsGameOver())
            {
                PlayTurn();
            }
            DisplayResults();
        }

        private bool IsGameOver()
        {
            foreach (var player in players)
            {
                if (player.Position == board.Size -1)
                {
                    Console.WriteLine($"{player.Name} doszedl do konca planszy, zakonczono gre!");
                    return true;
                }
            }
            return false;
        }

        private void PlayTurn()
        {
            Player currentPlayer = players[currentPlayerIndex % players.Count];
            Console.WriteLine($"Tura gracza {currentPlayer.Name}.");

            int diceRoll = RollDice();
            Console.WriteLine($"{currentPlayer.Name} wyrzucil {diceRoll}.");
            currentPlayer.Move(diceRoll, board.Size);

            Console.WriteLine($"{currentPlayer.Name} uzyl swojej umiejetnosci klasy!");
            currentPlayer.UseSpecialAbility();

            int reward = board.GetReward(currentPlayer.Position);
            if (reward > 0)
            {
                currentPlayer.UpdateScore(reward);
            }
            else
            {
                Console.WriteLine($"Brak nagrody na polu.");
            }

            currentPlayerIndex++;
        }

        private int RollDice()
        {
            Random rand = new Random();
            return rand.Next(1, 7);
        }

        private void DisplayResults()
        {
            Console.WriteLine("Koniec gry! Oto wyniki:");
            foreach (Player player in players)
            {
                Console.WriteLine($"{player.Name}: {player.Score} pkt.");
            }
        }
    }