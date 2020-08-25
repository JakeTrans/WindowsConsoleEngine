using ConsoleEngine.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEngine.Engine
{
    /// <summary>
    /// Core Object for Game Object - to be inherited with the special function for items
    /// </summary>
    public abstract class GameObject
    {
        /// <summary>
        /// Previous position on the object
        /// </summary>
        public Coordinate OldPosition { get; set; }

        /// <summary>
        /// Current Position of the object
        /// </summary>
        public Coordinate Position { get; set; }

        /// <summary>
        /// String array defining the objects display
        /// </summary>
        public string[] ObjectShape;

        /// <summary>
        /// creates a definition on the object for collison detection only
        /// </summary>
        public string[] HitBox;

        /// <summary>
        /// Has the object collided with anything
        /// </summary>
        public bool Hit { get; set; }

        /// <summary>
        /// point of collision
        /// </summary>
        public Coordinate HitLocation { get; set; }

        /// <summary>
        /// Automatic movement per update
        /// </summary>
        public Coordinate AutoMovement { get; set; }

        /// <summary>
        /// Computed Height of objects
        /// </summary>
        public int Height
        {
            get
            {
                return ObjectShape.Length;
            }
        }

        /// <summary>
        /// Computed Width of object
        /// </summary>
        public int Width
        {
            get
            {
                int wd = 0;
                foreach (string line in ObjectShape)
                {
                    if (line.Length > wd)
                    {
                        wd = line.Length;
                    }
                }
                return wd;
            }
        }

        /// <summary>
        /// Create a Gameobject
        /// </summary>
        /// <param name="SpawnPoint">XY of Spawn</param>
        /// <param name="Objectshape">Array containing the characters of the object</param>
        /// <param name="SB">Screen Buffer to attach to</param>
        public GameObject(Coordinate SpawnPoint, string[] Objectshape, ScreenBuffer SB)
        {
            Position = SpawnPoint;
            OldPosition = SpawnPoint;

            ObjectShape = Objectshape;
            AutoMovement = new Coordinate(0, 0);
            Hit = false;
            HitBox = ObjectShape;
        }

        /// <summary>
        /// Create a Gameobject
        /// </summary>
        /// <param name="SpawnPoint">XY of Spawn</param>
        /// <param name="Objectshape">Array containing the characters of the object</param>
        /// <param name="XyMovement">Movement of object per update regardless of control</param>
        /// <param name="SB">Screen Buffer to attach to</param>
        public GameObject(Coordinate SpawnPoint, string[] Objectshape, Coordinate XyMovement, ScreenBuffer SB)
        {
            Position = SpawnPoint;
            OldPosition = SpawnPoint;

            ObjectShape = Objectshape;
            AutoMovement = XyMovement;
            Hit = false;

            HitBox = ObjectShape;
        }

        /// <summary>
        /// Moves the object (will require a UpdateScreen to take affect
        /// </summary>
        /// <param name="XyMoveBy"></param>
        public void MoveObject(Coordinate XyMoveBy)
        {
            Position.X = Position.X + XyMoveBy.X;

            Position.Y = Position.Y + XyMoveBy.Y;
        }

        /// <summary>
        /// Move object based on Auto- movement property
        /// </summary>
        public void SelfMove()
        {
            MoveObject(AutoMovement);
        }

        /// <summary>
        /// Clears object in buffer pre-destruction
        /// </summary>
        public void DestroyObject()
        {
            ObjectShape = new string[] { " " };
        }
    }
}