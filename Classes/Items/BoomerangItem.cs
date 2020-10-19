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
    class BoomerangItem : IItem
    {
        private Vector2 position;
        private ISprite boomerangItemItemSprite;
        public bool Picked { get; set; }
        public String Name { get; set; }

        public BoomerangItem(int x, int y)
        {
            position.X = x;
            position.Y = y;
            boomerangItemItemSprite = ProjectileSpriteFactory.Instance.CreateBoomerangSprite();
            this.Picked = false;
            this.Name = "boomerang";
        }

        public void IsPicked()
        {
            this.Picked = true;
            SoundEffectFactory.Instance.PlayGetItemSoundEffect();
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, boomerangItemItemSprite.Width, boomerangItemItemSprite.Height);
        }

        public void CollidedWithLink(IPlayer link)
        {
            // or change state?
            this.IsPicked();
            link.PickUpItem(this.Name);
        }

        public void Update()
        {
            boomerangItemItemSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            boomerangItemItemSprite.Draw(spriteBatch, position);
        }
    }
}
