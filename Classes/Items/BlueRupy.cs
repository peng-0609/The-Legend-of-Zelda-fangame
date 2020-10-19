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
    class BlueRupy : IItem
    {
        private Vector2 position;
        private ISprite blueRupySprite;
        public bool Picked { get; set; }
        public String Name { get; set; }

        public BlueRupy(int x, int y)
        {
            position.X = x;
            position.Y = y;
            blueRupySprite = ItemSpriteFactory.Instance.CreateBlueRupySprite();
            this.Picked = false;
            this.Name = "blueRupy";
        }

        public void IsPicked()
        {
            this.Picked = true;
            SoundEffectFactory.Instance.PlayGetRupeeSoundEffect();
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, blueRupySprite.Width, blueRupySprite.Height);
        }
        public void CollidedWithLink(IPlayer link)
        {
            // or change state?
            this.IsPicked();
            link.PickUpItem(this.Name);
        }
        public void Update()
        {
            blueRupySprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            blueRupySprite.Draw(spriteBatch, position);
        }
    }
}
