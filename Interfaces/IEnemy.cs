using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public interface IEnemy
    {
        IEnemyState State { get; set; }
        Vector2 Position { get; set; }
        Direction initialDir { get; set; }
        String Name { get; set; }
        EnemyPhysicalProperty Enemyphysics { get; set; }
        bool IsDead { get; set; }
        bool IsIdle { get; set; }
        bool IsDisappeared { get; set; }
        bool IsAccelerating { get; set; }
        void Bekilled();
        Vector2 CurrentPos();
        void MoveDown();
        void CollidedWithProjectile();
        void MoveUp();

        void MoveLeft();
        void Attack();
        void MoveRight();
        void CollidedWithBlock();
        void CollidedWithWall();
        void CollidedWithWater();
        void CollidedWithDoor();
        void CollidedWithLink(IPlayer link, Direction direction, bool isRec,bool xSame,bool ySame);
        void Update(GameTime gameTime);

        Rectangle GetRectangle();
        void Draw(SpriteBatch spriteBatch);
    }
}
