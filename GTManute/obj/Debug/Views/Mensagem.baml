   M S B A M L   `   `   `  ����C  ?GTManute, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GTManute.ViewsGTManute.Views  5   	       GTManute.Views.Mensagem   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:GTManute.Views     5   	     � Title$  Mensagem��5   	   $	��130��6   $	��270��6'    � WindowStyle$
 None=�63    � 
ResizeMode$ NoResize=�6F    � WindowStartupLocation$ CenterScreen=�5	   	    � AllowsTransparency . ��6H   Z�  � 	Resources 5       	  Abrir �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime	 O� Value
 R� KeyTime  System.Windows.Visibility   Visible R� Value   Hidden 
 Fechar��%�  &	        &	 p    �� 5   
   .��5      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6,   $ 	rectangle��6�   .\�5        $ 0��6'   $	 1Q�63     5      $ 0:0:0.3��6'   $		 9.6Q�69   5      U� 5      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $ 	rectangle��6�   .\�5        $ 0��6'   $	 1Q�63     5      $ 0:0:0.3��6'   $	 4Q�69   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ 	rectangle��6�   .\�5        $ 0��6'   $	 0Q�63     5      $ 0:0:0.3��6'   $	 -107.501Q�69   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $ 	rectangle��6�   .\�5        $ 0��6'   $	 0Q�63     5      $ 0:0:0.3��6'   $	 -37.5Q�69   5      U� 5      $ (Rectangle.RadiusX)�6,   $ 	rectangle��6\   .\�5        $ 0��6'   $	 10Q�63     5      $ 0:0:0.3��6'   $
	 1.01Q�69   5       U� 5!      $ (Rectangle.RadiusY)�6,   $ 	rectangle��6\   .\�5"        $ 0��6'   $	 10Q�63     5#      $ 0:0:0.3��6'   $
	 1.01Q�69   5$      T� 5%      $ (UIElement.Visibility)�6,   $ txt_secundaria��6_   ..�5&      i� $
 0:0:0.3��6)   # Z 6;   5'      T� 5(      $ (UIElement.Visibility)�6,   $
 grid��6_   ..�5)      i� $
 0:0:0.3��6)   # Z 6;   5*      T� 5+      $ (UIElement.Visibility)�6,   $ grid1��6_   ..�5,      i� $
 0:0:0.3��6)   # Z 6;   5-      T� 5.      $ (UIElement.Visibility)�6,   $ textBlock_Copy��6_   ..�5/      i� $
 0:0:0.1��6)   # Z 6;   50      T� 51      $ (UIElement.Visibility)�6,   $ 	txt_fecha��6_   ..�52      i� $
 0:0:0.1��6)   # Z 6;   53      54      �� 55   
   .��56      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6,   $ 	rectangle��6�   .\�57        $ 0:0:0.0��6'   $		 9.6Q�69     58      $ 0:0:0.3��6'   $	 1Q�69   59      U� 5:      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $ 	rectangle��6�   .\�5;        $ 0:0:0.0��6'   $	 4Q�69     5<      $ 0:0:0.3��6'   $	 1Q�69   5=      U� 5>      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ 	rectangle��6�   .\�5?        $ 0:0:0.0��6'   $	 -107.501Q�69     5@      $ 0:0:0.3��6'   $	 0Q�69   5A      U� 5B      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $ 	rectangle��6�   .\�5C        $ 0:0:0.0��6'   $	 -37.5Q�69     5D      $ 0:0:0.3��6'   $	 0Q�69   5E      U� 5F      $ (Rectangle.RadiusX)�6,   $ 	rectangle��6\   .\�5G        $ 0:0:0.0��6'   $
	 1.01Q�69     5H      $ 0:0:0.3��6'   $	 10Q�69   5I      U� 5J      $ (Rectangle.RadiusY)�6,   $ 	rectangle��6\   .\�5K        $ 0:0:0.0��6'   $
	 1.01Q�69     5L      $ 0:0:0.3��6'   $	 10Q�69   5M      T� 5N      $ (UIElement.Visibility)�6,   $ txt_secundaria��6_   ..�5O      i� $
 0:0:0.0��6)   # Z 6;   i� 5P      $
 0:0:0.1��6)   # Z 6;   5Q      T� 5R      $ (UIElement.Visibility)�6,   $
 grid��6_   ..�5S      i� $
 0:0:0.0��6)   # Z 6;   i� 5T      $
 0:0:0.2��6)   # Z 6;   5U      T� 5V      $ (UIElement.Visibility)�6,   $ grid1��6_   ..�5W      i� $
 0:0:0.0��6)   # Z 6;   i� 5X      $
 0:0:0.2��6)   # Z 6;   5Y      T� 5Z      $ (UIElement.Visibility)�6,   $ 	txt_fecha��6_   ..�5[      i� $
 0��6)   # Z 65   i� 5\      $
 0:0:0.2��6)   # Z 6;   5]      T� 5^      $ (UIElement.Visibility)�6,   $ textBlock_Copy��6_   ..�5_      i� $
 0��6)   # Z 65   i� 5`      $
 0:0:0.2��6)   # Z 6;   5a      5b      5c       � Triggers 5d      :� 5e   
    :� RoutedEvent$# UIElement.MouseLeftButtonDown��6    :� 
SourceName$ textBlock_Copy��6C   .[�5f      �� #��[  6   5g      :� 5h   
   $# UIElement.MouseLeftButtonDown��6   $ 	txt_fecha��6C   .[�5i      �� -   5         ��Name$ Fechar_BeginStoryboard��5i      #��[ 6>   5j      .��5l      �  � ColumnDefinitions 5m   
   �� 5n      .+�5p   
   ��   primeiraCor#��[ 6   $��
10,10,10,0q�69     
SegundaCor#��[ 6M    �� RadiusY$ 10��6r    �� RadiusX$ 10��6   �� 5q   
   -   5         ��Name$ txt_principal��5q      $��20,20,20,44q�6+   $
��Wrap=�6@   $��	TextBlock��6T    J� RenderTransformOrigin$ 0.5,0.5&�6e   #���  6�   z�5r      V� 5s      .~�5t      �� �� 5u      �� 5v      T� 5w      5x      5z      � 5{   
   -   5         �Name$ grid_explica��5{      $��Right=�6%   $��25��6A   $��	0,0,15,10q�6M   $��Bottom=�6`   $��25��6{   .+�5|      �� -   5         ��Name$ 	rectangle��5|      #��[ 6+   $ 10��6N   $ 10��6[   $ 0.5,0.5&�6h   z�5}      V� 5~      .~�5      �� �� 5�      �� 5�      T� 5�      5�      5�      �� 5�      -   5        $ textBlock_Copy��5�      $
��Left=�60   $
��Wrap=�6K   $��25��6_   $��25��6j   #��[ 6v    �� TextAlignment$ Center=�6�   $
��Bold"�6�   $��?��6�   $��18(�6�   5�      �� 5�   
   -   5        $ txt_secundaria��5�      $��20,20,20,44q�6,   $
��Wrap=�6A   $��	TextBlock��6U   $ 0.5,0.5&�6f   $y�Hidden=�6�   #���  6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      5�      � 5�   
   -   5        $
 grid��5�      $��30��6   $��
85,0,86,10q�6)   $��Bottom=�6=   � 5�   
   -   5        $ grid1��5�      $��26��6   $��
85,0,86,14q�6*   $��Bottom=�6>   $y�Hidden=�6Y   .+�5�      ��   TerceiraCor#���  6   $
��Left=�6=   $��25��6X   $��0,0.667,0,0q�6d   $ 10��6y   $ 10��6�   
������ $	��Top=�6�   $��99��6�   �� 5�      -	   5        $ btn_ok_segundo��5�      #��[ 60   $
��Wrap=�6Z   $��Entrar��6n   $	��Top=�6|   $��25��6�   $ Center=�6�   $
��Bold"�6�   $��18(�6�   $
��Left=�6�   $��99��6�   6�   5�      �� 5�   
   -
   5        $ 	txt_fecha��5�      $
��Left=�6'   $��230,90,0,15q�6B   $
��Wrap=�6W   $��25��6k   $��25��6v   #��[ 6�   $ Center=�6�   $
��Bold"�6�   $��x��6�   $��18(�6�   $y�Hidden=�6�   �� 5�   
   -   5         ��Name$ btn_ok��5�      $��Ok��6!     	BotaoRosa#��[ 6.   $��98,95,97,10q�6Q   6f   5�      5�      