using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Interface
{
    public interface IGame
    {
        void NewGame(IPlayer player, IBoard board, IDisplay display);
        bool Move(string move);
        bool GameOver { get; }
        bool LostGame { get; }
        bool WonGame { get; }
        void Display();
    }
}
