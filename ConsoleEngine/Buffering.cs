using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEngine.Engine
{
    /// <summary>
    /// This class created a buffer for the console to smooth the drawing process,
    /// </summary>
    public class ScreenBuffer
    {
        //https://stackoverflow.com/questions/2743260/is-it-possible-to-write-to-the-console-in-colour-in-net
        public int Width { get; set; }

        public int Height { get; set; }

        public List<Animation> AnimatationtoRUN;
        public List<FixedText> FixedText;

        /// <summary>
        /// Creates a ScreenBuffer Object
        /// </summary>
        /// <param name="width">Width of the  buffer</param>
        /// <param name="height">Height of the Buffer</param>
        public ScreenBuffer(int width, int height)
        {
            Width = width;
            Height = height;

            screenBufferArray = new char[width, height];
            AnimatationtoRUN = new List<Animation>();
            FixedText = new List<FixedText>();
        }

        //initiate important variables
        public char[,] screenBufferArray; //main buffer array

        public string screenBuffer; //buffer as string (used when drawing)
        public Char[] arr; //temporary array for drawing string
        public int i = 0; //keeps track of the place in the array to draw to

        /// <summary>
        /// Write text it to the buffer (for one refresh
        /// </summary>
        /// <param name="text">text to displat</param>
        /// <param name="XYLocation">position to display it</param>
        public void Draw(string text, Coordinate XYLocation)
        {
            //split text into array
            arr = text.ToCharArray(0, text.Length);
            //iterate through the array, adding values to buffer
            i = 0;
            foreach (char c in arr)
            {
                screenBufferArray[XYLocation.X + i, XYLocation.Y] = c;
                i++;
            }
        }

        /// <summary>
        /// Basic Draw Function
        /// </summary>
        /// <param name="textlines"></param>
        /// <param name="XY"></param>
        private void Draw(string[] textlines, Coordinate XY)
        {
            for (int row = 0; row < textlines.Length; i++)
            {
                string text = textlines[row];

                //split text into array
                arr = text.ToCharArray(0, text.Length);
                //iterate through the array, adding values to buffer
                i = 0;
                foreach (char c in arr)
                {
                    screenBufferArray[XY.X + i, XY.Y + row] = c;
                    i++;
                }
                row++;
            }
        }

        /// <summary>
        /// Function to draw the screen from the buffer
        /// </summary>
        public void DrawScreen()
        {
            //Add animatation

            foreach (Animation MTAni in AnimatationtoRUN)
            {
                if (MTAni.AnimateFinished == false)
                {
                    Draw(MTAni.AnimationSteps[MTAni.Ticks - 1], MTAni.Position);
                    MTAni.Ticks = MTAni.Ticks + 1;
                }
            }
            //FixedText
            //Add Fixed Test

            foreach (FixedText FixText in FixedText)
            {
                Draw(FixText.Text, FixText.Position);
            }

            screenBuffer = "";
            //iterate through buffer, adding each value to screenBuffer
            for (int iy = 0; iy < Height - 1; iy++)
            {
                for (int ix = 0; ix < Width; ix++)
                {
                    screenBuffer += screenBufferArray[ix, iy];
                }
            }

            //set cursor position to top left and draw the string
            Console.SetCursorPosition(0, 0);
            Console.Write(screenBuffer);
            screenBufferArray = new char[Width, Height];
            //note that the screen is NOT cleared at any point as this will simply overwrite the existing values on screen. Clearing will cause flickering again.
        }

        /// <summary>
        /// Refreshs the screen removing any non-fixed text and non-game objects Drawn
        /// </summary>
        /// <param name="objlist">Master list of Objects that will be drawn</param>
        public void UpdateScreen(List<GameObject> objlist)
        {
            foreach (GameObject obj in objlist.ToList<GameObject>())
            {
                Draw(obj.ObjectShape, obj.Position);
            }
            DrawScreen();
        }

        /// <summary>
        /// Process to run at the end of your game to play any final Animation
        /// </summary>
        /// <param name="RefreshRate">How fast the screen should refresh</param>
        /// <param name="objlist">Master list of Objects that will be drawn</param>
        public void FinishAnimations(int RefreshRate, List<GameObject> objlist)
        {
            List<Animation> Unfinshedanimation;
            do
            {
                System.Threading.Thread.Sleep(RefreshRate);
                Unfinshedanimation = AnimatationtoRUN.Where(o => o.AnimateFinished == false).ToList();
                if (Unfinshedanimation.Count != 0)
                {
                    UpdateScreen(objlist);
                }
            } while (Unfinshedanimation.Count != 0);
        }
    }
}