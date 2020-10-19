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
    class YellowRupy : IItem
    {
        private Vector2 position;
        private ISprite yellowRupySprite;
        public bool Picked { get; set; }
        public String Name { get; set; }

        public YellowRupy(int x, int y)
        {
            position.X = x;
            position.Y = y;
            yellowRupySprite = ItemSpriteFactory.Instance.CreateYellowRupySprite();
            this.Picked = false;
            this.Name = "yellowRupy";
        }

        public void IsPicked()
        {
            this.Picked = true;
            SoundEffectFactory.Instance.PlayGetRupeeSoundEffect();
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, yellowRupySprite.Width, yellowRupySprite.Height);
        }

        public void CollidedWithLink(IPlayer link)
        {
            // or change state?
            this.IsPicked();
            link.PickUpItem(this.Name);
        }

        public void Update()
        {
            yellowRupySprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            yellowRupySprite.Draw(spriteBatch, position);
        }
    }
}
