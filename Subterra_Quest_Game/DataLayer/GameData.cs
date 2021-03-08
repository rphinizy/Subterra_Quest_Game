using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subterra_Quest_Game.Models;

namespace Subterra_Quest_Game.DataLayer
{
    public static class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                Name = "Crunchy",
                //FormOf = Player.PlayerForms.Beetle,
                Form ="Human",
                FormImg = "Images/hand.png",
                Health = 100,
                Experience = 20,
                Defense = 2,
                Strength = 2,
                StatPoints =3
            };
        }

        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                "\n          Welcome to the subterranean world of creepy crawlies.",
                "    Start your new life as a fierce ground beetle and fight monsters \n     for experience and loot as you make your way to Mole-City! "
                
            };
        }

        public static GameMapCoordinates InitialGameMapLocation()
        {
            return new GameMapCoordinates() { Row = 4, Column = 2 };
        }

        public static Map GameMap()
        {
            int rows = 5;
            int columns = 15;

            Map gameMap = new Map(rows, columns);

            gameMap.MapLocations[4, 2] = new Location()
            {
                Name = "Welcome",
                Description = "\nWelcome to the subterranean world of creepy crawlies."+
                "\nStart your new life as a fierce ground beetle and fight monsters" +
                "\nfor experience and loot as you make your way to Mole-City! ",
                Accessible = true,
                ModifyForm = "Human",
                ModifyFormImg = "Images/hand.png",
                ModifyChamberColor ="RosyBrown"
            };

            gameMap.MapLocations[1, 1] = new Location()
            {
                Name = "NW Beetle Cave",
                Description = "\nIt's dark and damp. You hear soft rumblings beneath the dirt." +
                "\nMaybe you should try moving around",
                Accessible = true,
                ModifyForm = "Beetle",
                ModifyFormImg = "Images/beetle3.png",
                ModifyChamberColor = "Black",
                ModifyMapLocatorTop ="135",
                ModifyMapLocatorLeft="95"
            };

            gameMap.MapLocations[1, 2] = new Location()
            {
                Name = "NE Beetle Cave",
                Description = "It's dark and damp.",
                Accessible = true,
                ModifyForm = "Beetle",
                ModifyFormImg = "Images/beetle3.png",
                ModifyChamberColor = "Black",
                ModifyMapLocatorTop = "135",
                ModifyMapLocatorLeft = "115"
            };

            gameMap.MapLocations[2, 1] = new Location()
            {
                Name = "SW Beetle Cave",
                Description = "You see a worm!",
                Accessible = true,
                ModifyForm = "Beetle",
                ModifyFormImg = "Images/beetle3.png",
                ModifyChamberColor = "Black",
                ModifyMapLocatorTop = "145",
                ModifyMapLocatorLeft = "95"
            };

            gameMap.MapLocations[2, 2] = new Location()
            {
                Name = "SE Beetle Cave",
                Description = "You see a tunnel to the east and a figure standing on the other side",
                Accessible = true,
                ModifyForm = "Beetle",
                ModifyFormImg = "Images/beetle3.png",
                ModifyChamberColor = "Black",
                ModifyMapLocatorTop = "145",
                ModifyMapLocatorLeft = "115"
            };

            gameMap.MapLocations[2, 3] = new Location()
            {
                Name = "Road 1 West",
                Description = "Up ahead to the east is a hooded creature/man...thing?",
                Accessible = true,
                ModifyForm = "Beetle",
                ModifyFormImg = "Images/beetle3.png",
                ModifyChamberColor = "Black",
                ModifyMapLocatorTop = "145",
                ModifyMapLocatorLeft = "140"
            };
            gameMap.MapLocations[2, 4] = new Location()
            {
                Name = "Road 1 East",
                Description = "He does not say anything. He does not let you pass either",
                Accessible = false,
                ModifyForm = "Beetle",
                ModifyFormImg = "Images/beetle3.png",
                ModifyChamberColor = "Black",
                ModifyMapLocatorTop = "155",
                ModifyMapLocatorLeft = "178"
            };
            gameMap.MapLocations[2, 5] = new Location()
            {
                Name = "Mole City NW",
                Description = "Before you lies a huge city of Mole-People!. There are tunnels leading in every direction.",
                Accessible = false,
                ModifyForm = "Mole",
                ModifyFormImg = "Images/mole3.png",
                ModifyChamberColor = "DarkGray",
                ModifyMapLocatorTop = "165",
                ModifyMapLocatorLeft = "190"

            };
            gameMap.MapLocations[2, 6] = new Location()
            {
                Name = "Mole City NE",
                Description = "You see the city exit to the East",
                Accessible = false,
                ModifyForm = "Mole",
                ModifyFormImg = "Images/mole3.png",
                ModifyChamberColor = "DarkGray",
                ModifyMapLocatorTop = "170",
                ModifyMapLocatorLeft = "220"
            };
            gameMap.MapLocations[3, 5] = new Location()
            {
                Name = "Mole City SW",
                Description = "You see a small gated entrance with a sign that says Worm Farm",
                Accessible = false,
                ModifyForm = "Mole",
                ModifyFormImg = "Images/mole3.png",
                ModifyChamberColor = "DarkGray",
                ModifyMapLocatorTop = "185",
                ModifyMapLocatorLeft = "195"
            };
            gameMap.MapLocations[3, 6] = new Location()
            {
                Name = "Mole City SE",
                Description = "More Mole-People",
                Accessible = false,
                ModifyForm = "Mole",
                ModifyFormImg = "Images/mole3.png",
                ModifyChamberColor = "DarkGray",
                ModifyMapLocatorTop = "185",
                ModifyMapLocatorLeft = "215"
            };
            gameMap.MapLocations[2, 7] = new Location()
            {
                Name = "Road 2 West",
                Description = "Up ahead is another Mysterious figure",
                Accessible = false,
                ModifyForm = "Mole",
                ModifyFormImg = "Images/mole3.png",
                ModifyChamberColor = "DarkGray",
                ModifyMapLocatorTop = "165",
                ModifyMapLocatorLeft = "250"
            };
            gameMap.MapLocations[2, 8] = new Location()
            {
                Name = "Road 2 East",
                Description = "The creature before you stares blankly before crunching on a carrot",
                Accessible = false,
                ModifyForm = "Mole",
                ModifyFormImg = "Images/mole3.png",
                ModifyChamberColor = "DarkGray",
                ModifyMapLocatorTop = "160",
                ModifyMapLocatorLeft = "270"
            };
            gameMap.MapLocations[2, 9] = new Location()
            {
                Name = "Burrow SW",
                Description = "You see a village teaming with cute, adorable bunny rabbits. Oh wait! You are also a rabbit now",
                Accessible = false,
                ModifyForm = "Bunny",
                ModifyFormImg = "Images/bunny.png",
                ModifyChamberColor = "DarkSlateGray",
                ModifyMapLocatorTop = "163",
                ModifyMapLocatorLeft = "290"
            };
            gameMap.MapLocations[1, 9] = new Location()
            {
                Name = "Burrow NW",
                Description = "A bunny family crosses your path",
                Accessible = false,
                 ModifyForm = "Bunny",
                ModifyFormImg = "Images/bunny.png",
                ModifyChamberColor = "DarkSlateGray",
                ModifyMapLocatorTop = "140",
                ModifyMapLocatorLeft = "290"

            };
            gameMap.MapLocations[1, 10] = new Location()
            {
                Name = "Burrow NE",
                Description = "You find nothing",
                Accessible = false,
                ModifyForm = "Bunny",
                ModifyFormImg = "Images/bunny.png",
                ModifyChamberColor = "DarkSlateGray",
                ModifyMapLocatorTop = "140",
                ModifyMapLocatorLeft = "308"
            };
            gameMap.MapLocations[2, 10] = new Location()
            {
                Name = "Burrow SE",
                Description = "You see a path leading east outside of the burrow",
                Accessible = false,
                ModifyForm = "Bunny",
                ModifyFormImg = "Images/bunny.png",
                ModifyChamberColor = "DarkSlateGray",
                ModifyMapLocatorTop = "163",
                ModifyMapLocatorLeft = "310"
            };
            gameMap.MapLocations[2, 11] = new Location()
            {
                Name = "Crossroads W",
                Description = "A figure beckons you over. He has..questions",
                Accessible = false,
                ModifyForm = "Bunny",
                ModifyFormImg = "Images/bunny.png",
                ModifyChamberColor = "DarkSlateGray",
                ModifyMapLocatorTop = "163",
                ModifyMapLocatorLeft = "340"
            };
            gameMap.MapLocations[2, 12] = new Location()
            {
                Name = "Crossroads",
                Description = "The figure points. I think he wants you to go that way",
                Accessible = false,
                ModifyForm = "Bunny",
                ModifyFormImg = "Images/bunny.png",
                ModifyChamberColor = "DarkSlateGray",
                ModifyMapLocatorTop = "168",
                ModifyMapLocatorLeft = "365"
            };
            gameMap.MapLocations[3, 12] = new Location()
            {
                Name = "Geode Cavern",
                Description = "You see a huge Geode looking golem monster!. He is preparing to fight!",
                Accessible = false,
                ModifyForm = "Bunny",
                ModifyFormImg = "Images/bunny.png",
                ModifyChamberColor = "DarkSlateGray",
                ModifyMapLocatorTop = "190",
                ModifyMapLocatorLeft = "375"
            };

            gameMap.MapLocations[2, 13] = new Location()
            {
                Name = "Garden",
                Description = "There's a farmer...and he has a rake... He sees you... He moves towards you... he RUNS towards you.",
                Accessible = false,
                ModifyForm = "Jackalope",
                ModifyFormImg = "Images/jackalope.png",
                ModifyChamberColor = "DarkSlateGray",
                ModifyMapLocatorTop = "160",
                ModifyMapLocatorLeft = "395"
            };


            return gameMap;
        }
       

    }
}
