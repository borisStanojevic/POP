   M S B A M L   `   `   `  ����H  DMyApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MyApplication.UIMyApplication.UI  5   	   %    MyApplication.UI.SalesmanWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MyApplication.UI     5   	     � Title$  SalesmanWindow��5   	   $��676.605��6    $��760.784��61    � SizeToContent$ WidthAndHeight=�6A    � 
ResizeMode$ NoResize=�6`    � WindowStartupLocation$ CenterScreen=�6v    � 	Resources 5
      &   System.Windows.Controls.DataGrid �� 
TargetType �� Property �� Value   Add �� 
TargetType	 ��Name
 �� Triggers P� Property P� Value 
 Update��%�  '        &	  J     &	 �    �� 5   
   "  6   .�5      ��  � ��
 �����6+   5      �� 5   
   " ��6   .�5      ��  � �� �#00C8516+   �� 5       � ��
 �����6+   �� 5       � ��
 �����6,   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      #��z��5      ._�5      �� $	 PART_Content��6/   #��z��5   +   #��z��5   +   #��z��5   +   6c   5      5      5!      
 5"      P� 5#       �@J�IsMouseOver . . �5$      ��  � �� �#007E3363   �� 5%       � ��
 �����63   �� 5&       �@�Cursor$
 Hand��6/   5'      5)      �� 5+   
   " ��6   .�5,      ��  � �� �#ffbb336+   �� 5-       � ��
 �����6+   �� 5.       � ��
 �����6,   �� 5/       � �� 50      �� 51      " ��6&   .R�52      �� #��z��6!   #��z��53      #��z��54      ._�55      �� $	 PART_Content��6/   #��z��56   +   #��z��57   +   #��z��58   +   6c   59      5:      5<      
 5=      P� 5>       �@J�IsMouseOver . . �5?      ��  � �� �#FF880063   �� 5@       � ��
 �����63   �� 5A       �@�Cursor$
 Hand��6/   5B      5D      5F      .��5G      � .+�5H   
     -   5        $��dgFurnitureForSale��5H   %      
IsReadOnly . $
��Left=�6?   $	��195��6Z   $��	10,10,0,0q�6g   $	��Top=�6z   $	��550��6�   6�     5I   
   -   5        $��dgServicesForSale��5I   %    . $
��Left=�6>   $	��195��6Y   $��
10,231,0,0q�6f   $	��Top=�6z   $	��550��6�   6�   �� 5J   
   -   5        $��btnAddFurnitureToSale��5J      $	��Add��6.   $
��Left=�6<   $��33��6W   $��
584,10,0,0q�6c   $	��Top=�6w   $	��137��6�   6�   �� 5K   
   -   5        $ ��btnRemoveFurnitureFromSale��5K      $��Remove��63   $
��Left=�6D   $��33��6_   $��
584,64,0,0q�6k   $	��Top=�6   $	��137��6�   6�   �� 5L   
   -   5        $��btnRemoveServiceFromSale��5L      $��Remove��61   $
��Left=�6B   $��33��6]   $��584,280,0,0q�6i   $	��Top=�6~   $	��137��6�   6�   �� 5M   
   -   5        $��btnAddServiceToSale��5M      $	��Add��6,   $
��Left=�6:   $��33��6U   $��584,231,0,0q�6a   $	��Top=�6v   $	��137��6�   6�   �� 5N   
   $
��Date��6   $
��Left=�6   $��30��6:   $��
10,456,0,0q�6F   $	��Top=�6Z   $	��119��6r   (  "System.Windows.Controls.DatePicker  5O   
   -   5        $��dpDateOfSale��5O      $
��Left=�6)   $��30��6D   $��165,456,0,0q�6P   $	��Top=�6e   $	��187��6}   �� 5P   
   $��Buyer��6   $
��Left=�6    $��30��6;   $��
10,513,0,0q�6G   $	��Top=�6[   $	��119��6s   �� 5Q   
   -   5        $��tbBuyer��5Q      $
��Left=�6!   $��30��6<   $��165,513,0,0q�6H    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��187��6�   �� 5R   
   -	   5        $��btnSaveSale��5R   :   #��[  6   $
��Save��6M   $
��Left=�6\   $��35��6w   $��10,579,15,15q�6�   $	��Top=�6�   $	��156��6�   6�   �� 5S   
   -
   5        #��[ 5S      $��History��6=   $
��Left=�6O   $��35��6j   $��584,579,15,15q�6v   $	��Top=�6�   $	��137��6�   6�   5U      5V      