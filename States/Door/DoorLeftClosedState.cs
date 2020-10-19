using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class DoorLeftClosedState : IDoorState
    {
        private ISprite doorSprite;
        private Door door;
        public int Width { get; set; }
        public int Height { get; set; }
        public DoorLeftClosedState(Door door)
        {
            this.door = door;
            doorSprite = ArtifactSpriteFactory.Instance.CreateLeftClosedDoorSprite();
            this.Width = doorSprite.Width;
            this.Height = doorSprite.Height;
            this.door.DoorState = DoorState.CLOSED;
        }

        public void Down()
        {
            door.State = new DoorDownClosedState(door);
        }

        public void Left()
        {
            //Do nothing. Is already in this state.
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
            door.State = new DoorLeftLockedState(door);
        }

        public void Open()
        {
            door.State = new DoorLeftOpenState(door);
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
