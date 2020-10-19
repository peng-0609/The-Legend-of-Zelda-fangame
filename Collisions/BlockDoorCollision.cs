using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class BlockDoorCollision
    {
        public static void HandleCollision(IBlock block, IDoor door, Direction direction)
        {
            door.CollidedWithBlock(block, direction);
        }
        public static void UpateLocation(IBlock block, IDoor door, Direction direction)
        {
            switch (direction)
            {
                case Direction.UP:
                    block.Position = new Vector2(block.Position.X, door.Position.Y - block.GetRectangle().Height);
                    break;

                case Direction.LEFT:
                    block.Position = new Vector2(door.Position.X - block.GetRectangle().Width, block.Position.Y);
                    break;

                case Direction.RIGHT:
                    block.Position = new Vector2(door.Position.X + door.GetRectangle().Width, block.Position.Y);
                    break;

                case Direction.DOWN:
                    block.Position = new Vector2(block.Position.X, door.Position.Y + door.GetRectangle().Height);
                    break;
            }

        }
    }
}
