using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public class LinkInventoryProperty
    {
        private IPlayer link;
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int RupeeCount { get; set; }
        public int KeyCount { get; set; }
        public int BombCount { get; set; }
        public bool MapPicked { get; set; }
        public bool CompassPicked { get; set; }
        public bool BowPicked { get; set; }
        public bool BoomerangPicked { get; set; }
        public bool SwordPicked { get; set; }
        public bool HeartContainerPicked { get; set; }
        public bool TriforcePicked { get; set; }
        public int Score { get; set; }

        public LinkInventoryProperty(IPlayer link)
        {
            this.link = link;
            this.Health = 6;
            this.MaxHealth = 6;
            this.RupeeCount = 0;
            this.KeyCount = 0;
            this.BombCount = 0;
            this.MapPicked = false;
            this.CompassPicked = false;
            this.BowPicked = false;
            this.BoomerangPicked = false;
            this.SwordPicked = true;
            this.HeartContainerPicked = false;
            this.TriforcePicked = false;
            this.Score = 0;
        }

        public void OneHpMode()
        {
            this.MaxHealth = 1;
            this.Health = 1;
        }

        public void PickUpItem(String itemName)
        {
            switch (itemName)
            {
                case "bomb":
                    this.BombCount++;
                    break;
                case "key":
                    this.KeyCount++;
                    break;
                case "yellowRupy":
                    this.RupeeCount++;
                    break;
                case "blueRupy":
                    this.RupeeCount += 5;
                    break;
                case "fairy":
                    this.Health = this.MaxHealth;
                    break;
                case "heart":
                    if(this.Health < this.MaxHealth)
                        this.Health++;
                    break;
                case "compass":
                    this.CompassPicked = true;
                    break;
                case "map":
                    this.MapPicked = true;
                    break;
                case "bow":
                    this.BowPicked = true;
                    break;
                case "boomerang":
                    this.BoomerangPicked = true;
                    break;
                case "sword":
                    this.SwordPicked = true;
                    break;
                case "heartContainer":
                    if (!link.OneHpMode&&!this.HeartContainerPicked)
                    {
                        this.HeartContainerPicked = true;
                        this.MaxHealth += 2;
                    }
                    break;
                case "triforce":
                    this.TriforcePicked = true;
                    break;
                default:
                    break;
            }
        }

    }
}
