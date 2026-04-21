public class HelpCommand : ICommand
{
    public void Execute(FountainOfObjectsGame game)
    {
        ConsoleHelper.WriteLine("--------------------------------------------------------------------------------", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("                                    COMMANDS                                    ", ConsoleColor.Yellow);
        Console.WriteLine("");
        // Move / Enable Commands
        // Move North
        ConsoleHelper.Write("\"", ConsoleColor.Gray);
        ConsoleHelper.Write("move north", ConsoleColor.DarkYellow);
        ConsoleHelper.WriteLine("\" -- Moves player one space north.", ConsoleColor.Gray);

        Console.WriteLine("");
        // Move South
        ConsoleHelper.Write("\"", ConsoleColor.Gray);
        ConsoleHelper.Write("move south", ConsoleColor.DarkYellow);
        ConsoleHelper.WriteLine("\" -- Moves player one space south.", ConsoleColor.Gray);

        Console.WriteLine("");
        // Move East
        ConsoleHelper.Write("\"", ConsoleColor.Gray);
        ConsoleHelper.Write("move east", ConsoleColor.DarkYellow);
        ConsoleHelper.WriteLine("\" -- Moves player one space east.", ConsoleColor.Gray);

        Console.WriteLine("");
        // Move West
        ConsoleHelper.Write("\"", ConsoleColor.Gray);
        ConsoleHelper.Write("move west", ConsoleColor.DarkYellow);
        ConsoleHelper.WriteLine("\" -- Moves player one space west.", ConsoleColor.Gray);

        Console.WriteLine("");
        // Enable Fountain
        ConsoleHelper.Write("\"", ConsoleColor.Gray);
        ConsoleHelper.Write("enable fountain", ConsoleColor.DarkYellow);
        ConsoleHelper.WriteLine("\" -- Enables the Fountain of Objects when in the fountain room.", ConsoleColor.Gray);

        Console.WriteLine("");
        // Shoot Commands
        // Shoot North
        ConsoleHelper.Write("\"", ConsoleColor.Gray);
        ConsoleHelper.Write("shoot north", ConsoleColor.DarkYellow);
        ConsoleHelper.WriteLine("\" -- Shoots an arrow one space north.", ConsoleColor.Gray);

        Console.WriteLine("");
        // Shoot South
        ConsoleHelper.Write("\"", ConsoleColor.Gray);
        ConsoleHelper.Write("shoot south", ConsoleColor.DarkYellow);
        ConsoleHelper.WriteLine("\" -- Shoots an arrow one space south.", ConsoleColor.Gray);

        Console.WriteLine("");
        // Shoot East 
        ConsoleHelper.Write("\"", ConsoleColor.Gray);
        ConsoleHelper.Write("shoot east", ConsoleColor.DarkYellow);
        ConsoleHelper.WriteLine("\" -- Shoots an arrow one space east.", ConsoleColor.Gray);

        Console.WriteLine("");
        // Shoot West
        ConsoleHelper.Write("\"", ConsoleColor.Gray);
        ConsoleHelper.Write("shoot west", ConsoleColor.DarkYellow);
        ConsoleHelper.WriteLine("\" -- Shoots an arrow one space west.", ConsoleColor.Gray);

        Console.WriteLine("");
    }
}