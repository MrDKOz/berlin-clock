using NUnit.Framework;

namespace BerlinClock.Tests;

public class MinutesTests
{
    private BerlinClock? _clock;

    [SetUp]
    public void Setup()
    {
        _clock = new BerlinClock();
    }
    
    [TestCase("00:00:00", "OOOOOOOOOOO")]
    [TestCase("23:59:59", "YYRYYRYYRYY")]
    [TestCase("12:04:00", "OOOOOOOOOOO")]
    [TestCase("12:23:00", "YYRYOOOOOOO")]
    [TestCase("12:35:00", "YYRYYRYOOOO")]
    public void FiveMinutesCalculationIsCorrect(DateTime dateTime, string expected)
    {
        var value = _clock?.GetFiveMinutes(dateTime);
        
        Assert.That(value, Is.EqualTo(expected));
    }
    
    [TestCase("00:00:00", "OOOO")]
    [TestCase("23:59:59", "YYYY")]
    [TestCase("12:32:00", "YYOO")]
    [TestCase("12:34:00", "YYYY")]
    [TestCase("12:35:00", "OOOO")]
    public void OneMinuteCalculationIsCorrect(DateTime dateTime, string expected)
    {
        var value = _clock?.GetSingleMinutes(dateTime);
        
        Assert.That(value, Is.EqualTo(expected));
    }
}