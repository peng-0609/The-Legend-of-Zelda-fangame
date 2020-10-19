using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class LinkBlockCollision
    {
        public static void HandleCollision(IPlayer link, IBlock block, Direction direction)
        {
            block.CollidedWithLink(link, direction);
        }
        public static void UpateLocation(IPlayer link, IBlock block, Direction direction)
        {
            switch (direction)
            {
                case Direction.UP:
                    block.Position = new Vector2(block.Position.X, block.Position.Y + 1);
                    link.Position = new Vector2(link.Position.X, block.Position.Y - link.GetRectangle().Height);
                    break;

                case Direction.LEFT:
                    block.Position = new Vector2(block.Position.X + 1, block.Position.Y);
                    link.Position = new Vector2(block.Position.X - link.GetRectangle().Width, link.Position.Y);
                    break;

                case Direction.RIGHT:
                    block.Position = new Vector2(block.Position.X - 1, block.Position.Y);
                    link.Position = new Vector2(block.Position.X + block.GetRectangle().Width, link.Position.Y);
                    break;

                case Direction.DOWN:
                    block.Position = new Vector2(block.Position.X, block.Position.Y - 1);
                    link.Position = new Vector2(link.Position.X, block.Position.Y + block.GetRectangle().Height);
                    break;
            }

        }
    }
}
