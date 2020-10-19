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
    class Bow : IItem
    {
        private Vector2 position;
        private ISprite bowSprite;
        public bool Picked { get; set; }
        public String Name { get; set; }

        public Bow(int x, int y)
        {
            position.X = x;
            position.Y = y;
            bowSprite = ItemSpriteFactory.Instance.CreateBowSprite();
            this.Picked = false;
            this.Name = "bow";
        }

        public void IsPicked()
        {
            this.Picked = true;
            SoundEffectFactory.Instance.PlayGetItemSoundEffect();
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, bowSprite.Width, bowSprite.Height);
        }

        public void CollidedWithLink(IPlayer link)
        {
            // or change state?
            this.IsPicked();
            link.PickUpItem(this.Name);
        }

        public void Update()
        {
            bowSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            bowSprite.Draw(spriteBatch, position);
        }
    }
}
