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
    class Fairy : IItem
    {
        private Vector2 position;
        private ISprite fairySprite;
        public bool Picked { get; set; }
        public String Name { get; set; }

        public Fairy(int x, int y)
        {
            position.X = x;
            position.Y = y;
            fairySprite = ItemSpriteFactory.Instance.CreateFairySprite();
            this.Picked = false;
            this.Name = "fairy";
        }

        public void IsPicked()
        {
            this.Picked = true;
            SoundEffectFactory.Instance.PlayGetItemSoundEffect();
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, fairySprite.Width, fairySprite.Height);
        }

        public void CollidedWithLink(IPlayer link)
        {
            // or change state?
            this.IsPicked();
            link.PickUpItem(this.Name);
        }

        public void Update()
        {
            fairySprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            fairySprite.Draw(spriteBatch, position);
        }
    }
}
