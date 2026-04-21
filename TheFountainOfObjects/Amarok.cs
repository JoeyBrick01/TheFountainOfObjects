public class Amarok : Monster
{
    public Amarok(Location start) : base(start)
    {
        this.Location = start;
    }

    public override void Activate(FountainOfObjectsGame game)
    {
        game.Player.Kill("Player is killed by an Amarok.");
    }
}