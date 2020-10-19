using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class DoorDownClosedState : IDoorState
    {
        private ISprite doorSprite;
        private Door door;
        public int Width { get; set; }
        public int Height { get; set; }
        public DoorDownClosedState(Door door)
        {
            this.door = door;
            doorSprite = ArtifactSpriteFactory.Instance.CreateDownClosedDoorSprite();
            this.Width = doorSprite.Width;
            this.Height = doorSprite.Height;
            this.door.DoorState = DoorState.CLOSED;
        }

        public void Down()
        {
            //Do nothing. Is already in this state.
        }

        public void Left()
        {
            door.State = new DoorLeftClosedState(door);
        }

        public void Right()
        {
            door.State = new DoorRightClosedState(door);
        }

        public void Up()
        {
            door.State = new DoorUpClosedState(door);
        }

        public void Locked()
        {
            door.State = new DoorDownLockedState(door);
        }

        public void Open()
        {
            door.State = new DoorDownOpenState(door);
            SoundEffectFactory.Instance.PlaySecretSoundEffect();
        }

        public void Closed()
        {
            //Do nothing. Is already in this state.
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
