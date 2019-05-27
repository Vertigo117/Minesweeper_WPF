using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;

namespace Minesweeper_WPF
{


    class MineField : Grid
    {
        MineField_Button button;

        MineField_Button[,] buttonArray;





        public MineField()
        {

            int columns = 10;
            int rows = 10;


            //this.Margin = new Thickness(10);
            buttonArray = new MineField_Button[columns, rows];


            int count = 1;

            for (int i = 0; i < columns; i++)
            {



                ColumnDefinitions.Add(new ColumnDefinition());
                RowDefinitions.Add(new RowDefinition());


                for (int j = 0; j < rows; j++)
                {


                    button = new MineField_Button();
                    buttonArray[j, i] = button;
                    button.MouseLeftButtonDown += new MouseButtonEventHandler(Click);



                    SetColumn(button, j);
                    SetRow(button, i);

                    Children.Add(button);
                    count++;
                }
            }
        }

        private void Click(object sender, EventArgs e)
        {
            button = (MineField_Button)sender;

            button.SetType(CellType.Near1);
        }
    }
}
