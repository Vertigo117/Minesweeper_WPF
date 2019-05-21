using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
//using System.Drawing;
using System.Windows.Media;

namespace Minesweeper_WPF
{
    class GameButton
    {
        public event EventHandler Dismantle;
        public event EventHandler Explode;
        public Button Button { get; }
        public bool Opened { get; private set; }
        public bool Dismantled { get; private set; }
        Game game;
        public bool Mined { get; set; }
        public int X { get; }
        public int Y { get; }
        //private int height;
        //private int width;

        public GameButton(Game game, int x, int y)
        {
            this.game = game;
            X = x;
            Y = y;
            Button = new Button();
            Button.Click += new System.Windows.RoutedEventHandler(Click);
            Button.MouseDown += new System.Windows.Input.MouseButtonEventHandler(DismantleClick);

            Button.Background = Brushes.Gray;
            Button.BorderBrush = Brushes.Black;
            RowDefinition rowDefinition = new RowDefinition();
            ColumnDefinition columnDefinition = new ColumnDefinition();
            rowDefinition.Height = new System.Windows.GridLength(25);
            columnDefinition.Width = new System.Windows.GridLength(25);

            game.Grid.RowDefinitions.Add(rowDefinition);
            game.Grid.ColumnDefinitions.Add(columnDefinition);
            Grid.SetRow(Button, x);
            Grid.SetColumn(Button, y);
            game.Grid.Children.Add(Button);

        }

        private void OnDismantle()
        {
            if (Dismantle != null)
            {
                Dismantle(this, new EventArgs());
            }
        }

        protected void OnExplode()
        {


            if (Explode != null)
            {
                Explode(this, new EventArgs());
            }
        }

        public void Open()
        {
            if (!Opened && !Dismantled)
            {
                Button.Background = null;
                
                //Button.BorderBrush = Brushes.Transparent;
                //Button.Background = 
                //Button.BackColor = SystemColors.ControlLight;

                Opened = true;
                // Подсчёт бомб
                int c = 0;
                if (game.IsBomb(X - 1, Y - 1)) c++;
                if (game.IsBomb(X - 0, Y - 1)) c++;
                if (game.IsBomb(X + 1, Y - 1)) c++;
                if (game.IsBomb(X - 1, Y - 0)) c++;
                if (game.IsBomb(X - 0, Y - 0)) c++;
                if (game.IsBomb(X + 1, Y - 0)) c++;
                if (game.IsBomb(X - 1, Y + 1)) c++;
                if (game.IsBomb(X - 0, Y + 1)) c++;
                if (game.IsBomb(X + 1, Y + 1)) c++;

                if (c > 0)
                {

                    Button.Content = c.ToString();

                    switch (c)
                    {
                        case 1:
                            Button.Foreground = Brushes.Blue;
                            break;
                        case 2:
                            Button.Foreground = Brushes.Green;
                            break;
                        case 3:
                            Button.Foreground = Brushes.Red;
                            break;
                        case 4:
                            Button.Foreground = Brushes.DarkBlue;
                            break;
                        case 5:
                            Button.Foreground = Brushes.DarkRed;
                            break;
                        case 6:
                            Button.Foreground = Brushes.LightBlue;
                            break;
                        case 7:
                            Button.Foreground = Brushes.Orange;
                            break;
                        case 8:
                            Button.Foreground = Brushes.Ivory;
                            break;
                    }
                }
                else
                {

                    //Button.FlatStyle = FlatStyle.Flat;

                    Button.IsEnabled = false;

                    game.OpenSpot(X - 1, Y - 1);
                    game.OpenSpot(X - 0, Y - 1);
                    game.OpenSpot(X + 1, Y - 1);
                    game.OpenSpot(X - 1, Y - 0);
                    game.OpenSpot(X - 0, Y - 0);
                    game.OpenSpot(X + 1, Y - 0);
                    game.OpenSpot(X - 1, Y + 1);
                    game.OpenSpot(X - 0, Y + 1);
                    game.OpenSpot(X + 1, Y + 1);
                }
            }
            //game.Button.Image = Images.SmileyOriginal;
        }


        private void Click(object sender, EventArgs e)
        {


            if (!Dismantled)
            {
                if (Mined)
                {
                    Button.Background = null;
                    Button.BorderBrush = null;
                    //Button.FlatStyle = FlatStyle.Flat;
                    //Button.IsEnabled = false;

                    Button.Background = Images.MineExploded;
                    OnExplode();
                    //Button.Background = Brushes.Red;
                }
                else
                {
                    Open();
                }
            }
        }

        public void RemoveEvents()
        {
            Button.Click -= new System.Windows.RoutedEventHandler(Click);
            Button.MouseDown -= new MouseButtonEventHandler(DismantleClick);

        }

        private void DismantleClick(object sender, MouseButtonEventArgs e)
        {
            if(!Opened && e.RightButton == MouseButtonState.Pressed)
            {
                if(Dismantled)
                {
                    Dismantled = false;
                    //button.image
                    Button.Background = null;
                }
                else
                {
                    Dismantled = true;



                    Button.Background = Images.Flag;
                }

                OnDismantle();

            }
            else
            {
                
            }
        }
    }
}
