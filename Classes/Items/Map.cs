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
    class Map : IItem
    {
        private Vector2 position;
        private ISprite mapSprite;
        public bool Picked { get; set; }
        public String Name { get; set; }

        public Map(int x, int y)
        {
            position.X = x;
            position.Y = y;
            mapSprite = ItemSpriteFactory.Instance.CreateMapSprite();
            this.Picked = false;
            this.Name = "map";
        }

        public void IsPicked()
        {
            this.Picked = true;
            SoundEffectFactory.Instance.PlayGetItemSoundEffect();
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, mapSprite.Width, mapSprite.Height);
        }

        public void CollidedWithLink(IPlayer link)
        {
            // or change state?
            this.IsPicked();
            link.PickUpItem(this.Name);
        }

        public void Update()
        {
            mapSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mapSprite.Draw(spriteBatch, position);
        }
    }
}
