using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace ConsoleEngine.Engine
{

    /// <summary>
    /// Class to run the Collision Detection element
    /// </summary>
    public class CollisionDetection
    {
        /// <summary>
        /// GameObject that may collide
        /// </summary>
        public List<GameObject> HitableItems;

        /// <summary>
        /// Builds a instance of the collision detected (ignores anything already hit)
        /// </summary>
        /// <param name="ItemstoWatch">List of Items to check (hit items will be removed)</param>
        public CollisionDetection(List<GameObject> ItemstoWatch)
        {
            HitableItems = ItemstoWatch.Where(x => x.Hit == false).ToList();
        }
        /// <summary>
        /// Run the detection to test if any GameObject has collided with another
        /// </summary>
        public void RunDetection()
        {
            foreach (GameObject Item1 in HitableItems)
            {
                foreach (GameObject Item2 in HitableItems)
                {
                    if (Item1 != Item2)
                    {
                        Rectangle item1rect = new Rectangle(Item1.Position.X, Item1.Position.Y, Item1.Width, Item1.Height);
                        Rectangle item2rect = new Rectangle(Item2.Position.X, Item2.Position.Y, Item2.Width, Item2.Height);

                        if (item1rect.IntersectsWith(item2rect) || item2rect.IntersectsWith(item1rect))
                        {
                            Rectangle intersectArea = Rectangle.Intersect(item1rect, item2rect);//hit area

                            bool hitconfirmed = false;

                            for (int WidthCheck = intersectArea.X; WidthCheck < intersectArea.X + (intersectArea.Width); WidthCheck++)
                            {
                                for (int HeightCheck = intersectArea.Y; HeightCheck < intersectArea.Y + (intersectArea.Height); HeightCheck++)
                                {
                                    //Get location
                                    string item1HitChar = Item1.HitBox[HeightCheck - Item1.Position.Y].Substring(WidthCheck - Item1.Position.X, intersectArea.Width);
                                    string item2HitChar = Item2.HitBox[HeightCheck - Item2.Position.Y].Substring(WidthCheck - Item2.Position.X, intersectArea.Width);

                                    if (item1HitChar != " " && item2HitChar != " ")
                                    {
                                        hitconfirmed = true;
                                        //Item1.HitLocation = new Coordinate(HeightCheck, WidthCheck);
                                        //Item2.HitLocation = new Coordinate(HeightCheck, WidthCheck);
                                        Item1.HitLocation = new Coordinate(WidthCheck, HeightCheck);
                                        Item2.HitLocation = new Coordinate(WidthCheck, HeightCheck);
                                    }

                                }

                            }
                            if (hitconfirmed == true)
                            {
                                Item1.Hit = true;
                                Item2.Hit = true;
                            }
                        }
                    }
                }

            }

        }


        /// <summary>
        /// Run the detection to test if any GameObject has collided with the GameObject in the Parameter
        /// </summary>
        /// <param name="itemtoTest">GameObject to Check</param>
        public void RunDetection(GameObject itemtoTest)
        {

            foreach (GameObject Item2 in HitableItems)
            {
                if (itemtoTest != Item2)
                {
                    Rectangle item1rect = new Rectangle(itemtoTest.Position.X, itemtoTest.Position.Y, itemtoTest.Width, itemtoTest.Height);
                    Rectangle item2rect = new Rectangle(Item2.Position.X, Item2.Position.Y, Item2.Width, Item2.Height);

                    if (item1rect.IntersectsWith(item2rect) || item2rect.IntersectsWith(item1rect))
                    {
                        Rectangle intersectArea = Rectangle.Intersect(item1rect, item2rect);//hit area

                        bool hitconfirmed = false;

                        for (int WidthCheck = intersectArea.X; WidthCheck < intersectArea.X + (intersectArea.Width); WidthCheck++)
                        {
                            for (int HeightCheck = intersectArea.Y; HeightCheck < intersectArea.Y + (intersectArea.Height); HeightCheck++)
                            {
                                //Get location
                                string item1HitChar = itemtoTest.HitBox[HeightCheck - itemtoTest.Position.Y].Substring(WidthCheck - itemtoTest.Position.X, intersectArea.Width);
                                string item2HitChar = Item2.HitBox[HeightCheck - Item2.Position.Y].Substring(WidthCheck - Item2.Position.X, intersectArea.Width);

                                if (item1HitChar != " " && item2HitChar != " ")
                                {
                                    hitconfirmed = true;
                                    //itemtoTest.HitLocation = new Coordinate(HeightCheck, WidthCheck);
                                    //Item2.HitLocation = new Coordinate(HeightCheck, WidthCheck);
                                    itemtoTest.HitLocation = new Coordinate(WidthCheck, HeightCheck);
                                    Item2.HitLocation = new Coordinate(WidthCheck, HeightCheck);
                                }

                            }

                        }
                        if (hitconfirmed == true)
                        {
                            itemtoTest.Hit = true;
                            Item2.Hit = true;
                        }
                    }




                }






            }

        }
    }

}



