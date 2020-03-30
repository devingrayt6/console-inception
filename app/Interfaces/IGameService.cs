using System.Collections.Generic;

namespace inception.Interfaces
{

    interface IGameService
    {
        //go, look, take, use, inventory, Rest, setup, help
        List<string> Messages { get; set; }
        // void Reset();

        // #region Console Commands
        // bool Go(string direction);
        // void Look();
        // void Take(string itemName);
        // void Use(string itemName);
        // void Inventory();
        // void Help();
        // #endregion
    }
}