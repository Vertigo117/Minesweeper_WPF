using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Minesweeper_WPF
{
    public enum CellType
    {
        /// <summary>
        /// Simple button.
        /// </summary>
        Button = 0,

        /// <summary>
        /// Flagged cell.
        /// </summary>
        Flagged = 1,

        /// <summary>
        /// Pressed cell exploded.
        /// </summary>
        BombExplode = 3,

        /// <summary>
        /// Wrong flagged cell.
        /// </summary>
        NoBomb = 4,

        /// <summary>
        /// Bomb cell.
        /// </summary>
        Bomb = 5,

        /// <summary>
        /// 8 bombs around.
        /// </summary>
        Near8 = 7,

        /// <summary>
        /// 7 bombs around.
        /// </summary>
        Near7 = 8,

        /// <summary>
        /// 6 bombs around.
        /// </summary>
        Near6 = 9,

        /// <summary>
        /// 5 bombs around.
        /// </summary>
        Near5 = 10,

        /// <summary>
        /// 4 bombs around.
        /// </summary>
        Near4 = 11,

        /// <summary>
        /// 3 bombs around.
        /// </summary>
        Near3 = 12,

        /// <summary>
        /// 2 bombs around.
        /// </summary>
        Near2 = 13,

        /// <summary>
        /// 1 bombs around.
        /// </summary>
        Near1 = 14,

        /// <summary>
        /// Empty opened cell.
        /// </summary>
        Empty = 15
    }

    class MineField_Button : ContentControl
    {
        private const int ButtonImageOffsetStep = 16;

        private static readonly BitmapSource ButtonTypesImageSource;

        public static readonly DependencyProperty CurrentCellTypeProperty =
            DependencyProperty.Register(
                nameof(CurrentCellType),
                typeof(CellType),
                typeof(MineField_Button),
                new PropertyMetadata(CellType.Button, CellTypeChanged));

        public void SetType(CellType cellType)
        {
            if (CurrentCellType == cellType)
            {
                return;
            }

            CurrentCellType = cellType;
        }

        public CellType CurrentCellType
        {
            get
            {
                return (CellType)GetValue(CurrentCellTypeProperty);
            }

            private set
            {
                SetValue(CurrentCellTypeProperty, value);
            }
        }

        public MineField_Button()
        {
            DataContext = this;
        }

        static MineField_Button()
        {
            //if (ImagesUri.InDesignMode())
            //{
            //    return;
            //}

            ButtonTypesImageSource =
                new BitmapImage(ImagesUri.ButtonTypeUri);
        }

        private static void CellTypeChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (args.OldValue != args.NewValue)
            {
                ((MineField_Button)dependencyObject).UpdateButtonImage();
            }
        }

        private void UpdateButtonImage()
        {
            Content = GetCroppedBitmap(CurrentCellType);
        }

        private static Image GetCroppedBitmap(CellType cellType)
        {
            int offset = (int)cellType;
            var bitmap = new CroppedBitmap(
                ButtonTypesImageSource,
                new Int32Rect(0, offset * ButtonImageOffsetStep, ButtonImageOffsetStep, ButtonImageOffsetStep));

            return new Image { Source = bitmap };
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            UpdateButtonImage();
        }
    }
}
