using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class BlockWallCollision
    {
        public static void HandleCollision(IBlock block, IWall wall, Direction direction)
        {
            wall.CollidedWithBlock(block, direction);
        }
        public static void UpateLocation(IBlock block, IWall wall, Direction direction)
        {
            switch (direction)
            {
                case Direction.UP:
                    block.Position = new Vector2(block.Position.X, wall.Position.Y - block.GetRectangle().Height);
                    break;

                case Direction.LEFT:
                    block.Position = new Vector2(wall.Position.X - block.GetRectangle().Width, block.Position.Y);
                    break;

                case Direction.RIGHT:
                    block.Position = new Vector2(wall.Position.X + wall.GetRectangle().Width, block.Position.Y);
                    break;

                case Direction.DOWN:
                    block.Position = new Vector2(block.Position.X, wall.Position.Y + wall.GetRectangle().Height);
                    break;
            }

        }
    }
}
