   M S B A M L   `   `   `  ����  BillingToolBox.    (BillingToolBox.Windows.ServiceEditWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Pick your services��5   	   $	��350��6$   $	��500��61   $	��350��6=   $	��500��6M    � 
ResizeMode$ CanResizeWithGrip=�6\   .��5      � $��5q�6    � ColumnDefinitions 5   
   �� 5      $��0.45* �6   �� 5      $
��0.1* �6   �� 5	      $��0.45* �6    � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   .+�5   
   �� -   5        $��listBox_AvailableServices��5   3   $��0��6   $��2��6"   $��0,0,0,28q�6T    �� SelectionMode$ Extended=�6f   6   �� 5   
   -   5        $��button_Save��5   w   $��0��6   $��1��6"   $
��Save��6/   $��23��6>   $��Right=�6J   $��0,0,0,0q�6f   $��Bottom=�6�   $��75��6�   6�   �� 5   
   -   5        $��listBox_CurrentServices��5   3   $��2��6   $��2��6"   $��0,0,0,28q�6R   $ Extended=�6d   6}   �� 5   
   -   5        $��button_Cancel��5   x   $��2��6   $��1��6"   $��Cancel��6/   $��23��6@   $
��Left=�6L   $��0,0,0,0q�6g   $��Bottom=�6�   $��75��6�   6�   �� 5   
   -   5        $��
button_Add��5   y   $��1��6   $��0��6!   $	��-->��6.   $��23��6?   $��Center=�6K   $��0,0,0,5q�6h   $��Bottom=�6�   $��45��6�   6�   �� 5   
   -   5        $��button_Delete��5   y   $��1��6   $��1��6!   $	��<--��6.   $��23��6?   $��Center=�6K   $��0,5,0,0q�6h   $	��Top=�6�   $��45��6�   6�   5      5      