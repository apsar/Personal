   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.4.3.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   B >Starvis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:StarvisStarvis 5   	   >/clr-namespace:ControlzEx;assembly=MahApps.Metro
ControlzEx  5   	      Starvis.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   'localclr-namespace:Starvis     5   	   F
ControlzEx/clr-namespace:ControlzEx;assembly=MahApps.Metro     5   	   -   5        (   "MahApps.Metro.Controls.MetroWindow   Name$  MainWindowTest��5   	   $��2q�5
   	    � 
ResizeMode$ NoResize=�5   	      WindowTitleBrush �#70D08A   	GlowBrush �	#FF82CA96   WindowTransitionsEnabled .   � WindowStartupLocation$ CenterScreen=�5   	    � Title$ Starvis��5   	   $��500.442��6   $��614.777��6*   ��6:   Z�  � 	Resources 5         sbShowLeftMenu �� TargetProperty	 t� From	
 t� To g� DecelerationRatio g� Duration  sbHideLeftMenu g� AccelerationRatio��%  &	        &	 �     �� 5   
   .��5      t� $ Margin�6!   $	 
-150,0,0,0X�6D   $
 0,0,0,0X�6V   $ .9Q�6c   $ 0:0:1D�6z   5      �� 5   
   .��5      t� $ Margin�6!   $	 0,0,0,0X�6D   $
 
-150,0,0,0X�6S   $ .9Q�6c   $ 0:0:1D�6z   5      5      .��5      � .+�5    
   �� ��5!      �� 5"       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5#      �  � Color$ Black��6#    � Offset$ 0Q�61   � 5$      $ 	#FF434346��6#   $ 1Q�65   5%      .+�5(      � .+�5*      ��  K� ZIndex$ 2��6   $	��604��6/   
 �� Top$ 47��6;   $��0,0,0,0q�6K   .+�5+      � $��95��6   ��5,      �� 5-      $ 0.5,1&�62   $ 0.5,0&�6C   .��5.   "   � $ Black��6/   $ 0Q�6=   � 5/   "   $ 	#FF53C271��6/   $ 0.135Q�6A   50      .+�53      �� -   5         ��Name$ MainText��53   N   $��10,31,149,22q�6"   *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Type Your Command....��6`    J� RenderTransformOrigin$ 0.774,0.414&�6�   �� 54      -   5        $
��Left=�54   !   $��
518,31,0,0q�6<   $	��Top=�6P   $��52��6h   $
��42px��6s   .��55      �� $*��$/images/appbar.microphone.google.png��6$   $
��32px��6R   $
��32px��6_   56      57      � 58      $	��438��6   ��59      �� 5:      $ 0.5,1&�62   $ 0.5,0&�6C   .��5;   "   � $ Black��6/   $ 0Q�6=   � 5<   "   $ 	#FFE0E0E0��6/   5=       � ColumnDefinitions 5?      �� 5@      $��* �6/   �� 5A      $��* �6/   �� 5B      $��* �6/    � RowDefinitions 5E      �� 5F      $��0* �6,   �� 5G      $	��184 �6,   �� 5H      $��2* �6,   �� 5I      $	��83* �6,   .+�5K      �� -   5         ��Name$ pnlLeftMenu��5K   6   $ 2��6%    �� Orientation$ 
Horizontal=�6K   $
��Left=�6d   $��-150,0,0,0.4q�6   $��4��6�   $	��301��6�   .+�5L      �� $��0,0,0,8q�6&   $	��140��6@   ���	#FF53C271$��	0,0,0,0.4q�6c   ._�5M   "   �� -   5         ��Name$
 Tabs��5M   -    �� TabStripPlacement$ Right=�6<   $	��428��6�   $	��Top=�6�   $��0,10,0,-7.6q�6�   ���	#FF53C271���	#FF53C271 5N   &    �� 
TargetType  HeaderTextBlockStyle �� Triggers �� Binding  �� RelativeSource! �� AncestorType" �� Value# �� Property$ �� Value��%�   &	       �� 5P   *   " ��60    5Q   .   �� 5R   2    6>   �� *
IsSelected+  �� "! ��" True5S      .a�5U   6   �� # � ��$ �	#FF38A97F6U   5W   3   5Y   +   5\   '   .@�5_   &   �� -   5        % ��Name$% Arena��5_   /   $��50��6>   $	��162��6J   ��5a   *   �� 5b   .   $	 0,1&�6B   $	 0,0&�6Q   .��5c   2   � $ 	#FFF0F0F0��6?   $ 0Q�6Q   � 5d   2   $ 	#FF53C271��6?   $ 0.029Q�6Q   5e   /   ��5g   *   �� 5i   .   $��Center=�5j   5   $��Center=�6Q   $��Tahoma)�5k   5   $��
UltraLight"�5l   5   & �� 
LineHeight$& 30��5m   5   $��SemiExpanded&�5n   5   
�������&   System.Windows.Media.TextOptions'   TextFormattingMode$' Display=�5p   5   #��[ 5s   -   $��50��6\   $	��162��6h   �� 5t      .F�5u   6   �� -   5        ( ��Name$
( img4��5u   =   $.��(/images/appbar.social.apple.appstore.png��6M   $��+10,+10,+10,+10q�6   $
��32px��6�   $
��32px��6�   5v   3   �� 6F   $� ��6J   �� 6U   .F�5w   6   �� $��+10,+15,+10,+10q�6A   $��69��6Z   .+�5x   :   �� �� 6E   $�Arena��6I   6Y   5z   7   5{   3   6G   5�   '   �� 5�   &   -   5        $% Outlook��5�   .   $��50��6?   $	��162��6K   ��5�   *   �� 5�   .   $	 0,1&�6B   $	 0,0&�6Q   .��5�   2   � $ 	#FFF0F0F0��6?   $ 0Q�6Q   � 5�   2   $ 	#FF53C271��6?   $ 0.029Q�6Q   5�   /   ��5�   *   �� 5�   .   $��Center=�69   $��Center=�6U   $��Tahoma)�5�   5   $��
UltraLight"�5�   5   $& 30��5�   5   $��SemiExpanded&�5�   5   
�������$' Display=�5�   5   #��[ 5�   -   $��50��6[   $	��162��6g   �� 5�      .F�5�   6   �� -	   5        $
( img2��5�   =   $'��!/images/appbar.office.outlook.png��6M   $��+10,+10,+10,+10q�6x   $
��32px��6�   $
��32px��6�   5�   3   �� 6F   $� ��6J   �� 6U   .F�5�   6   �� $��+10,+15,+10,+10q�6A   $��69��6Z   .+�5�   :   �� �� 6E   $�Outlook��6I   6[   5�   7   5�   3   6G   5�   '   �� 5�   &   -
   5        $
% Jira��5�   .   $��Right=�6<   $��50��6X   $	��162��6d   $��Segoe UI Semibold)�6p   ��5�   *   �� 5�   .   $	 0,1&�6B   $	 0,0&�6Q   .��5�   2   � $ 	#FFF0F0F0��6?   $ 0Q�6Q   � 5�   2   $ 	#FF53C271��6?   $ 0.029Q�6Q   5�   /   ��5�   *   �� 5�   .   $��Center=�6;   $��Center=�6W   $��Tahoma)�5�   5   $��
UltraLight"�5�   5   $& 30��5�   5   ) �� TextAlignment$
) Left=�5�   7   $��SemiExpanded&�5�   5   
�������$' Display=�5�   5   #��[ 5�   -   $��60��6[   $	��162��6g   �� 6t   .F�5�   6   �� -   5        $
( img3��5�   =   $$��/images/appbar.social.jira.png��6M   $��+10,+10,+10,+10q�6u   $
��32px��6�   $
��32px��6�   5�   3   �� 6F   $� ��6J   �� 6U   .F�5�   6   �� $��+10,+15,+10,+10q�6A   $��69��6Z   .+�5�   :   �� �� 6E   $
�Jira��6I   6X   5�   7   5�   3   6G   5�   '   �� 5  &   -   5        $% HotKey��5  /   $��50��6?   $	��162��6K   ��5  *   �� 5  .   $	 0,1&�6B   $	 0,0&�6Q   .��5  2   � $ 	#FFF0F0F0��6?   $ 0Q�6Q   � 5  2   $ 	#FF53C271��6?   $ 0.029Q�6Q   5  /   ��5  *   �� 5!  .   $��Center=�5"  5   $��Center=�6Q   $��Tahoma)�5#  5   $��
UltraLight"�5$  5   $& 30��5%  5   $��SemiExpanded&�5&  5   
�������$' Display=�5(  5   #��[ 5+  -   $��50��6\   $	��162��6h   �� 5,     .F�5-  6   �� -   5        $
( img7��5-  =   $/��)/images/appbar.clipboard.variant.text.png��6M   $��+10,+10,+10,+10q�6�   $
��32px��6�   $
��32px��6�   5.  3   �� 6F   $� ��6J   �� 6U   .F�5/  6   �� $��+10,+15,+10,+10q�6A   $��69��6Z   .+�50  :   �� �� 6E   $�HotKey��6I   6Z   52  7   53  3   6G   5<  '   �� 5>  &   -   5        $% Browse��5>  /   $��50��6?   $	��162��6K   ��5@  *   �� 5A  .   $	 0,1&�6B   $	 0,0&�6Q   .��5B  2   � $ 	#FFF0F0F0��6?   $ 0Q�6Q   � 5C  2   $ 	#FF53C271��6?   $ 0.029Q�6Q   5D  /   ��5F  *   �� 5H  .   $��Center=�5I  5   $��Center=�6Q   $��Tahoma)�5J  5   $��
UltraLight"�5K  5   $& 30��5L  5   $��SemiExpanded&�5M  5   
�������$' Display=�5O  5   #��[ 5R  -   $��50��6\   $	��162��6h   �� 5S     .F�5T  6   �� -   5        $
( img8��5T  =   $%��/images/appbar.browser.wire.png��6M   $��+10,+10,+10,+10q�6v   $
��32px��6�   $
��32px��6�   5U  3   �� 6F   $� ��6J   �� 6U   .F�5V  6   �� $��+10,+15,+10,+10q�6A   $��69��6Z   .+�5W  :   �� �� 6E   $�Browse��6I   6Z   5Y  7   5Z  3   6G   5c  '   �� 5f  &   -   5        $% Settings��5f  /   $��50��6A   $	��162��6M   ��5h  *   �� 5i  .   $	 0,1&�6B   $	 0,0&�6Q   .��5j  2   � $ 	#FFF0F0F0��6?   $ 0Q�6Q   � 5k  2   $ 	#FF53C271��6?   $ 0.029Q�6Q   5l  /   ��5n  *   �� 5p  .   $��Center=�5q  5   $��Center=�6Q   $��Tahoma)�5r  5   $��
UltraLight"�5s  5   $& 30��5t  5   $��SemiExpanded&�5u  5   
�������$' Display=�5w  5   #��[ 5z  -   $��50��6\   $	��162��6h   �� 5{     .F�5|  6   �� -   5        $
( img6��5|  =   $!��/images/appbar.settings.png��6M   $��+10,+10,+10,+10q�6r   $
��32px��6�   $
��32px��6�   5}  3   �� 6F   $� ��6J   �� 6U   .F�5~  6   �� $��+10,+15,+10,+10q�6A   $��69��6Z   .+�5  :   �� �� 6E   $�Settings��6I   6\   5�  7   5�  3   6G   5�  '   5�  #   5�     � 5�     .+�5�  "   �� -   5        * ��Name$* btnLeftMenuHide��5�  )   $
��52px��6B   $
��52px��6O   + J� Opacity$	+ 0.3Q�6{   $y�Hidden=�6�   .��5�  &   �� $&�� /images/appbar.chevron.right.png��6,   $
��16px��6V   $
��16px��6c   5�  #   �� 5�  "   -   5        $* btnLeftMenuShow��5�  )   $
��52px��6B   $
��52px��6O   $	+ 0.3Q�6]   .��5�  &   �� $%��/images/appbar.chevron.left.png��6,   $
��16px��6U   $
��16px��6b   5�  #   5�     5�     �� 5�     $��hello��6    $��0,0,5.6,184q�60   $��2��6E   � 5�     $��9.8,10,10,21.4q�6   $��4��67   $��2��6H    5�     �� 5�  "   .+�5�       Starvis.Profile  -   5        ,  Name$, 
ProfileTab��5�  ,     Starvis.Profile-   Loaded$- Profiles_Loaded��6n   $	��Top=�6@   $��-280,0,0.4,0q�6X   $	��358��6�   $y�Visible=�6�   $��Right=�6�   $	��397��6�     Starvis.Outlook  5�     -   5        .  Name$. 
OutlookTab��5�  ,   $	��Top=�6@   $��-280px,0,0.4,0q�6X   $	��526��6q   $	��358��6}   $y�Hidden=�6�     Starvis.Jira  5�     -   5        /  Name$/ JiraTab��5�  )   $	��Top=�6:   $��-280px,0,0.4,0q�6R   $	��526��6k   $	��358��6w   $y�Hidden=�6�     Starvis.Code  5�     -   5        0  Name$0 VisualStudioTab��5�  )   $	��Top=�6B   $��-280px,0,0.4,0q�6Z   $	��526��6s   $	��358��6   $y�Hidden=�6�   	  Starvis.Arena	  5�     -   5        1 	 Name$1 ArenaTab��5�  *   $	��Top=�6<   $��-280px,0,0.4,0q�6T   $	��526��6m   $	��358��6y   $y�Hidden=�6�   
  Starvis.Settings
  5�     -   5        2 
 Name$2 SettingsTab��5�  -   $	��Top=�6B   $��-280px,0,0.4,0q�6Z   $	��526��6s   $	��358��6   $y�Hidden=�6�     Starvis.Browse  5�     -   5        3  Name$3 	BrowseTab��5�  +   $	��Top=�6>   $��-280px,0,0.4,0q�6V   $	��526��6o   $	��358��6{   $y�Hidden=�6�     Starvis.HotKey  5�     -   5        4  Name$4 	HotKeyTab��5�  +   $	��Top=�6>   $��-280px,0,0.4,0q�6V   $	��526��6o   $	��358��6{   $y�Hidden=�6�   5�     5�     5�     5�     5�     5�     5�     