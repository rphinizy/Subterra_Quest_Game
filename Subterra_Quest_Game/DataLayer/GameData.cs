using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                Name="Crunchy",
                Form ="Human",
                FormImg = "Images/hand.png",
                Health = 100,
                Experience = 20,
                Defense = 2,
                Strength = 2,
                StatPoints =3,
                Color = Player.ColorType.Red,
                Inventory = new ObservableCollection<GameItem>()
                {
                  
                }
            
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

        private static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.ID == id);
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

            gameMap.StandardGameItems = StandardGameItems();

            gameMap.MapLocations[4, 2] = new Location()
            {
                Name = "Welcome",
                Description = "\nWelcome to the subterranean world of creepy crawlies." +
                "\nStart your new life as a fierce ground beetle and fight monsters" +
                "\nfor experience and loot as you make your way to Mole-City! ",
                Accessible = true,
                ModifyForm = "Human",
                ModifyFormImg = "Images/hand.png",
                ModifyChamberColor = "RosyBrown",
                ModifyPlayerMessage = ""
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
                ModifyMapLocatorTop ="140",
                ModifyMapLocatorLeft="113",
                ModifyPlayerMessage = ""
            };

            gameMap.MapLocations[1, 2] = new Location()
            {
                Name = "NE Beetle Cave",
                Description = "It's dark and damp.",
                Accessible = true,
                ModifyForm = "Beetle",
                ModifyFormImg = "Images/beetle3.png",
                ModifyChamberColor = "Black",
                ModifyMapLocatorTop = "140",
                ModifyMapLocatorLeft = "133",
                ModifyPlayerMessage = ""

            };

            gameMap.MapLocations[2, 1] = new Location()
            {
                Name = "SW Beetle Cave",
                Description = "You see a worm!",
                Accessible = true,
                ModifyForm = "Beetle",
                ModifyFormImg = "Images/beetle3.png",
                ModifyChamberColor = "Black",
                ModifyMapLocatorTop = "155",
                ModifyMapLocatorLeft = "113",
                ModifyPlayerMessage = "",
                GameItems = new ObservableCollection<GameItem>
                {
                    GameItemById(1001)
                }
            };

            gameMap.MapLocations[2, 2] = new Location()
            {
                Name = "SE Beetle Cave",
                Description = "You see a tunnel to the east. \n A dark figure is standing on the other side",
                Accessible = true,
                ModifyForm = "Beetle",
                ModifyFormImg = "Images/beetle3.png",
                ModifyChamberColor = "Black",
                ModifyMapLocatorTop = "155",
                ModifyMapLocatorLeft = "133",
                ModifyPlayerMessage = ""

            };

            gameMap.MapLocations[2, 3] = new Location()
            {
                Name = "Road 1 West",
                Description = "Up ahead to the east is a hooded creature/man...thing?",
                Accessible = true,
                ModifyForm = "Beetle",
                ModifyFormImg = "Images/beetle3.png",
                ModifyChamberColor = "Black",
                ModifyMapLocatorTop = "158",
                ModifyMapLocatorLeft = "155",
                ModifyPlayerMessage = "",
                GameItems = new ObservableCollection<GameItem>
                {
                    GameItemById(2002)
                }
            };
            gameMap.MapLocations[2, 4] = new Location()
            {
                Name = "Road 1 East",
                Description = "He does not say anything.\n He is waiting for you to do something",
                Accessible = true,
                ModifyForm = "Beetle",
                ModifyFormImg = "Images/beetle3.png",
                ModifyChamberColor = "Black",
                ModifyMapLocatorTop = "160",
                ModifyMapLocatorLeft = "178",
                ModifyPlayerMessage = ""
            };
            gameMap.MapLocations[2, 5] = new Location()
            {
                Name = "Mole City NW",
                Description = "Before you lies a huge city of Mole-People!.\n There are tunnels leading in every direction.",
                Accessible = true,
                ModifyForm = "Mole",
                ModifyFormImg = "Images/mole3.png",
                ModifyChamberColor = "DarkGray",
                ModifyMapLocatorTop = "170",
                ModifyMapLocatorLeft = "195",
                ModifyPlayerMessage = "",
                RequiredRareItemID = 2002

            };
            gameMap.MapLocations[2, 6] = new Location()
            {
                Name = "Mole City NE",
                Description = "You see the city exit to the East",
                Accessible = true,
                ModifyForm = "Mole",
                ModifyFormImg = "Images/mole3.png",
                ModifyChamberColor = "DarkGray",
                ModifyMapLocatorTop = "170",
                ModifyMapLocatorLeft = "215",
                ModifyPlayerMessage = ""
            };
            gameMap.MapLocations[3, 5] = new Location()
            {
                Name = "Mole City SW",
                Description = "You see a small gated entrance with a sign that says Worm Farm",
                Accessible = true,
                ModifyForm = "Mole",
                ModifyFormImg = "Images/mole3.png",
                ModifyChamberColor = "DarkGray",
                ModifyMapLocatorTop = "185",
                ModifyMapLocatorLeft = "195",
                ModifyPlayerMessage = ""
            };
            gameMap.MapLocations[3, 6] = new Location()
            {
                Name = "Mole City SE",
                Description = "More Mole-People",
                Accessible = true,
                ModifyForm = "Mole",
                ModifyFormImg = "Images/mole3.png",
                ModifyChamberColor = "DarkGray",
                ModifyMapLocatorTop = "185",
                ModifyMapLocatorLeft = "215",
                 GameItems = new ObservableCollection<GameItem>
                {
                    GameItemById(1002)
                }
            };
            gameMap.MapLocations[2, 7] = new Location()
            {
                Name = "Road 2 West",
                Description = "Up ahead is another Mysterious figure",
                Accessible = true,
                ModifyForm = "Mole",
                ModifyFormImg = "Images/mole3.png",
                ModifyChamberColor = "DarkGray",
                ModifyMapLocatorTop = "165",
                ModifyMapLocatorLeft = "230",
                ModifyPlayerMessage = ""
            };
            gameMap.MapLocations[2, 8] = new Location()
            {
                Name = "Road 2 East",
                Description = "The creature before you stares blankly",
                Accessible = true,
                ModifyForm = "Mole",
                ModifyFormImg = "Images/mole3.png",
                ModifyChamberColor = "DarkGray",
                ModifyMapLocatorTop = "160",
                ModifyMapLocatorLeft = "250",
                ModifyPlayerMessage = ""
            };
            gameMap.MapLocations[2, 9] = new Location()
            {
                Name = "Burrow SW",
                Description = "You see a village teaming with cute, adorable bunny rabbits. \nOh wait! You are also a rabbit now",
                Accessible = true,
                ModifyForm = "Bunny",
                ModifyFormImg = "Images/bunny.png",
                ModifyChamberColor = "DarkSlateGray",
                ModifyMapLocatorTop = "160",
                ModifyMapLocatorLeft = "275",
                ModifyPlayerMessage = ""
            };
            gameMap.MapLocations[1, 9] = new Location()
            {
                Name = "Burrow NW",
                Description = "A bunny family crosses your path",
                Accessible = true,
                ModifyForm = "Bunny",
                ModifyFormImg = "Images/bunny.png",
                ModifyChamberColor = "DarkSlateGray",
                ModifyMapLocatorTop = "140",
                ModifyMapLocatorLeft = "275",
                ModifyPlayerMessage = ""

            };
            gameMap.MapLocations[1, 10] = new Location()
            {
                Name = "Burrow NE",
                Description = "You find nothing",
                Accessible = true,
                ModifyForm = "Bunny",
                ModifyFormImg = "Images/bunny.png",
                ModifyChamberColor = "DarkSlateGray",
                ModifyMapLocatorTop = "140",
                ModifyMapLocatorLeft = "300",
                ModifyPlayerMessage = "",
                GameItems = new ObservableCollection<GameItem>
                {
                    GameItemById(1003)
                }
            };
            gameMap.MapLocations[2, 10] = new Location()
            {
                Name = "Burrow SE",
                Description = "You see a path leading east outside of the burrow",
                Accessible = true,
                ModifyForm = "Bunny",
                ModifyFormImg = "Images/bunny.png",
                ModifyChamberColor = "DarkSlateGray",
                ModifyMapLocatorTop = "160",
                ModifyMapLocatorLeft = "300",
                ModifyPlayerMessage = "",
                GameItems = new ObservableCollection<GameItem>
                {
                    GameItemById(2001)
                }
            };
            gameMap.MapLocations[2, 11] = new Location()
            {
                Name = "Crossroads W",
                Description = "A figure beckons you over. He has... questions",
                Accessible = true,
                ModifyForm = "Bunny",
                ModifyFormImg = "Images/bunny.png",
                ModifyChamberColor = "DarkSlateGray",
                ModifyMapLocatorTop = "163",
                ModifyMapLocatorLeft = "325",
                ModifyPlayerMessage = ""
            };
            gameMap.MapLocations[2, 12] = new Location()
            {
                Name = "Crossroads",
                Description = "The figure points. I think he wants you to go that way",
                Accessible = true,
                ModifyForm = "Bunny",
                ModifyFormImg = "Images/bunny.png",
                ModifyChamberColor = "DarkSlateGray",
                ModifyMapLocatorTop = "167",
                ModifyMapLocatorLeft = "355",
                ModifyPlayerMessage = ""
            };
            gameMap.MapLocations[3, 12] = new Location()
            {
                Name = "Geode Cavern",
                Description = "You see a huge Geode looking golem monster!\n\n He is preparing to fight!",
                Accessible = true,
                ModifyForm = "Bunny",
                ModifyFormImg = "Images/bunny.png",
                ModifyChamberColor = "DarkSlateGray",
                ModifyMapLocatorTop = "190",
                ModifyMapLocatorLeft = "375",
                ModifyPlayerMessage = ""
            };

            gameMap.MapLocations[2, 13] = new Location()
            {
                Name = "Garden",
                Description = "There's a farmer and he has a rake.\n He sees you...\n He moves towards you... \n He RUNS towards you.",
                Accessible = true,
                ModifyForm = "Jackalope",
                ModifyFormImg = "Images/jackalope.png",
                ModifyChamberColor = "DarkSlateGray",
                ModifyMapLocatorTop = "160",
                ModifyMapLocatorLeft = "395",
                ModifyPlayerMessage = "",
                RequiredRareItemID = 2001
            };

            return gameMap;
        }

        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Food(1001, "Worms", 10, Food.UseActionType.HEALPLAYER, "A pile of slimy wriggling worms. Yum!", 50 ,"They wiggle all the way down", "Images/unknownItem.jpg"),
                new Food(1002, "GoldWorms", 100, Food.UseActionType.HEALPLAYER, "A glittering golden pile of worms. So shiny!", 100, "Not bad!", "Images/unknownItem.jpg"),
                new Food(1003, "Carrot", 15, Food.UseActionType.HEALPLAYER, "Bright orange and crunchy", 75, "hits the spot","Images/unknownItem,jpg"),
                new RareItem(2001, "Antlers of Jackalope", 1000, RareItem.RareList.Antlers, "Dangerous looking sharp pointy antlers fitted to a helmet.", 300, "You equip the helmet. Perfect fit and ready for battle!","Images/unknownItem,jpg"),
                new RareItem(2002, "Mole Hair", 500, RareItem.RareList.MoleHair, "Fuzzy patch of hair", 100, "You transformed!", "Images/unknownItem,jpg")
            };
        }
    }



}
