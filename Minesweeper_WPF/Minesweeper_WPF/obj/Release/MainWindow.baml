   M S B A M L   `   `   `  ���� J  FMinesweeper_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Minesweeper_WPFMinesweeper_WPF       Minesweeper_WPF.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:Minesweeper_WPF       � Title$  MineSweeper��$	��340��$	��230�� � 
ResizeMode$ CanMinimize=� � 	Resources ��%    .��]� -   $��GameDockPanel��.+�o� -    o�Name$ GameMenu��$	��Top=�.@�m� $
��Game��.@�m� -   $	��New���� m� -   $��Beginner��m� -   $��Intermediate��m� -   $��Expert���� m� -   $
��Exit���� $��3 3 0 0q�
�������._�]� 
�������.+��� $	��Top=�$��6q�
�������$��
2, 2, 0, 0q�._��� 
�������$��0 0 2 2q�._�� $��10q� � RowDefinitions �� ��  � ColumnDefinitions �� �� $��25 ��� .+�$  Minesweeper_WPF.EmotionsButton  -     Name$ emotionsBtn��   EmotionTypeValue$ Common=�$��1��$��1��$  Minesweeper_WPF.CounterControl  -	     Name$ timer��$��1��$��2��$��25��$��Right=�  -
   $ minesCounter��$��1��$��0��$��25��$
��Left=��� $��6 2 6 6q�
�������$��4 4 0 0q�}�. ._��� }�. 
�������$��0 0 4 4q�._�  Minesweeper_WPF.MineField  -   	  Name$	 	mineField��