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
            Room darkRoom = new Room("Dark Room", "You are in a dark room and can't see a thing. You do however feel something dangling at about eye level. Feels like a small chain of some type.");
            Room classRoom = new Room("Class Room", "You seem to be in mr. Yangs old highschool math class. It also seems...you're not wearing pants! How embarrassing! Everyone is laughing at you!! Looks like there's a door to the north...");
            Room hallWay = new Room("Hall Way", "You are in the Hall Way...There is a door at the end of the hall (east).");
            Room tvRoom= new Room("tvRoom", "There is a couch in front of you with a man who you recognize as mr. Yang watching television. You look at the TV and realize the movie is about you! You seem to be starring in The Breakfast Club... as the teacher...");

            // Third level Rooms
            Room safeRoom = new Room("Safe Room", "You are in an empty room that is completely white. Floor, ceiling, walls...All white except for a black safe in the middle. The safe has a keypad with [1][2][3][4]. Type [passcode: <thepasscode>] to crack open the safe!");
            
            // NOTE Create all Items
            Item chain = new Item("chain", "A small chain that is hanging above your head...");

            // NOTE Make Room Relationships

            //First Dream Level 
            backPlane.Exits.Add("forward", middlePlane);
            middlePlane.Exits.Add("backward", backPlane);
            middlePlane.Exits.Add("forward", frontPlane);
            frontPlane.Exits.Add("backward", middlePlane);
            frontPlane.Exits.Add("forward", cockPit);
            cockPit.Exits.Add("backward", frontPlane);

            // Second Dream Level
            darkRoom.Exits.Add("switch", classRoom);
            classRoom.Exits.Add("north", hallWay);
            hallWay.Exits.Add("east", tvRoom);
            hallWay.Exits.Add("south", classRoom);
            tvRoom.Exits.Add("west", hallWay);

            // Set inception relationships
            cockPit.InceptTo = darkRoom;
            tvRoom.InceptTo = safeRoom;


            // NOTE put Items in Rooms
            darkRoom.Items.Add(chain);

            CurrentRoom = middlePlane;
        }
    }
}