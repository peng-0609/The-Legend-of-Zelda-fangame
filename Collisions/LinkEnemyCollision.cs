using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class LinkEnemyCollision
    {
        public static void HandleCollision(IPlayer link, IEnemy enemy, Direction direction, bool isRec,bool xSame, bool ySame )
        {

            if (!enemy.IsDead)
            {
                enemy.CollidedWithLink(link, direction,isRec,xSame,ySame);
            }
                

        }
        public static void UpateLocation(IPlayer link, IEnemy trap,bool ySame,bool xSame)
        {
            /*  switch (direction)
              {
                  case Direction.DOWN: */
            if (xSame)
            {


                if (link.Position.X < trap.CurrentPos().X)
                {
                    trap.IsIdle = false;
                    trap.Enemyphysics.Direction = Direction.LEFT;
                    trap.initialDir = Direction.LEFT;
                    trap.MoveLeft();
                }
                else
                {
                    trap.IsIdle = false;
                    trap.Enemyphysics.Direction = Direction.RIGHT;
                    trap.initialDir = Direction.RIGHT;
                    trap.MoveRight();
                }
            }
            //     break;
            // case Direction.RIGHT: 
            if (ySame)
            {

            
                  if (link.Position.Y < trap.CurrentPos().Y)
                  {
                      trap.IsIdle = false;
                      trap.Enemyphysics.Direction = Direction.UP;
                      trap.initialDir = Direction.UP;
                      trap.MoveUp();
                  }
                  else
                  {
                      trap.IsIdle = false;
                      trap.Enemyphysics.Direction = Direction.DOWN;
                      trap.initialDir = Direction.DOWN;
                      trap.MoveDown();
                  }
            }
            /*     break;

             case Direction.LEFT: 
                  if (link.Position.Y < trap.CurrentPos().Y)
                  {
                      trap.IsIdle = false;
                      trap.Enemyphysics.Direction = Direction.UP;
                      trap.MoveUp();
                  }
                  else
                  {
                      trap.IsIdle = false;
                      trap.Enemyphysics.Direction = Direction.DOWN;
                      trap.MoveDown();
                  }
                  break;
              case Direction.UP: 
                  if (link.Position.X < trap.CurrentPos().X)
                  {
                      trap.IsIdle = false;
                      trap.Enemyphysics.Direction = Direction.LEFT;
                      trap.MoveLeft();
                  }
                  else
                  {
                      trap.IsIdle = false;
                      trap.Enemyphysics.Direction = Direction.RIGHT;
                      trap.MoveRight();
                 }
                  break;
          } */
        }
    }
}
