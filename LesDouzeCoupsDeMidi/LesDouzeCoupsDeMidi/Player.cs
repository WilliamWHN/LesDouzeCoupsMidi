using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesDouzeCoupsDeMidi
{
    class Player
    {
        private string nickname;
        private int score;
        private TimeSpan elapsedTime;

        public Player(string nickname, int score, TimeSpan elapsedTime)
        {
              
        }   

        public string getNickName
        {
            get
            {
                return this.nickname;
            }
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            set
            {
               this.score = score; 
            }
        }      
    }
}
