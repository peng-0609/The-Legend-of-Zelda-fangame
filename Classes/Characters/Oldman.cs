using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    public class Oldman : ICharacter
    {
        private Vector2 position;
        private ISprite oldmanSprite;

        public Oldman(int x, int y)
        {
            position.X = x;
            position.Y = y;
            oldmanSprite = CharacterSpriteFactory.Instance.CreateOldmanSprite();
        }

        public void Update()
        {
            oldmanSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            oldmanSprite.Draw(spriteBatch, position);
        }
    }
}
