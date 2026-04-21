// The beating heart of the Fountain of Objects game. Tracks the progression of a single
// round of gameplay.
public class FountainOfObjectsGame
{
    // The map being used by the game.
    public Map Map { get; }

    // The player playing the game.
    public Player Player { get; }

    // The list of monsters in the game.
    public Monster[] Monsters { get; }

    // Whether the player has turned on the fountain yet or not. (Defaults to `false`.)
    public bool IsFountainOn { get; set; }

    // A list of senses that the player can detect. Add to this collection in the constructor.
    private readonly ISense[] _senses;

    // Initializes a new game round with a specific map and player.
    public FountainOfObjectsGame(Map map, Player player, Monster[] monsters)
    {
        Map = map;
        Player = player;
        Monsters = monsters;

        // Each of these senses will be used during the game. Add new senses here.
        _senses = new ISense[]
        {
            new LightInEntranceSense(), 
            new FountainSense(), 
            new PitSense(), 
            new MaelstromSense(), 
            new AmarokSense()
        };
    }

    // Runs the game one turn at a time.
    public void Run()
    {
        DateTime _gameStart = DateTime.Now;
        Console.Clear();
        DisplayIntro();
        // This is the "game loop." Each turn runs through this `while` loop once.
        while (!HasWon && Player.IsAlive)
        {
            DisplayStatus();
            ICommand command = GetCommand();
            command.Execute(this);

            foreach (Monster monster in Monsters)
                if (monster.Location == Player.Location && monster.IsAlive) monster.Activate(this);
            
            if (CurrentRoom == RoomType.Pit)
            {
                Player.Kill("Player has stumbled into a bottomless pit.");
            }
        }

        DateTime _gameEnd = DateTime.Now;

        if (HasWon)
        {
            ConsoleHelper.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!", ConsoleColor.DarkGreen);
            ConsoleHelper.WriteLine("You win!", ConsoleColor.DarkGreen);
        }
        else
        {
            ConsoleHelper.WriteLine(Player.CauseOfDeath, ConsoleColor.Red);
            ConsoleHelper.WriteLine("You lost.", ConsoleColor.Red);
        }
        TimeSpan _gameTime = _gameEnd - _gameStart;
        ConsoleHelper.WriteLine($"Elapsed time: {_gameTime.Minutes} Minutes, {_gameTime.Seconds} Seconds.", ConsoleColor.Yellow);

    }

    // Displays the status to the player, including what room they are in and asks each sense to display itself
    // if it is currently relevant.
    private void DisplayStatus()
    {
        ConsoleHelper.WriteLine("--------------------------------------------------------------------------------", ConsoleColor.Gray);
        ConsoleHelper.WriteLine($"You are in the room at (Row={Player.Location.Row}, Column={Player.Location.Column}).", ConsoleColor.Gray);
        if (Player.ArrowCount > 0)
        {
            ConsoleHelper.WriteLine($"Player currently has {Player.ArrowCount} arrow(s). ", ConsoleColor.Gray);
        }
        else
        {
            ConsoleHelper.WriteLine("Player has run out of arrows.", ConsoleColor.Gray);
        }

        foreach (ISense sense in _senses)
            if (sense.CanSense(this))
                sense.DisplaySense(this);
    }

    // Gets an `ICommand` object that represents the player's desires.
    private ICommand GetCommand()
    {
        while (true) // Until we get a legitimate command, keep asking.
        {
            ConsoleHelper.Write("What do you want to do? ", ConsoleColor.White);
            Console.ForegroundColor = ConsoleColor.Cyan;
            string? input = Console.ReadLine();

            // Check for a match with each known command.
            if (input == "move north") return new MoveCommand(Direction.North);
            if (input == "move south") return new MoveCommand(Direction.South);
            if (input == "move east") return new MoveCommand(Direction.East);
            if (input == "move west") return new MoveCommand(Direction.West);
            if (input == "enable fountain") return new EnableFountainCommand();
            // More commands go here.
            if (input == "shoot north") return new ShootCommand(Direction.North);
            if (input == "shoot south") return new ShootCommand(Direction.South);
            if (input == "shoot east") return new ShootCommand(Direction.East);
            if (input == "shoot west") return new ShootCommand(Direction.West);
            if (input == "help") return new HelpCommand();

            // If none of the above were a match, we have no clue what the command was. Try again.
            ConsoleHelper.WriteLine($"I did not understand '{input}'.", ConsoleColor.Red);
        }
    }

    // Introduction dialogue to game.
    private void DisplayIntro()
    {
        // Intro
        ConsoleHelper.WriteLine("You enter the Cavern of Objects, a maze of rooms filled with dangerous pits in search", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("of the Fountain of Objects.", ConsoleColor.Gray);

        ConsoleHelper.Write("Light ", ConsoleColor.Yellow);
        ConsoleHelper.Write("is visible only in the entrance, and no other ", ConsoleColor.Gray);
        ConsoleHelper.Write("Light ", ConsoleColor.Yellow);
        ConsoleHelper.WriteLine("is seen anywhere in the caverns.", ConsoleColor.Gray);

        ConsoleHelper.WriteLine("You must navigate the Caverns with your other senses.", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("Find the Fountain of Objects, activate it, and return to the entrance.", ConsoleColor.Gray);

        // Warnings
        Console.WriteLine("");
        //Pits
        ConsoleHelper.Write("Look out for ", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("pits. ", ConsoleColor.Red);

        ConsoleHelper.Write("You will feel a breeze if a ", ConsoleColor.Gray);
        ConsoleHelper.Write("pit ", ConsoleColor.Red);
        ConsoleHelper.WriteLine("is in an adjacent room.", ConsoleColor.Gray);

        ConsoleHelper.Write("If you enter a room with a ", ConsoleColor.Gray);
        ConsoleHelper.Write("pit", ConsoleColor.Red);
        ConsoleHelper.Write(", you will ", ConsoleColor.Gray);
        ConsoleHelper.Write("die", ConsoleColor.Red);
        ConsoleHelper.WriteLine(".", ConsoleColor.Gray);

        Console.WriteLine("");
        // Maelstroms
        ConsoleHelper.Write("Maelstroms ", ConsoleColor.Red);
        ConsoleHelper.WriteLine("are violent forces of sentient wind. ", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("Entering a room with one could transport you to any other location in the caverns.", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("You will be able to hear their growling and groaning in nearby rooms.", ConsoleColor.Gray);

        Console.WriteLine("");
        // Amaroks
        ConsoleHelper.Write("Amoraks ", ConsoleColor.Red);
        ConsoleHelper.WriteLine("roam the caverns.", ConsoleColor.Gray);

        ConsoleHelper.Write("Encountering once is certain ", ConsoleColor.Gray);
        ConsoleHelper.Write("death", ConsoleColor.Red);
        ConsoleHelper.WriteLine(", but you can smell their rotten stench in nearby rooms.", ConsoleColor.Gray);

        Console.WriteLine("");
        // Arrows
        ConsoleHelper.WriteLine("You carry with you a bow and arrows. ", ConsoleColor.Gray);

        ConsoleHelper.Write("You can use them to shoot ", ConsoleColor.Gray);
        ConsoleHelper.Write("monsters ", ConsoleColor.Red);
        ConsoleHelper.WriteLine("in the caverns but be warned: ", ConsoleColor.Gray);

        ConsoleHelper.WriteLine("you have a limited supply.", ConsoleColor.Gray);
    }

    // Indicates if the player has won or not.
    public bool HasWon => CurrentRoom == RoomType.Entrance && IsFountainOn;

    // Looks up what room type the player is currently in.
    public RoomType CurrentRoom => Map.GetRoomTypeAtLocation(Player.Location);
}