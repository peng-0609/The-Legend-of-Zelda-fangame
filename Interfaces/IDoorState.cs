using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public interface IDoorState
    {
        int Width { get; set; }
        int Height { get; set; }
        void Up();
        void Down();
        void Left();
        void Right();
        void Open();
        void Locked();
        void Closed();
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
