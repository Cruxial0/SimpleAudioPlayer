   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   L HSimpleAudioPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:SimpleAudioPlayer.GUI.ControlsSimpleAudioPlayer.GUI.Controls 5   	   "   SimpleAudioPlayer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   D @ModernWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   5   	   2sys&clr-namespace:System;assembly=mscorlib   5   	   =Controls,clr-namespace:SimpleAudioPlayer.GUI.Controls   5   	   0  *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle  . $��14(�5
       � Title$ Basically Better Spotify��5   	   $
��auto��6*   $
��auto��68   $��0q�6E    � 
ResizeMode$ CanMinimize=�5   	    � SizeToContent$ WidthAndHeight=�5   	    � WindowStyle$ ThreeDBorderWindow=�5   	   .��5      �  � OverridesDefaultStyle . $
��auto��6(    � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5       $
��auto �6   �� 5!      $
��auto �6   �� 5"      $��* �6   �� 5#      $��20 �6   .+�5&   
   &   System.Windows.Controls.DataGrid  -   5          Name$ SongList��5&      $��1��6%   $��1��62   $	��200��5(      $	��300��6#   $	��200��5)      	   
IsReadOnly	 . 
   SelectionMode$
 Single=�5-         SelectionUnit$
 Cell=�6*      CurrentCell 5'      �� *SelectedCell+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.@�5.      1  +SimpleAudioPlayer.GUI.Controls.SongListItem  $
��Left=�6$   $	��169��6?   $	��Top=�6L   $	��796��6d    J� RenderTransformOrigin$ 0.5, 0.5&�6p      	SongTitle$ Caramel Heaven��6�      
background$6 0/SimpleAudioPlayer;component/GUI/Controls/bg.jpg��6�   ��5/      �� 50       �� ImageSource$6 0/SimpleAudioPlayer;component/GUI/Controls/bg.jpg��6!    j� Stretch$ UniformToFill=�6`   z�52      V� 53      .~�54      ��  �� ScaleX$
 0.45Q�6)    �� ScaleY$
 0.45Q�67   55      57      58      � 5:   
   -   5         �Name$ volumeDisplay��5:      $��1��6-   $��2��6=    � Minimum$ 0Q�5;       � Maximum$	 100Q�6"    � SmallChange$ 1Q�5<       � LargeChange$ 10Q�6&    � Value$ 50Q�67   $	��100��5=      $��10��5>      $
��auto��6"   $��0,0,0,0q�5?      �� 5A   
   -   5         ��Name$ 	volumeBar��5A      $��1��6$   $��3��64   $ 0Q�5B      $	 100Q�6   $��30��5C      $
��auto��6   $ 50Q�5D      $ 1Q�6B   $ 10Q�6R   $��0,10,0,0q�5E       .  ��6A   Z� �� 5G   
   -   5         ��Name$ searchBarTxt��5G      $��1��6C   $��4��6S   $��	25,5,25,5q�6`   {�.  6s   �� 5I   
   -   5         ��Name$ SongSelectBtn��5I      $��3��6(   $��2��68   $��Select osu!.db��6E   $	��115��5J      $��10,0,0,0q�6   6/   �� 5L   
   -   5        $ SongStopBtn��5L      $��3��6&   $��3��66   $��Refresh osu!.db��6C   $	��115��5M      $��	10,10,0,0q�6   60   �� 5O   
   -   5        $ SongPauseBtn��5O      $��3��6'   $��4��67   $��Toggle Pause��6D   $	��115��5P      $��	10,10,0,0q�6   60   �� 5R   
   -   5        $ SelectDirectoryBtn��5R      $��3��6-   $��5��6=   $��	Stop Song��6J   $	��115��5S      $��	10,10,0,0q�6   60   �� 5U   
   -	   5        $ ToggleLoopBtn��5U      $��3��6(   $��6��68   $��Toggle Loop��6E   $	��115��5V      $��	10,10,0,0q�6   60   �� 5X   
   -
   5        $ PlaylistTesting��5X      $��3��6*   $��7��6:   $��Playlist��6G   $��	10,10,0,0q�5Y      6$   �� 5[   
   -   5        $ Browse��5[      $��3��6!   $��8��61   $��Browse��6>   $��	10,10,0,0q�5\      6$   �� 5^   
   -   5         ��Name$ NowPlayingTxt��5^      $��Now Playing:��6+   $��1��5_      $��9��6$   $��2��61   $��0,10,0,0q�5`      $
��Left=�6&     �� Padding$  0q�6A   5b      5c      