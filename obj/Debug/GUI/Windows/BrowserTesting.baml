   M S B A M L   `   `   `  ����L  HSimpleAudioPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SimpleAudioPlayerSimpleAudioPlayer  5   	   &     SimpleAudioPlayer.BrowserTesting   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:SimpleAudioPlayer     5   	   $��18(�5        � Title$  BrowserTesting��5   	   $
��auto��6    $	��800��6.    � SizeToContent$ WidthAndHeight=�5	   	    � 
ResizeMode$ NoResize=�6(    � WindowStyle$ 
ToolWindow=�6>    J� CommandBindings 5
      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$# NavigationCommands.BrowseBack��5      6d     5   
   -   5        $&  NavigationCommands.BrowseForward��5      6j     5   
   -   5        $! NavigationCommands.GoToPage��5      6`   .��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��20 �6   .+�5   
   ]� $��1��6   $��1��6$   $��2��61   $	��400��6E   .+�5      c� $	��Top=�6   .@�5      �� $#��NavigationCommands.BrowseBack��6   �� 5      $&�� NavigationCommands.BrowseForward��6   �� 5       �� 5!      -   5        $��txtUrl��5!      $	��300��6(   64   �� 5"      $!��NavigationCommands.GoToPage��6   5#      (  "System.Windows.Controls.WebBrowser  5$      -   5        $��	WBBrowser��5$      $	��736��6L   5%      �� 5&   
   $��1��6   $��2��6%    �� Orientation$ 
Horizontal=�62   $��0,10,0,0q�6K   .+�5'      �� -   5        	 ��Name$	 
btnAddSong��5'      $��Add Song��6)   6<   5(      5)      5*      