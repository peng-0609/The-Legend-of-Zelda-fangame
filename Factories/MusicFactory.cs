using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public class MusicFactory
    {
        private Song dungeonTheme;
        private Song endingTheme;
        private Song menuTheme;
        private Song overworldTheme;
        private Song titleTheme;

        private static MusicFactory instance;

        public static MusicFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MusicFactory();
                }
                return instance;
            }
        }

        private MusicFactory()
        {
        }

        public void LoadAllContents(ContentManager content)
        {
            dungeonTheme = content.Load<Song>("Music/DungeonTheme");
            endingTheme = content.Load<Song>("Music/EndingTheme");
            menuTheme = content.Load<Song>("Music/MenuTheme");
            overworldTheme = content.Load<Song>("Music/OverworldTheme");
            titleTheme = content.Load<Song>("Music/TitleTheme");
        }

        public void PlayDungeonTheme()
        {
            MediaPlayer.Play(dungeonTheme);
            MediaPlayer.IsRepeating = true;
        }

        public void PlayEndingTheme()
        {
            MediaPlayer.Play(endingTheme);
            MediaPlayer.IsRepeating = true;
        }

        public void PlayMenuTheme()
        {
            MediaPlayer.Play(menuTheme);
            MediaPlayer.IsRepeating = true;
        }

        public void PlayOverworldTheme()
        {
            MediaPlayer.Play(overworldTheme);
            MediaPlayer.IsRepeating = true;
        }

        public void PlayTitleTheme()
        {
            MediaPlayer.Play(titleTheme);
            MediaPlayer.IsRepeating = true;
        }

        public void Pause()
        {
            MediaPlayer.Pause();
        }

        public void Resume() => MediaPlayer.Resume();
    }
}
