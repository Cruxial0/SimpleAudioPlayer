   M S B A M L   `   `   `  ���� L  HSimpleAudioPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SimpleAudioPlayerSimpleAudioPlayer  '    !SimpleAudioPlayer.PlaylistManager   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:SimpleAudioPlayer       � 
ResizeMode$  NoResize=� � SizeToContent$ WidthAndHeight=� � Title$ PlaylistManager��$	��450��$��734.836��.���  � ColumnDefinitions �� $��20 ��� $
��auto ��� $
��auto ��� $��* ��� $��20 � � RowDefinitions �� $��20 ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��* ��� $��20 �.+�&   System.Windows.Controls.DataGrid  -     Name$ Playlist��$��1��$��1��$	��250��$	��450��$	��250��$	��450��   
IsReadOnly .    SelectionMode$ Single=�   SelectionUnit$
 Cell=�	   CurrentCell	 �� *SelectedCell+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� -    ��Name$ SongModifyPanel��$��2��$��1��$	��120��$��0,10,0,0q����	#7F9C9C9C{�.  .+��  �� $
��auto ��� $
��auto ��� $��* � �� $
��auto ��� $
��auto ��� $
��auto �.+��� -    ��Name$ songNameTxt�� � ToolTip$&  Name of currently selected song.��$��5,10,0,0q�$	��240��$��25���� -   $ 	SongIdTxt��$$ ID of currently selected song.��$��5,10,0,0q�$	��240��$��25��$��1���� -   $ SongPathTxt��$/ )File path of the currently selected song.��$��5,10,0,0q�$	��240��$��25��$��2���� -    ��Name$ VerifyApplyBtn��$��Verify and Apply��$��1��$��2��$��50, 10, 5, 0q��� -   $ FileLocationBtn��$��Select file location��$��1��$��1��$��2��$��50, 10, 5, 0q��� -   $ OpenFileBtn��$��Open file location��$��1��$��2��$��2��$��50, 10, 5, 0q��� -	   $ PlaylistManagementPanel��$��1��$��2��$��2��$��10,0,0,0q�$
��auto�����	#7F9C9C9C{�. .+��  �� $
��auto ��� $
��auto ��� $��* � �� $
��auto ��� $
��auto ��� $��* �.+��� -
   $ PlaylistCreateBtn��$��Create Playlist��$	��100��$��45��$��9,10,0,0q��� -   $ PlaylistSelectBtn��$��Select Playlist��$	��100��$��45��$��	9,10,10,0q�$��1���� -   $ SongFileRightBtn��$��1��$��2��$��10q�$��25���� -    ��Name$ 	ModeLabel��$$��Current Mode: Modify disabled.��$��9,75,0,0q�$��2��$��2��
���  ���� -   $ VerifyPlaylistBtn��$��Verify Playlist��$	��100��$��45��$��9,95,0,0q�$��Bottom=�$��2��d� -    d�Name$ 
ToggleMode��$��Toggle Modify��$	��100��$��45��$��	9,95,10,0q�$��Bottom=�$��2��$��1���� -   $ PlaylistModifyPanel��$��2��$��2��$��2��$��	10,10,0,0q�$
��auto�����	#7F9C9C9C{�.  .+��  �� $
��auto ��� $
��auto ��� $��* � �� $
��auto ��� $
��auto ��� $��* �.+��� -   $ RenamePlaylistBtn��$��Rename Playlist��$	��100��$��45��$��9,10,0,0q��� -   $ NewDirectoryBtn��$��New Directory��$	��100��$��45��$��	9,10,10,0q�$��1���� -   $ PlaylistApplyChangesBtn��$��Apply Changes��$��0��$��1��$��
10,10,10,0q�$��45��$��2��