   M S B A M L   `   `   `  ����E  ALibraryApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:LibraryApp.ViewLibraryApp.View  5   	   (    "LibraryApp.View.PersonalDataWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:LibraryApp.View     5   	     � Title$+  %Персональные данные��5   	   $	��442��6%   $	��479��62   .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFE364FF��6    � Offset$ 0Q�61   � 5      $ 	#FF49E2A4��6   $ 1Q�61   5      .+�5   
   �� -   5         ��Name$ label��5      $��ФИО��6   $
��Left=�6-   $��30��6H   $��	30,59,0,0q�6T   $	��Top=�6g   $��70��6   $��16(�6�   $��Arial)�6�   �� 5   
   -   5        $ 
label_Copy��5      $��Телефон��6$   $
��Left=�66   $��30��6Q   $��	30,94,0,0q�6]   $	��Top=�6p   $��90��6�   $��16(�6�   $��Arial)�6�   �� 5   
   -   5        $ label_Copy1��5      $ ��Дата рождения:��6%   $
��Left=�6>   $��30��6Y   $��
30,160,0,0q�6e   $	��Top=�6y   $	��135��6�   $��16(�6�   $��Arial)�6�   �� 5   
   -   5         ��Name$ EmpCheckBox��5      $��Сотрудник��6(   $
��Left=�6<   $��20��6W   $��290,160,0,0q�6c   $	��Top=�6x   $	��115��6�   $��16(�6�   $��Arial)�6�   �� 5   
   -   5         ��Name$ button��5      $��Вход��6!   $
��Left=�60   $��60��6K   $��115,320,0,0q�6W   $	��Top=�6l   $	��245��6�   
���  ��$��36(�6�   $��Arial)�6�   
�������6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $
��Date��5      $
��Left=�6!   $��85��6<   $��
30,195,0,0q�6H   $	��Top=�6\   $	��135��6t   $��16(�6�   $��Arial)�6�   �� 5   
   -   5         ��Name$ 
FioTextBox��5      $
��Left=�6&   $��30��6A   $��
143,59,0,0q�6M   	 �� TextWrapping$
	 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��230��6�   $��16(�6�   $��Arial)�6�   �� 5   
   -   5        $ TelephoneTextBox��5      $
��Left=�6,   $��30��6G   $��
143,94,0,0q�6S   $
	 Wrap=�6g   $�� ��6{   $	��Top=�6�   $	��230��6�   $��16(�6�   $��Arial)�6�   5      5      