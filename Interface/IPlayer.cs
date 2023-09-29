using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Interface
{
    public interface IPlayer
    {
        int NumberOfMoves { get; set; }
        int NumberOfLives { get; set; }

    }
}
