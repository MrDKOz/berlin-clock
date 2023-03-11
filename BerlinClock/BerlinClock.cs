namespace BerlinClock;

public class BerlinClock
{
    public string GetFiveHours(DateTime dateTime)
    {
        var lightCount = dateTime.Hour / 5;

        return $"{new string('R', lightCount)}{new string('O', 4 - lightCount)}";
    }

    public string GetSingleHours(DateTime dateTime)
    {
        var lightCount = dateTime.Hour % 5;

        return $"{new string('R', lightCount)}{new string('O', 4 - lightCount)}";
    }

    public string GetFiveMinutes(DateTime dateTime)
    {
        var lightCount = dateTime.Minute / 5;

        return $"{new string('Y', lightCount)}{new string('O', 11 - lightCount)}".Replace("YYY", "YYR");
    }
    
    public string GetSingleMinutes(DateTime dateTime)
    {
        var lightCount = dateTime.Minute % 5;

        return $"{new string('Y', lightCount)}{new string('O', 4 - lightCount)}";
    }

    public string GetSeconds(DateTime dateTime) => dateTime.Second % 2 == 0 ? "Y" : "O";

    public string GetTime(DateTime dateTime) =>
        $"{GetSeconds(dateTime)}{Environment.NewLine}" +
        $"{GetFiveHours(dateTime)}{Environment.NewLine}" +
        $"{GetSingleHours(dateTime)}{Environment.NewLine}" +
        $"{GetFiveMinutes(dateTime)}{Environment.NewLine}" +
        $"{GetSingleMinutes(dateTime)}";
}