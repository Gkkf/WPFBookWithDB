   M S B A M L   `   `   `  ����E  AKsiazkaWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:KsiazkaWPF
KsiazkaWPF  5   	       KsiazkaWPF.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:KsiazkaWPF     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��450��6)   $	��450��69   $	��800��6I   $	��800��6U   $	��800��6d    � WindowStartupLocation$ CenterScreen=�6s   .��5	      � -   5        .+�5
   
   o�  o� 
IsMainMenu . $	��Top=�6!   $��Center=�69   .@�5      m� $
��Baza��6   .@�5      m� -   5        $��Stwórz/wczytaj bazę��5      6Q   5      m� 5      $��Opcje��6   .@�5      m� -   5        $��Dodaj��5      6E   m� 5      -   5        $��Edytuj��5      6F   m� 5      -   5        $��Usuń��5      6D   5      5      �� 5   
   -   5        $��	searchbar��5   -   $
��Left=�6   $��	70,25,0,0q�6>    �� TextWrapping$
 Wrap=�6Q   $	��Top=�6e   $	��525��6}   $��28��6�   $��18(�6�   �� 5   
   -   5        $��Szukaj��5      $
��Left=�6"   $��
610,25,0,0q�6=   $	��Top=�6Q   $	��110��6i   $��28��6�   � 5   
   $��10,60,10,65q�6   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��dataGrid��5         AutoGenerateColumns .  $��Center=�6C   $	��Top=�6`      CanUserResizeRows .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .  	   CanUserSortColumns	 .  
   CanUserResizeColumns
 .     
IsReadOnly .  � ContextMenu 5      �� 5      .@�5      m� -	   5        $��Dodaj��5   #   62   m� 5      -
   5        $��Edytuj��5   #   63   m� 5      -   5        $��Usuń��5   #   61   5          Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$
 Imie��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Name+6P     5%      $ Nazwisko��6)   $	 150 6W    6;   �� *	Surname+6W     5&      $ Nr Telefonu��6)   $	 150 6Y    6>   �� *Number+6Y     5'      $ E-mail��6)   $	 200 6S    69   �� *Email+6S      ColumnHeaderStyle 5)      �� 5*       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5+      ��  �� Property � �� �� Value$ Center=�6G   5,      5.      5/      � 51   
   $��Center=�6   $	��802��6,   $��60��68   $��Bottom=�6D    � ColumnDefinitions 52      �� 53      $	��300 �6#   �� 54      $	��200 �6#   �� 55      $	��300 �6#    � RowDefinitions 57      �� 58      $��60 �6    .+�5;      �� -   5         ��Name$
 back��5;   %   $��0��6   $��15, 0, 0, 10q�63   $��
Poprzednia��6I   6^   �� 5<      -   5         ��Name$ 	pageCount��5<   $   $��1��6   $��0, 0, 0, 10q�67   $��Center=�6L   $��Center=�6g   $��1��6�   �� 5=      -   5        $
 next��5=   %   $��2��6   $��0, 0, 15, 10q�63   $��	Następna��6I   6\   � 5>      -   5         �Name$ progress��5>   w   $��1��6   $��Center=�6*   $��10��6G   $	��Top=�6S   $	��180��6k   6w   5?      5@      5A      