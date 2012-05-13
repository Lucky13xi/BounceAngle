using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;


namespace BounceAngle
{
    class SoundManager
    {
        private  SoundEffect click;
        private  SoundEffect survivorDeath;
        private  Song dayOverture;
        private  Song nightOverture;
        private  SoundEffect gunFire;
        private  SoundEffect zombieSound;
        private SoundEffect shuffling;

        private  SoundEffect zombieDeath;

        private  float sfxVolume;

        public  void initializeSounds(ContentManager Content)
        {
            click = Content.Load<SoundEffect>("Audio//clickSound");
            survivorDeath = Content.Load<SoundEffect>("Audio//survivorDeathSound");
            dayOverture = Content.Load<Song>("Audio//dayOverture");
            nightOverture = Content.Load<Song>("Audio//nightOverture");
            gunFire = Content.Load<SoundEffect>("Audio//gunFire");
            zombieSound = Content.Load<SoundEffect>("Audio//zombie");
            shuffling = Content.Load<SoundEffect>("Audio//shuffling");
            zombieDeath = Content.Load<SoundEffect>("Audio//zombieDeath");

            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.8f;
            sfxVolume = 0.8f;
        
        }

        public  void playDayMusic()
        {
            MediaPlayer.Stop();
            MediaPlayer.Play(dayOverture);
        }

        public  void stopMusic()
        {
            MediaPlayer.Pause();
        }
        public  void playNightMusic()
        {
            MediaPlayer.Stop();
            MediaPlayer.Play(nightOverture);
        }

        public  void volumeDown()
        {
            MediaPlayer.Volume -= 0.1f;
            sfxVolume = Math.Min(1, MediaPlayer.Volume + 0.1f);
        }

        public  void volumeUp()
        {
            MediaPlayer.Volume += 0.1f;
            sfxVolume = Math.Min(1, MediaPlayer.Volume + 0.1f);
        }

        public  void playClick()
        {
            click.Play(sfxVolume, 0f, 0f);
        }

        public  void playSurvivorDeathSound()
        {
            survivorDeath.Play(sfxVolume, 0f, 0f);
        }
        public  void playZombieSound()
        {
            zombieSound.Play(sfxVolume, 0, 0);
        }
        public  void playZombieDeath()
        {
            zombieDeath.Play(sfxVolume, 0, 0);
        }
        public  void playGunFire()
        {
            gunFire.Play(sfxVolume, 0, 0);
        }
        public  void playShuffling()
        {
            shuffling.Play(sfxVolume, 0, 0);
        }
    }
}
