using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class EnemyProjectileCollision
    {
        public static void HandleCollision(IEnemy enemy,IProjectile projectile)
        {
            if (projectile.IsUsed && !(projectile is FireBall))
            {
                enemy.CollidedWithProjectile();
            }
        }
    }
}
