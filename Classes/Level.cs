using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public class Level : ILevel
    {
        public IRoom Room { get; set; }
        public List<IEnemy> Enemies { get; set; }
        public List<IItem> Items { get; set; }
        public List<IBlock> Blocks { get; set; }
        public List<IWater> Water { get; set; }
        public List<IDoor> Doors { get; set; }
        public List<IWall> Walls { get; set; }
        public List<ICharacter> Characters { get; set; }
        public List<IProjectile> Projectiles { get; set; }
        public List<IStair> Stairs { get; set; }
        public bool IsMapUsed { get; set; }
        private IHUD dungeonHUD;
        private bool unlimited;
        private bool createdHeart;
        private IPlayer link;
        public Game1 game;

        public Level(Game1 game)
        {
            Room = null;
            Enemies = new List<IEnemy>();
            Items = new List<IItem>();
            Blocks = new List<IBlock>();
            Water = new List<IWater>();
            Doors = new List<IDoor>();
            Walls = new List<IWall>();
            Characters = new List<ICharacter>();
            Projectiles = new List<IProjectile>();
            Stairs = new List<IStair>();
            IsMapUsed = false;
            dungeonHUD = game.DungeonHUD;
            unlimited = game.gameStateManager.Unlimited;
            link = game.Link;
            createdHeart = false;
            this.game = game;
        }

        public void Update(GameTime gameTime)
        {
            Room.Update();
            foreach (IEnemy enemy in Enemies)
                enemy.Update(gameTime);
            foreach (IItem item in Items)
                item.Update();
            foreach (IBlock block in Blocks)
                block.Update();
            foreach (IWater water in Water)
                water.Update();
            foreach (IDoor door in Doors)
                door.Update();
            foreach (IWall wall in Walls)
                wall.Update();
            foreach (ICharacter character in Characters)
                character.Update();
            foreach (IProjectile projectile in Projectiles)
                projectile.Update(gameTime);
            foreach (IStair stair in Stairs)
                stair.Update();

            foreach (IItem item in Items.Where(pickedItem => pickedItem.Picked == true).ToList())
                Items.Remove(item);
            foreach (IProjectile projectile in Projectiles.Where(usedProjectile => usedProjectile.IsDisappeared == true).ToList())
                Projectiles.Remove(projectile);
            foreach (IEnemy enemy in Enemies.Where(deadEnemy => deadEnemy.IsDisappeared == true).ToList())
            {
                Enemies.Remove(enemy);
                if (unlimited)
                {
                    link.Inventory.Score += 5;
                    CreateNewEnemy(enemy.Name, Enemies);
                }

            }
            if (Enemies.Count == 0)
            {
                if (!unlimited && !createdHeart)
                    createdHeart = CreateHeart(Items);
                    
                foreach (IDoor door in Doors)
                    if (door.DoorState == DoorState.CLOSED)
                    {
                        door.Open();
                        door.Update();
                    }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            Room.Draw(spriteBatch);
            foreach (IEnemy enemy in Enemies)
                enemy.Draw(spriteBatch);
            foreach (IItem item in Items)
                item.Draw(spriteBatch);
            foreach (IBlock block in Blocks)
                block.Draw(spriteBatch);
            foreach (IWater water in Water)
                water.Draw(spriteBatch);
            foreach (IDoor door in Doors)
                door.Draw(spriteBatch);
            foreach (IWall wall in Walls)
                wall.Draw(spriteBatch);
            foreach (ICharacter character in Characters)
                character.Draw(spriteBatch);
            foreach (IProjectile projectile in Projectiles)
                projectile.Draw(spriteBatch);
            foreach (IStair stair in Stairs)
                stair.Draw(spriteBatch);
            if (IsMapUsed)
            {
                ItemSpriteFactory.Instance.CreateDetailedMapSprite().Draw(spriteBatch, new Vector2(0, 120));
            }
        }

        private bool CreateHeart(List<IItem> Items)
        {
            Items.Add(new Heart(300, 440));
            return true;
        }

        private void CreateNewEnemy(String Name, List<IEnemy> Enemies)
        {
            Random ran = new Random();
            int xPos = ran.Next(80, 440);
            int yPos = ran.Next(200, 440);
            switch (Name)
            {
                case "Aquamentus":
                    Enemies.Add(new Aquamentus(xPos, yPos,game.Level));
                    break;
                case "Gel":
                    Enemies.Add(new Gel(xPos, yPos));
                    break;
                case "Goriya":
                    Enemies.Add(new Goriya(xPos, yPos));
                    break;
                case "Keese":
                    Enemies.Add(new Keese(xPos, yPos));
                    break;
                case "Stalfos":
                    Enemies.Add(new Stalfos(xPos, yPos));
                    break;
                case "Wallmaster":
                    Enemies.Add(new Wallmaster(xPos, yPos));
                    break;
                default:
                    break;
            }
        }
    }
}
