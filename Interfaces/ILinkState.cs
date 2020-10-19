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
    public interface ILinkState
    {
        int Width { get; set; }
        int Height { get; set; }
        void TakeDamage();
        void Die();
        void FaceUp();
        void FaceDown();
        void FaceLeft();
        void FaceRight();
        void Run();
        void Attack();
        void PickUpItem();
        void UseBomb();
        void UseBoomerang();
        void Shoot();
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
