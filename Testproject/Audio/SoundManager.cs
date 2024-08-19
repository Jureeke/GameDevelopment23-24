using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testproject.Audio
{
    public class SoundManager
    {
        private ContentManager content;
        private Song backgroundMusic;

        public SoundManager(ContentManager content)
        {
            this.content = content;
        }

        public void PlayBackgroundMusic(string songName, bool isRepeating = true, float volume = 0.1f)
        {
            backgroundMusic = content.Load<Song>(songName);
            MediaPlayer.IsRepeating = isRepeating;
            MediaPlayer.Volume = volume;
            MediaPlayer.Play(backgroundMusic);
        }

        public void StopBackgroundMusic()
        {
            MediaPlayer.Stop();
        }

        public void PauseBackgroundMusic()
        {
            MediaPlayer.Pause();
        }

        public void ResumeBackgroundMusic()
        {
            MediaPlayer.Resume();
        }

        public void SetVolume(float volume)
        {
            MediaPlayer.Volume = volume;
        }

        public bool IsPlaying()
        {
            return MediaPlayer.State == MediaState.Playing;
        }
    }
}
