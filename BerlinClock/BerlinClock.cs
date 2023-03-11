namespace BerlinClock;

public class BerlinClock
{
    private static IReadOnlyList<string> SingleHours => new[]
    {
        "OOOO",
        "ROOO",
        "RROO",
        "RRRO",
        "RRRR"
    };
    
    private static IReadOnlyList<string> HoursBlock => new[]
    {
        "OOOO",
        "ROOO",
        "RROO",
        "RRRO",
        "RRRR"
    };
    
    private static IReadOnlyList<string> SingleMinutes => new[]
    {
        "OOOO",
        "YOOO",
        "YYOO",
        "YYYO",
        "YYYY"
    };

    private static IReadOnlyList<string> MinutesBlock => new[]
    {
        "OOOOOOOOOOO",
        "YOOOOOOOOOO",
        "YYOOOOOOOOO",
        "YYROOOOOOOO",
        "YYRYOOOOOOO",
        "YYRYYOOOOOO",
        "YYRYYROOOOO",
        "YYRYYRYOOOO",
        "YYRYYRYYOOO",
        "YYRYYRYYROO",
        "YYRYYRYYRYO",
        "YYRYYRYYRYY"
    };
    
    private static IReadOnlyList<string> Seconds => new[]
    {
        "Y",
        "O"
    };

    public string GetFiveHours(TimeOnly time) => HoursBlock[time.Hour / 5];

    public string GetSingleHours(TimeOnly time) => SingleHours[time.Hour % 5];

    public string GetFiveMinutes(TimeOnly time) => MinutesBlock[time.Minute / 5];

    public string GetSingleMinutes(TimeOnly time) => SingleMinutes[time.Minute % 5];
    
    public string GetSeconds(TimeOnly time) => Seconds[time.Second % 2];

    public string GetTime(TimeOnly dateTime) =>
        $"{GetSeconds(dateTime)}" +
        $"{GetFiveHours(dateTime)}" +
        $"{GetSingleHours(dateTime)}" +
        $"{GetFiveMinutes(dateTime)}" +
        $"{GetSingleMinutes(dateTime)}";
}