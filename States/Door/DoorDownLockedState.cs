using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class DoorDownLockedState : IDoorState
    {
        private ISprite doorSprite;
        private Door door;
        public int Width { get; set; }
        public int Height { get; set; }
        public DoorDownLockedState(Door door)
        {
            this.door = door;
            doorSprite = ArtifactSpriteFactory.Instance.CreateDownLockedDoorSprite();
            this.Width = doorSprite.Width;
            this.Height = doorSprite.Height;
            this.door.DoorState = DoorState.LOCKED;
        }

        public void Down()
        {
            //Do nothing. Is already in this state.
        }

        public void Left()
        {
            door.State = new DoorLeftLockedState(door);
        }

        public void Right()
        {
            door.State = new DoorRightLockedState(door);
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
            door.State = new DoorDownOpenState(door);
        }

        public void Closed()
        {
            door.State = new DoorDownClosedState(door);
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
