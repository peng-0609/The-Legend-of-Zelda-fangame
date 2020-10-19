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
    public interface IBlockState
    {

        int Width { get; set; }
        int Height { get; set; }
        void Move();
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
