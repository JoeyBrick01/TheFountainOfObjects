public class AmarokSense : ISense
{
    public bool CanSense(FountainOfObjectsGame game)
    {
        if (game.Map.HasNeighborWithType(game.Player.Location, RoomType.Amarok))
        {
            return true;
        }
        return false;
    }

    public void DisplaySense(FountainOfObjectsGame game)
    {
        ConsoleHelper.WriteLine("You can smell the rotten stench of an amarok in a nearby room.", ConsoleColor.Yellow);
    }
}