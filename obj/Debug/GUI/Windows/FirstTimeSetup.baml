   M S B A M L   `   `   `  ����L  HSimpleAudioPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SimpleAudioPlayerSimpleAudioPlayer  5   	   &     SimpleAudioPlayer.FirstTimeSetup   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:SimpleAudioPlayer     5   	   $��Segoe UI Light)�5      $��20(�66     � Title$  FirstTimeSetup��5   	   $	��450��6    $	��600��6-    � 
ResizeMode$ CanMinimize=�69    � 	Resources 5	         	Checkmark �� CreateOptions �� CacheOption �� 	UriSource��%�   &	        �� 5
   
   $ IgnoreImageCache=�6(   $ OnLoad=�6I   $� �C:\Users\Benjamin\source\repos\SimpleAudioPlayer\GUI\Windows\604a0cadf94914c7ee6c6e552e9b4487-curved-check-mark-circle-icon-by-vexels.png?�6^   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5       $��20 �6   .+�5#   
   �� $��First time setup��6   $��1��6,   $��1��6<   $��32(�5$      $	��Top=�6"   $��Center=�6:   $��4��5%      �� 5'   
    �� Orientation$ Vertical=�6   $��2��6,   $��1��69   $��4��6I   $��0,20,0,0q�6]   .+�5(      �  5)      �� 5*      $
��auto �6'   �� 5+      $��* �6'    5-      �� 5.      $
��auto �6$   �� 5/      $
��auto �6$   �� 50      $
��auto �6$   �� 51      $
��auto �6$   �� 52      $
��auto �6$   �� 53      $
��auto �6$   �� 54      $��* �6$   .+�57      �� $%��Select osu!.db file (Optional):��6   $��0��6C   $��0��6S   $��0,10,0,0q�6`   �� 58      $-��'Select local song directory (Optional):��6   $��0,10,0,0q�6K   $��0��6]   $��1��6m   �� 5:      -   5        	 ��Name$	 osuDirectoryBtn��5:      $��Select File��62   $��1��6H   $��0��6X   $��30��6e   $��Bottom=�6q   $	��145��5;      $��Right=�6%   6A   �� 5<      -   5        $	 localDirectoryBtn��5<      $��Select Directory��64   $��1��6O   $��1��6_   $��30��6l   $��Bottom=�6x   $	��145��5=      $��Right=�6%   6A   �� 5?      -   5        
 ��Name$
 osuCheck��5?      #���   6*   $
��auto��5@      $��30��6%   $��1��61   $��
61,7,150,0q�6A   $y�Hidden=�5A      �� 5C      -   5        $
 
localCheck��5C      #���   6,   $
��auto��5D      $��30��6%   $��1��61   $��1��6A   $��
61,7,150,0q�6N   $y�Hidden=�5E      �� 5G      -   5        $	 setupFinishBtn��5G      $��Finish��61   $��0��5H      $��2��6)   $��2��66   $��125, 30, 125, 0q�5I      62   5J      5K      5L      5M      