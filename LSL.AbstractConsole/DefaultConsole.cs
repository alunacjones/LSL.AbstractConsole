using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LSL.AbstractConsole
{
    /// <summary>
    /// A default implementation of <c>IConsole</c> that writes to a provided <c>TextWriter</c>
    /// </summary>
    public class DefaultConsole : IConsole
    {
        private readonly TextWriter _writer;

        /// <summary>
        /// Constructs the <c>DefaultConsole</c> that will write to the provided <c>TextWriter</c>
        /// </summary>
        /// <param name="writer">The <c>TextWriter</c></param>
        public DefaultConsole(TextWriter writer) => _writer = writer;

        /// <inheritdoc/>
        public IConsole Write(string text, bool includeNewLine, IEnumerable<object> args)
        {
            IConsole Execute(Action action)
            {
                action();
                return this;
            }

            return (includeNewLine, args) switch
            {
                (true, _) when args.Any() => Execute(() => _writer.WriteLine(text, args.ToArray())),
                (true, _) => Execute(() => Execute(() => _writer.WriteLine(text))),
                (false, _) when args.Any() => Execute(() => _writer.Write(text, args.ToArray())),
                (false, _) => Execute(() => _writer.Write(text))
            };
        }
    }
}