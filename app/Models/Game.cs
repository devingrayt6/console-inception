using inception.Interfaces;

namespace inception.Models
{
    class Game : IGame
    {
        public IPlayer CurrentPlayer { get; set; }
        public IRoom CurrentRoom { get; set; }

        ///<summary>Initalizes data and establishes relationships</summary>
        public Game()
        {
            // NOTE ALL THESE VARIABLES ARE REMOVED AT THE END OF THIS METHOD
            // We retain access to the objects due to the linked list


            // NOTE Create all rooms

            // First level rooms
            Room middlePlane = new Room("middle of plane", "You are are in the middle row of a medium sized airplane. You know your target is sitting somewhere on the plane. Use 'forward' and 'backward' to find your target. Use 'incept' to dive into his/her dreams when you do.");
            Room backPlane = new Room("back of plane", "You are at the back of the plane. You do not see your target, but you do see a rodent. Not a very clean plane...");
            Room frontPlane = new Room("front of plane", "You are at the front of the plane. You do not see your target. You do however notice that there are no airbags and only one parachute in case of an emergency...");
            Room cockPit = new Room("cockpit", "You are in the cockpit with the pilot and co pilot. You realize the pilot is your target and that the co pilot is currently asleep... incepting the pilot will knock him out...");
           
            // Second level Rooms
            Room produce = new Room("Produce Section", @"
                 \|/
                 AXA
                /XXX\
                \XXX/
                 `^'
            Plenty of Fruit and Veggies, wonder why no on is stockpiling these yet");
            Room electronics = new Room("Electronics", "Lots of stuff still here, yet no webcams in sight.");
            Room frozenFoods = new Room("Frozen Foods", "Mostly empty shelves though the vegan chocolate hummus is still in stock for some reason");
            EndRoom checkout = new EndRoom("Checkout", "A stressed minimum wage employee stares out you with a thousand yard stare, he has seen too much these last few weeks", true, "You breeze through the checkout with your new found wealth!");
            EndRoom toiletPaperIsle = new EndRoom("Toiletries", "A hoarde of people are racing through this aisle with their weapons out", false, "You are trampled under foot and your name is lost to history");

            // NOTE Create all Items
            Item tp = new Item("Toilet Paper", "A Single Roll of precious paper, it must have fallen from a pack");

            // NOTE Make Room Relationships

            //First Dream Level 
            backPlane.Exits.Add("forward", middlePlane);
            middlePlane.Exits.Add("backward", backPlane);
            middlePlane.Exits.Add("forward", frontPlane);
            frontPlane.Exits.Add("backward", middlePlane);
            frontPlane.Exits.Add("forward", cockPit);
            cockPit.Exits.Add("backward", frontPlane);

            // Second Dream Level
            produce.Exits.Add("east", electronics);
            electronics.Exits.Add("west", produce);
            electronics.Exits.Add("north", frozenFoods);
            electronics.Exits.Add("east", toiletPaperIsle);
            frozenFoods.Exits.Add("south", electronics);

            frozenFoods.AddLockedRoom(tp, "west", checkout);
            checkout.Exits.Add("east", frozenFoods);


            // Set inception relationships
            cockPit.InceptTo = produce;


            // NOTE put Items in Rooms
            electronics.Items.Add(tp);


            CurrentRoom = middlePlane;
        }
    }
}