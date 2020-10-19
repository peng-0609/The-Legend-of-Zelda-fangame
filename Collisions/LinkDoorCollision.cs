using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class LinkDoorCollision
    {
        public static void ChangeTheRoom(Direction direction, GameStateManager gameStateManager, int doorNum)
        {
                gameStateManager.ChangeRoom(direction, doorNum);

        }
        public static void HandleCollision(IPlayer link, IDoor door, Direction direction, bool linkInsideOpenDoor)
        {
            door.CollidedWithLink(link, direction,linkInsideOpenDoor);
        }
        public static void UpateLocation(IPlayer link, IDoor door, Direction direction, bool linkInsideOpenDoor)
        {
            if (door.DoorState == DoorState.LOCKED)
            {
                if (link.Inventory.KeyCount > 0)
                {
                    door.Open();
                    link.Inventory.KeyCount--;
                    SoundEffectFactory.Instance.PlayDoorUnlockSoundEffect();
                }
            }
            link.linkphysicalProperty.Velocity = new Vector2(0, 0);
            switch (direction)
            {
                case Direction.DOWN:
                    if (door.DoorState == DoorState.OPEN && linkInsideOpenDoor)
                        link.SetPos(new Vector2(300, 215));
                    else if (door.DoorState == DoorState.CLOSED|| door.DoorState == DoorState.LOCKED)
                            link.SetPos(new Vector2(link.Position.X, door.Position.Y - link.GetRectangle().Height));
                    break;

                case Direction.RIGHT:
                    if (door.DoorState == DoorState.OPEN && linkInsideOpenDoor)
                        link.SetPos(new Vector2(86, 320));
                    else if (door.DoorState == DoorState.CLOSED || door.DoorState == DoorState.LOCKED)
                        link.SetPos(new Vector2(door.Position.X - link.GetRectangle().Width, link.Position.Y));
                    break;

                case Direction.LEFT:
                    if (door.DoorState == DoorState.OPEN && linkInsideOpenDoor)
                        link.SetPos(new Vector2(525, 320));
                    else if (door.DoorState == DoorState.CLOSED || door.DoorState == DoorState.LOCKED)
                        link.SetPos(new Vector2(door.Position.X + door.GetRectangle().Width, link.Position.Y));
                    break;

                 case Direction.UP:
                    if (door.DoorState == DoorState.OPEN && linkInsideOpenDoor)
                        link.SetPos(new Vector2(300, 440));
                    else if (door.DoorState == DoorState.CLOSED || door.DoorState == DoorState.LOCKED)
                        link.SetPos(new Vector2(link.Position.X, door.Position.Y + door.GetRectangle().Height));
                    break;
                }
           
        }
    }
}
