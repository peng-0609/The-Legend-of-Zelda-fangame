using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class AllCollisionHandler
    {
        public ILevel Level { get; set; }
        public GameStateManager gameState { get; set; }
        public AllCollisionHandler(GameStateManager gameState)
        {
            this.gameState = gameState;
            Level = gameState.GameClass.Level;
        }

        public void CheckAllCollisions()
        {

            Rectangle linkRectangle = gameState.GameClass.Link.GetRectangle();
            CheckLinkBlockCollision(linkRectangle);
            CheckLinkEnemyCollision(linkRectangle);
            CheckLinkItemCollision(linkRectangle);
            CheckLinkWallCollision(linkRectangle);
            CheckLinkDoorCollision(linkRectangle);
            CheckLinkStairCollision(linkRectangle);
            CheckLinkWaterCollision(linkRectangle);
            CheckLinkProjectileCollision(linkRectangle);
            CheckEnemyBlockCollision();
            CheckEnemyWallCollision();
            CheckEnemyWaterCollision();
            CheckEnemyDoorCollision();
            CheckBlockWallCollision();
            CheckBlockDoorCollision();
            CheckProjectileEnemyCollision();
            CheckProjectileWallCollision();
            CheckProectileBlockCollision();
            CheckProectileDoorCollision();
            CheckProectileStairCollision();
        }


        private void CheckProectileDoorCollision()
        {
            foreach (IProjectile projectile in Level.Projectiles)
            {

                    Rectangle projectileRectangle = projectile.GetRectangle();

                    foreach (IDoor door in Level.Doors)
                    {
                        Rectangle doorRectangle = door.GetRectangle(); ;
                        Rectangle intersectionBox = Rectangle.Intersect(doorRectangle, projectileRectangle);
                        if (!intersectionBox.IsEmpty)
                        {
                            Direction direction = GetCollisionDirection(intersectionBox, projectileRectangle, doorRectangle);
                            ProjectileDoorCollision.HandleCollision(projectile, door, direction);
                        }

                    }

            }
        }
        private void CheckProectileStairCollision()
        {
            foreach (IProjectile projectile in Level.Projectiles)
            {

                    Rectangle projectileRectangle = projectile.GetRectangle();

                    foreach (IStair stair in Level.Stairs)
                    {
                        Rectangle stairRectangle = stair.GetRectangle(); ;
                        Rectangle intersectionBox = Rectangle.Intersect(stairRectangle, projectileRectangle);
                        if (!intersectionBox.IsEmpty)
                        {
                            Direction direction = GetCollisionDirection(intersectionBox, projectileRectangle, stairRectangle);
                            ProjectileStairCollision.HandleCollision(projectile, stair, direction);
                        }

                    }

            }
        }

        private void CheckProectileBlockCollision()
        {
            foreach (IProjectile projectile in Level.Projectiles)
            {

                    Rectangle projectileRectangle = projectile.GetRectangle();

                    foreach (IBlock block in Level.Blocks)
                    {
                        Rectangle blockRectangle = block.GetRectangle(); ;
                        Rectangle intersectionBox = Rectangle.Intersect(blockRectangle, projectileRectangle);
                        if (!intersectionBox.IsEmpty)
                        {
                            Direction direction = GetCollisionDirection(intersectionBox, projectileRectangle, blockRectangle);
                            ProjectileBlockCollision.HandleCollision(projectile, block, direction);
                        }

                    }

            }
        }

        private void CheckLinkProjectileCollision(Rectangle linkRectangle)
        {
            foreach (IProjectile projectile in Level.Projectiles)
            {
                if(projectile is Boomerang)
                {
                    Rectangle projectileRectangle = projectile.GetRectangle();
                    Rectangle initialRectangle = projectile.InitialRec();
                    Direction initialDirection = projectile.InitialDir();
                    Rectangle intersectionRectangle = Rectangle.Intersect(projectileRectangle, initialRectangle);
                    if (!intersectionRectangle.IsEmpty && initialDirection != projectile.getDirection())
                    {
                        Direction direction = GetCollisionDirection(intersectionRectangle, linkRectangle, projectileRectangle);
                        LinkProjectileCollision.HandleCollision(gameState.GameClass.Link, projectile);
                    }
                }
                
            }

            foreach (IProjectile projectile in Level.Projectiles)
            {
                Rectangle projectileRectangle = projectile.GetRectangle();
                Rectangle intersectionRectangle = Rectangle.Intersect(projectileRectangle, linkRectangle);
                if (!intersectionRectangle.IsEmpty)
                {
                    Direction direction = GetCollisionDirection(intersectionRectangle, linkRectangle, projectileRectangle);
                    LinkProjectileCollision.HandleCollision(gameState.GameClass.Link, projectile);
                }
            }
        }
        private void CheckProjectileWallCollision()
        {
            foreach (IProjectile projectile in Level.Projectiles)
            {
                    Rectangle projectileRectangle = projectile.GetRectangle();

                    foreach (IWall wall in Level.Walls)
                    {
                        Rectangle wallRectangle = wall.GetRectangle(); ;
                        Rectangle intersectionBox = Rectangle.Intersect(wallRectangle, projectileRectangle);
                        if (!intersectionBox.IsEmpty)
                        {
                            Direction direction = GetCollisionDirection(intersectionBox, projectileRectangle, wallRectangle);
                            ProjectileWallCollision.HandleCollision(projectile, wall, direction);
                        }

                    }
                

            }
        }

        private void CheckProjectileEnemyCollision()
        {
            foreach (IProjectile projectile in Level.Projectiles)
            {
                Rectangle projectileRectangle = projectile.GetRectangle();

                foreach (IEnemy enemy in Level.Enemies)
                {
                    Rectangle enemyRectangle = enemy.GetRectangle(); ;
                    Rectangle intersectionBox = Rectangle.Intersect(enemyRectangle, projectileRectangle);
                    if (!intersectionBox.IsEmpty)
                    {
                        Direction direction = GetCollisionDirection(intersectionBox, projectileRectangle, enemyRectangle);
                        EnemyProjectileCollision.HandleCollision(enemy, projectile);
                    }

                }

            }
        }

        private void CheckBlockDoorCollision()
        {
            foreach (IBlock block in Level.Blocks)
            {
                Rectangle blockRectangle = block.GetRectangle();

                foreach (IDoor door in Level.Doors)
                {
                    Rectangle doorRectangle = door.GetRectangle(); ;
                    Rectangle intersectionBox = Rectangle.Intersect(doorRectangle, blockRectangle);
                    if (!intersectionBox.IsEmpty)
                    {
                        Direction direction = GetCollisionDirection(intersectionBox, blockRectangle, doorRectangle);
                        BlockDoorCollision.HandleCollision(block, door, direction);
                    }

                }

            }
        }

        private void CheckBlockWallCollision()
        {
            foreach (IBlock block in Level.Blocks)
            {
                Rectangle blockRectangle = block.GetRectangle();

                foreach (IWall wall in Level.Walls)
                {
                    Rectangle wallRectangle = wall.GetRectangle(); ;
                    Rectangle intersectionBox = Rectangle.Intersect(wallRectangle, blockRectangle);
                    if (!intersectionBox.IsEmpty)
                    {
                        Direction direction = GetCollisionDirection(intersectionBox, blockRectangle, wallRectangle);
                        BlockWallCollision.HandleCollision(block, wall, direction);
                    }

                }

            }
        }

        private void CheckEnemyDoorCollision()
        {
            foreach (IEnemy enemy in Level.Enemies)
            {
                Rectangle enemyRectangle = enemy.GetRectangle();

                foreach (IDoor door in Level.Doors)
                {
                    Rectangle doorRectangle = door.GetRectangle(); ;
                    Rectangle intersectionBox = Rectangle.Intersect(doorRectangle, enemyRectangle);
                    if (!intersectionBox.IsEmpty)
                    {
                        Direction direction = GetCollisionDirection(intersectionBox, enemyRectangle, doorRectangle);
                        EnemyDoorCollision.HandleCollision(enemy, door, direction);
                    }

                }

            }
        }

        private void CheckLinkWaterCollision(Rectangle linkRectangle)
        {
            foreach (IWater water in Level.Water)
            {
                Rectangle waterRectangle = water.GetRectangle();
                Rectangle intersectionRectangle = Rectangle.Intersect(waterRectangle, linkRectangle);
                if (!intersectionRectangle.IsEmpty)
                {
                    Direction direction = GetCollisionDirection(intersectionRectangle, linkRectangle, waterRectangle);
                    LinkWaterCollision.HandleCollision(gameState.GameClass.Link, water, direction);
                }
            }
        }

        private void CheckEnemyWaterCollision()
        {
            foreach (IEnemy enemy in Level.Enemies)
            {
                Rectangle enemyRectangle = enemy.GetRectangle();

                foreach (IWater water in Level.Water)
                {
                    Rectangle waterRectangle = water.GetRectangle(); ;
                    Rectangle intersectionBox = Rectangle.Intersect(waterRectangle, enemyRectangle);
                    if (!intersectionBox.IsEmpty)
                    {
                        Direction direction = GetCollisionDirection(intersectionBox, enemyRectangle, waterRectangle);
                        EnemyWaterCollision.HandleCollision(enemy, water, direction);
                    }

                }

            }
        }

        private void CheckLinkEnemyCollision(Rectangle linkRectangle)
        {
            
            int height = 0;
            int width = 0;

            foreach (IEnemy enemy in Level.Enemies)
            {
                if (enemy is Trap)
                {
                    width = enemy.State.Width;
                    height = enemy.State.Height;
                    Rectangle enemyRectangleX = new Rectangle((int)enemy.Position.X, (int)enemy.Position.Y, 1000, height);
                    Rectangle enemyRectangleY = new Rectangle((int)enemy.Position.X, (int)enemy.Position.Y, width, 1000);
                    Rectangle intersectionRectangleX = Rectangle.Intersect(enemyRectangleX, linkRectangle);
                    Rectangle intersectionRectangleY = Rectangle.Intersect(enemyRectangleY, linkRectangle);
                   
                    if (!intersectionRectangleX.IsEmpty && enemy.IsIdle){
                        LinkEnemyCollision.HandleCollision(gameState.GameClass.Link, enemy, Direction.UP, true, false, true);
                    }
                    if (!intersectionRectangleY.IsEmpty && enemy.IsIdle)
                    {
                        LinkEnemyCollision.HandleCollision(gameState.GameClass.Link, enemy, Direction.UP, true, true, false);
                    }
                }
            }


            foreach (IEnemy enemy in Level.Enemies)
            {
                Rectangle enemyRectangle = enemy.GetRectangle();
                Rectangle intersectionRectangle = Rectangle.Intersect(enemyRectangle, linkRectangle);
                if (!intersectionRectangle.IsEmpty)
                {
                    Direction direction = GetCollisionDirection(intersectionRectangle, linkRectangle, enemyRectangle);
                    LinkEnemyCollision.HandleCollision(gameState.GameClass.Link, enemy, direction,false,false,false);
                }
            }
        }

        private void CheckLinkItemCollision(Rectangle linkRectangle)
        {

            foreach (IItem item in Level.Items)
            {
                Rectangle itemRectangle = item.GetRectangle();
                Rectangle intersectionRectangle = Rectangle.Intersect(itemRectangle, linkRectangle);
                if (!intersectionRectangle.IsEmpty)
                {
                    LinkItemCollision.HandleCollision(gameState.GameClass.Link, item);
                }
            }


        }

        //private void CheckLinkProjectileCollision(Rectangle linkRectangle)
        //{
        //    foreach (IProjectile projectile in Level.Projectiles)
        //    {
        //        Rectangle projectileRectangle = projectile.GetRectangle();
        //        Rectangle intersectionRectangle = Rectangle.Intersect(projectileRectangle, linkRectangle);
        //        if (!intersectionRectangle.IsEmpty)
        //        {
        //            LinkProjectileCollision.HandleCollision(Level.Link, projectile);
        //        }
        //    }
        //}

        private void CheckLinkDoorCollision(Rectangle linkRectangle)
        {
            foreach (IDoor door in Level.Doors)
            {
                Rectangle doorRectangle = door.GetRectangle();
                Rectangle intersectionRectangle = Rectangle.Intersect(doorRectangle, linkRectangle);
                if (!intersectionRectangle.IsEmpty)
                {
                    //Direction direction = GetCollisionDirection(intersectionRectangle, linkRectangle, doorRectangle);
                    Direction direction = gameState.GameClass.Link.linkphysicalProperty.direction;
                    bool linkInsideOpenDoor = intersectionRectangle == linkRectangle;
                    LinkDoorCollision.HandleCollision(gameState.GameClass.Link, door, direction,linkInsideOpenDoor);
                    if (linkInsideOpenDoor)
                        LinkDoorCollision.ChangeTheRoom(direction, gameState, door.ConnectedRoom);

                }
            }
        }

        private void CheckLinkStairCollision(Rectangle linkRectangle)
        {
            foreach (IStair stair in Level.Stairs)
            {
                Rectangle stairRectangle = stair.GetRectangle();
                Rectangle intersectionRectangle = Rectangle.Intersect(stairRectangle, linkRectangle);
                if (!intersectionRectangle.IsEmpty)
                {
                    Direction direction = stair.Destination;
                    LinkStairCollision.ChangeTheRoom(direction, gameState);
                    LinkStairCollision.HandleCollision(gameState.GameClass.Link, stair, direction);
                }
            }
        }

        private void CheckLinkBlockCollision(Rectangle linkRectangle)
        {
            foreach (IBlock block in Level.Blocks)
            {
                Rectangle blockRectangle = block.GetRectangle();
                Rectangle intersectionRectangle = Rectangle.Intersect(blockRectangle, linkRectangle);
                if (!intersectionRectangle.IsEmpty)
                {
                    Direction direction = GetCollisionDirection(intersectionRectangle, linkRectangle, blockRectangle);
                    LinkBlockCollision.HandleCollision(gameState.GameClass.Link, block, direction);
                }
            }
        }

        private void CheckEnemyBlockCollision()
        {
            foreach (IEnemy enemy in Level.Enemies)
            {
                Rectangle enemyRectangle = enemy.GetRectangle();

                foreach (IBlock block in Level.Blocks)
                {
                    Rectangle blockRectangle = block.GetRectangle(); ;
                    Rectangle intersectionBox = Rectangle.Intersect(blockRectangle, enemyRectangle);
                    if (!intersectionBox.IsEmpty)
                    {
                        Direction direction = GetCollisionDirection(intersectionBox, enemyRectangle, blockRectangle);
                        EnemyBlockCollision.HandleCollision(enemy, block, direction);
                    }

                }

            }
        }

        private void CheckEnemyWallCollision()
        {
            foreach (IEnemy enemy in Level.Enemies)
            {
                Rectangle enemyRectangle = enemy.GetRectangle();

                foreach (IWall wall in Level.Walls)
                {
                    Rectangle wallRectangle = wall.GetRectangle(); ;
                    Rectangle intersectionBox = Rectangle.Intersect(wallRectangle, enemyRectangle);
                    if (!intersectionBox.IsEmpty)
                    {
                        Direction direction = GetCollisionDirection(intersectionBox, enemyRectangle, wallRectangle);
                        EnemyWallCollision.HandleCollision(enemy, wall, direction);
                    }

                }

            }
        }

        private void CheckLinkWallCollision(Rectangle linkRectangle)
        {
            foreach (IWall wall in Level.Walls)
            {
                Rectangle wallRectangle = wall.GetRectangle();
                Rectangle intersectionRectangle = Rectangle.Intersect(wallRectangle, linkRectangle);
                if (!intersectionRectangle.IsEmpty)
                {
                    Direction direction = GetCollisionDirection(intersectionRectangle, linkRectangle, wallRectangle);
                    LinkWallCollision.HandleCollision(gameState.GameClass.Link, wall, direction);
                }
            }
        }

        private static Direction GetCollisionDirection(Rectangle intersectionRectangle, Rectangle linkRectangle, Rectangle gameObjectRectangle)
        {
            if (intersectionRectangle.Width >= intersectionRectangle.Height)
            {
                return linkRectangle.Top <= gameObjectRectangle.Top ? Direction.UP : Direction.DOWN;
            }
            else
            {
                return linkRectangle.Left <= gameObjectRectangle.Left ? Direction.LEFT : Direction.RIGHT;
            }

        }


    }
}
