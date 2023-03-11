namespace BerlinClock;

public static class LookupTables
{
    public static IReadOnlyList<string> Seconds => new[]
    {
        "Y",
        "O"
    };
    
    public static readonly IReadOnlyDictionary<string, int> SecondsReverse =
        Seconds
            .Select((pattern, index) => (pattern, index))
            .ToDictionary(x => x.pattern, x => x.index);
    
    public static IReadOnlyList<string> HoursBlock => new[]
    {
        "OOOO",
        "ROOO",
        "RROO",
        "RRRO",
        "RRRR"
    };
    
    public static readonly IReadOnlyDictionary<string, int> HoursBlockReverse =
        HoursBlock
            .Select((pattern, index) => (pattern, index))
            .ToDictionary(x => x.pattern, x => x.index);
    
    public static IReadOnlyList<string> SingleHours => new[]
    {
        "OOOO",
        "ROOO",
        "RROO",
        "RRRO",
        "RRRR"
    };
    
    public static readonly IReadOnlyDictionary<string, int> SingleHoursReverse =
        SingleHours
            .Select((pattern, index) => (pattern, index))
            .ToDictionary(x => x.pattern, x => x.index);

    public static IReadOnlyList<string> SingleMinutes => new[]
    {
        "OOOO",
        "YOOO",
        "YYOO",
        "YYYO",
        "YYYY"
    };
    
    public static readonly IReadOnlyDictionary<string, int> SingleMinutesReverse =
        SingleMinutes
            .Select((pattern, index) => (pattern, index))
            .ToDictionary(x => x.pattern, x => x.index);

    public static IReadOnlyList<string> MinutesBlock => new[]
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
    
    public static readonly IReadOnlyDictionary<string, int> MinutesBlockReverse =
        MinutesBlock
            .Select((pattern, index) => (pattern, index))
            .ToDictionary(x => x.pattern, x => x.index);
}