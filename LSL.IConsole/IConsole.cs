using System.Collections.Generic;

namespace LSL.IConsole
{
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
        /// <param name="args">Any arguments if the message has placeholders in it</param>
        /// <returns></returns>
        IConsole Write(string text, bool includeNewLine, IEnumerable<object> args);
    }
}