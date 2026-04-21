public class ShootCommand : ICommand
{
    public Direction direction {get;}

    public ShootCommand(Direction direction)
    {
        this.direction = direction;
    }
    public void Execute(FountainOfObjectsGame game)
    {
        Location currentPlayerLocation = game.Player.Location;
        Location arrowShotAtLocation = direction switch
        {
            Direction.North => new Location(game.Player.Location.Row - 1, game.Player.Location.Column),
            Direction.South => new Location(game.Player.Location.Row + 1, game.Player.Location.Column),
            Direction.West => new Location(game.Player.Location.Row, game.Player.Location.Column - 1),
            Direction.East => new Location(game.Player.Location.Row, game.Player.Location.Column + 1)
        };

        if (game.Player.ArrowCount > 0)
        {
            game.Player.UseArrow();
            foreach(Monster monster in game.Monsters)
            {
                if (monster.Location == arrowShotAtLocation)
                {
                    monster.IsAlive = false;
                    game.Map.SetRoomTypeAtLocation(monster.Location, RoomType.Normal);
                }
            }
        }
    }
}