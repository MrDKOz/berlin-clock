using FluentAssertions;
using NUnit.Framework;

namespace BerlinClock.Tests;

public class FullClockTests
{
    private readonly BerlinClock _clock = new();
    
    [TestCase("00:00:00", "YOOOOOOOOOOOOOOOOOOOOOOO")]
    [TestCase("23:59:59", "ORRRRRRROYYRYYRYYRYYYYYY")]
    [TestCase("16:50:06", "YRRROROOOYYRYYRYYRYOOOOO")]
    [TestCase("11:37:01", "ORROOROOOYYRYYRYOOOOYYOO")]
    public void FullClockCalculationIsCorrect(string time, string expected) => 
        _clock.GetTime(TimeOnly.Parse(time)).Should().Be(expected);
}