   M S B A M L   `   `   `  ����E  ALibraryApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:LibraryApp.ViewLibraryApp.View  5   	   #    LibraryApp.View.JournalWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:LibraryApp.View     5   	     � Title$  Журнал��5   	   $��439.13��6   $��607.608��6(   .��5	      � .+�5
   
   �� -   5         ��Name$ label��5
      $4��.Дата начала бронирования��6   $
��Left=�6B   $	��Top=�6]   $��	52,55,0,0q�6u   �� 5   
   -   5        $ label_Copy1��5      $:��4Дата окончания бронирования��6%   $
��Left=�6K   $	��Top=�6f   $��	52,91,0,0q�6~   �� 5   
   -   5        $ 
label_Copy��5      $��Статус брони ��6$   $
��Left=�6<   $	��Top=�6W   $��
52,125,0,0q�6o   �� 5   
   -   5        $ label_Copy2��5      $&�� Код бронирования ��6%   $
��Left=�6A   $	��Top=�6\   $��
52,161,0,0q�6t   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��	DateStart��5      $	��Top=�6&   $��255,53,143,0q�6>   $��23��6T     5   
   -   5        $��DateEnd��5      $	��Top=�6$   $��253,90,144,0q�6<   $��23��6R   �� 5   
   -   5         ��Name$ StatusComboBox��5      $	��Top=�6+   $��251,122,144,0q�6C   $��21��6Z   �� 5   
   -   5         ��Name$ CodeTextBox��5      $��251,160,144,0q�6'    �� TextWrapping$
 Wrap=�6>   $�� ��6R   $��21��6Z   $	��Top=�6f   �� 5   
   -	   5         ��Name$ button��5      $��Сохранить��6!   $��Bottom=�65   $��101,0,127,54q�6P   $��87��6f   6r   5      5      