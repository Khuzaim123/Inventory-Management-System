   M S B A M L   `   `   `  ����  Inventory managment    InventoryApp.Dashboard   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$!  Inventory Management System��5   	   $	��602��6-   $
��1207��6:   ���#F0F4F8 � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�64    � 	Resources 5         MetricBoxStyle �� 
TargetType �� Property �� Value��%l  &	        �� 5   
   " ��6'   .�5	      ��  � ��
 �����6+   �� 5
       �@��Padding$ 10q�6(   �� 5       � ��$ 10q�6'   �� 5       �@��CornerRadius$ 10��6-   �� 5       � ��$	 220��6&   �� 5       � ��$	 120��6'   �� 5       � ��$ Center=�64   �� 5       � ��$	 Top=�62   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��220 �6   �� 5      $��* �6   .+�5   
   �� ���#008080 �� CornerRadius$ 10��6&   $��10q�68   	 �� Padding$	 10q�6D   ._�5      �� $��Stretch=�6   .+�5      �� $��Navigate��6   
�������$��22(�6?   $
��Bold"�6M   $��10q�6_   
 �� TextAlignment$
 Center=�6k   �� 5      $��	Dashboard��6   
����������#008080$
��Bold"�6U   $
��10,5q�6g   $��10q�6u   �� 5      -   5        $��Products��5      
����������#008080$
��Bold"�6T   $
��10,5q�6f   $��10q�6t   6�   �� 5       -   5        $��	Suppliers��5       
����������#008080$
��Bold"�6U   $
��10,5q�6g   $��10q�6u   6�   �� 5!      -   5        $��Orders��5!      
����������#008080$
��Bold"�6R   $
��10,5q�6d   $��10q�6r   6   �� 5"      -   5        $��Reports��5"      
����������#008080$
��Bold"�6S   $
��10,5q�6e   $��10q�6s   6�   �� 5#      -   5         ��Name$ ScanBarcode��5#      $��Scan Barcode��6.   
����������#008080$
��Bold"�6m   $
��10,5q�6   $��10q�6�   6�   �� 5$      -   5        $ btnInventoryTracking��5$      $��Inventory Tracking��67   
����������#008080$
��Bold"�6|   $
��10,5q�6�   $��10q�6�   6�   �� 5%      -   5        $��Customer Info��5%      
����������#008080$
��Bold"�6Y   $
��10,5q�6k   $��10q�6y   6�   �� 5'      -   5        $��Help and Support��5'      
����������#008080$
��Bold"�6\   $
��10,5q�6n   $��10q�6|   6�   �� 5(      -	   5        $��	Audit Log��5(      
����������#008080$
��Bold"�6U   $
��10,5q�6g   $��10q�6u   6�   5)      5*      �� 5-   
   $��1��6   $��20q�6%   .+�5.      �� $��Dashboard Overview��6   $��22(�62   $
��Bold"�6@   ���#333$��10q�6d   �� 51       �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�53      �� #��[  6   
����·�._�54      �� .+�55      �� $��Total Stock��6$   $��16(�67   $
��Bold"�6E   
�������6W   �� 56      $��24(�6@   $
��Bold"�6N   
�������$��Center=�6s   ��6$   �� *
TotalStock+6s   57      58      �� 5;      #��[  6   
�������._�5<      �� .+�5=      �� $��Low Stock Alerts��6$   $��16(�6<   $
��Bold"�6J   
�������6\   �� 5>      
���������6'   �� *LowStockAlerts+��5@      �� 5A   "   .R�5B   &   �� $��14(�6A   ��60   �� 6A   5C   #   5E      5F      5G      �� 5J      #��[  6   
������._�5K      �� .+�5L      �� $��Total Sales��6$   $��16(�67   $
��Bold"�6E   
�������6W   �� 5M      $��24(�6@   $
��Bold"�6N   
�������$��Center=�6s   ��6$   �� *
TotalSales+6s   5N      5O      �� 5R      #��[  6   
��� ���._�5S      �� .+�5T      �� $��Total Purchases��6$   $��16(�6;   $
��Bold"�6I   
�������6[   �� 5U      $��24(�6D   $
��Bold"�6R   
�������$��Center=�6w   ��6$   �� *TotalPurchases+6w   5V      5W      5X      5Y      5Z      5[      