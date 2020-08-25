using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEngine
{
    /// <summary>
    /// Main Struct for dealing with position and movement
    /// </summary>
    public class Coordinate
    {
        /// <summary>
        /// Create a new Cordinate based on X/Y
        /// </summary>
        /// <param name="x">X Component of the Coordinate</param>
        /// <param name="y">Y Component of the Coordinate</param>
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// X-axis location
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y-axis location
        /// </summary>
        public int Y { get; set; }
    }
}