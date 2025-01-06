using System;
using System.Collections.Generic;
using Abilities;
using GameCreator;
using PlayerCreator;
using BoardCreator;

namespace BoardGameSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();

            Console.WriteLine("Rozpoczeto gre!");
            Console.Write("Podaj ilosc graczy: ");
            int playerCount = int.Parse(Console.ReadLine());

            Console.Write("Podaj ilosc pol na planszy: ");
            int boardSize = int.Parse(Console.ReadLine());

            for (int i = 1; i <= playerCount; i++)
            {
                Console.Write($"Podaj imie gracza nr. {i}: ");
                string name = Console.ReadLine();

                Console.WriteLine("Wybierz klase gracza:");
                Console.WriteLine("1. Warrior\n2. Mage\n3. Healer");
                Console.Write("(1/2/3): ");
                int choice = int.Parse(Console.ReadLine());

                IPlayerType playerType = choice switch
                {
                    1 => new Warrior(),
                    2 => new Mage(),
                    3 => new Healer(),
                    _ => throw new ArgumentException("Nieprawidlowy wybor.")
                };

                players.Add(new Player { Name = name, PlayerType = playerType });
            }

            Game game = new Game(boardSize, players);
            game.Start();
        }
    }
}
