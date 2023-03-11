using FluentAssertions;
using NUnit.Framework;

namespace BerlinClock.Tests;

public class ConversionTests
{
    private readonly BerlinClockConverter _converter = new();
    
    [TestCase("YOOOOOOOOOOOOOOOOOOOOOOO", "00:00:00")]
    [TestCase("ORRRRRRROYYRYYRYYRYYYYYY", "23:59:00")]
    [TestCase("YRRROROOOYYRYYRYYRYOOOOO", "16:50:00")]
    [TestCase("ORROOROOOYYRYYRYOOOOYYOO", "11:37:00")]
    public void FullClockConversionIsCorrect(string time, string expected) => 
        _converter.ConvertStringToTimeOnly(time).Should().Be(TimeOnly.Parse(expected));
    
}