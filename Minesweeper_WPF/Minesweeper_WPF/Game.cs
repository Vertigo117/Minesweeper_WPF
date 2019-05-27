﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Input;

namespace Minesweeper_WPF
{
    class Game
    {
        private MineField mineField;
        private CounterControl minesCounter;
        private CounterControl timeCounter;
        private int dismantledMines;
        private int incorrectDismantledMines;
        public event EventHandler DismantledMinesChanged;
        public event EventHandler Defeat;
        Timer timer;


        

        MineField_Button button;

        MineField_Button[,] buttonArray;

        public int Time { get; set; }

        public int DismantledMines
        {
            get { return dismantledMines + incorrectDismantledMines; }
        }

        public Game(MineField mineField, CounterControl minesCounter, CounterControl timeCounter)
        {
            this.mineField = mineField;
            this.minesCounter = minesCounter;
            this.timeCounter = timeCounter;

            
        }

        public void Start(int columns, int rows, int mines)
        {
            mineField.Columns = columns;
            mineField.Rows = rows;
            mineField.Mines = mines;
            dismantledMines = 0;
            incorrectDismantledMines = 0;
            mineField.Children.Clear();
            mineField.ColumnDefinitions.Clear();
            mineField.RowDefinitions.Clear();

            //mineField.Engage();
            minesCounter.Number = mineField.Mines;

            buttonArray = new MineField_Button[mineField.Columns, mineField.Rows];

            for (int c = 0; c < mineField.Columns; c++)
            {



                mineField.ColumnDefinitions.Add(new ColumnDefinition());
                mineField.RowDefinitions.Add(new RowDefinition());


                for (int r = 0; r < mineField.Rows; r++)
                {


                    button = new MineField_Button(c, r);
                    button.Explode += new EventHandler(Explode);
                    button.Dismantle += new EventHandler(Dismantle);
                    button.MouseLeftButtonDown += new MouseButtonEventHandler(Click);
                    button.MouseRightButtonDown += new MouseButtonEventHandler(Dismantle_click);

                    Grid.SetColumn(button, c);
                    Grid.SetRow(button, r);
                    mineField.Children.Add(button);
                    buttonArray[c, r] = button;
                }
            }

            PlaceMines();
            DismantledMinesChanged?.Invoke(this, new EventArgs());

            //timer = new Timer();
            //timer.Interval = 1000;
            //timer.
        }

        private void Dismantle_click(object sender, MouseButtonEventArgs e)
        {
            MineField_Button b = (MineField_Button)sender;
            if(!b.Opened)
            {
                if(b.Dismantled)
                {
                    b.Dismantled = false;
                    b.SetType(CellType.Button);
                }
                else
                {
                    b.Dismantled = true;
                    b.SetType(CellType.Flagged);
                }
                b.Dismantle?.Invoke(b, new EventArgs());
            }
        }

        private void Explode(object sender, EventArgs e)
        {

            Defeat?.Invoke(this, new EventArgs());

            foreach(MineField_Button b in buttonArray)
            {
                b.MouseLeftButtonDown -= new MouseButtonEventHandler(Click);
                b.MouseRightButtonDown -= new MouseButtonEventHandler(Dismantle_click);

                if(button.Mined && button.CurrentCellType!=CellType.BombExplode)
                {
                   if(!button.Dismantled)
                    {
                        button.SetType(CellType.Bomb);
                    }
                   else
                    {
                        button.SetType(CellType.Flagged);
                    }
                }
                else
                {
                    if(button.Dismantled)
                    {
                        button.SetType(CellType.NoBomb);
                    }
                }
            }
        }

        //private void RemoveEvents()
        //{
        //    button.MouseLeftButtonDown -= new MouseButtonEventHandler(Click);
        //    button.MouseRightButtonDown -= new MouseButtonEventHandler(Dismantle_click);
        //}

        private void Dismantle(object sender, EventArgs e)
        {
            MineField_Button b = (MineField_Button)sender;
            if(b.Dismantled)
            {
                if(b.Mined)
                {
                    dismantledMines++;
                }
                else
                {
                    incorrectDismantledMines--;
                }
            }
            else
            {
                if(b.Mined)
                {
                    dismantledMines--;
                }
                else
                {
                    incorrectDismantledMines--;
                }
            }

            

            if(dismantledMines==mineField.Mines)
            {
                mineField.IsEnabled = false;
            }
        }

        

        

        private void Click(object sender, MouseButtonEventArgs e)
        {
            button = (MineField_Button)sender;

            if (!button.Dismantled)
            {
                if (button.Mined)
                {
                    button.SetType(CellType.BombExplode);
                    //Explode?.Invoke(this, new EventArgs());
                    button.Explode?.Invoke(this, new EventArgs());
                }
                else Open(button);
            }
        }

        private void Open(MineField_Button button)
        {

            if (!button.Opened && !button.Dismantled)
            {
                button.Opened = true;

                int c = 0;
                if (CheckMine(button.X - 1, button.Y - 1)) c++;
                if (CheckMine(button.X - 0, button.Y - 1)) c++;
                if (CheckMine(button.X + 1, button.Y - 1)) c++;
                if (CheckMine(button.X - 1, button.Y - 0)) c++;
                if (CheckMine(button.X - 0, button.Y - 0)) c++;
                if (CheckMine(button.X + 1, button.Y - 0)) c++;
                if (CheckMine(button.X - 1, button.Y + 1)) c++;
                if (CheckMine(button.X - 0, button.Y + 1)) c++;
                if (CheckMine(button.X + 1, button.Y + 1)) c++;

                if (c > 0)
                {
                    switch (c)
                    {
                        case 1:
                            button.SetType(CellType.Near1);
                            break;
                        case 2:
                            button.SetType(CellType.Near2);
                            break;
                        case 3:
                            button.SetType(CellType.Near3);
                            break;
                        case 4:
                            button.SetType(CellType.Near4);
                            break;
                        case 5:
                            button.SetType(CellType.Near5);
                            break;
                        case 6:
                            button.SetType(CellType.Near6);
                            break;
                        case 7:
                            button.SetType(CellType.Near7);
                            break;
                        case 8:
                            button.SetType(CellType.Near8);
                            break;
                    }
                }
                else
                {
                    button.SetType(CellType.Empty);
                    OpenSpot(button.X - 1, button.Y - 1);
                    OpenSpot(button.X - 0, button.Y - 1);
                    OpenSpot(button.X + 1, button.Y - 1);
                    OpenSpot(button.X - 1, button.Y - 0);
                    OpenSpot(button.X - 0, button.Y - 0);
                    OpenSpot(button.X + 1, button.Y - 0);
                    OpenSpot(button.X - 1, button.Y + 1);
                    OpenSpot(button.X - 0, button.Y + 1);
                    OpenSpot(button.X + 1, button.Y + 1);
                }

            }



        }

        private bool CheckMine(int x, int y)
        {
            if (x >= 0 && x < mineField.Columns)
            {
                if (y >= 0 && y < mineField.Rows)
                {
                    return buttonArray[x, y].Mined;
                }
            }
            return false;
        }

        private void OpenSpot(int x, int y)
        {
            if (x >= 0 && x < mineField.Columns)
            {
                if (y >= 0 && y < mineField.Rows)
                {
                    Open(buttonArray[x, y]);
                }
            }
        }

        private void PlaceMines()
        {
            Random r = new Random();
            int mineCounter = 0;

            while (mineCounter < mineField.Mines)
            {
                int x = r.Next(mineField.Columns);
                int y = r.Next(mineField.Rows);

                if (!buttonArray[x, y].Mined)
                {
                    buttonArray[x, y].Mined = true;
                    mineCounter++;
                }
            }
        }
    }
}
