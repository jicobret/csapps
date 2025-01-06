namespace BoardCreator;
using GameCreator;
using PlayerCreator;
using BoardGameSimulator;
public class Board
{
    private readonly int[] rewards;
    private readonly int size;

    public Board(int size)
    {
        this.size = size;
        rewards = new int[size];
        GenerateRewards();
    }

    private void GenerateRewards()
    {
        Random rand = new Random();
        for (int i = 0; i < size; i++)
        {
            rewards[i] = rand.Next(0, 11);
        }
    }

    public int GetReward(int position)
    {
        return rewards[position];
    }

    public int Size => size;
}