   M S B A M L   `   `   `  ����G  CDuplexClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:DuplexClientDuplexClient  5   	       DuplexClient.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:DuplexClient     5   	     � Title$  
MainWindow��5   	   
�������$	��600��6/   $	��800��6<   .��5	      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� -   5         ��Name$ 	userLabel��5      $��User: ��6'   $
��Wrap=�65   $��Stretch=�6I   $��Stretch=�6g   $��24(�6�   �� 5   
   -   5        $ streamingCode��5      $��Streaming Code: ��6+   $
��Wrap=�6C   $��1��6W   $��Stretch=�6d   $��Stretch=�6�   $��22(�6�   �� 5   
   -   5         ��Name$ toggleButton��5      $��Toogle Stream��6'   $��1��6?   $��Stretch=�6O   $��3��6m   $��Stretch=�6z   $��36(�6�   #��� ��6�    J� Opacity$	 0.7Q�6�   $��Segoe WP Black)�6�   6  �� 5   
   -   5         ��Name$ statusLabel��5      
���  ��$��Streaming: OFF��66   $��Stretch=�6O   $��Stretch=�6m   $��1��6�   $��2��6�   $��48(�6�   #��� ��6�   $��Segoe WP Black)�6   5      5      