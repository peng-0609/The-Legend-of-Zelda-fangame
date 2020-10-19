using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class LinkWallCollision
    {
        public static void HandleCollision(IPlayer link, IWall wall, Direction direction)
        {
            wall.CollidedWithLink(link, direction);
        }
        public static void UpateLocation(IPlayer link, IWall wall, Direction direction)
        {
            switch (direction)
            {
                case Direction.UP:
                    link.SetPos(new Vector2(link.Position.X, wall.Position.Y - link.GetRectangle().Height));
                    link.linkphysicalProperty.Velocity = new Vector2(0, 0);
                    break;

                case Direction.LEFT:
                    link.SetPos( new Vector2(wall.Position.X - link.GetRectangle().Width, link.Position.Y));
                    link.linkphysicalProperty.Velocity = new Vector2(0, 0);
                    break;

                case Direction.RIGHT:
                    link.SetPos( new Vector2(wall.Position.X + wall.GetRectangle().Width, link.Position.Y));
                    link.linkphysicalProperty.Velocity = new Vector2(0, 0);
                    break;

                case Direction.DOWN:
                    link.SetPos( new Vector2(link.Position.X, wall.Position.Y + wall.GetRectangle().Height));
                    link.linkphysicalProperty.Velocity = new Vector2(0, 0);
                    break;
            }

        }
    }
}
