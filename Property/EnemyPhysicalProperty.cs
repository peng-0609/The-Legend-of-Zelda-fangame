using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class EnemyPhysicalProperty
    {
        private IEnemy enemy;
        public Vector2 Velocity { get; set; }
        public Vector2 Accerlation { get; set; }
        public Direction Direction { get; set; }
        private readonly int Min = Util.Instance.ZERO;
        private readonly int Max = Util.Instance.HUNDRED;

        public EnemyPhysicalProperty(IEnemy enemy)
        {
            this.enemy = enemy;
            Direction = Direction.LEFT;
            Accerlation = new Vector2(Min,Min);
            Velocity = new Vector2(Min, Min);
        }
       
        public void Update(GameTime gametime)
        {
            
             
            float deltaTime = (float)gametime.ElapsedGameTime.TotalSeconds;
            if (enemy.IsDead||enemy.IsIdle)
            {
                Velocity = new Vector2(0, 0);
            }
            else
            {               
                if (enemy.IsAccelerating) { 
                    if (Velocity.Y > 150)
                    {
                        Velocity = new Vector2(Min, 150);
                    }
                    else if (Velocity.Y < -150)
                    {
                        Velocity = new Vector2(Min, -150);
                    }
                    else if (Velocity.X > 150)
                    {
                        Velocity = new Vector2(150, Min);
                    }   
                    else if (Velocity.X < -150)
                    {
                        Velocity = new Vector2(-150, Min);
                    }
                    else
                    {
                        if (Direction == Direction.DOWN)
                        {
                            Accerlation = new Vector2(Min, Max);
                        }
                        else if (Direction == Direction.UP)
                        {
                            Accerlation = new Vector2(Min, -Max);
                        }
                        else if (Direction == Direction.RIGHT)
                        {
                            Accerlation = new Vector2(Max,Min);
                        }
                        else
                        {
                            Accerlation = new Vector2(-Max, Min);
                        }
                        Velocity += Accerlation * deltaTime;
                    }
                }else {
                    if (Direction == Direction.DOWN)
                    {
                        Velocity = new Vector2(Min, 75);
                    }
                        else if (Direction == Direction.UP)
                    {
                        Velocity = new Vector2(Min, -75);
                    }
                    else if (Direction == Direction.RIGHT)
                    {
                        Velocity = new Vector2(75, Min);
                    }
                    else
                    {
                        Velocity = new Vector2(-75, Min);
                    }
                }
            }
            enemy.Position += Velocity * deltaTime;
            
        }

    }
}
