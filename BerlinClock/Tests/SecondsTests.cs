using NUnit.Framework;

namespace BerlinClock.Tests;

public class SecondsTests
{
    private BerlinClock? _clock;

    [SetUp]
    public void Setup()
    {
        _clock = new BerlinClock();
    }

    [TestCase("00:00:00", "Y")]
    [TestCase("23:59:59", "O")]
    [TestCase("12:04:00", "Y")]
    [TestCase("12:23:00", "Y")]
    [TestCase("12:35:00", "Y")]
    public void SecondsCalculationIsCorrect(DateTime dateTime, string expected)
    {
        var value = _clock?.GetSeconds(dateTime);

        Assert.That(value, Is.EqualTo(expected));
    }
}