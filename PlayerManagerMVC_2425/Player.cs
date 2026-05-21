using System;

namespace PlayerManagerMVC
{
    // Model class representing a player with a name and score.
    // Implements IComparable to allow sorting by score by default.
    public class Player : IComparable<Player>
    {
        public string Name { get; }
        public int Score { get; }

        // Create a new player with the given name and score.
        public Player(string name, int score)
        {
            Name = name;
            Score = score;
        }

        // Return a readable string representation of the player.
        public override string ToString()
        {
            return $"{Name} ({Score})";
        }

        // Compare players by score in descending order so higher scores sort first.
        public int CompareTo(Player other)
        {
            if (other is null)
                return 1;
            return other.Score - Score;
        }
    }
}