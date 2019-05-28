using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Minesweeper_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int mines;
        private int columns;
        private int rows;
        Game game;

        public MainWindow()
        {
            InitializeComponent();
            mines = 10;
            columns = 10;
            rows = 10;
            emotionsBtn.Click += (sender, e) => { Engage(); };
            Engage();
        }

        

        private void Engage()
        {
            emotionsBtn.EmotionTypeValue = EmotionType.Common;
            game = new Game(mineField, minesCounter, timer);
            game.DismantledMinesChanged += (sender, e) => { minesCounter.Number = mineField.Mines - game.DismantledMines; };
            game.Defeat += (sender, e) => { emotionsBtn.EmotionTypeValue = EmotionType.Lose; Sounds.PlayOnDefeat(); };
            game.Victory += (sender, e) => { emotionsBtn.EmotionTypeValue = EmotionType.Win; Sounds.PlayOnVictory(); };
            game.ChangeEmotion += (sender, e) => { emotionsBtn.EmotionTypeValue = EmotionType.PressDown; };
            game.RestoreEmotion += (sender, e) => { emotionsBtn.EmotionTypeValue = EmotionType.Common; };
            game.Start(columns,rows,mines);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            MenuItem menuItem = (MenuItem)e.OriginalSource;
            
            switch(menuItem.Header.ToString())
            {
                case "New":
                    Engage();
                    break;

                case "Beginner":
                    mines = 10;
                    columns = 10;
                    rows = 10;
                    break;

                case "Intermediate":
                    mines = 40;
                    columns = 20;
                    rows = 20;
                    this.Height = 480;
                    this.Width = 400;
                    Engage();
                    break;

                case "Expert":
                    mines = 80;
                    columns = 40;
                    rows = 30;
                    this.Height = 780;
                    this.Width = 800;
                    Engage();
                    break;

                case "Exit":
                    this.Close();
                    break;
            }
        }
    }
}
