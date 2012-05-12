using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;


namespace TOJam
{
    class SoundManager
    {
        private static SoundEffect click;
        private static SoundEffect survivorDeath;
        private static Song dayOverture;
        private static Song nightOverture;
        private static SoundEffect gunFire;

        private static SoundEffect zombieSound;
        private static SoundEffect zombieDeath;
        private static SoundEffect shuffling;
        private static SoundEffect scavenging;

        private static float sfxVolume;

        public static void initializeSounds(ContentManager Content)
        {
            click = Content.Load<SoundEffect>("Audio//clickSound");
            survivorDeath = Content.Load<SoundEffect>("Audio//survivorDeathSound");
            dayOverture = Content.Load<Song>("Audio//dayOverture");
            nightOverture = Content.Load<Song>("Audio//nightOverture");
            gunFire = Content.Load<SoundEffect>("Audio//gunFire");

            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.2f;
            sfxVolume = 0.2f;
        
        }

        public static void playDayMusic()
        {
            MediaPlayer.Stop();
            MediaPlayer.Play(dayOverture);
        }

        public static void stopMusic()
        {
            MediaPlayer.Pause();
        }
        public static void playNightMusic()
        {
            MediaPlayer.Stop();
            MediaPlayer.Play(nightOverture);
        }

        public static void volumeDown()
        {
            MediaPlayer.Volume -= 0.1f;
            sfxVolume = Math.Min(1, MediaPlayer.Volume + 0.1f);
        }

        public static void volumeUp()
        {
            MediaPlayer.Volume += 0.1f;
            sfxVolume = Math.Min(1, MediaPlayer.Volume + 0.1f);
        }

        public static void playClick()
        {
            click.Play(sfxVolume, 0f, 0f);
        }

        public static void playSurvivorDeathSound()
        {
            survivorDeath.Play(sfxVolume, 0f, 0f);
        }
        public static void playZombieSound()
        {
            zombieSound.Play(sfxVolume, 0, 0);
        }
        public static void playZombieDeath()
        {
            zombieDeath.Play(sfxVolume, 0, 0);
        }
        public static void playGunFire()
        {
            gunFire.Play(sfxVolume, 0, 0);
        }
        public static void playScavenge()
        {
            scavenging.Play(sfxVolume, 0, 0);
        }
        public static void playShuffling()
        {
            shuffling.Play(sfxVolume, 0, 0);
        }
    }
}
