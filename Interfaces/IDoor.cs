using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public interface IDoor
    {
        Vector2 Position { get; set; }
        DoorState DoorState { get; set; }
        int ConnectedRoom { get; set; }
        void Up();
        void Down();
        void CollidedWithBlock(IBlock block, Direction direction);
        void Left();
        void Right();
        void Open();
        void Locked();
        void Closed();
        void InitializeState(int direction, int doorState);
        Rectangle GetRectangle();
        void CollidedWithEnemy(IEnemy enemy, Direction direction);
        void CollidedWithProjectile(IProjectile projectile, Direction direction);
        void CollidedWithLink(IPlayer link, Direction direction, bool linkInsideOpenDoor);
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
