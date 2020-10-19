using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public interface IEnemyState
    {
        int Width { get; set; }
        int Height { get; set; }
        void MoveLeft();
        void MoveRight();
        void MoveUp();
        void MoveDown();
        void Update();
        void Bekilled();
        void Attack();
        void Draw(SpriteBatch spriteBatch);
    }
}
