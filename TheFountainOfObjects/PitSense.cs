public class PitSense : ISense
{
    public bool CanSense(FountainOfObjectsGame game)
    {
        if (game.Map.HasNeighborWithType(game.Player.Location, RoomType.Pit))
        {
            return true;
        }     
        return false;
    }
    public void DisplaySense(FountainOfObjectsGame game)
    {
        ConsoleHelper.WriteLine("You feel a draft. There is a pit in a nearby room.", ConsoleColor.Yellow);
    }
}