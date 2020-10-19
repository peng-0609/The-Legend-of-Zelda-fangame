using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public interface IGameState
    {
        bool isPause { get; set; }
        void Draw(SpriteBatch spriteBatch);
        void Action();
        void Up();
        void Down();
        void Update(GameTime gameTime);
        void Left();
        void Right();
        void Item();
        void Resume();
    }
}
