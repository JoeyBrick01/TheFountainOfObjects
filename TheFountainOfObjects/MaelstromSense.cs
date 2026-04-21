public class MaelstromSense : ISense
{
    public bool CanSense(FountainOfObjectsGame game)
    {
        if (game.Map.HasNeighborWithType(game.Player.Location, RoomType.Maelstrom))
        {
            return true;
        }     
        return false;
    }
    public void DisplaySense(FountainOfObjectsGame game)
    {
        ConsoleHelper.WriteLine("You hear the growling and groaning of a maelstrom nearby.", ConsoleColor.Yellow);
    }
}