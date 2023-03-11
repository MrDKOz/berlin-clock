using System.Text.RegularExpressions;

namespace BerlinClock;

public class BerlinClockConverter
{
    public TimeOnly ConvertStringToTimeOnly(string time)
    {
        var match = _timeRegex.Match(time);

        if (match.Success &&
            TryParseSeconds(match.Groups["SECONDS"].Value, out _) &&
            TryParseHoursBlock(match.Groups["HOURSBLOCK"].Value, out var hoursBlock) &&
            TryParseSingleHours(match.Groups["SINGLEHOURS"].Value, out var singleHours) &&
            TryParseMinutesBlock(match.Groups["MINUTESBLOCK"].Value, out var minutesBlock) &&
            TryParseSingleMinute(match.Groups["SINGLEMINUTES"].Value, out var singleMinutes))
        {
            return new TimeOnly(hoursBlock * 5 + singleHours, minutesBlock * 5 + singleMinutes, 0);
        }
        
        throw new ArgumentException("Invalid time format", nameof(time));
    }
    
    private static bool TryParseSeconds(string input, out int value) =>
        LookupTables.SecondsReverse.TryGetValue(input, out value);

    private static bool TryParseHoursBlock(string input, out int value) =>
        LookupTables.HoursBlockReverse.TryGetValue(input, out value);
    
    private static bool TryParseSingleHours(string input, out int value) =>
        LookupTables.SingleHoursReverse.TryGetValue(input, out value);
    
    private static bool TryParseMinutesBlock(string input, out int value) =>
        LookupTables.MinutesBlockReverse.TryGetValue(input, out value);
    
    private static bool TryParseSingleMinute(string input, out int value) =>
        LookupTables.SingleMinutesReverse.TryGetValue(input, out value);
    
    

    private static readonly Regex _timeRegex = new("^" + $"(?<SECONDS>{RegexJoin(LookupTables.Seconds)})" +
                                                   $"(?<HOURSBLOCK>{RegexJoin(LookupTables.HoursBlock)})" +
                                                   $"(?<SINGLEHOURS>{RegexJoin(LookupTables.SingleHours)})" +
                                                   $"(?<MINUTESBLOCK>{RegexJoin(LookupTables.MinutesBlock)})" +
                                                   $"(?<SINGLEMINUTES>{RegexJoin(LookupTables.SingleMinutes)})" + "$");
    
    private static string RegexJoin(IReadOnlyList<string> patterns) =>
        $"({string.Join("|", patterns.Select(Regex.Escape))})";
}