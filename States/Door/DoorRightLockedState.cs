using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class DoorRightLockedState : IDoorState
    {
        private ISprite doorSprite;
        private Door door;
        public int Width { get; set; }
        public int Height { get; set; }
        public DoorRightLockedState(Door door)
        {
            this.door = door;
            doorSprite = ArtifactSpriteFactory.Instance.CreateRightLockedDoorSprite();
            this.Width = doorSprite.Width;
            this.Height = doorSprite.Height;
            this.door.DoorState = DoorState.LOCKED;
        }

        public void Down()
        {
            door.State = new DoorDownLockedState(door);
        }

        public void Left()
        {
            door.State = new DoorLeftLockedState(door);
        }

        public void Right()
        {
            //Do nothing. Is already in this state.
        }

        public void Up()
        {
            door.State = new DoorUpLockedState(door);
        }

        public void Locked()
        {
            //Do nothing. Is already in this state.
        }

        public void Open()
        {
            door.State = new DoorRightOpenState(door);
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
