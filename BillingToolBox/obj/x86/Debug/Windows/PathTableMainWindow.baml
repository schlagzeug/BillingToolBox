   M S B A M L   `   `   `  ����  BillingToolBox0    *BillingToolBox.Windows.PathTableMainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Path Table Editor��5   	   $	��400��6$   $	��440��61   $	��300��6=   $	��440��6M    � 
ResizeMode$ CanResizeWithGrip=�6\   .��5      � $��5q�6   .+�5   
   �� -   5        $��label1��5   M   $��Path Table:��6   $��28��6&   $
��Left=�62   $	��Top=�6[   $��0,0,0,0q�6s   $��75��6�   $��Right=�6�   �� 5   
   -   5        $��label_PathTable��5   I   $��28��6   $
��Left=�6   $��80,0,0,0q�67   $	��Top=�6`   $	��250��6x   $
��Left=�6�   �� 5   
   -   5        $��button_OpenPathTable��5   Z   $
��Open��6   $��23��6    $
��Left=�6,   $��	335,0,0,0q�6G   $	��Top=�6v   $��75��6�   6�   �� 5
   
   -   5        $��label2��5
   h   $��Billing Server Name:��6   $��28��6/   $
��Left=�6;   $��0,28,0,0q�6V   $	��Top=�6v   $	��135��6�   $��Right=�6�   �� 5   
   -   5        $��textBox_BillingServer��5   M   $��23��6   $
��Left=�6   $��
140,28,0,0q�69   $	��Top=�6j   $	��190��6�   �� 5   
   -   5        $��label3��5   j   $��Billing Database Name:��6   $��28��61   $
��Left=�6=   $��0,56,0,0q�6X   $	��Top=�6x   $	��135��6�   $��Right=�6�   �� 5   
   -   5        $��textBox_BillingDatabase��5   M   $��23��6   $
��Left=�6   $��
140,56,0,0q�69   $	��Top=�6l   $	��190��6�   �� 5   
   -   5        $��button_Save��5   =   $��Update��6   $
��Left=�6"   $��75��6P   $��
335,56,0,0q�6u   $��23��6�   $	��Top=�6�   &   System.Windows.Controls.DataGrid  5   
   -	   5        $��dataGrid_PathTableItems��5   f      AutoGenerateColumns .    AlternatingRowBackground
 ��ح�$��	0,84,0,28q�6S   6�   �� 5   
   -
   5        $��button_Cancel��5   O   $��Refresh��6   $
��Left=�6#   $��0,0,0,0q�6>   $��75��6d   $��23��6�   $��Bottom=�6�   �� 5   
   -   5        $��button_AddEntry��5   P   $��Add New Entry��6   $��23��6)   $
��Left=�65   $��Bottom=�6g   $	��100��6�   $��80,0,0,0q�6�   5      5      