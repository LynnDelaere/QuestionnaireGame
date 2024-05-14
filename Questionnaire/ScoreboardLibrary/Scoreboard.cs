using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreboardLibrary
{
    public class Scoreboard
    {
        private List<PlayerScore> scoreList;
        public Scoreboard()
        {
            scoreList = new List<PlayerScore>();
        }
        public void AddPlayer(string name, int score)
        {
            scoreList.Add(new PlayerScore(name, score));
        }
        public void UpdatePlayerScore(string name, int score)
        {
            foreach (PlayerScore player in scoreList)
            {
                if (player.Name == name)
                {
                    player.Score += score;
                }
            }
        }
        public override string ToString()
        {
            SortScoreboard();
            string scoreBoard = "";
            foreach (PlayerScore name in scoreList)
            {
                scoreBoard += name.ToString() + "\n";
            }
            return scoreBoard;
        }
        public List<PlayerScore> GetScoreList()
        {
            return scoreList.ToList();
        }
        public void SortScoreboard()
        {
            scoreList.Sort((player1, player2) => player2.Score.CompareTo(player1.Score));
        }
    }
}
