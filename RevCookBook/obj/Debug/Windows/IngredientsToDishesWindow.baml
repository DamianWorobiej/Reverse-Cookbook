   M S B A M L   `   `   `  ����F  BRevCookBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:RCookBookDBRCookBookDB  5   	   +    %RCookBookDB.IngredientsToDishesWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:RCookBookDB     5   	   -   5          � Title$  IngredientsToDishesWindow��5   	   $	��500��6+   $	��500��68    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $��25 �6   �� 5      $��25 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��35 �6   .+�5   
   �� -   5        $��Zamknij��5      $��5,0,5,10q�5      $��1��5      $��4��5      �� 5   
   -   5         ��Name$ 	tb_Search��5      $��1��5      $��0��5      $��20,0,0,0q�5!      �� 5$   
   $��Szukaj po nazwie��6   $��0��5%      $��0��5&      $��20,0,0,0q�5'      �� 5)   
   $"��Szukaj dań wegetariańskich��6   $��2��65   �� 5*   
   -   5         ��Name$ 
cbox_Vegan��5*      $��1��6'   $��2��64   $��20,0,0,0q�6D   6W   �� 5-   
   -   5         ��Name$ lbl_Ingredients��5-      $��
Składniki��5.      $��2��5/      $��0��50      $��20,0,0,0q�51      �� 52   
   -   5         ��Name$ IngredientsListView��52      $��2��53      $��0��54      $��2��55      $��1��56      $��
20,35,0,20q�57      ��58      ��  �� Path$ Ingredients�	 �� View	 5;      �� 5<      .P�5=      �� $��Nazwa��6%   
 �� Width$

 auto��64    �� DisplayMemberBinding 5>   %   �� *Name+5?      5A      �� 5C   
   -   5        $, &lbl_DishesWithSelectedIngredientsList1��5C      $��Lista dań zawierających��5D      $��2��5E      $��2��5F      �� 5G   
   -   5        $, &lbl_DishesWithSelectedIngredientsList2��5G      $��wybrane składniki��5H      $��2��5I      $��2��5J      $��0,12,0,0q�5K      �� 5L   
   -	   5        $ Wybrane��5L      $��2��5M      $��2��5N      $��2��5O      $��1��5P      $��
0,35,20,20q�5Q      ��5R      �� $ Dishes�	 5U      �� 5V      .P�5W      �� $��Nazwa składnika��6%   $

 auto��6>    5X   $   �� *Name+�� 5Y      $��Ilość��6%   $
 60��64    5Z   %   �� *Time+5[      5]      5^      5_      