using System;
using System.IO;
using FluentAssertions;
using FluentAssertions.Execution;

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

        writer.Flush();

        // Assert  
        using var _ = new AssertionScope();

        Environment.NewLine.Should().Be("\r\n");
        
        writer
            .ToString()
            //.ReplaceLineEndings()
            .Should().Be(
            """
            some text with stuff
            another line
            and another with more stuff

            """.FixStringConstantForAppVeyor()//.ReplaceLineEndings()
        );
    }
}

public static class StringFixingExtensionsForAppVeyor
{
    public static string FixStringConstantForAppVeyor(this string source)
    {
        if (source.IndexOf("\r\n") > -1)
        {
            return source;
        }

        return source.ReplaceLineEndings("\r\n");
    }
}
