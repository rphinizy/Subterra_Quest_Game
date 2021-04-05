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
                HealthPoints = 100,
                Experience = 20,
                Defense = 2,
                Strength = 2,
                StatPoints =3,
                SkillLevel =1,
                Color = Player.ColorType.Red,
                Inventory = new ObservableCollection<GameItem>()
                {
                  GameItemById(3001)
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

        private static NPC NpcById(int id)
        {
            return Npcs().FirstOrDefault(i => i.ID == id);
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
                Id=1,
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
                Id=2,
                Name = "NW Beetle Cave",
                Description = "\nIt's dark and damp. You hear soft rumblings beneath the dirt." +
                "\nMaybe you should try moving around",
                Accessible = true,
                ModifiyExperiencePoints = 10,
                ModifyForm = "Beetle",
                ModifyFormImg = "Images/beetle3.png",
                ModifyChamberColor = "Black",
                ModifyMapLocatorTop ="140",
                ModifyMapLocatorLeft="113",
                ModifyPlayerMessage = ""
            };

            gameMap.MapLocations[1, 2] = new Location()
            {
                Id=3,
                Name = "NE Beetle Cave",
                Description = "It's dark and damp... Something is moving",
                Accessible = true,
                ModifyForm = "Beetle",
                ModifiyExperiencePoints = 10,
                ModifyFormImg = "Images/beetle3.png",
                ModifyChamberColor = "Black",
                ModifyMapLocatorTop = "140",
                ModifyMapLocatorLeft = "133",
                ModifyPlayerMessage = "",
              NPCS = new ObservableCollection<NPC>
                {
                    NpcById(2001)
                }

            };

            gameMap.MapLocations[2, 1] = new Location()
            {
                Id=4,
                Name = "SW Beetle Cave",
                Description = "You see a worm!",
                Accessible = true,
                ModifiyExperiencePoints = 10,
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
                Id=5,
                Name = "SE Beetle Cave",
                Description = "You see a tunnel to the east. \n A dark figure is standing on the other side",
                Accessible = true,
                ModifiyExperiencePoints = 10,
                ModifyForm = "Beetle",
                ModifyFormImg = "Images/beetle3.png",
                ModifyChamberColor = "Black",
                ModifyMapLocatorTop = "155",
                ModifyMapLocatorLeft = "133",
                ModifyPlayerMessage = ""

            };

            gameMap.MapLocations[2, 3] = new Location()
            {
                Id=6,
                Name = "Road 1 West",
                Description = "Up ahead to the east is a hooded creature/man...thing?",
                Accessible = true,
                ModifiyExperiencePoints = 5,
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
                Id=7,
                Name = "Road 1 East",
                Description = "He does not say anything.\n He is waiting for you to do something",
                Accessible = false,
                ModifiyExperiencePoints = 5,
                ModifyForm = "Beetle",
                ModifyFormImg = "Images/beetle3.png",
                ModifyChamberColor = "Black",
                ModifyMapLocatorTop = "160",
                ModifyMapLocatorLeft = "178",
                ModifyPlayerMessage = "",
                NPCS = new ObservableCollection<NPC>
                {
                    NpcById(1001)
                }
            };
            gameMap.MapLocations[2, 5] = new Location()
            {
                Id=8,
                Name = "Mole City NW",
                Description = "Before you lies a huge city of Mole-People!.\n There are tunnels leading in every direction.",
                Accessible = true,
                ModifiyExperiencePoints = 20,
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
                Id=9,
                Name = "Mole City NE",
                Description = "You see the city exit to the East",
                Accessible = true,
                ModifiyExperiencePoints = 20,
                ModifyForm = "Mole",
                ModifyFormImg = "Images/mole3.png",
                ModifyChamberColor = "DarkGray",
                ModifyMapLocatorTop = "170",
                ModifyMapLocatorLeft = "215",
                ModifyPlayerMessage = ""
            };
            gameMap.MapLocations[3, 5] = new Location()
            {
                Id=10,
                Name = "Mole City SW",
                Description = "You see a small gated entrance with a sign that says Worm Farm",
                Accessible = true,
                ModifiyExperiencePoints = 20,
                ModifyForm = "Mole",
                ModifyFormImg = "Images/mole3.png",
                ModifyChamberColor = "DarkGray",
                ModifyMapLocatorTop = "185",
                ModifyMapLocatorLeft = "195",
                ModifyPlayerMessage = ""
            };
            gameMap.MapLocations[3, 6] = new Location()
            {
                Id=11,
                Name = "Mole City SE",
                Description = "More Mole-People",
                Accessible = true,
                ModifiyExperiencePoints = 20,
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
                Id=12,
                Name = "Road 2 West",
                Description = "Up ahead is another Mysterious figure",
                Accessible = true,
                ModifiyExperiencePoints = 5,
                ModifyForm = "Mole",
                ModifyFormImg = "Images/mole3.png",
                ModifyChamberColor = "DarkGray",
                ModifyMapLocatorTop = "165",
                ModifyMapLocatorLeft = "230",
                ModifyPlayerMessage = "",
                GameItems = new ObservableCollection<GameItem>
                {
                    GameItemById(2003)
                }
            };
            gameMap.MapLocations[2, 8] = new Location()
            {
                Id=13,
                Name = "Road 2 East",
                Description = "The creature before you stares blankly",
                Accessible = false,
                ModifiyExperiencePoints = 5,
                ModifyForm = "Mole",
                ModifyFormImg = "Images/mole3.png",
                ModifyChamberColor = "DarkGray",
                ModifyMapLocatorTop = "160",
                ModifyMapLocatorLeft = "250",
                ModifyPlayerMessage = "",
                RequiredRareItemID = 2003,

            };
            gameMap.MapLocations[2, 9] = new Location()
            {
                Id=14,
                Name = "Burrow SW",
                Description = "You see a village teaming with cute, adorable bunny rabbits. \nOh wait! You are also a rabbit now",
                Accessible = true,
                ModifiyExperiencePoints = 25,
                ModifyForm = "Bunny",
                ModifyFormImg = "Images/bunny.png",
                ModifyChamberColor = "DarkSlateGray",
                ModifyMapLocatorTop = "160",
                ModifyMapLocatorLeft = "275",
                ModifyPlayerMessage = ""
            };
            gameMap.MapLocations[1, 9] = new Location()
            {
                Id=15,
                Name = "Burrow NW",
                Description = "A bunny family crosses your path",
                Accessible = true,
                ModifiyExperiencePoints = 25,
                ModifyForm = "Bunny",
                ModifyFormImg = "Images/bunny.png",
                ModifyChamberColor = "DarkSlateGray",
                ModifyMapLocatorTop = "140",
                ModifyMapLocatorLeft = "275",
                ModifyPlayerMessage = ""

            };
            gameMap.MapLocations[1, 10] = new Location()
            {
                Id=16,
                Name = "Burrow NE",
                Description = "You find nothing",
                Accessible = true,
                ModifiyExperiencePoints = 25,
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
                Id=17,
                Name = "Burrow SE",
                Description = "You see a path leading east outside of the burrow",
                Accessible = true,
                ModifiyExperiencePoints = 25,
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
                Id=18,
                Name = "Crossroads W",
                Description = "A figure beckons you over. He has... questions",
                Accessible = true,
                ModifiyExperiencePoints =5,
                ModifyForm = "Bunny",
                ModifyFormImg = "Images/bunny.png",
                ModifyChamberColor = "DarkSlateGray",
                ModifyMapLocatorTop = "163",
                ModifyMapLocatorLeft = "325",
                ModifyPlayerMessage = ""
            };
            gameMap.MapLocations[2, 12] = new Location()
            {
                Id=19,
                Name = "Crossroads",
                Description = "The figure points. I think he wants you to go that way",
                Accessible = true,
                ModifiyExperiencePoints =5,
                ModifyForm = "Bunny",
                ModifyFormImg = "Images/bunny.png",
                ModifyChamberColor = "DarkSlateGray",
                ModifyMapLocatorTop = "167",
                ModifyMapLocatorLeft = "355",
                ModifyPlayerMessage = ""
            };
            gameMap.MapLocations[3, 12] = new Location()
            {
                Id=20,
                Name = "Geode Cavern",
                Description = "You see a huge Geode looking golem monster!\n\n He is preparing to fight!",
                Accessible = true,
                ModifiyExperiencePoints = 0,
                ModifyForm = "Bunny",
                ModifyFormImg = "Images/bunny.png",
                ModifyChamberColor = "DarkSlateGray",
                ModifyMapLocatorTop = "190",
                ModifyMapLocatorLeft = "375",
                ModifyPlayerMessage = ""
            };

            gameMap.MapLocations[2, 13] = new Location()
            {
                Id=21,
                Name = "Garden",
                Description = "There's a farmer and he has a rake.\n He sees you...\n He moves towards you... \n He RUNS towards you.",
                Accessible = false,
                ModifiyExperiencePoints = 0,
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
                new RareItem(2002, "Mole Hair", 500, RareItem.RareList.MoleHair, "Fuzzy patch of hair", 100, "You transformed into a mole! \n\n Onward to Mole City!", "Images/unknownItem.jpg"),
                new RareItem(2003, "Rabbit's Foot",1000, RareItem.RareList.RabbitFoot, "Looks used", 200,"You transformed!", "Images/unknownItem.jpg"),
                new Weapon(3001, "Bite",10, Weapon.AttackList.bite, "Bite your enemy!", 10, "you bite your enemy!", "Images/unkownItem.jpg", 1, 5),
                new Weapon(3002, "Claw",20, Weapon.AttackList.claw, "Claw your enemy!", 20, "you claw your enemy!", "Images/unkownItem.jpg", 3, 8),
                new Weapon(3003, "Thump",30, Weapon.AttackList.thump, "Thump your enemy!", 30, "you thump your enemy!", "Images/unkownItem.jpg", 5, 10),
                new Weapon(3004, "Antler",10, Weapon.AttackList.antler, "Stab your enemy!", 10, "you stab your enemy!", "Images/unkownItem.jpg", 15, 30)
            };
        }

        public static List<NPC> Npcs()
        {
           return new List<NPC>()
           {
               new Monster()
               {
                  ID = 2001,
                  Name = "Slimy Worm",
                  Race = Character.RaceType.Worm,
                  LocationId= 3,
                  HealthPoints =5,
                  Description = "A slimy, squirmy, wriggling worm. Seems mostly harmless",
                  SkillLevel = 1,
                  Messages = new List<string>()
                  {
                    "The worm lunges at you",
                    "The worm wriggles around"

                  }
               },

               new Citizen()
               {
                  ID = 1001,
                  Name = "Western Road Keeper",
                  Race = Character.RaceType.Human,
                  Description = "Shadowy figure",
                  Messages = new List<string>()
                  {
                   "Excuse me, but are you looking for something.",
                   "You requre a special item to pass"
                  }
               },

               new Citizen()
               {
                   ID = 1002,
                   Name = "Eastern Road Keeper",
                   Race = Character.RaceType.Human,
                   Description = "Shadowy figure",
                   Messages = new List<string>()
                   {
                    "Excuse me, but are you looking for something.",
                    "You requre a special item to pass"
                   }
               }
           };
        }
    }



}
