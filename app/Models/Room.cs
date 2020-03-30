using System.Collections.Generic;
using inception.Interfaces;

namespace inception.Models
{
    class Room : IRoom
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public List<IItem> Items { get; set; }
        public Dictionary<string, IRoom> Exits { get; set; }
        public Dictionary<IItem, KeyValuePair<string, IRoom>> LockedExits { get; set; }
        public IRoom InceptTo { get; set; }

        public void AddLockedRoom(IItem key, string direction, IRoom room)
        {
            var lockedRoom = new KeyValuePair<string, IRoom>(direction, room);
            LockedExits.Add(key, lockedRoom);
        }

        public string Use(IItem item)
        {
            if (LockedExits.ContainsKey(item))
            {
                Exits.Add(LockedExits[item].Key, LockedExits[item].Value);
                LockedExits.Remove(item);
                if (item.Name.ToLower() == "key")
                {
                    return "You go one dream deeper...";
                }
                return "You have unlocked a room";
            }
            return "No use for that here";
        }

        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Items = new List<IItem>();
            Exits = new Dictionary<string, IRoom>();
            LockedExits = new Dictionary<IItem, KeyValuePair<string, IRoom>>();
        }
    }
}