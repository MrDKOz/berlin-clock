using NUnit.Framework;
using FluentAssertions;

namespace BerlinClock.Tests;

public class HoursTests
{
    private readonly BerlinClock _clock = new();
    
    [TestCase("00:00:00", "OOOO")]
    [TestCase("23:59:59", "RRRR")]
    [TestCase("02:04:00", "OOOO")]
    [TestCase("08:23:00", "ROOO")]
    [TestCase("16:35:00", "RRRO")]
    public void FiveHoursCalculationIsCorrect(string time, string expected) => 
        _clock.GetFiveHours(TimeOnly.Parse(time)).Should().Be(expected);

    [TestCase("00:00:00", "OOOO")]
    [TestCase("23:59:59", "RRRO")]
    [TestCase("02:04:00", "RROO")]
    [TestCase("08:23:00", "RRRO")]
    [TestCase("14:35:00", "RRRR")]
    public void OneHourCalculationIsCorrect(string time, string expected) => 
        _clock.GetSingleHours(TimeOnly.Parse(time)).Should().Be(expected);
}