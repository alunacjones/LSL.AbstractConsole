using System.Collections.Generic;
using System.Linq;

namespace LSL.IConsole
{
    /// <summary>
    /// ConsoleExtensions
    /// </summary>
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
}