namespace Abilities;
using PlayerCreator;

public interface IPlayerType{
    void SpecialAbility(Player player);
}

public class Warrior : IPlayerType
{
    public void SpecialAbility(Player player)
    {
        player.UpdateScore(5);
        Console.WriteLine($"{player.Name} (Warrior) otrzymuje bonus 5 punktow!");
    }
}

public class Mage : IPlayerType
{
    public void SpecialAbility(Player player)
    {
        player.UpdateScore(2);
        Console.WriteLine($"{player.Name} (Mage) rzuca czar, przyzywajac 2 punkty!");
    }
}

public class Healer : IPlayerType
{
    public void SpecialAbility(Player player)
    {
        player.UpdateScore(3);
        Console.WriteLine($"{player.Name} (Healer) uleczyl sie, zyskujac 3 punkty!");
    }
}
