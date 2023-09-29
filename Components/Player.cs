using MineSweeper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Components
{
    public class Player : IPlayer
    {
        public Player(int defaultNumberOfLives)
        {
            NumberOfLives = defaultNumberOfLives;
        }

        public int NumberOfMoves { get; set; } = 0;
        public int NumberOfLives { get; set; }
    }

}
