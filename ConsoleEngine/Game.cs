using ConsoleEngine.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleEngine
{
    /// <summary>
    /// Main helper class containing all main functions
    /// </summary>
    public class Game
    {
        /// <summary>
        ///
        /// </summary>
        public List<GameObject> objlist;

        /// <summary>
        ///
        /// </summary>
        public ScreenBuffer SB;

        /// <summary>
        ///
        /// </summary>
        public Controls Controls;

        /// <summary>
        ///
        /// </summary>
        public int RefreshRate { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objlist"></param>
        /// <param name="sB"></param>
        /// <param name="refreshRate"></param>
        /// <param name="ConsoleHeight"></param>
        /// <param name="ConsoleWidth"></param>
        public Game(List<GameObject> objlist, ScreenBuffer sB, int refreshRate, int ConsoleHeight, int ConsoleWidth)
        {
            this.objlist = objlist;
            SB = sB;
            RefreshRate = refreshRate;
            Console.WindowHeight = ConsoleHeight;
            Console.WindowWidth = ConsoleWidth;
        }

        /// <summary>
        ///
        /// </summary>
        public void RunGame()
        {
            do
            {
                Thread.Sleep(RefreshRate);

                SB.UpdateScreen(objlist);
            } while (1 == 1);
        }
    }
}