   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem   SimpleAudioPlayer"   SimpleAudioPlayer.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     D @ModernWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   2sys&clr-namespace:System;assembly=mscorlib   0  *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle  . $��14(� � Title$ Basically Better Spotify��$
��auto��$
��auto��$��0q� � 
ResizeMode$ CanMinimize=� � SizeToContent$ WidthAndHeight=� � WindowStyle$ ThreeDBorderWindow=�.���  � OverridesDefaultStyle . $
��auto�� � ColumnDefinitions �� $��20 ��� $
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
��auto ��� $��* ��� $��20 �.+�&   System.Windows.Controls.DataGrid  -     Name$ SongList��$��1��$��1��$	��200��$	��300��$	��200��	   
IsReadOnly	 . 
   SelectionMode$
 Single=�   SelectionUnit$
 Cell=�   CurrentCell �� *SelectedCell+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�� -    �Name$ volumeDisplay��$��1��$��2�� � Minimum$ 0Q� � Maximum$	 100Q� � SmallChange$ 1Q� � LargeChange$ 10Q� � Value$ 50Q�$	��100��$��10��$
��auto��$��0,0,0,0q��� -    ��Name$ 	volumeBar��$��1��$��3��$ 0Q�$	 100Q�$��30��$
��auto��$ 50Q�$ 1Q�$ 10Q�$��0,10,0,0q� .  ��Z� �� -    ��Name$ searchBarTxt��$��1��$��4��$��	25,5,25,5q�{�.  �� -    ��Name$ SongSelectBtn��$��3��$��2��$��Select osu!.db��$	��115��$��10,0,0,0q��� -   $ SongStopBtn��$��3��$��3��$��Refresh osu!.db��$	��115��$��	10,10,0,0q��� -   $ SongPauseBtn��$��3��$��4��$��Toggle Pause��$	��115��$��	10,10,0,0q��� -   $ SelectDirectoryBtn��$��3��$��5��$��	Stop Song��$	��115��$��	10,10,0,0q��� -	   $ ToggleLoopBtn��$��3��$��6��$��Toggle Loop��$	��115��$��	10,10,0,0q��� -
   $ PlaylistTesting��$��3��$��7��$��Playlist��$��	10,10,0,0q��� -   $ Browse��$��3��$��8��$��Browse��$��	10,10,0,0q��� -    ��Name$ NowPlayingTxt��$��Now Playing:��$��1��$��9��$��2��$��0,10,0,0q�$
��Left=� �� Padding$ 0q�