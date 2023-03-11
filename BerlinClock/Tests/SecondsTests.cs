using FluentAssertions;
using NUnit.Framework;

namespace BerlinClock.Tests;

public class SecondsTests
{
    private readonly BerlinClock _clock = new ();

    [TestCase("00:00:00", "Y")]
    [TestCase("23:59:59", "O")]
    [TestCase("12:04:00", "Y")]
    [TestCase("12:23:00", "Y")]
    [TestCase("12:35:00", "Y")]
    public void SecondsCalculationIsCorrect(string time, string expected) => 
        _clock.GetSeconds(TimeOnly.Parse(time)).Should().Be(expected);
}