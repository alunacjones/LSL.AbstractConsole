using System.IO;
using FluentAssertions;

namespace LSL.AbstractConsole.Tests;

public class DefaultConsoleTests
{
    [Test]
    public void GivenCallsToTheConsole_ThenItShouldProduceTheExpectedResult()
    {
        // Arrange
        using var writer = new StringWriter();
        var sut = new DefaultConsole(writer);

        // Act
        sut.Write("some text")
            .Write(" with {0}", "stuff")
            .WriteLine()
            .WriteLine("another line")
            .WriteLine("and another with {0}", "more stuff");

        // Assert        
        writer
            .ToString()
            .ReplaceLineEndings()
            .Should().Be(
            """
            some text with stuff
            another line
            and another with more stuff

            """.ReplaceLineEndings()
        );
    }
}