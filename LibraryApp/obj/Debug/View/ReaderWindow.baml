   M S B A M L   `   `   `  ����E  ALibraryApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:LibraryApp.ViewLibraryApp.View  5   	   "    LibraryApp.View.ReaderWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:LibraryApp.View     5   	     � Title$  Читатель��5   	   $	��450��6   $	��800��6'   .��5	      � .+�5
   
   �� -   5         ��Name$ 
tabControl��5
      $
��Left=�6)   $	��409��6D   $��0,10,0,0q�6Q   $	��Top=�6c   $	��792��6{   .@�5      �� $��
Книги��6   .��5      � ���	#FFE5E5E5.+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridBook��5      $
��Left=�65   $	��371��6P   $	��Top=�6]   $	��637��6u      CanUserAddRows .     CanUserDeleteRows .  6�   �� 5      -   5         ��Name$ button��5      $��Бронировать��6-   $
��Left=�6C   $��60��6^   $��
647,15,0,0q�6j   $	��Top=�6~   $	��129��6�   6�   �� 5      -   5        $ button_Copy��5      $��
Выход��62   $
��Left=�6B   $��60��6]   $��647,306,0,0q�6i   $	��Top=�6~   $	��129��6�   6�   5      5      �� 5      $��История��6   .��5      � ���	#FFE5E5E5.+�5        -   5        $ HistoryDataGrid��5      $
��Left=�68   $	��381��6S   $	��Top=�6`   $	��637��6x    .   .   J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5      V� 5      .~�5   "   �� �� 5   "   �� 5   "    �� Angle$ 0.311Q�62   T� 5   "   5      5      �� 5      -   5        $ button1��5      $��Обновить��6.   $��Right=�6A   $��0,19,8,0q�6]   $	��Top=�6o   $	��127��6�   $��54��6�   6�   �� 5      -   5        $ button1_Copy��5      $��
Выход��63   $��Right=�6C   $��0,0,8,19q�6_   $��Bottom=�6q   $	��130��6�   $��47��6�   6�   5       5!      5"      5#      5$      