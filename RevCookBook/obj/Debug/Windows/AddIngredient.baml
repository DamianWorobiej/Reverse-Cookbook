   M S B A M L   `   `   `  ����F  BRevCookBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:RCookBookDBRCookBookDB  5   	       RCookBookDB.AddIngredient   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:RCookBookDB     5   	     � Title$  AddIngredient��5   	   $	��500��6   $	��300��6,    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   .+�5   
   �� $��0��6   $��10q�6"   .+�5      �� $��Nazwa składnika��6   �� 5      -   5         ��Name$ tb_Name��5      .��6'   ��5      �� 5       �� Path$
 Name�6   .��5       5      �� 5      $��Szukaj kategorii��6   �� 5      -   5        $ 	tb_Search��5      6)   �� 5      $��	Kategoria��6   6*   �� 5      -   5         ��Name$ lv_Category��5      $	��175��5       �� DisplayMemberPath$
 Name��5      ��5      �� $ 
Collection� �� SelectedItem 5      �� $ SelectedCategory�5&      �� 5'      $$��Czy to produkt wegetariański?��6   �� 5(      -   5         ��Name$ 	cbox_Meat��5(      $��20,0,0,0q�6*   	 d� 	IsChecked	 6<   �� *Vegan+5)      �� 5*   
   -   5        
 ��Name$
 
btn_AddIng��5*      $��Dodaj produkt��6%   $��1��6=   $��5q�6J   6U   �� 5+   
   -   5        $
 btn_AddCategory��5+      $��Dodaj kategorię��6*   $��2��6D   $��5q�6Q   6\   �� 5,   
   -   5        $
 	btn_Close��5,      $��Zamknij��6$   $��3��66   $��5q�6C   6N   5-      5.      