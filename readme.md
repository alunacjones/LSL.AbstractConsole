[![Build status](https://img.shields.io/appveyor/ci/alunacjones/lsl-iconsole.svg)](https://ci.appveyor.com/project/alunacjones/lsl-iconsole)
[![Coveralls branch](https://img.shields.io/coverallsCoverage/github/alunacjones/LSL.AbstractConsole)](https://coveralls.io/github/alunacjones/LSL.LSL.AbstractConsole)
[![NuGet](https://img.shields.io/nuget/v/LSL.AbstractConsole.svg)](https://www.nuget.org/packages/LSL.AbstractConsole/)

# LSL.AbstractConsole

This library provides an abstraction to write to a console.

## Basics 

The Main interface `IConsole` is defined as follows

```csharp
/// <summary>
/// The basic abstraction of a console to write to
/// </summary>
public interface IConsole
{
    /// <summary>
    /// Write to the console
    /// </summary>
    /// <param name="text">The text to write</param>
    /// <param name="includeNewLine">Append a new line to the text if <c>true</c></param>
    /// <param name="args">Any arguments if the <c>text</c> has placeholders in it</param>
    /// <returns></returns>
    IConsole Write(string text, bool includeNewLine, IEnumerable<object> args);
}
```

A default implementation called `DefaultConsole` can be instantied and used as follows:

```csharp
using LSL.AbstractConsole;

...

using var writer = new StringWriter();

var console = new DefaultConsole(writer);
console.Write("some text {0}", false, new object[] { "to display" });

var output = writer.ToString();

/* output will contain the following
some text to display
*/
```

> **NOTE**: `Console.Out` can be used as the output to just output to the console.

## Extension methods

The following extesion methods are available to align with string-based `Console.XXX` methods:

```csharp
public static class ConsoleExtensions
{
    private static readonly IEnumerable<object> _emptyArgs = Enumerable.Empty<object>();

    /// <summary>
    /// Writes the placeholder formatted <c>text</c> to the <c>IConsole</c> with the provided args
    /// </summary>
    /// <param name="console"></param>
    /// <param name="text">The placeholder formatted message</param>
    /// <param name="args">The arguments to use for the placeholders</param>
    /// <returns>The original <c>IConsole</c> to chain calls with</returns>
    public static IConsole Write(this IConsole console, string text, params object[] args) => console.Write(text, false, args);

    /// <summary>
    /// Writes the <c>text</c> to the <c>IConsole</c>
    /// </summary>
    /// <param name="console"></param>
    /// <param name="text">The text to output</param>
    /// <returns>The original <c>IConsole</c> to chain calls with</returns>
    public static IConsole Write(this IConsole console, string text) => console.Write(text, false, _emptyArgs);

    /// <summary>
    /// Writes the <c>text</c> to the <c>IConsole</c> including an environment specific <c>NewLine</c>
    /// </summary>
    /// <param name="console"></param>
    /// <param name="text">The text to output</param>
    /// <returns>The original <c>IConsole</c> to chain calls with</returns>
    public static IConsole WriteLine(this IConsole console, string text) => console.Write(text, true, _emptyArgs);

    /// <summary>
    /// Writes the placeholder formatted <c>text</c> to the <c>IConsole</c> including an environment specific <c>NewLine</c>
    /// </summary>
    /// <param name="console"></param>
    /// <param name="text">The placeholder formatted message</param>
    /// <param name="args">The arguments to use for the placeholders</param>
    /// <returns>The original <c>IConsole</c> to chain calls with</returns>
    public static IConsole WriteLine(this IConsole console, string text, params object[] args) => console.Write(text, true, args);

    /// <summary>
    /// Writes a new line with no content
    /// </summary>
    /// <param name="console"></param>
    /// <returns>The original <c>IConsole</c> to chain calls with</returns>
    public static IConsole WriteLine(this IConsole console) => console.WriteLine(string.Empty, true, _emptyArgs);
}
```

