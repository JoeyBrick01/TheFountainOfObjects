FountainOfObjectsGame game = CreateSmallGame();

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Choose your map: ");
Console.WriteLine("1. Small");
Console.WriteLine("2. Medium");
Console.WriteLine("3. Large");
string? input = Convert.ToString(Console.ReadLine());

if(input == "1") game = CreateSmallGame();
if(input == "2") game = CreateMediumGame();
if(input == "3") game = CreateLargeGame();

game.Run();

// -------------------------------------------------------------------------------
//                                   Methods
// -------------------------------------------------------------------------------


// Creates a small 4x4 game.
FountainOfObjectsGame CreateSmallGame()
{
    Map map = new Map(4, 4);
    Location start = new Location(0, 0);
    map.SetRoomTypeAtLocation(start, RoomType.Entrance);
    map.SetRoomTypeAtLocation(new Location(0, 2), RoomType.Fountain);
    map.SetRoomTypeAtLocation(new Location(2, 2), RoomType.Pit);

    Monster[] monsters = new Monster[] { 
        new Maelstrom(new Location(3, 1)), 
        new Amarok(new Location(0, 1))
        };

    map.SetRoomTypeAtLocation(new Location(3, 1), RoomType.Maelstrom);
    map.SetRoomTypeAtLocation(new Location(0, 1), RoomType.Amarok);

    return new FountainOfObjectsGame(map, new Player(start), monsters);
}

FountainOfObjectsGame CreateMediumGame()
{
    Map map = new Map(6, 6);
    Location start = new Location(0, 0);
    map.SetRoomTypeAtLocation(start, RoomType.Entrance);
    map.SetRoomTypeAtLocation(new Location(4, 5), RoomType.Fountain);
    map.SetRoomTypeAtLocation(new Location(2, 2), RoomType.Pit);
    map.SetRoomTypeAtLocation(new Location(1, 3), RoomType.Pit);
    

    Monster[] monsters = new Monster[] { 
        new Maelstrom(new Location(0, 2)),
        new Amarok(new Location(3, 2)),
        new Amarok(new Location(2, 1))
        };

    map.SetRoomTypeAtLocation(new Location(0, 2), RoomType.Maelstrom);
    map.SetRoomTypeAtLocation(new Location(3, 2), RoomType.Amarok);
    map.SetRoomTypeAtLocation(new Location(2, 1), RoomType.Amarok);

    return new FountainOfObjectsGame(map, new Player(start), monsters);
}

FountainOfObjectsGame CreateLargeGame()
{
Map map = new Map(8, 8);
    Location start = new Location(0, 0);
    map.SetRoomTypeAtLocation(start, RoomType.Entrance);
    map.SetRoomTypeAtLocation(new Location(6, 7), RoomType.Fountain);
    map.SetRoomTypeAtLocation(new Location(2, 4), RoomType.Pit);
    map.SetRoomTypeAtLocation(new Location(7, 7), RoomType.Pit);
    map.SetRoomTypeAtLocation(new Location(3, 5), RoomType.Pit);
    map.SetRoomTypeAtLocation(new Location(1, 3), RoomType.Pit);


    Monster[] monsters = new Monster[]
    {
        new Maelstrom(new Location(4, 6)),
        new Maelstrom(new Location(3, 2)),
        new Amarok(new Location(3, 3)),
        new Amarok(new Location(1, 7)),
        new Amarok(new Location(2, 6))
    };

    map.SetRoomTypeAtLocation(new Location(4, 6), RoomType.Maelstrom);
    map.SetRoomTypeAtLocation(new Location(3, 2), RoomType.Maelstrom);
    map.SetRoomTypeAtLocation(new Location(3, 3), RoomType.Amarok);
    map.SetRoomTypeAtLocation(new Location(1, 7), RoomType.Amarok);
    map.SetRoomTypeAtLocation(new Location(2, 6), RoomType.Amarok);

    return new FountainOfObjectsGame(map, new Player(start), monsters);
}