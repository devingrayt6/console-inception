using System;
using inception.Controllers;
using inception.Interfaces;

namespace console_inception
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            IGameController gc = new GameController();
            gc.Run();
        }
    }
}
