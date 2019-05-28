using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

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
