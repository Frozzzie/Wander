   M S B A M L   `   `   `  ����S  OWandererDevelopmentTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:WandererDevelopmentTools.XAMLExtensions'WandererDevelopmentTools.XAMLExtensions  5      >    8WandererDevelopmentTools.CreatureCreation.CreatureEditor   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Eext5clr-namespace:WandererDevelopmentTools.XAMLExtensions     5        � Title$  CreatureEditor��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��AUTO �6   �� 5      $
��AUTO �6   �� 5      $
��AUTO �6   �� 5      $
��AUTO �6    � ColumnDefinitions 5   
   �� 5      $
��AUTO �6   �� 5      $
��AUTO �6   �� 5      $
��AUTO �6   �� 5      $
��AUTO �6   .+�5   
   �� $��0��6   $��1��6%   $��0��69    �� Orientation$ 
Horizontal=�6F   .+�5      �� $��Center=�6   .��66   Creature Name:6F   �� 5      -   5         ��Name$ NameTextBox��5      $��Center=�6+   $��2q�6F   $	��180��6Q   .��6s   Garden Snake6�   5      � 5   
   $��0��6   $��1��6    5      �� 5       $
��AUTO �6    �� 5!      $
��AUTO �6    �� 5"      $
��AUTO �6    �� 5#      $
��AUTO �6    �� 5$      $
��AUTO �6    �� 5%      $
��AUTO �6     5'      �� 5(      $
��AUTO �6#   �� 5)      $
��AUTO �6#   �� 5*      $
��AUTO �6#   .+�5,      >   8WandererDevelopmentTools.XAMLExtensions.IntUpDownControl  -   5          Name$ StrengthControl��5,   @   >   8WandererDevelopmentTools.XAMLExtensions.IntUpDownControl   Changed$ StatControl_Changed��6�   $��0��6#   $��0��60   $
��AUTO��6Y      Number$ 10��6f      	MinNumber$ 0��6r   	   	MaxNumber$		 100��6�   6�     5-      -   5        $ ConstControl��5-   @   $ StatControl_Changed��6�   $��1��6#   $��0��60   $
��AUTO��6V   $ 10��6c   $ 0��6o   $		 100��6}   6�     5.      -   5        $ 
DexControl��5.   @   $ StatControl_Changed��6�   $��2��6#   $��0��60   $
��AUTO��6T   $ 10��6a   $ 0��6m   $		 100��6{   6�     5/      -   5        $ PerceptionControl��5/   @   $ StatControl_Changed��6�   $��3��6#   $��0��60   $
��AUTO��6[   $ 10��6h   $ 0��6t   $		 100��6�   6�     50      -   5        $ 
IntControl��50   @   $ StatControl_Changed��6�   $��4��6#   $��0��60   $
��AUTO��6T   $ 10��6a   $ 0��6m   $		 100��6{   6�     51      -   5        $ 
WisControl��51   @   $ StatControl_Changed��6�   $��5��6#   $��0��60   $
��AUTO��6T   $ 10��6a   $ 0��6m   $		 100��6{   6�   �� 52      $��Strength��6   $��0��6'   $��1��64   $��Center=�6D   $��Center=�6_   �� 53      $��Const��6   $��1��6$   $��1��61   $��Center=�6A   $��Center=�6\   �� 54      $��	Dexterity��6   $��Center=�6(   $��2��6C   $��1��6P   $��Center=�6`   �� 55      $��
Perception��6   $��Center=�6)   $��3��6D   $��1��6Q   �� 56      $��Intelligence��6   $��Center=�6+   $��4��6F   $��1��6S   �� 57      $��Wisdom��6   $��Center=�6%   $��5��6@   $��1��6M   $��Center=�6]   �� 58      -   5        
 ��Name$
 StrModLabel��58      $��Center=�6)   $��Center=�6D   $��+0��6a   $��2��6n   $��0��6~   �� 59      -	   5        $
 ConModLabel��59      $��Center=�6)   $��Center=�6D   $��+0��6a   $��2��6n   $��1��6~   �� 5:      -
   5        $
 DexModLabel��5:      $��Center=�6)   $��Center=�6D   $��+0��6a   $��2��6n   $��2��6~   �� 5;      -   5        $
 PerModLabel��5;      $��Center=�6)   $��Center=�6D   $��+0��6a   $��2��6n   $��3��6~   �� 5<      -   5        $
 IntModLabel��5<      $��Center=�6)   $��Center=�6D   $��+0��6a   $��2��6n   $��4��6~   �� 5=      -   5        $
 WisModLabel��5=      $��Center=�6)   $��Center=�6D   $��+0��6a   $��2��6n   $��5��6~   5>      �� 5@   
   -   5         ��Name$ 
SaveButton��5@      $��2��6>   $��0��6K   $
��Save��6[   �� 5A   
   -   5        $ 
LoadButton��5A      $��3��6>   $��0��6K   $
��Load��6[   5B      5C      