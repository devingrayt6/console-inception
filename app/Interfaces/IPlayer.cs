using System.Collections.Generic;

namespace inception.Interfaces
{

    interface IPlayer
    {
        string Name { get; set; }
        List<IItem> Inventory {get; set; }
    }
}