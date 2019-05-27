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
        

        public MainWindow()
        {
            InitializeComponent();
            Start();

        }

        private void emotionsBtn_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void Start()
        {
            emotionsBtn.EmotionTypeValue = EmotionType.Common;
            Game game = new Game(mineField, mines, timer);
            game.Start(10, 10, 10);
            emotionsBtn.Click += new RoutedEventHandler(emotionsBtn_Click);
            game.DismantledMinesChanged += (sender, e) => { mines.Number = mineField.Mines - game.DismantledMines; };
            game.Defeat += (sender, e) => { emotionsBtn.EmotionTypeValue = EmotionType.Lose; };
        }
    }
}
