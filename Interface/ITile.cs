using MineSweeper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Interface
{
    public interface ITile
    {
        TileType Type { get; set; }
        string Value { get; set; }
        bool Revealed { get; set; }
        string ToString();
    }
}
