//using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Minesweeper_WPF
{
    static class Images
    {
        public static ImageBrush Mine { get; private set; }
        public static ImageBrush MineExploded { get; private set; }
        public static ImageBrush Flag { get; private set; }
        public static ImageBrush MineCrossed { get; private set; }
        public static ImageBrush SmileyOriginal { get; private set; }
        public static ImageBrush SmileyScared { get; private set; }
        public static ImageBrush SmileyDead { get; private set; }
        public static ImageBrush SmileyCool { get; private set; }

        static Images()
        {
            Mine = new ImageBrush(new BitmapImage(new System.Uri(@"\\msk.mts.ru\ug\User\Folders\06\00\avtimche\Desktop\Minesweeper_WPF\Minesweeper_WPF\Minesweeper_WPF\Images\Mine.png"))/*Properties.Resources.Mine, new Size(15, 15)*/);
            MineExploded = new ImageBrush(new BitmapImage(new System.Uri(@"\\msk.mts.ru\ug\User\Folders\06\00\avtimche\Desktop\Minesweeper_WPF\Minesweeper_WPF\Minesweeper_WPF\Images\MineExploded.jpg")));
            Flag = new ImageBrush(new BitmapImage(new System.Uri(@"\\msk.mts.ru\ug\User\Folders\06\00\avtimche\Desktop\Minesweeper_WPF\Minesweeper_WPF\Minesweeper_WPF\Images\Flag.png")));
            MineCrossed = new ImageBrush(new BitmapImage(new System.Uri(@"\\msk.mts.ru\ug\User\Folders\06\00\avtimche\Desktop\Minesweeper_WPF\Minesweeper_WPF\Minesweeper_WPF\Images\MineCrossed.png")));
            SmileyOriginal = new ImageBrush(new BitmapImage(new System.Uri(@"\\msk.mts.ru\ug\User\Folders\06\00\avtimche\Desktop\Minesweeper_WPF\Minesweeper_WPF\Minesweeper_WPF\Images\Smiley_original.png")));
            SmileyScared = new ImageBrush(new BitmapImage(new System.Uri(@"\\msk.mts.ru\ug\User\Folders\06\00\avtimche\Desktop\Minesweeper_WPF\Minesweeper_WPF\Minesweeper_WPF\Images\Smiley_original.png")));
            SmileyDead = new ImageBrush(new BitmapImage(new System.Uri(@"\\msk.mts.ru\ug\User\Folders\06\00\avtimche\Desktop\Minesweeper_WPF\Minesweeper_WPF\Minesweeper_WPF\Images\Smiley_dead.png")));
            SmileyCool = new ImageBrush(new BitmapImage(new System.Uri(@"\\msk.mts.ru\ug\User\Folders\06\00\avtimche\Desktop\Minesweeper_WPF\Minesweeper_WPF\Minesweeper_WPF\Images\Smiley_cool.png")));

        }


    }
}
