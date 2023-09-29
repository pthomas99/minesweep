using MineSweeper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Components
{
    public class Game : IGame
    {
        public IPlayer Player { get; set; }
        public IDisplay Output { get; set; }
        public IBoard Board { get; set; }

        public void Display()
        {
            Board.Display(Output);
            Output.Write($"Current Position: {Board.CurrentTile.Value} Lives: {Player.NumberOfLives} Moves: {Player.NumberOfMoves} " + Environment.NewLine);
            Output.Write("Enter your next move: use 'up' 'down' left' 'right' commands" + Environment.NewLine);
        }

        public bool GameOver
        {
            get { return LostGame || WonGame; }
        }
        public bool LostGame
        {
            get { return Player.NumberOfLives == 0; }
        }

        public bool WonGame
        {
            get { return !LostGame && Board.IsLastColumn; }
        }
        public bool Move(string move)
        {
            bool validMove = false;
            switch(move) 
            {
                case "up":
                    validMove = Board.Move(Enums.MoveType.UP);
                    break;
                case "down":
                    validMove = Board.Move(Enums.MoveType.DOWN);
                    break;
                case "left":
                    validMove = Board.Move(Enums.MoveType.LEFT);
                    break;
                case "right":
                    validMove = Board.Move(Enums.MoveType.RIGHT);
                    break;
                default:
                    break;
            }
            if (validMove) 
            {
                Player.NumberOfMoves++;
                if (!Board.CurrentTile.Revealed)
                {
                    Board.CurrentTile.Revealed = true;
                    // Check for Mines
                    if (Board.CurrentTile.Type == Enums.TileType.MINE)
                    {
                        // Loose Life.
                        Player.NumberOfLives--;
                    }
                }
            }
            return validMove;
        }
        public void NewGame(IPlayer player, IBoard board, IDisplay display)
        {
            Player = player;
            Board = board;
            Output = display;
        }

    }     
}
