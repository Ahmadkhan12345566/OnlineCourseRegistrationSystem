   M S B A M L   `   `   `  ����G  CLoginProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:LoginProjectLoginProject  5   	       LoginProject.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:LoginProject     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6    � Offset$ 0Q�6-   � 5      $ 	#FFF55151��6   $ 0.161Q�61   5       � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $��* �6   .+�5$   
   �� -   5         ��Name$ 
labelLogin��5$      $��0��5%      $��2��5&      $��Center=�5'      $��Login��5(      $��49��5)      $��89��5*      $��30(�5+      $
��Bold"�5,      �� 5/   
   -   5        $ 	labelName��5/      $��Userame:��50      $��1��51      $��0��52      $��Center=�53      $��Center=�54      $��Black"�55      $��15(�56      �� 59   
   -   5        $ labelPassword��59      $��	Password:��5:      $��2��5;      $��0��5<      $��Center=�5=      $��Center=�5>      $��Black"�5?      $��15(�5@      �� 5B   
   -   5         ��Name$ textBox��5B      $��1��5C      $��1��5D      $��Stretch=�5E      $��Center=�5F      $��25��5G      $��0,0,90,0q�5H      G� 5J   
   -   5        	 G�Name$	 loginPasswordBox��5J      $��2��5K      $��1��5L      $��Stretch=�5M      $��Center=�5N      $��0,0,90,0q�5O      $��25��5P      �� 5Q   
   
 �� Orientation$
 
Horizontal=�5S      $��2��5T      $��3��5U      $��Center=�5V      .+�5Z   
   �� -   5         ��Name$ 
buttonExit��5Z      $
��Exit��5[      $��3��5\      $��1��5]      $
��Left=�5^      $��Center=�5_      $��Black"�5`      $��20,15,20,15q�5a      $��	10,5,10,5q�5b      6%   �� 5e   
   -   5        $ buttonLogin��5e      $��Login��5f      $��3��5g      $��1��5h      $��Center=�5i      $��Center=�5j      $��Black"�5k      $��20,15,20,15q�5l      $��	10,5,10,5q�5m      �� 5p      -   5        $ buttonSignup��5p      $��SignUp��5q      $��3��5r      $��1��5s      $��Center=�5t      $��Center=�5u      $��Black"�5v      $��20,15,20,15q�5w      $��	10,5,10,5q�5x      6)   5|      5      5�      