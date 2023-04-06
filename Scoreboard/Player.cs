using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoreboard
{
    internal class Player
    {
        public string Username { get; set; }
        public int HighScore { get; set; }

        public Player()
        {

        }

        public Player(string username, int highScore)
        {
            this.Username = username;
            this.HighScore = highScore;
        }
    }
}
