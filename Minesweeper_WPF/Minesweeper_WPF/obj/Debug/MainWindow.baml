   M S B A M L   `   `   `  ����J  FMinesweeper_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Minesweeper_WPFMinesweeper_WPF  5   	        Minesweeper_WPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Minesweeper_WPF     5   	     � Title$  MineSweeper��5   	   $	��340��6   $	��230��6*    � 
ResizeMode$ CanMinimize=�66    � 	Resources 5	      ��%    5      .��5      ]� -   5        $��GameDockPanel��5      .+�5   
   o� -   5         o�Name$ GameMenu��5      $	��Top=�6!   .@�5      m� $
��Game��6   .@�5      m� -   5        $	��New��5      6(   �� 5      m� 5      -   5        $��Beginner��5      6-   m� 5      -   5        $��Intermediate��5      62   m� 5      -   5        $��Expert��5      6,   �� 5      m� 5      -   5        $
��Exit��5      6)   5      5      �� 5   
   $��3 3 0 0q�6   
�������._�5      ]� 
�������.+�5      �� $	��Top=�6   $��6q�6.   
�������$��
2, 2, 0, 0q�6P   ._�5      �� 
�������$��0 0 2 2q�61   ._�5      � $��10q�6    � RowDefinitions 5      �� 5   "   �� 5    "    � ColumnDefinitions 5#      �� 5$   "   �� 5%   "   $��25 �63   �� 5&   "   .+�5(      $  Minesweeper_WPF.EmotionsButton  -   5          Name$ emotionsBtn��5(   M      EmotionTypeValue$ Common=�63   $��1��6b   $��1��6o   $  Minesweeper_WPF.CounterControl  5)      -	   5          Name$ timer��5)   3   $��1��6B   $��2��6O   $��25��6_   $��Right=�6k     5*      -
   5        $ minesCounter��5*   3   $��1��6I   $��0��6V   $��25��6f   $
��Left=�6r   5/      50      51      �� 52      $��6 2 6 6q�6   
�������$��4 4 0 0q�6B   }�. ._�53      �� }�. 
�������$��0 0 4 4q�6E   ._�54        Minesweeper_WPF.MineField  -   5        	  Name$	 	mineField��54   *   55      56      57      59      5:      5;      