using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Sprint2
{
    public class LevelLoaderFactory
    {
        private static LevelLoaderFactory instance;

        public static LevelLoaderFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LevelLoaderFactory();
                }
                return instance;
            }
        }

        private LevelLoaderFactory()
        {

        }

        public ILevel LoadContents(Game1 game, string xml, int roomNum)
        {
            ILevel level = new Level(game);
            XmlReader reader = XmlReader.Create(xml);
            reader.MoveToContent();
            while (reader.Read())
            {
                if (!reader.IsStartElement())
                    continue;
                if (reader.LocalName == "room" && int.Parse(reader.GetAttribute("id")) == roomNum)
                {
                    level.Room = new Room(roomNum);
                    XmlReader inner = reader.ReadSubtree();
                    inner.MoveToContent();
                    while (inner.Read())
                    {
                        if (!inner.IsStartElement())
                            continue;
                        string name = inner.Name;
                        string type = inner.GetAttribute("Type");
                        int xPos = int.Parse(inner.GetAttribute("X"));
                        int yPos = int.Parse(inner.GetAttribute("Y"));
                        int width = 0;
                        int height = 0;
                        if (inner.GetAttribute("Width") != null)
                        {
                            width = int.Parse(inner.GetAttribute("Width"));
                        }
                        if (inner.GetAttribute("Height") != null)
                        {
                            height = int.Parse(reader.GetAttribute("Height"));
                        }
                        CreateGameObjects(level, name, type, xPos, yPos, width, height);

                    }
                    inner.Close();
                }
            }
            return level;
        }

        private static void CreateGameObjects(ILevel level, string name, string type, int xPos, int yPos, int width, int height)
        {
            switch (name)
            {
                case "Enemy":
                    CreateEnemy(level, type, xPos, yPos);
                    break;
                case "Item":
                    CreateItem(level, type, xPos, yPos);
                    break;
                case "Artifact":
                    CreateArtifact(level, type, xPos, yPos, width, height);
                    break;
                case "Character":
                    CreateCharacter(level, type, xPos, yPos);
                    break;
                case "Projectile":
                    CreateProjectile(level, type, xPos, yPos);
                    break;
                default:
                    break;
            }
        }

        private static void CreateEnemy(ILevel level, string type, int xPos, int yPos)
        {
            switch (type)
            {
                case "Aquamentus":
                    level.Enemies.Add(new Aquamentus(xPos, yPos,level));
                    break;
                case "Gel":
                    level.Enemies.Add(new Gel(xPos, yPos));
                    break;
                case "Goriya":
                    level.Enemies.Add(new Goriya(xPos, yPos));
                    break;
                case "Keese":
                    level.Enemies.Add(new Keese(xPos, yPos));
                    break;
                case "Stalfos":
                    level.Enemies.Add(new Stalfos(xPos, yPos));
                    break;
                case "Trap":
                    level.Enemies.Add(new Trap(xPos, yPos));
                    break;
                case "Wallmaster":
                    level.Enemies.Add(new Wallmaster(xPos, yPos));
                    break;
                default:
                    break;
            }
        }

        private static void CreateItem(ILevel level, string type, int xPos, int yPos)
        {
            switch (type)
            {
                case "BlueRupy":
                    level.Items.Add(new BlueRupy(xPos, yPos));
                    break;
                case "Bow":
                    level.Items.Add(new Bow(xPos, yPos));
                    break;
                case "Clock":
                    level.Items.Add(new Clock(xPos, yPos));
                    break;
                case "Compass":
                    level.Items.Add(new Compass(xPos, yPos));
                    break;
                case "Fairy":
                    level.Items.Add(new Fairy(xPos, yPos));
                    break;
                case "Heart":
                    level.Items.Add(new Heart(xPos, yPos));
                    break;
                case "HeartContainer":
                    level.Items.Add(new HeartContainer(xPos, yPos));
                    break;
                case "Key":
                    level.Items.Add(new Key(xPos, yPos));
                    break;
                case "Map":
                    level.Items.Add(new Map(xPos, yPos));
                    break;
                case "Sword":
                    level.Items.Add(new Sword(xPos, yPos));
                    break;
                case "Triforce":
                    level.Items.Add(new Triforce(xPos, yPos));
                    break;
                case "YellowRupy":
                    level.Items.Add(new YellowRupy(xPos, yPos));
                    break;
                case "BombItem":
                    level.Items.Add(new BombItem(xPos, yPos));
                    break;
                case "BoomerangItem":
                    level.Items.Add(new BoomerangItem(xPos, yPos));
                    break;
                default:
                    break;
            }
        }

        private static void CreateArtifact(ILevel level, string type, int xPos, int yPos, int width, int height)
        {
            switch (type)
            {
                case "MovableBlock":
                    level.Blocks.Add(new MovableBlock(xPos, yPos));
                    break;
                case "UnmovableBlock":
                    level.Walls.Add(new UnmovableBlock(xPos, yPos, width, height));
                    break;
                case "Water":
                    level.Water.Add(new Water(xPos, yPos));
                    break;
                case "Door":
                    level.Doors.Add(new Door(xPos, yPos, width/10, width%10, height));
                    break;
                case "Stair":
                    level.Stairs.Add(new Stair(xPos, yPos, width));
                    break;
                default:
                    break;
            }
        }

        private static void CreateCharacter(ILevel level, string type, int xPos, int yPos)
        {
            switch (type)
            {
                case "Oldman":
                    level.Characters.Add(new Oldman(xPos, yPos));
                    break;
                default:
                    break;
            }
        }

        private static void CreateProjectile(ILevel level, string type, int xPos, int yPos)
        {
            switch (type)
            {
                case "Bomb":
                    level.Projectiles.Add(new Bomb(xPos, yPos));
                    break;
                default:
                    break;
            }
        }
    }
}
