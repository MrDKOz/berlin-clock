namespace BerlinClock;

public class BerlinClock
{

    public string GetFiveHours(TimeOnly time) => LookupTables.HoursBlock[time.Hour / 5];

    public string GetSingleHours(TimeOnly time) => LookupTables.SingleHours[time.Hour % 5];

    public string GetFiveMinutes(TimeOnly time) => LookupTables.MinutesBlock[time.Minute / 5];

    public string GetSingleMinutes(TimeOnly time) => LookupTables.SingleMinutes[time.Minute % 5];
    
    public string GetSeconds(TimeOnly time) => LookupTables.Seconds[time.Second % 2];

    public string GetTime(TimeOnly dateTime) =>
        $"{GetSeconds(dateTime)}" +
        $"{GetFiveHours(dateTime)}" +
        $"{GetSingleHours(dateTime)}" +
        $"{GetFiveMinutes(dateTime)}" +
        $"{GetSingleMinutes(dateTime)}";
}