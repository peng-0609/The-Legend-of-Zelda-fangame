using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class LinkWaterCollision
    {
        public static void HandleCollision(IPlayer link, IWater water, Direction direction)
        {
            water.CollidedWithLink(link, direction);
        }
        public static void UpateLocation(IPlayer link, IWater water, Direction direction)
        {
            switch (direction)
            {
                case Direction.UP:
                    link.SetPos( new Vector2(link.Position.X, water.Position.Y - link.GetRectangle().Height));
                    break;

                case Direction.LEFT:
                    link.SetPos( new Vector2(water.Position.X - link.GetRectangle().Width, link.Position.Y));
                    break;

                case Direction.RIGHT:
                    link.SetPos( new Vector2(water.Position.X + water.GetRectangle().Width, link.Position.Y));
                    break;

                case Direction.DOWN:
                    link.SetPos(new Vector2(link.Position.X, water.Position.Y + water.GetRectangle().Height));
                    break;
            }

        }
    }
}
