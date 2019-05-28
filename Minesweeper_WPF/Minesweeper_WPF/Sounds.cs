using System.Media;

namespace Minesweeper_WPF
{
    static class Sounds
    {
        
       
       

        public static void PlayOnVictory()
        {
            SoundPlayer soundPlayer = new SoundPlayer();
            soundPlayer.SoundLocation = "Sounds/skyrim.wav";
            soundPlayer.Load();
            soundPlayer.Play();
        }

        public static void PlayOnDefeat()
        {
            SoundPlayer soundPlayer = new SoundPlayer();
            soundPlayer.SoundLocation = "Sounds/darkSouls.wav";
            soundPlayer.Load();
            soundPlayer.Play();
        }
    }
}
