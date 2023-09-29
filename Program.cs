// See https://aka.ms/new-console-template for more information
using MineSweeper.Components;
using MineSweeper.Interface;
using System.Reflection.Metadata.Ecma335;
using System.Text;

const int DefaultNumberOfLives = 3;
IPlayer player = new Player(DefaultNumberOfLives);
IDisplay display = new DebugDisplay();
IBoard board = new Board();
IGame game = new Game();
game.NewGame(player, board, display);
game.Display();
do
{
    string? input = display.Read();
    if (!game.Move(input))
    {
        display.Write("INVALID MOVE" + Environment.NewLine);
    }
    game.Display();
} while (!game.GameOver);
if (game.WonGame)
{
    display.Write($"YOU WON IN {player.NumberOfMoves} MOVES" + Environment.NewLine);
}
display.Write("GAME OVER" + Environment.NewLine);



