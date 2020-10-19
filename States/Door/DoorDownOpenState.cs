using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class DoorDownOpenState : IDoorState
    {
        private ISprite doorSprite;
        private Door door;
        public int Width { get; set; }
        public int Height { get; set; }
        public DoorDownOpenState(Door door)
        {
            this.door = door;
            doorSprite = ArtifactSpriteFactory.Instance.CreateDownOpenDoorSprite();
            this.Width = doorSprite.Width;
            this.Height = doorSprite.Height;
            this.door.DoorState = DoorState.OPEN;
        }

        public void Down()
        {
            //Do nothing. Is already in this state.
        }

        public void Left()
        {
            door.State = new DoorLeftOpenState(door);
        }

        public void Right()
        {
            door.State = new DoorRightOpenState(door);
        }

        public void Up()
        {
            door.State = new DoorUpOpenState(door);
        }

        public void Locked()
        {
            door.State = new DoorDownLockedState(door);
        }

        public void Open()
        {
            //Do nothing. Is already in this state.
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
