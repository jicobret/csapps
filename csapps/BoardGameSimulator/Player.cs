namespace PlayerCreator;
using Abilities;
public class Player
{
    public string Name { get; set; }
    public int Position { get; set; } = 0;
    public int Score { get; set; } = 0;
    public IPlayerType PlayerType { get; set; }

    public void Move(int steps, int boardSize)
    {
        Position = Math.Min(Position + steps, boardSize - 1);
        Console.WriteLine($"{Name} poruszyl sie na pole {Position}.");
    }

    public void UpdateScore(int points)
    {
        Score += points;
        Console.WriteLine($"{Name} zyskal {points} pkt. Punkty: {Score}.");
    }

    public void UseSpecialAbility()
    {
        PlayerType.SpecialAbility(this);
    }
}