   M S B A M L   `   `   `  ����J  FdodawanieDanych, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:dodawanieDanychdodawanieDanych  5   	        dodawanieDanych.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:dodawanieDanych     5   	   -   5          � Title$  	Piłkarze��5   	   $	��450��6   $	��800��6'   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��6* �6   �� 5      $��2* �6   .+�5   
   �� $��2��6   .+�5      �� $��5q�6   .��6   Imię:6&   .   (dodawanieDanych.TextBoxWithErrorProvider  5      -   5          Name$ textBoxWEPImie��5   -   $��10q�6E   $��15(�6Q   �� 5      $��5q�6   .��6   	Nazwisko:6*     5      -   5        $ textBoxWEPNazwisko��5   -   $��10q�6I   $��15(�6U   �� 5      -   5         ��Name$
 wiek��5      $��5q�6"   .��6-   Wiek: 5 lat6:   �� 5      -   5        $��
wiekSlider��5      $��10q�6'   $	��200��63    �� Orientation$ 
Horizontal=�6?   $��Center=�5       � Minimum$ 5Q�62    � Maximum$	 100Q�6>    � SmallChange$ 5Q�5      	 � LargeChange$	 10Q�6%   
 �� TickPlacement$
 BottomRight=�66    �� AutoToolTipPrecision$ 0��5        �� AutoToolTipPlacement$ BottomRight=�6.   5!      �� 5#      -   5        $
 waga��5#      $��5q�6"   .��6-   Waga: 10 kg6:   �� 5$      -   5        $��
wagaSlider��5$      $��10q�6'   $	��200��63   $ 
Horizontal=�6?   $��Center=�5%      $ 10Q�62   $	 150Q�6?   $ 5Q�5&      $	 10Q�6%   $
 BottomRight=�66   $ 0��5'      $ BottomRight=�6.   5(      5+      �� 5,   
   -   5         ��Name$ buttonDodaj��5,      $��2��6&   $	��100��63   $��50��6?   $��10q�6K   $��Dodaj��6W   $��Center=�6g   $
��Left=�6�   6�   �� 5-   
   -	   5        $ buttonEdytuj��5-      $��2��6'   $	��100��65   $��50��6A   $��10q�6M   $��Edytuj��6Y   {�.  $��Center=�6|   $��Center=�6�   6�   �� 5.   
   -
   5        $ 
buttonUsun��5.      $��2��6%   $	��100��63   $��50��6?   $��10q�6K   $��Usuń��6W   {�.  $��Center=�6x   $��Right=�6�   6�   �� 50   
   $-��'------------LISTA PIŁKARZY------------��6   $��1��6A   $��Center=�6Q   $��Center=�6l   $��20(�6�   �� 51   
   -   5         ��Name$ listBoxPilkarze��51      $��1��6+   $��2��68   $��1��6I   $��15q�6Y   $��15(�6e   52      53      54      