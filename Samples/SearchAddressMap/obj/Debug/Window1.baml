   M S B A M L   `   `   `  ����  SearchAddressMap    SearchAddressMap.Window1   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5          � Title$*  $Sample Application using Google.Maps��5      $	��532��62   $	��700��6?    � 
ResizeMode$ CanMinimize=�6K   .��5      � .+�5   
   �� -   5        $��searchTextBox��5   3   $��23��6   $��12,12,100,0q�6   $	��Top=�6H   .��6`   1000 7th Ave6n   �� 5   
   -   5        $��searchButton��5   0   $��23��6   $��	0,12,12,0q�6   $	��Top=�6D   $��Right=�6\   $��75��6x   .��6�   Search6�   R� 5   
   -   5        $��resultsTreeView��5   (   $��12,0,350,12q�6   $	��332��6y   $��Bottom=�6�   �� 5	   
   -   5        $��image1��5	   #   $��	0,0,12,12q�6   $
��Fill=�61   $��Right=�6@   $	��332��6\   $	��332��6h   $��Bottom=�6u   �� 5
   
   -   5        $��
zoomSlider��5
   0   $��22��6   $��	0,50,12,0q�6   $	��Top=�6B    � Value$ 14Q�6�    � Maximum$ 20Q�6�   $��Right=�6�   $	��143��6�    � SmallChange$ 1Q�6�    � LargeChange$ 2Q�6�    �� TickPlacement$ TopLeft=�6�    �� Interval$ 33��6�    �� IsSnapToTickEnabled . 	 �� TickFrequency$	 4Q�6"  �� 5   
   -   5        $��	zoomLabel��5   0   $��31��6   $��
0,49,144,0q�6   $	��Top=�6A   $��Right=�6Y   $��48��6u   .��6�   Zoom6�   �� 5   
   -   5        $��mapTypeComboBox��5   3   $��23��6   $��
0,49,198,0q�6   $	��Top=�6J   
 �� SelectedIndex$
 0��6�   $��Right=�6�   $	��146��6�   .@�5      �� .��6   	roadmap6$   �� 5      .��6   	satellite6&   �� 5      .��6   hybrid6#   �� 5      .��6   	terrain6$   5      �� 5   
   -	   5        $��border1��5   $   $��	0,0,12,12q�6   $��1q�63   
���   �$��Right=�6[   $	��332��6w   $	��332��6�   $��Bottom=�6�   5      5      