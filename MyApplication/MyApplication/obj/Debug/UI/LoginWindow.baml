   M S B A M L   `   `   `  ����H  DMyApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MyApplication.UIMyApplication.UI  5   	   "    MyApplication.UI.LoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MyApplication.UI     5   	     � Title$  LoginWindow��5   	   $��280.335��6   $��452.744��6.    � WindowStartupLocation$ CenterScreen=�6>    � 
ResizeMode$ NoResize=�6c    � 	Resources 5
         Add �� 
TargetType �� Property �� Value �� 
TargetType ��Name	 �� Triggers
 P� Property P� Value��%T  &	        �� 5   
   " ��6   .�5      ��  � �� �#00C8516+   �� 5       � ��
 �����6+   �� 5       � ��
 �����6,   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      #��z��5      ._�5      �� $ PART_Content��6/   #��z��5   +   #��z��5   +   #��z��5   +   6c   5      5      5      	 5      P� 5      
 �@J�IsMouseOver . . �5      ��  � �� �#007E3363   �� 5        � ��
 �����63   �� 5!       �@�Cursor$
 Hand��6/   5"      5$      5%      .��5'      � $��0,0,0.4,-4.6q�6    � ColumnDefinitions 5(   
   �� 5)      $
��134* �6   �� 5*      $
��275* �6    � RowDefinitions 5,   
   �� 5-      $	��67* �6   �� 5.      $	��67* �6   �� 5/      $	��97* �6   .+�51   
   �� $��
Username :��6   $��Center=�6%   $��Center=�6I   $
��Left=�6k   $��	10,32,0,0q�6�   $	��Top=�6�   $	��125��6�   $
��Bold"�6�   $��14(�6�   �� 52   
   $��
Password :��6   $��Center=�6%   $��Center=�6I   $
��Left=�6k   $��10,30.8,0,0q�6�   $	��Top=�6�   $	��125��6�   $��1��6�   $
��Bold"�6�   $��14(�6�   �� 53   
   -   5         ��Name$ 
tbUsername��53       �� AcceptsReturn .  $��Disabled=�6<   $��Disabled=�6r   $��1q�6�   $
��Left=�6�   $��Center=�6�   $
��Left=�6�   $��6.2,30,0,12.8q�6  $��Center=�60  $	��259��6K  $��1��6W  $��14(�6g  $��30��6u  �� 54   
   -   5         ��Name$ btnLogin��54   ;   #���   6   $��Log in��6M   $
��Left=�6^   $��45��6y   $��5.2,42.4,0,0q�6�   $��2��6�   $	��Top=�6�   $	��150��6�   $��1��6�    J� RenderTransformOrigin$ 0.525,1.558&�6�   $��14(�6   $
��Bold"�6  6   G� 55   
   -   5         G�Name$ 
pbPassword��55      $��Disabled=�6*   $��Disabled=�6`   $��1��6�   $
��Left=�6�   $��Center=�6�   $
��Left=�6�   $��6.2,29.2,0,12.8q�6  $��1��6  $��Center=�6)  $	��259��6D  $��30��6P  $��14(�6\  �� 56   
   -   5         ��Name$ 	tbMessage��56      $��1��6(   $
��Left=�68   $��18��6S   $��6.2,10.2,0,0q�6_   $��2��6u   $
��Wrap=�6�   $	��Top=�6�   $	��259��6�   $y�Hidden=�6�   57      58      