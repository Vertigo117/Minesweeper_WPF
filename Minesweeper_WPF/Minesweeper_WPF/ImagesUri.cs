using System;

namespace Minesweeper_WPF
{
    static class ImagesUri
    {
        public static readonly Uri NumbersUri = new Uri("pack://application:,,,/Minesweeper_WPF;component/Images/Numbers.bmp", UriKind.RelativeOrAbsolute);

        public static readonly Uri EmotionsUri = new Uri("pack://application:,,,/Minesweeper_WPF;component/Images/Emotions.bmp", UriKind.RelativeOrAbsolute);

        public static readonly Uri ButtonTypeUri = new Uri("pack://application:,,,/Minesweeper_WPF;component/Images/ButtonTypes.bmp", UriKind.RelativeOrAbsolute);
    }
}
