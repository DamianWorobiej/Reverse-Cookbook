   M S B A M L   `   `   `  ����F  BRevCookBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:RCookBookDBRCookBookDB  5   	       RCookBookDB.FindDish   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:RCookBookDB     5   	   -   5          � Title$  FindDish��5   
   $	��500��6   $	��300��6(    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      �  � RowDefinitions 5   
   �� 5      $	��130 �6   �� 5      $��3* �6   �� 5      $��80 �6   .+�5   
   �� $��10q�6   $��0��6!   .+�5      �� -   5         ��Name$ 
l_wyszukaj��5      $��Wyszukaj danie po nazwie��6(   �� 5      -   5         ��Name$ tb_Name��5      ��6'   ��  �� Path$ 
NameSearch�6H   �� 5      -   5        $ l_danie��5      $��Danie wegetariańskie?��6%   �� 5      -   5         ��Name$ 	cbox_Meat��5      $��20,0,0,0q�6*    d� 	IsChecked 6<   �� $ Vegan�6]   �� 5      -   5        $ l_lista��5      $��
Lista dań��6%   5      �� 5   
   -   5         ��Name$ 	lv_Dishes��5      $��1��5      $��10q�5      	 �� DisplayMemberPath$
	 Name��5      ��5      �� $ 
Collection�
 �� SelectedItem
 5      �� $ SelectedItem� �� View 5      �� 5       .P�5!      ��  �� Width$
 auto��6)    �� DisplayMemberBinding 66   �� *Name+5"      5$      �� 5%      -   5         ��Name$ 	btn_Close��5%      $��2��5&      $��Zamknij��5(      $��20q�5)      5+      5,      