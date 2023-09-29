using MineSweeper.Enums;
using MineSweeper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Components
{
    public class Tile : ITile
    {
        public TileType Type { get; set; }
        public string Value { get; set; }
        public bool Revealed { get; set; } = false;

        public Tile(TileType type, string value)
        {
            Type = Type;
            Value = value;
        }

        public override string ToString()
        {
            string revealValue = " ";
            if (Revealed) 
            {
                // Default tile.
                revealValue = "-";
                if (Type == TileType.MINE)
                {
                    // Mine tile
                    revealValue = "*";
                }
            }
            return $"[{revealValue}]";
        }
    }

}
