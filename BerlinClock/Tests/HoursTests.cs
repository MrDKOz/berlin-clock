using NUnit.Framework;

namespace BerlinClock.Tests;

public class HoursTests
{
    private BerlinClock? _clock;
    
    [SetUp]
    public void Setup()
    {
        _clock = new BerlinClock();
    }
    
    [TestCase("00:00:00", "OOOO")]
    [TestCase("23:59:59", "RRRR")]
    [TestCase("02:04:00", "OOOO")]
    [TestCase("08:23:00", "ROOO")]
    [TestCase("16:35:00", "RRRO")]
    public void FiveHoursCalculationIsCorrect(DateTime dateTime, string expected)
    {
        var value = _clock?.GetFiveHours(dateTime);
        
        Assert.That(value, Is.EqualTo(expected));
    }
    
    [TestCase("00:00:00", "OOOO")]
    [TestCase("23:59:59", "RRRO")]
    [TestCase("02:04:00", "RROO")]
    [TestCase("08:23:00", "RRRO")]
    [TestCase("14:35:00", "RRRR")]
    public void OneHourCalculationIsCorrect(DateTime dateTime, string expected)
    {
        var value = _clock?.GetSingleHours(dateTime);
        
        Assert.That(value, Is.EqualTo(expected));
    }
}