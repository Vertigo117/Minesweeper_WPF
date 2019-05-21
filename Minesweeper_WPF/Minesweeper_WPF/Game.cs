using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Minesweeper_WPF
{
    class Game
    {
        int height;
        int width;
        int mines=10;
        //Grid grid;
        GameButton[,] gameButtons;
        private int dismantledMines;
        private int incorrectDismantledMines;
        public event EventHandler DismantledMinesChanged;
        public event EventHandler Victory;
        public int Mines { get; }
        public Grid Grid { get; }

        public int DismantledMines
        {
            get
            {
                return dismantledMines + incorrectDismantledMines;
            }
        }

        public Game(int height, int width, Grid grid)
        {

            this.height = height;
            this.width = width;
            Grid = grid;
            Mines = 10;

            

        }

        public void Start()
        {
            dismantledMines = 0;
            incorrectDismantledMines = 0;
            Grid.Children.Clear();
            gameButtons = new GameButton[width, height];
             
            
            for(int i=0;i<height;i++)
            {
                for(int j=0;j<width;j++)
                {
                    

                    GameButton gameButton = new GameButton(this,i,j);
                    gameButtons[i, j] = gameButton;

                    //GameButton gameButton = new GameButton();
                    //RowDefinition rowDefinition = new RowDefinition();
                    //ColumnDefinition columnDefinition = new ColumnDefinition();
                    //rowDefinition.Height = new System.Windows.GridLength(25);
                    //columnDefinition.Width = new System.Windows.GridLength(25);

                    //grid.RowDefinitions.Add(rowDefinition);
                    //grid.ColumnDefinitions.Add(columnDefinition);
                    //Grid.SetRow(gameButton, i);
                    //Grid.SetColumn(gameButton, j);
                    //grid.Children.Add(gameButton);
                }
            }

            int b = 0;
            Random r = new Random();
            while(b<mines)
            {
                int x = r.Next(width);
                int y = r.Next(height);

                GameButton gameButton = gameButtons[x, y];
                if(!gameButton.Mined)
                {
                    gameButton.Mined = true;
                    b++;
                }

                OnDismantledMinesChanged();

                //timer
            }
        }

        public void OpenSpot(int x, int y)
        {
            if (x >= 0 && x < width)
            {
                if (y >= 0 && y < height)
                {
                    gameButtons[x, y].Open();
                }
            }
        }

        public bool IsBomb(int x, int y)
        {
            if (x >= 0 && x < width)
            {
                if (y >= 0 && y < height)
                {
                    return gameButtons[x, y].Mined;
                }
            }
            return false;
        }

        private void Dismantle(object sender, EventArgs e)
        {
            GameButton s = (GameButton)sender;


            if (s.Dismantled)
            {
                if (s.Mined)
                {
                    dismantledMines++;
                }
                else
                {
                    incorrectDismantledMines++;
                }
            }
            else
            {
                if (s.Mined)
                {
                    dismantledMines--;
                }
                else
                {
                    incorrectDismantledMines--;
                }
            }

            OnDismantledMinesChanged();

            if (dismantledMines == Mines)
            {
                //timer.Stop();
                //Panel.Enabled = false;
                Victory(this, new EventArgs());
            }
        }


        private void OnDismantledMinesChanged()
        {
            if (DismantledMinesChanged != null)
            {
                DismantledMinesChanged(this, new EventArgs());
            }
        }
    }
}
