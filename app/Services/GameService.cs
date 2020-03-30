using System;
using System.Collections.Generic;
using inception.Interfaces;
using inception.Models;

namespace inception.Services
{
  class GameService : IGameService
  {
    public List<string> Messages { get; set; }
    private IGame _game { get; set; }

    public GameService(string playerName)
    {
      Messages = new List<string>();
      _game = new Game();
      _game.CurrentPlayer = new Player(playerName);
      Look();
    }

    public bool Go(string direction)
    {
      //if the current room has that direction on the exits dictionary
      if (_game.CurrentRoom.Exits.ContainsKey(direction))
      {
        // set current room to the exit room
        _game.CurrentRoom = _game.CurrentRoom.Exits[direction];
        // populate messages with room description
        Messages.Add($"You Travel {direction}, and discover: ");
        Look();
        EndRoom end = _game.CurrentRoom as EndRoom;
        if (end != null)
        {
          Messages.Add(end.Narrative);
          return false;
        }
        return true;
      }
      //no exit in that direction
      Messages.Add("No Room in that direction");
      Look();
      return true;
    }

    public bool Incept()
    {
      if (_game.CurrentRoom.InceptTo != null)
      {
        _game.CurrentRoom = _game.CurrentRoom.InceptTo;
        Look();
        return true;
      }
      else if (_game.CurrentRoom.Name == "Safe Room")
      {
        Console.WriteLine("You have gone one dream to deep...You lose your grip on reality and dream for an eternity until...YOU DIE!");
        return false;
      }
      else
      {
        Console.WriteLine("You must be in the same room as your target to incept them!");
        return true;
      }
    }

    public void Help()
    {
      Console.Clear();
      Console.WriteLine("[look] describe surroundings");
      Console.WriteLine("[take <item>] take item");
      Console.WriteLine("[use <item>] Use an item");
      Console.WriteLine("[inventory] show what is in your inventory");
      Console.WriteLine("[go <direction>] go towards that direction");
      Console.WriteLine("[help] this...");

    }

    public void Inventory()
    {
      Messages.Add("Current Inventory: ");
      foreach (var item in _game.CurrentPlayer.Inventory)
      {
        Messages.Add($"{item.Name} - {item.Description}");
      }
    }

    public void Look()
    {
      Messages.Add(_game.CurrentRoom.Name);
      Messages.Add(_game.CurrentRoom.Description);
      if (_game.CurrentRoom.Items.Count > 0)
      {
        Messages.Add("There Are a few things in this room:");
        foreach (var item in _game.CurrentRoom.Items)
        {
          Messages.Add("     " + item.Name);
        }
      }
      // string exits = string.Join(", ", _game.CurrentRoom.Exits.Keys);
      // Messages.Add("There are exits to the " + exits);

      // string lockedExits = "";
      // foreach (var lockedRoom in _game.CurrentRoom.LockedExits.Values)
      // {
      //     lockedExits += lockedRoom.Key;
      // }
      // Messages.Add("There are locked exits to the " + lockedExits);

    }

    public void Reset()
    {
      string name = _game.CurrentPlayer.Name;
      _game = new Game();
      _game.CurrentPlayer = new Player(name);
    }

    public void Take(string itemName)
    {
      IItem found = _game.CurrentRoom.Items.Find(i => i.Name.ToLower() == itemName);
      if (found != null)
      {
        _game.CurrentPlayer.Inventory.Add(found);
        _game.CurrentRoom.Items.Remove(found);
        Messages.Add($"You have taken the {itemName}");
        return;
      }
      Messages.Add("Cannot find item by that name");
    }

    public void Use(string itemName)
    {
      var found = _game.CurrentPlayer.Inventory.Find(i => i.Name.ToLower() == itemName);
      var foundInRoom = _game.CurrentRoom.Items.Find(i => i.Name.ToLower() == itemName);

      if (found != null)
      {
        Messages.Add(_game.CurrentRoom.Use(found));
      }
      else if (itemName == "chain")
      {
        _game.CurrentRoom = _game.CurrentRoom.Exits["switch"];
        Look();
      }
      else
      {
        Messages.Add("You don't have that Item");
      }
      // check if item is in Inventory
      return;
    }

    public bool CrackSafe(string code)
    {
      if (code == "1112")
      {
        Messages.Add("CONGRATULATION YOU WIN!!!");
      }
      else
      {
        Messages.Add("Unfortunately that is the wrong password. You blow up.");
      }
      return false;
    }

  }
}