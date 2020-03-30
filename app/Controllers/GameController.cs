using System;
using inception.Interfaces;
using inception.Services;

namespace inception.Controllers
{
  class GameController : IGameController
  {

    private IGameService _gs { get; set; }
    private bool _running { get; set; } = false;
    public void Run()
    {
      Console.Clear();
      Console.WriteLine("WELCOME TO INCEPTION!");
      Console.WriteLine(@"
            You have entered into someone elses dream.
            Your mission is to the third level...
            a dream within a dream within a dream...
            and incept the target.

            At this level you will be able to access their private memory storage.
            
            Plant the Idea...

            And get back to reality...

            Without dying. 

            GOOD LUCK!!
            ");
      Console.Write("What is your name?: ");
      _gs = new GameService(Console.ReadLine());
      _running = true;

      Console.Clear();
      Print();

      while (_running)
      {
        GetUserInput();
        Print();
      }
    }

    public void GetUserInput()
    {
      // go north
      // take brass key
      // command option
      // look
      // command
      Console.WriteLine("What would you like to do?");
      string input = Console.ReadLine().ToLower() + " "; //go north ;take toilet paper ;look 
      string command = input.Substring(0, input.IndexOf(" ")); //go; take; look
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();//north; toilet paper;''

      Console.Clear();
      switch (command)
      {
        case "quit":
          _running = false;
          break;
        case "reset":
          _gs.Reset();
          break;
        case "look":
          _gs.Look();
          break;
        case "inventory":
          _gs.Inventory();
          break;
        case "go":
          _running = _gs.Go(option);
          break;
        case "incept":
          _running = _gs.Incept();
          break;
        case "passcode:":
          _running = _gs.CrackSafe(option);
          break;
        case "take":
          _gs.Take(option);
          break;
        case "use":
          _gs.Use(option);
          break;
        case "help":
          _gs.Help();
          break;
        default:
          _gs.Messages.Add("Not a recognized command");
          _gs.Look();
          break;
      }
    }

    public void Print()
    {
      foreach (string message in _gs.Messages)
      {
        Console.WriteLine(message);
      }
      _gs.Messages.Clear();
    }
  }

}