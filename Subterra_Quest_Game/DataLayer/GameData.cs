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
                SkillLevel =1,
                Color = Player.ColorType.Red,
                Inventory = new ObservableCollection<GameItem>()
                {
                    GameItemById(1000)
                   
                },
                Quests = new ObservableCollection<Quest>()
                {
                    QuestById(1),
                    QuestById(2)
                }

            };
        }

        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                "\n          Welcome to the subterranean world of creepy crawlies.",
                "    Start your new life as a fierce ground beetle and fight monsters \n   Check the NPC tab for tutorial instructions. "
                
            };
        }

        private static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.ID == id);
        }

        private static Location LocationById(int id)
        {
            List<Location> locations = new List<Location>();

            foreach (Location location in GameMap().MapLocations)
            {
                if (location != null) locations.Add(location);
            }

            return locations.FirstOrDefault(i => i.Id == id);
        }

        private static NPC NpcById(int id)
        {
            return Npcs().FirstOrDefault(i => i.ID == id);
        }

        private static Quest QuestById(int id)
        {
            return Quests().FirstOrDefault(m => m.Id == id);
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
                ModifyPlayerMessage = "",
                NPCS = new ObservableCollection<NPC>
                {
                    NpcById(9999)
                }
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
                ModifyLocationMessage = "Have you been here before? It seems familiar",
                ModifyPlayerMessage="",
                NPCS = new ObservableCollection<NPC>
                {
                    NpcById(2001),
                    NpcById(1000)
                }
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
                ModifyLocationMessage = "It's still dark and damp",
                ModifyPlayerMessage="",
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
                ModifyLocationMessage = "Are you going in circles?",
                ModifyPlayerMessage="",
                GameItems = new ObservableCollection<GameItem>
                {
                    GameItemById(1001)
                },
                 NPCS = new ObservableCollection<NPC>
                {
                    NpcById(2001)
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
                ModifyLocationMessage = "It's dark in here",
                ModifyPlayerMessage ="",
                NPCS = new ObservableCollection<NPC>
                {
                    NpcById(2001)
                }

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
                ModifyLocationMessage = "Up ahead the hooded creature is still there",
                ModifyPlayerMessage="",
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
                ModifyLocationMessage = "The hooded figure sits paitiently",
                ModifyPlayerMessage="",
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
                ModifyChamberColor = "Black",
                ModifyMapLocatorTop = "170",
                ModifyMapLocatorLeft = "195",
                ModifyLocationMessage = "Mole City West Gate",
                ModifyPlayerMessage="",
                RequiredRareItemID = 2002

            };
            gameMap.MapLocations[2, 6] = new Location()
            {
                Id=9,
                Name = "Mole City NE",
                Description = "The worms are much, much, MUCH bigger here",
                Accessible = true,
                ModifiyExperiencePoints = 20,
                ModifyForm = "Mole",
                ModifyFormImg = "Images/mole3.png",
                ModifyChamberColor = "Black",
                ModifyMapLocatorTop = "170",
                ModifyMapLocatorLeft = "215",
                ModifyLocationMessage = "You see the city exit to the East",
                ModifyPlayerMessage="",
                NPCS = new ObservableCollection<NPC>
                {
                    NpcById(2002)
                }
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
                ModifyChamberColor = "Black",
                ModifyMapLocatorTop = "185",
                ModifyMapLocatorLeft = "195",
                ModifyLocationMessage= "The worm farm seems to be non - operatonal \n Perhaps a later game expantion ? ",
                ModifyPlayerMessage = "",
                NPCS = new ObservableCollection<NPC>
                {
                    NpcById(2002)
                }
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
                ModifyChamberColor = "Black",
                ModifyMapLocatorTop = "185",
                ModifyMapLocatorLeft = "215",
                ModifyLocationMessage="The Villagers regard you indifferently",
                ModifyPlayerMessage="",
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
                ModifyChamberColor = "Black",
                ModifyMapLocatorTop = "165",
                ModifyMapLocatorLeft = "230",
                ModifyLocationMessage = "The Mysterious villager stares into your soul... spooky",
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
                ModifyChamberColor = "Black",
                ModifyMapLocatorTop = "160",
                ModifyMapLocatorLeft = "250",
                ModifyLocationMessage = "May I help you?",
                ModifyPlayerMessage = "",
                RequiredRareItemID = 2003,
                NPCS = new ObservableCollection<NPC>
                {
                    NpcById(1002)
                }

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
                ModifyLocationMessage = "The Villagers regard you indifferently",
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
                ModifyLocationMessage = "There seem to be even more villagers than before",
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
                ModifyLocationMessage = "You still find nothing",
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
                ModifyLocationMessage = "The path exiting the Burrow is up ahead",
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
                ModifyLocationMessage = "A figure beckons you over.He has... questions",
                ModifyPlayerMessage = ""
            };
            gameMap.MapLocations[2, 12] = new Location()
            {
                Id=19,
                Name = "Crossroads",
                Description = "The figure points. I think he wants you to go that way",
                Accessible = false,
                ModifiyExperiencePoints =5,
                ModifyForm = "Bunny",
                ModifyFormImg = "Images/bunny.png",
                ModifyChamberColor = "DarkSlateGray",
                ModifyMapLocatorTop = "167",
                ModifyMapLocatorLeft = "355",
                ModifyLocationMessage = "The figure points. I think he wants you to go that way",
                ModifyPlayerMessage = "",
                NPCS = new ObservableCollection<NPC>
                {
                    NpcById(1002)
                }
            };
            gameMap.MapLocations[3, 12] = new Location()
            {
                Id=20,
                Name = "Geode Cavern",
                Description = "You see a huge Geode looking golem monster!\n\n He is preparing to fight!",
                Accessible = true,
                ModifiyExperiencePoints = 0,
                ModifyForm = "Jackalope",
                ModifyFormImg = "Images/jackalope.png",
                ModifyChamberColor = "DarkSlateGray",
                ModifyMapLocatorTop = "190",
                ModifyMapLocatorLeft = "375",
                ModifyLocationMessage = "\nIt's dead.. or you're dead..\n Or somebody is about to die",
                ModifyPlayerMessage = ""
            };

            gameMap.MapLocations[2, 13] = new Location()
            {
                Id=21,
                Name = "Garden",
                Description = "There's a farmer and he has a rake.\n He sees you...\n He moves towards you... \n He RUNS towards you.",
                Accessible = true,
                ModifiyExperiencePoints = 0,
                ModifyForm = "Jackalope",
                ModifyFormImg = "Images/jackalope.png",
                ModifyChamberColor = "DarkSlateGray",
                ModifyMapLocatorTop = "160",
                ModifyMapLocatorLeft = "395",
                ModifyLocationMessage = "\nIt's dead.. or you're dead..\n Or somebody is about to die",
                ModifyPlayerMessage = "",
                RequiredRareItemID = 2001
            };

            return gameMap;
        }


        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Food(1000, "Fuzzy Mint", 30, Food.UseActionType.HEALPLAYER, "Must have been \n in your pocket", 50 ,"\n You ate the mint! \nInteresting Texture...", "Images/unknownItem.jpg"),
                new Food(1001, "Worms", 25, Food.UseActionType.HEALPLAYER, "A pile of slimy wriggling worms. Yum!", 50 ,"They wiggle all the way down", "Images/unknownItem.jpg"),
                new Food(1002, "GoldWorms", 100, Food.UseActionType.HEALPLAYER, "A glittering golden pile of worms. So shiny!", 100, "Not bad!", "Images/unknownItem.jpg"),
                new Food(1003, "Carrot", 40, Food.UseActionType.HEALPLAYER, "Bright orange and crunchy", 75, "hits the spot","Images/unknownItem,jpg"),
                new RareItem(2001, "Antlers of Jackalope", 1000, RareItem.RareList.Antlers, "Dangerous looking sharp pointy antlers fitted to a helmet.", 300, "You equip the helmet. Perfect fit and ready for battle!","Images/unknownItem,jpg"),
                new RareItem(2002, "Mole Hair", 500, RareItem.RareList.MoleHair, "Fuzzy patch of hair", 100, "\n Mole City is now Unlocked!", "Images/unknownItem.jpg"),
                new RareItem(2003, "Rabbit's Foot",1000, RareItem.RareList.RabbitFoot, "Looks used", 200,"You can now enter Bunny Burrow!", "Images/unknownItem.jpg"),
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
                  Health =5,
                  Description = "A slimy, squirmy, wriggling worm. Seems mostly harmless",
                  SkillLevel = 5,
                  Messages = new List<string>()
                  {
                    "The worm lunges at you",
                    "The worm wriggles around",
                    "Gross! stop that worm!"

                  }
               },
               new Monster()
               {
                  ID = 2002,
                  Name = "Huge Worm",
                  Race = Character.RaceType.Worm,
                  LocationId= 4,
                  Health =15,
                  Description = "An extra large worm \n Like... really big.",
                  SkillLevel = 10,
                  Messages = new List<string>()
                  {
                    "The worm bites at you! \n It has teeth!?",
                    "The worm lets out a terrible scream",
                    "It charges at you!"

                  }
               },

               new Citizen()
               {
                  ID = 9999,
                  Name = "Tutorial",
                  Race = Character.RaceType.Human,
                  Description = "Speak to me for game instructions",
                  Messages = new List<string>()
                  {
                   "Press the 'Enter Underground' to begin the game." +
                   "\n You will be transformed into a beetle." +
                   "\n Fight your way through the map changing forms until"+
                   "\n you reach the final boss.",
                   "Throughout the map you will find monsters, items and NPCs"+
                   "\n Interactions with monster, items, and NPCs is located"+
                   "\n on the upper right corner of the UI.",
                   "\n Press 'Enter Underground' when you are ready to begin!"

                  }
               },
               new Citizen()
               {
                  ID = 1000,
                  Name = "Cave Guide",
                  Race = Character.RaceType.Human,
                  Description = "You hear a voice. It's too dark to see anything",
                  Messages = new List<string>()
                  {
                   "Hello? Who is there? \n You are stuck in the underground now." +
                   "\n The only way out is to head East towards Mole City." +
                   "\n Before you can do that you must find something special.",
                   "\nIt was a mistake comming here...",
                   "\nNow you must make your way through the underground.",
                   "You should gain experience before going forward." +
                   "\nTry killing some worms for starters." +
                   "\n Fine tune your abilities by spending skill points.",
                   "\nStrength will make you do more damage." +
                   "\nStamina will make you take less damage.",
                   "\nA dangerous battle awaits you.",
                   "\nYou must prepare for the inevitable."
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
                   "You requre a special item to pass",
                   "Have you seen a small patch of fur?"
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
                    "You requre a special item to pass",
                    "I've lost my lucky rabbits foot"
                   }
               },
                  new Citizen()
               {
                   ID = 1003,
                   Name = "Crossroads Keeper",
                   Race = Character.RaceType.Human,
                   Description = "Shadowy figure",
                   Messages = new List<string>()
                   {
                    "It's much to dangerous. Turn Around",
                    "You can't battle the boss without a helmet!"
                   }
               }
           };
        }

        public static List<Quest> Quests()
        {
            return new List<Quest>()
            {
                new QuestTravel()
                {
                    Id = 1,
                    Name = "Scouting",
                    Description = "Explore all locations and gather all information possible.",
                    Status = Quest.QuestStatus.Incomplete,
                    RequiredLocations = new List<Location>()
                    {
                        
                        LocationById(7),
                        LocationById(9),
                        LocationById(13),
                        LocationById(15)
                   
                    },
                    ExperiencePoints = 300
                },

               
                new QuestEngage()
                {
                    Id = 2,
                    Name = "Locate",
                    Description = "Locate and speak to all required persons.",
                    Status = Quest.QuestStatus.Incomplete,
                    RequiredNpcs = new List<NPC>()
                    {
                        NpcById(1000),
                        NpcById(1001),
                        NpcById(1002)
                    },
                    ExperiencePoints = 100
                },

            };

        }
    }



}
