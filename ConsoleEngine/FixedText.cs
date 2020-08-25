using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEngine.Engine
{
    /// <summary>
    /// Fixed test to display on every update
    /// </summary>
    public class FixedText
    {
        /// <summary>
        /// Creates a new FixedText Object
        /// </summary>
        /// <param name="text">Text to Add</param>
        /// <param name="position">Where to add it</param>
        public FixedText(string text, Coordinate position)
        {
            Text = text;
            Position = position;
        }

        /// <summary>
        /// Text to display
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Position of text
        /// </summary>
        public Coordinate Position { get; set; }
    }
}