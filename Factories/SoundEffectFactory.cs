using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public class SoundEffectFactory
    {
        /* Sword slash */
        private SoundEffect swordSlash;
        /* Sword shooting magic */
        private SoundEffect swordShoot;
        /* Both sword sounds combined */
        private SoundEffect swordCombined;
        /* Shield deflecting an object */
        private SoundEffect shield;
        /* Shooting an arrow / Boomerang flying */
        private SoundEffect arrowBoomerang;
        /* Dropping a bomb */
        private SoundEffect bombDrop;
        /* Bomb exploding */
        private SoundEffect bombBlow;
        /* Playing the Recorder */
        private SoundEffect recorder;
        /* An enemy getting hit */
        private SoundEffect enemyHit;
        /* An enemy dying */
        private SoundEffect enemyDie;
        /* Link getting hurt */
        private SoundEffect linkHurt;
        /* Link dying */
        private SoundEffect linkDie;
        /* Low health beep */
        private SoundEffect lowHealth;
        /* "New Item" fanfare */
        private SoundEffect fanfare;
        /* Get an inventory item (or fairy) */
        private SoundEffect getItem;
        /* Get a heart (or key) */
        private SoundEffect getHeart;
        /* Get a rupee */
        private SoundEffect getRupee;
        /* Loopable portion of health refilling or rupee count changing */
        private SoundEffect refillLoop;
        /* Text appearing */
        private SoundEffect text;
        /* A key appearing */
        private SoundEffect keyAppear;
        /* A dungeon door unlocking */
        private SoundEffect doorUnlock;
        /* Dungeon boss screaming */
        private SoundEffect bossScream;
        /* Dungeon boss getting hurt */
        private SoundEffect bossHurt;
        /* Found a secret / Correct solution / Puzzle solved */
        private SoundEffect secret;

        private static SoundEffectFactory instance;

        public static SoundEffectFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SoundEffectFactory();
                }
                return instance;
            }
        }

        private SoundEffectFactory()
        {
        }

        public void LoadAllContents(ContentManager content)
        {
            swordSlash = content.Load<SoundEffect>("SoundEffects/SwordSlash");
            swordShoot = content.Load<SoundEffect>("SoundEffects/SwordShoot");
            swordCombined = content.Load<SoundEffect>("SoundEffects/SwordCombined");
            shield = content.Load<SoundEffect>("SoundEffects/Shield");
            arrowBoomerang = content.Load<SoundEffect>("SoundEffects/ArrowBoomerang");
            bombDrop = content.Load<SoundEffect>("SoundEffects/BombDrop");
            bombBlow = content.Load<SoundEffect>("SoundEffects/BombBlow");
            recorder = content.Load<SoundEffect>("SoundEffects/Recorder");
            enemyHit = content.Load<SoundEffect>("SoundEffects/EnemyHit");
            enemyDie = content.Load<SoundEffect>("SoundEffects/EnemyDie");
            linkHurt = content.Load<SoundEffect>("SoundEffects/LinkHurt");
            linkDie = content.Load<SoundEffect>("SoundEffects/LinkDie");
            lowHealth = content.Load<SoundEffect>("SoundEffects/LowHealth");
            fanfare = content.Load<SoundEffect>("SoundEffects/Fanfare");
            getItem = content.Load<SoundEffect>("SoundEffects/GetItem");
            getHeart = content.Load<SoundEffect>("SoundEffects/GetHeart");
            getRupee = content.Load<SoundEffect>("SoundEffects/GetRupee");
            refillLoop = content.Load<SoundEffect>("SoundEffects/RefillLoop");
            text = content.Load<SoundEffect>("SoundEffects/Text");
            keyAppear = content.Load<SoundEffect>("SoundEffects/KeyAppear");
            doorUnlock = content.Load<SoundEffect>("SoundEffects/DoorUnlock");
            bossScream = content.Load<SoundEffect>("SoundEffects/BossScream");
            bossHurt = content.Load<SoundEffect>("SoundEffects/BossHurt");
            secret = content.Load<SoundEffect>("SoundEffects/Secret");
        }

        public void PlaySwordSlashSoundEffect()
        {
            swordSlash.Play();
        }

        public void PlaySwordShootSoundEffect()
        {
            swordShoot.Play();
        }

        public void PlaySwordCombinedSoundEffect()
        {
            swordCombined.Play();
        }

        public void PlayShieldSoundEffect()
        {
            shield.Play();
        }

        public void PlayArrowBoomerangSoundEffect()
        {
            arrowBoomerang.Play();
        }

        public void PlayBombDropSoundEffect()
        {
            bombDrop.Play();
        }

        public void PlayBombBlowSoundEffect()
        {
            bombBlow.Play();
        }

        public void PlayRecorderSoundEffect()
        {
            recorder.Play();
        }

        public void PlayEnemyHitSoundEffect()
        {
            enemyHit.Play();
        }

        public void PlayEnemyDieSoundEffect()
        {
            enemyDie.Play();
        }

        public void PlayLinkHurtSoundEffect()
        {
            linkHurt.Play();
        }

        public void PlayLinkDieSoundEffect()
        {
            linkDie.Play();
        }

        public void PlayLowHealthSoundEffect()
        {
            lowHealth.Play();
        }

        public void PlayFanfareSoundEffect()
        {
            fanfare.Play();
        }

        public void PlayGetItemSoundEffect()
        {
            getItem.Play();
        }

        public void PlayGetHeartSoundEffect()
        {
            getHeart.Play();
        }

        public void PlayGetRupeeSoundEffect()
        {
            getRupee.Play();
        }

        public void PlayRefillLoopSoundEffect()
        {
            refillLoop.Play();
        }

        public void PlayTextSoundEffect()
        {
            text.Play();
        }

        public void PlayKeyAppearSoundEffect()
        {
            keyAppear.Play();
        }

        public void PlayDoorUnlockSoundEffect()
        {
            doorUnlock.Play();
        }

        public void PlayBossScreamSoundEffect()
        {
            bossScream.Play();
        }

        public void PlayBossHurtSoundEffect()
        {
            bossHurt.Play();
        }

        public void PlaySecretSoundEffect()
        {
            secret.Play();
        }
    }
}
