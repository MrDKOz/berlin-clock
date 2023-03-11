using Spectre.Console;

namespace BerlinClock
{
    internal static class Program
    {
        static void Main()
        {
            AnsiConsole.Write(
                new FigletText("Berlin Clock!")
                    .LeftJustified()
                    .Color(Color.Blue));
            
            UserChoice();
        }

        static void UserChoice()
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What do you want to do?")
                    .AddChoices("Show the time", "Convert a string", "Exit"));

            switch (choice)
            {
                case "Show the time":
                    ShowTheTime();
                    break;
                case "Convert a string":
                    ConvertAString();
                    break;
                case "Exit":
                    Environment.Exit(0);
                    break;
            }
        }
        
        static void ConvertAString()
        {
            var time = AnsiConsole.Ask<string>("Enter a time (Berlin clock format): ");
            var clock = new BerlinClockConverter();

            AnsiConsole.MarkupLine($"The time is: {clock.ConvertStringToTimeOnly(time)}");
            UserChoice();
        }

        static void ShowTheTime()
        {
            var clock = new BerlinClock();

            for (;;)
            {
                AnsiConsole.WriteLine("The time is: ");
                
                var time = clock.GetTime(TimeOnly.FromDateTime(DateTime.Now))
                    .Replace("Y", "[yellow]Y[/]")
                    .Replace("R", "[red]R[/]")
                    .Replace("O", "[white]O[/]");
                
                AnsiConsole.Markup(time);
                
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.Clear();
            }
        }
    }
}