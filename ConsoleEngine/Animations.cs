using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEngine.Engine
{
    /// <summary>
    /// Class to build frame-by-frame Animations
    /// </summary>
    public class Animation
    {
        /// <summary>
        /// current frame of the animation
        /// </summary>
        public int Ticks { get; set; }

        /// <summary>
        /// Top left point the Animation will start at
        /// </summary>
        public Coordinate Position { get; set; }

        /// <summary>
        /// List of arrays containing each frame of a Animation
        /// </summary>
        public List<string[]> AnimationSteps;

        /// <summary>
        /// Creates a new animation
        /// </summary>
        /// <param name="AniChars">List of arrays containing each frame of a Animation</param>
        /// <param name="XYPosition">Top left point the Animation will start at</param>
        public Animation(List<string[]> AniChars, Coordinate XYPosition)
        {
            AnimationSteps = AniChars;
            Position = XYPosition;

            Ticks = 1;
        }

        /// <summary>
        /// Has the animation finished
        /// </summary>
        public bool AnimateFinished
        {
            get
            {
                if (Ticks > AnimationSteps.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}