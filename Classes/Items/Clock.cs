using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    class Clock : IItem
    {
        private Vector2 position;
        private ISprite clockSprite;
        public bool Picked { get; set; }
        public String Name { get; set; }

        public Clock(int x, int y)
        {
            position.X = x;
            position.Y = y;
            clockSprite = ItemSpriteFactory.Instance.CreateClockSprite();
            this.Picked = false;
            this.Name = "clock";
        }

        public void IsPicked()
        {
            this.Picked = true;
            SoundEffectFactory.Instance.PlayGetItemSoundEffect();
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, clockSprite.Width, clockSprite.Height);
        }

        public void CollidedWithLink(IPlayer link)
        {
            // or change state?
            this.IsPicked();
            link.PickUpItem(this.Name);
        }

        public void Update()
        {
            clockSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            clockSprite.Draw(spriteBatch, position);
        }
    }
}
