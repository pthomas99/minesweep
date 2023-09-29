using MineSweeper.Enums;
using MineSweeper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Components
{
    public class Board : IBoard
    {
        public ITile[,] Tiles { get; set; }

        public int BoardSize { get; set; }

        public int BoardArea 
        {
            get { return BoardSize * BoardSize;}
         }

        public int MaxMines
        {
            get { return BoardArea / 3; }
        }

        private int CurrentX = 0;
        private int CurrentY = 0;

        public bool IsLastColumn
        {
            get { return CurrentY == BoardSize-1; }
        }

        public ITile CurrentTile
        {
            get { return Tiles[CurrentX, CurrentY]; }
        }
        public bool Move(MoveType move)
        {
            bool valid = false;
            var x = CurrentX;
            var y = CurrentY;
            switch(move)
            {
                case MoveType.UP:
                    if (x > 0)
                    {
                        x--;
                        valid = true;
                    }
                    break;
                case MoveType.DOWN:
                    if (x < BoardSize-1)
                    {
                        x++;
                        valid = true;
                    }
                    break;
                case MoveType.LEFT:
                    if (y > 0)
                    {
                        y--;
                        valid = true;
                    }
                    break;
                case MoveType.RIGHT:
                    if (y < BoardSize - 1)
                    {
                        y++;
                        valid = true;
                    }
                    break;
            }

            if (valid)
            {
                CurrentX = x;
                CurrentY = y;
            }
            return valid;          
        }


        /// <summary>
        /// generate a square playing board based on the size given = default to size of chess board 8x8
        /// </summary>
        /// <param name="boardSize"></param>
        public Board(int boardSize = 8)
        {
            BoardSize = boardSize;
            // generate a square playing board based on the size given 
            Tiles = BuildBoard();
            // add random mines  
            AddMines();
            SetStartPoition();
        }

        void SetStartPoition()
        {
            Random rnd = new Random();
            // always start to the left of the board - get random position.
            CurrentY = 0;
            bool isValid = false;
            while (!isValid)
            {
                int rndVal = rnd.Next(0, BoardArea);
                int x = rndVal / BoardSize;
                if (Tiles[x, CurrentY].Type != TileType.MINE)
                {
                    CurrentX = x;
                    CurrentTile.Revealed = true;
                    isValid = true;
                }
            }
        }

        private void AddMines()
        {
            // simple strategy to add mines - using the size of the board - fill 1/3 of the board with mines 
            // psudo code for algorim from https://www.cs.ubc.ca/~acton/techTrek/MineSweeper/Minesweeper.pdf
            int numMines = 0;
            Random rnd = new Random();
            while (numMines < MaxMines)
            {
                int rndVal = rnd.Next(0, BoardArea);
                int x = rndVal / BoardSize;
                int y = rndVal % BoardSize;

                if (Tiles[x, y].Type != TileType.MINE)
                {
                    Tiles[x, y].Type = TileType.MINE;
                    numMines++;
                }
            }
        }

        public void Display(IDisplay display)
        {
            for (int x = 0; x < BoardSize; x++)
            {
                // Display the X axis value of the Board - A1 is bottom left of board as per standard for Chess moves.
                display.Write(String.Format("{0,-3}", BoardSize - x));
                for (int y = 0; y < BoardSize; y++)
                {
                    // dispay the actual tile content on the board
                    display.Write($" {Tiles[x, y].ToString()} ");
                }
                display.Write(Environment.NewLine);
            }
            // Display the Y axis Value of the Board - uses the 
            display.Write(String.Format("{0,-4}", ""));
            for (int x = 0; x < BoardSize; x++)
            {
                display.Write(String.Format(" {0,-4}", (char)(Convert.ToChar('A') + x)));
            }
            display.Write(Environment.NewLine);
        }

        private Tile[,] BuildBoard()
        {
            Tile[,] tiles = new Tile[BoardSize, BoardSize];
            for (int x = 0; x < BoardSize; x++)
            {
                for (int y = 0; y < BoardSize; y++)
                {
                    string val = $"{(char)(Convert.ToChar('A') + y)}{BoardSize - x}";
                    tiles[x, y] = new Tile(TileType.EMPTY, val);
                }
            }
            return tiles;
        }
    }

}
