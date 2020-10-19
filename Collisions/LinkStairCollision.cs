using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class LinkStairCollision
    {
        public static void ChangeTheRoom(Direction direction, GameStateManager gameStateManager)
        {
            if (direction == Direction.UP)
            {
                gameStateManager.ChangeRoom(direction, 17);

            }
            else if (direction == Direction.DOWN)
            {
                gameStateManager.ChangeRoom(direction, 13);
            }

        }
        public static void HandleCollision(IPlayer link, IStair stair, Direction direction)
        {
            stair.CollidedWithLink(link, direction);
        }
        public static void UpateLocation(IPlayer link, IStair stair, Direction direction)
        {

            switch (direction)
            {
                case Direction.UP:
                    link.SetPos(new Vector2(285, 325));
                    link.linkphysicalProperty.Velocity = new Vector2(0, 0);
                    break;

                case Direction.DOWN:
                    link.SetPos(new Vector2(125, 170));
                    link.linkphysicalProperty.Velocity = new Vector2(0, 0);
                    break;
            }

        }
    }
}
