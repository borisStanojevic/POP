   M S B A M L   `   `   `  ����H  DMyApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MyApplication.UIMyApplication.UI  5   	   &     MyApplication.UI.FurnitureWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MyApplication.UI     5   	     � Title$  FurnitureWindow��5   	   $��443.2��6!   $	��400��60    � WindowStartupLocation$ CenterScreen=�6<    � SizeToContent$ WidthAndHeight=�6a    � 
ResizeMode$ NoResize=�6�    � 	Resources 5
         TextBoxErrorTemplate��%d   &	        �� 5   
   .R�5      �� 
���  ��$��2q�6'   ._�5      �� 5      5      5      .��5      � .+�5   
   �� $
��Name��6   $
��Left=�6   $��27��6:   $��	10,10,0,0q�6F   $	��Top=�6Y   $	��114��6q   �� 5   
   $��Furniture type��6   $
��Left=�6)   $��27��6D   $��
10,151,0,0q�6P   $	��Top=�6d   $	��114��6|   �� 5   
   $��Price��6   $
��Left=�6    $��27��6;   $��	10,52,0,0q�6G   $	��Top=�6Z   $	��114��6r   �� 5   
   $��Action sale��6   $
��Left=�6&   $��27��6A   $��
10,249,0,0q�6M   $	��Top=�6a   $	��114��6y   �� 5   
   -   5        $��tbName��5   _    =� ErrorTemplate# [  6   $
��Left=�6m   $��27��6�   $��
151,10,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��211��6�   .��6  ��5      �� 5       �� Path$
 Name�6    �� UpdateSourceTrigger$ PropertyChanged=�6&   	 �� ValidationRules	 5      +   %MyApplication.UI.StringValidationRule  5      5      .��5      5      �� 5    
   -   5        $��tbPrice��5    _   # [  6   $
��Left=�6n   $��27��6�   $��
151,52,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��211��6�   .��6  ��5!      �� 5"      $ Price�6   $ PropertyChanged=�6'   	 5#      ,   &MyApplication.UI.IntegerValidationRule  5$      5&      .��5'      5(      �� 5)   
   -   5        $��
tbQuantity��5)   _   # [  6   $
��Left=�6r   $��27��6�   $��
151,97,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��211��6�   .��6
  ��5*      �� 5+      $ Quantity�6   $ PropertyChanged=�6*   	 5,        5-      5/      .��50      51      �� 52   
   -   5        $��cbFurnitureType��52      
 �� SelectedValuePath$
 Id��6*   $
��Left=�6B   $��29��6]   $��151,151,0,0q�6i   $	��Top=�6~   $	��111��6�    J� RenderTransformOrigin$ 0.503,1.007&�6�   �� 53   
   -   5        $��cbActionSale��53      $
 Id��6'   $
��Left=�6>   $��29��6Y   $��151,247,0,0q�6e   $	��Top=�6z   $	��111��6�   �� 54   
   -   5        $��btnAddEditFurniture��54      $	��Add��6,   $
��Left=�6:   $	��Top=�6U   $��98��6m   $��151,323,15,15q�6x   $��29��6�   6�   �� 55   
    �� IsCancel . $��Cancel��6!   $
��Left=�62   $	��Top=�6M   $��98��6e   $��264,323,15,15q�6p   $��29��6�   �� 56   
   $��Quantity��6   $
��Left=�6#   $��27��6>   $��	10,97,0,0q�6J   $	��Top=�6]   $	��114��6u   57      58      