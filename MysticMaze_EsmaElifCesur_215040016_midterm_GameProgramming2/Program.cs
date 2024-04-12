namespace MysticMaze_EsmaElifCesur_215040016_midterm_GameProgramming2
{
    //If you escape with the first treasure you find in this labyrinth, I doubt your courage.
    //If you want to fight the Chaos Hydra, you are brave; maybe you have a chance and power against Chaos Hydra. 
    //If you run away from the maze the same way you came, you are a coward. I hope you are brave. Have fun playing :)!
    class Location
    {
        public string Name { get; set; } // Name of the location
        public string Description { get; set; } // Description of the location

        // Constructor to initialize the location
        public Location(string name, string description)
        {
            Name = name;
            Description = description;
        }

        // Method to display information about the location
        public virtual void ShowLocationInfo()
        {
            Console.WriteLine($"You are at {Name}: {Description}");
        }
    }

    // Derived class representing a room which inherits from Location
    class Room : Location
    {
        public bool HasMonster { get; set; } // Indicates whether the room has a monster

        // Constructor to initialize the room
        public Room(string name, string description, bool hasMonster) : base(name, description)
        {
            HasMonster = hasMonster;
        }

        // Override method to display information about the room
        public override void ShowLocationInfo()
        {
            base.ShowLocationInfo();
            if (HasMonster)
                Console.WriteLine("There is a fierce, fearless monster in the room!");
        }
    }

    // Derived class representing a monster
    class Monster
    {
        public string Name { get; set; } // Name of the monster
        public int Health { get; set; } // Health of the monster

        // Constructor to initialize the monster
        public Monster(string name, int health)
        {
            Name = name;
            Health = health;
        }

        // Method to display information about the monster
        public void ShowMonsterInfo()
        {
            Console.WriteLine($"A {Name} appears with {Health} health!");
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to the Mystic Maze!");

            // Array of locations in the maze
            Location[] locations = new Location[]
            {
            new Room("Entrance Hall", "a dimly lit room with torches and strange writings on the walls", false),
            new Room("Corridor", "a long corridor with eerie sounds echoing from the darkness", true),
            new Room("Treasure Room", "a room filled with glittering treasures", false),
            new Room("Chamber of Secrets", "a mysterious chamber with ancient symbols carved on the walls", true)
            };

            // Start exploring locations from the first location
            await ExploreLocations(locations, 0);
        }

        // Method to handle exploring through locations
        static async Task ExploreLocations(Location[] locations, int currentLocationIndex)
        {
            while (currentLocationIndex < locations.Length)
            {
                Location currentLocation = locations[currentLocationIndex];
                currentLocation.ShowLocationInfo();

                await Task.Delay(1000);

                if (currentLocation is Room room && room.HasMonster)
                {
                    await EncounterMonster();
                }
                else
                {
                    await FindTreasure();
                }

                Console.WriteLine("Do you want to continue exploring?");
                Console.WriteLine("1. Yes, move to the next location.");
                Console.WriteLine("2. No, stop exploring.");

                string input = GetUserInput("1", "2");
                if (input == "1")
                {
                    Console.WriteLine();
                    currentLocationIndex++;
                }
                else if (input == "2")
                {
                    Console.WriteLine("You decide to stop exploring. You gave up too easily..");
                    break;
                }
            }

            if (currentLocationIndex >= locations.Length)
            {
                Console.WriteLine("Congratulations! You managed to escape from the labyrinth with treasures. Well done! You are a skilled player!");
            }
        }

        static async Task EncounterMonster()
        {
            Console.WriteLine("You encounter a fierce, fearless monster!");

            await Task.Delay(1000);

            Monster monster = new Monster("Chaos Hydra", 100);
            monster.ShowMonsterInfo();

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Fight the monster!");
            Console.WriteLine("2. Flee from the room!");

            string input = GetUserInput("1", "2");

            Random random = new Random();
            bool playerWins = random.Next(2) == 0;

            if (input == "1")
            {
                if (playerWins)
                {
                    Console.WriteLine("You bravely engage the monster in battle and emerge victorious!");
                }
                else
                {
                    Console.WriteLine("You bravely engage the monster in battle, but unfortunately, you were defeated!");
                    Console.WriteLine("Game Over!");
                    Environment.Exit(0);
                }
            }
            else if (input == "2")
            {
                Console.WriteLine("You wisely choose to flee from the room.");
                Console.WriteLine("I think you were very scared!");
                Console.WriteLine("You escaped from the maze but you couldn't collect all the treasure. Good job.");
                Environment.Exit(0);
            }
        }

        static async Task FindTreasure()
        {
            Console.WriteLine("You search the room and find a shiny treasure chest!");

            await Task.Delay(1000);

            Console.WriteLine("You open the chest and find valuable treasure!");
        }

        static string GetUserInput(params string[] validOptions)
        {
            string input = Console.ReadLine();

            while (!Array.Exists(validOptions, option => option == input))
            {
                Console.WriteLine("Invalid input. Please enter a valid option.");
                input = Console.ReadLine();
            }
            return input;
        }
    }
}
