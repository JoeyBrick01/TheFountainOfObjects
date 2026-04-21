public class Maelstrom : Monster
{
    public Maelstrom(Location start) : base(start)
    {
        this.Location = start;
    }

    public override void Activate(FountainOfObjectsGame game)
    {
        game.Map.SetRoomTypeAtLocation(this.Location, RoomType.Normal);

        // Handles player movement
        Location oldPlayerLocation = game.Player.Location;
        // One north, two east
        Location newPlayerlocation = new Location(oldPlayerLocation.Row - 1, oldPlayerLocation.Column + 2);
        if (game.Map.IsOnMap(newPlayerlocation))
        {
            game.Player.Location = newPlayerlocation;
            ConsoleHelper.WriteLine("Player has encountered a Maelstrom, Player has been moved to a new room.", ConsoleColor.Yellow);
        }
        else
        {
            ConsoleHelper.WriteLine("Player would move out of bounds. Player Moves to entrance.", ConsoleColor.Red);
            game.Player.Location = new Location(0, 0);
        }

        // Handles Maelstrom movement
        // One south, two west
        Location newMaelstromLocation = new Location(this.Location.Row + 1, this.Location.Column - 2);
        if (game.Map.IsOnMap(newMaelstromLocation) && game.Map.GetRoomTypeAtLocation(newMaelstromLocation) == RoomType.Normal)
        {
            // move maelstrom, and set that new room to Monster
            this.Location = newMaelstromLocation;
            game.Map.SetRoomTypeAtLocation(this.Location, RoomType.Maelstrom);
        }
        else
        {
            // revert roomtype back to monster, as maelstrom doesn't move
            game.Map.SetRoomTypeAtLocation(this.Location, RoomType.Maelstrom);
        }
    }
}