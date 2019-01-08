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

        public Player(string nickname, int score)
        {
            this.nickname = nickname;
            this.score = score;
        }   

        public string getNickName
        {
            get
            {
                return this.nickname;
            }
            set
            {
                this.nickname = value;
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
               this.score = value; 
            }
        }      
    }
}
