using FluentAssertions;
using NUnit.Framework;

namespace BerlinClock.Tests;

public class MinutesTests
{
    private readonly BerlinClock _clock = new ();

    [TestCase("00:00:00", "OOOOOOOOOOO")]
    [TestCase("23:59:59", "YYRYYRYYRYY")]
    [TestCase("12:04:00", "OOOOOOOOOOO")]
    [TestCase("12:23:00", "YYRYOOOOOOO")]
    [TestCase("12:35:00", "YYRYYRYOOOO")]
    public void FiveMinutesCalculationIsCorrect(string time, string expected) => 
        _clock.GetFiveMinutes(TimeOnly.Parse(time)).Should().Be(expected);

    [TestCase("00:00:00", "OOOO")]
    [TestCase("23:59:59", "YYYY")]
    [TestCase("12:32:00", "YYOO")]
    [TestCase("12:34:00", "YYYY")]
    [TestCase("12:35:00", "OOOO")]
    public void OneMinuteCalculationIsCorrect(string time, string expected) => 
        _clock.GetSingleMinutes(TimeOnly.Parse(time)).Should().Be(expected);
}