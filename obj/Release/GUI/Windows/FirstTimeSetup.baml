   M S B A M L   `   `   `  ���� L  HSimpleAudioPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SimpleAudioPlayerSimpleAudioPlayer  &     SimpleAudioPlayer.FirstTimeSetup   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:SimpleAudioPlayer     $��Segoe UI Light)�$��20(�  � Title$  FirstTimeSetup��$	��450��$	��600�� � 
ResizeMode$ CanMinimize=� � 	Resources    	Checkmark �� CreateOptions �� CacheOption �� 	UriSource��%�   &	        �� $ IgnoreImageCache=�$ OnLoad=�$� �C:\Users\Benjamin\source\repos\SimpleAudioPlayer\GUI\Windows\604a0cadf94914c7ee6c6e552e9b4487-curved-check-mark-circle-icon-by-vexels.png?�.���  � ColumnDefinitions �� $��20 ��� $
��auto ��� $
��auto ��� $
��auto ��� $��* ��� $��20 � � RowDefinitions �� $��20 ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��* ��� $��20 �.+��� $��First time setup��$��1��$��1��$��32(�$	��Top=�$��Center=�$��4����  �� Orientation$ Vertical=�$��2��$��1��$��4��$��0,20,0,0q�.+��  �� $
��auto ��� $��* � �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��* �.+��� $%��Select osu!.db file (Optional):��$��0��$��0��$��0,10,0,0q��� $-��'Select local song directory (Optional):��$��0,10,0,0q�$��0��$��1���� -   	 ��Name$	 osuDirectoryBtn��$��Select File��$��1��$��0��$��30��$��Bottom=�$	��145��$��Right=��� -   $	 localDirectoryBtn��$��Select Directory��$��1��$��1��$��30��$��Bottom=�$	��145��$��Right=��� -   
 ��Name$
 osuCheck��#���   $
��auto��$��30��$��1��$��
61,7,150,0q�$y�Hidden=��� -   $
 
localCheck��#���   $
��auto��$��30��$��1��$��1��$��
61,7,150,0q�$y�Hidden=��� -   $	 setupFinishBtn��$��Finish��$��0��$��2��$��2��$��125, 30, 125, 0q�