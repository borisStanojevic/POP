   M S B A M L   `   `   `  ����H  DMyApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MyApplication.UIMyApplication.UI  5   	   !    MyApplication.UI.UserWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MyApplication.UI     5   	     � Title$  
UserWindow��5   	   $	��375��6   $��420.608��6)    � 
ResizeMode$ NoResize=�69    � WindowStartupLocation$ CenterScreen=�6O    � SizeToContent$ WidthAndHeight=�6t    � 	Resources 5
         TextBoxErrorTemplate��%d   &	        �� 5   
   .R�5      �� 
���  ��$��2q�6'   ._�5      �� 5      5      5      .��5      � .+�5   
   �� -   5        $��tbName��5   _    =� ErrorTemplate# [  6   $
��Left=�6m   $��31��6�   $��
156,10,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��231��6�   .��6  ��5      �� 5       �� Path$
 Name�6    �� UpdateSourceTrigger$ PropertyChanged=�6&   	 �� ValidationRules	 5      +   %MyApplication.UI.StringValidationRule  5      5      .��5      5      �� 5   
   -   5        $��	tbSurname��5   _   # [  6   $
��Left=�6p   $��31��6�   $��
156,59,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��231��6�   .��6  ��5      �� 5      $ Surname�6   $ PropertyChanged=�6)   	 5        5      5!      .��5"      5#      �� 5$   
   -   5        $��
tbUsername��5$   _   # [  6   $
��Left=�6q   $��33��6�   $��156,114,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��231��6�   .��6
  ��5%      �� 5&      $ Username�6   $ PropertyChanged=�6*   	 5'      -   'MyApplication.UI.UsernameValidationRule  5(      5*      .��5+      5,      �� 5-   
   $
��Name��6   $
��Left=�6   $��31��6:   $��	10,10,0,0q�6F   $	��Top=�6Y   $	��113��6q   �� 5.   
   $��Surname��6   $
��Left=�6"   $	��Top=�6=   $��	10,59,0,0q�6U   $	��113��6h   $��31��6t   �� 5/   
   $��Username��6   $
��Left=�6#   $��33��6>   $��
10,114,0,0q�6J   $	��Top=�6^   $	��113��6v   �� 50   
   $��Password��6   $
��Left=�6#   $��31��6>   $��
10,167,0,0q�6J   $	��Top=�6^   $	��113��6v   �� 51   
   -   5        $��
tbPassword��51   _   # [  6   $
��Left=�6r   $��31��6�   $��156,167,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��231��6�   .��6  ��52      �� 53      $ Password�6   $ PropertyChanged=�6*   	 54      -   'MyApplication.UI.PasswordValidationRule  55      57      .��58      59      �� 5:   
   $��	User Type��6   $
��Left=�6$   $��30��6?   $��
10,222,0,0q�6K   $	��Top=�6_   $	��113��6w   �� 5;   
   -   5        $��
cbUserType��5;      $
��Left=�6L   $��156,222,0,0q�6g   $	��Top=�6|   $	��100��6�   
 �� SelectedItem
 6%   �� $ UserType�6�   �� 5<   
   -   5        $��btnAddEditUser��5<      $	��Add��6'   $
��Left=�65   $��156,283,15,15q�6P   $	��Top=�6g   $	��100��6   $��30��6�   6�   �� 5=   
   $��Cancel��6    �� IsCancel . $
��Left=�62   $��281,283,15,15q�6M   $	��Top=�6d   $	��106��6|   $��30��6�   5?      5@      