using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class DoorRightOpenState : IDoorState
    {
        private ISprite doorSprite;
        private Door door;
        public int Width { get; set; }
        public int Height { get; set; }
        public DoorRightOpenState(Door door)
        {
            this.door = door;
            doorSprite = ArtifactSpriteFactory.Instance.CreateRightOpenDoorSprite();
            this.Width = doorSprite.Width;
            this.Height = doorSprite.Height;
            this.door.DoorState = DoorState.OPEN;
        }

        public void Down()
        {
            door.State = new DoorDownOpenState(door);
        }

        public void Left()
        {
            door.State = new DoorLeftOpenState(door);
        }

        public void Right()
        {
            //Do nothing. Is already in this state.
        }

        public void Up()
        {
            door.State = new DoorUpOpenState(door);
        }

        public void Locked()
        {
            door.State = new DoorRightLockedState(door);
        }

        public void Open()
        {
            //Do nothing. Is already in this state.
        }

        public void Closed()
        {
            door.State = new DoorRightClosedState(door);
        }

        public void Update()
        {
            doorSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            doorSprite.Draw(spriteBatch, door.Position);
        }
    }
}
