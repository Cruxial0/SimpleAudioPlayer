   M S B A M L   `   `   `  ����L  HSimpleAudioPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:SimpleAudioPlayer.GUI.ControlsSimpleAudioPlayer.GUI.Controls  5      1    +SimpleAudioPlayer.GUI.Controls.SongListItem   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:SimpleAudioPlayer.GUI.Controls     5      $	��170��5      $	��800��6,     � UseLayoutRounding  .   J� RenderTransformOrigin$ 100,100&�6R   ���	#00000000���	#00000000.��5      �� -   5         ��Name$ ImageBorder��5       �� CornerRadius$ 12,12,12,12��6"   
������ $��1q�5
       �� Padding$ 0q�5      z�5   
   V� 5      .~�5      �� �� 5      �� 5      T� 5      5      ��5   
   �� 5       j� Stretch$ UniformToFill=�6E    �� ImageSource 6   �� *SongImageBackground+6E   ._�5   
   � -   5         �Name$ Overlay_Fade��5      $
��Left=�6%   $	��170��6@   $	��Top=�6M   $	��800��6e   ���	#A5000000.+�5      �� -   5         ��Name$ lblSongName��5      $��Caramel Heaven��6)   $
��Left=�6B   $��	10,10,0,0q�6]   $	��Top=�6p   
�������$��Segoe UI Light)�6�   $��35(�6�   $	��659��6�   �� 5      -   5        $ 	lblArtist��5      $��
Last Note.��6'   $
��Left=�6<   $��	10,60,0,0q�6W   $	��Top=�6j   
�������$��20(�6�   $��Segoe UI Light)�6�   $	��659��6�   �� 5      -   5        $ lblSongLength��5      $��3m 52s��6+   $
��Left=�6<   $��	10,87,0,0q�6W   $	��Top=�6j   
�������$��20(�6�   $��Segoe UI Light)�6�   $	��659��6�   �� 5      -   5        $ lblFileOrigin��5      $
��osu!��6+   $
��Left=�6:   $��
10,113,0,0q�6U   $	��Top=�6i   
�������$��20(�6�   $��Segoe UI Light)�6�   $	��659��6�   �� 5      -   5        	 ��Name$	 imgBackground��5      $
��Left=�6+   $	��100��6F   $	��Top=�6S   $	��100��6k   $��
674,34,0,0q�6w   $��PlayButton.png��6�   $��UniformToFill=�6�   {�.  
 J� OpacityMask
 5      �� 5      $ Triangle@0,5x.png��6!   $ UniformToFill=�6A    J� Effect 5!      3  -System.Windows.Media.Effects.DropShadowEffect  5"         
BlurRadius$ 10Q�6'      Opacity$	 0.3Q�67   5$      �� 5%      -   5        $ hiddenFilePath��5%      $��Label��6,   $
��Left=�6<   $��131,150,0,0q�6W   $	��Top=�6l   $y�Hidden=�6�   5&      5'      5(      