   M S B A M L   `   `   `  ����H  DMyApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MyApplication.UIMyApplication.UI  5   	   *    $MyApplication.UI.FurnitureTypeWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MyApplication.UI     5   	     � Title$  FurnitureTypeWindow��5   	   $	��300��6%   $	��400��62    � 
ResizeMode$ NoResize=�6>    � WindowStartupLocation$ CenterScreen=�6T    � SizeToContent$ WidthAndHeight=�6y    � 	Resources 5
         TextBoxErrorTemplate��%d   &	        �� 5   
   .R�5      �� 
���  ��$��2q�6'   ._�5      �� 5      5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��8* �6    � RowDefinitions 5   
   �� 5      $��6* �6   �� 5      $��7* �6   �� 5      $��0* �6   �� 5      $	��17* �6   .+�5   
   �� -   5         ��Name$ lblName��5      $��0��6!   $
��Name��61   $��Center=�6@   $��15,20.6,25.2,16.6q�6]   $��67��6x   $��Center=�6�   $��26��6�   $��1��6�   $��Disabled=�6�   �� 5   
   -   5         ��Name$ tbName��5   �   	 =� ErrorTemplate#	 [  6   $��0q�6_   $��1q�6k   $��Center=�6   $	��295��6�   $��89,11.4,9.6,16.8q�6�   $��35��6�   $��1��6�   $��Center=�6�   $��Center=�6  $
 �� HorizontalScrollBarVisibility$
 Disabled=�6(   �� SelectionOpacity$ 0Q�6Q  $��2��6f  .��6�  ��5      �� 5        �� Path$
 Name�6    �� UpdateSourceTrigger$ PropertyChanged=�6&    �� ValidationRules 5!      +   %MyApplication.UI.StringValidationRule  5"      5$      .��5%      5&      �� 5'   
   -   5         ��Name$ btnAddEditFurnitureType��5'      $	��Add��62   $
��Left=�6@   $��35��6[   $��9.8,19.2,0,0q�6g   $��3��6}   $	��Top=�6�   $��95��6�   $��1��6�   �� 5(   
   -   5        $ 	btnCancel��5(      $��Cancel��6$   $��1��65   $
��Left=�6E   $��35��6`   $��152.8,19.2,15,15q�6l   $��3��6�   $	��Top=�6�   $��95��6�    �� IsCancel . 6�   5)      5*      