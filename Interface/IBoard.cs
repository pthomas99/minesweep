using MineSweeper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Interface
{
    public interface IBoard
    {
        int BoardSize { get; set; }

        int BoardArea { get; }

        int MaxMines {  get; }

        bool IsLastColumn { get; }
        ITile CurrentTile { get; }
        bool Move(MoveType move);
        void Display(IDisplay display);
    }
}
