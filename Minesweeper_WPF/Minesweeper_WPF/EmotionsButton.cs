using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;

namespace Minesweeper_WPF
{
    public enum EmotionType
    {
        Pressed,
        Win,
        Lose,
        PressDown,
        Common
    }

    class EmotionsButton : Button, INotifyPropertyChanged
    {
        private const int ImageSize = 24;

        public static readonly DependencyProperty EmotionTypeValueProperty;

        private static readonly BitmapSource EmotionsImageSource;

        public static readonly DependencyProperty ParentWindowProperty;

        private ImageSource imageSourceBefore;

        private ImageSource imageSource;

        public event PropertyChangedEventHandler PropertyChanged;



        static EmotionsButton()
        {
            //if (SharedUtils.InDesignMode())
            //{
            //    return;
            //}

            EmotionsImageSource = new BitmapImage(ImagesUri.EmotionsUri);
            ParentWindowProperty = DependencyProperty.Register(
                nameof(ParentWindow),
                typeof(Window),
                typeof(EmotionsButton),
                new PropertyMetadata(default(Window), (source, args) => { ((EmotionsButton)source).ParentChanged(); }));

            EmotionTypeValueProperty = DependencyProperty.Register(
                nameof(EmotionTypeValue),
                typeof(EmotionType),
                typeof(EmotionsButton),
                new PropertyMetadata(
                    default(EmotionType),
                    (source, args) => { ((EmotionsButton)source).EmotionTypeChanged(); }));
        }

        public EmotionsButton()
        {
            Template = CreateButtonTemplate();
        }

        public Window ParentWindow
        {
            get
            {
                return (Window)GetValue(ParentWindowProperty);
            }
            set
            {
                SetValue(ParentWindowProperty, value);
            }
        }

        public ImageSource ImageSource
        {
            get
            {
                return imageSource;
            }

            set
            {
                imageSource = value;
                OnPropertyChanged();
            }
        }

        private ControlTemplate CreateButtonTemplate()
        {
            var imageFactory = new FrameworkElementFactory(typeof(Image), "EmotionImage");
            imageFactory.SetBinding(
                Image.SourceProperty,
                new Binding(nameof(ImageSource))
                {
                    RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(EmotionsButton), 1)
                });

            var controlTemplate = new ControlTemplate { VisualTree = imageFactory };

            var pressedTrigger = new Trigger { Property = IsPressedProperty, Value = true };
            pressedTrigger.Setters.Add(new Setter()
            {
                TargetName = "EmotionImage",
                Property = Image.SourceProperty,
                Value = GetEmotionImageSource(EmotionType.Pressed)
            });

            controlTemplate.Triggers.Add(pressedTrigger);
            return controlTemplate;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void EmotionTypeChanged()
        {
            ImageSource = GetEmotionImageSource(EmotionTypeValue);
        }

        private void ParentChanged()
        {
            if (ParentWindow != null)
            {
                ParentWindow.PreviewMouseLeftButtonDown += (sender, args) => MousePressed();
                ParentWindow.PreviewMouseLeftButtonUp += (sender, args) => MouseReleased();
                ParentWindow.Deactivated += (sender, args) => MouseReleased();
                ParentWindow.MouseLeave += (sender, args) => MouseReleased();
            }
        }

        private static ImageSource GetEmotionImageSource(EmotionType emotionTypeValue)
        {
            int offset = (int)emotionTypeValue;
            return new CroppedBitmap(EmotionsImageSource, new Int32Rect(0, offset * ImageSize, ImageSize, ImageSize));
        }

        private void MousePressed()
        {
            if (!IsFinilizedState)
            {
                imageSourceBefore = ImageSource;
                ImageSource = GetEmotionImageSource(EmotionType.PressDown);
            }
        }

        private void MouseReleased()
        {
            if (imageSourceBefore != null && !IsFinilizedState)
            {
                ImageSource = imageSourceBefore;
            }
        }

        private bool IsFinilizedState
        {
            get
            {
                return EmotionTypeValue == EmotionType.Lose || EmotionTypeValue == EmotionType.Win;
            }
        }

        public EmotionType EmotionTypeValue
        {
            get
            {
                return (EmotionType)GetValue(EmotionTypeValueProperty);
            }
            set
            {
                SetValue(EmotionTypeValueProperty, value);
            }
        }
    }
}
