using MineSweeper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Components
{
    public class DebugDisplay : IDisplay
    {
        public string? Read()
        {
            return Console.ReadLine();
        }

        public void Write(string? value)
        {
            Console.Write(value);
        }

    }
}
