using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreboardLibrary
{
    public class PlayerScore
    {
        // Attributes
        private string name;
        private int score;

        // Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        public PlayerScore(string name, int score)
        {
            Name = name;
            Score = score;
        }
        public override string ToString()
        {
            return $"Name: {Name} Score: {Score}";
        }
    }
}
