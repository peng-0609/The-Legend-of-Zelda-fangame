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
    class Sword : IItem
    {
        private Vector2 position;
        private ISprite swordSprite;
        public bool Picked { get; set; }
        public String Name { get; set; }

        public Sword(int x, int y)
        {
            position.X = x;
            position.Y = y;
            swordSprite = ItemSpriteFactory.Instance.CreateSwordSprite();
            this.Picked = false;
            this.Name = "sword";
        }

        public void IsPicked()
        {
            this.Picked = true;
            SoundEffectFactory.Instance.PlayGetItemSoundEffect();
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, swordSprite.Width, swordSprite.Height);
        }

        public void CollidedWithLink(IPlayer link)
        {
            // or change state?
            this.IsPicked();
            link.PickUpItem(this.Name);
        }

        public void Update()
        {
            swordSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            swordSprite.Draw(spriteBatch, position);
        }
    }
}
