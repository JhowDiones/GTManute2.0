   M S B A M L   `   `   `  ���� C  ?GTManute, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GTManute.ViewsGTManute.Views      GTManute.Views.Mensagem   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:GTManute.Views       � Title$  Mensagem��$	��130��$	��270�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � AllowsTransparency . ��Z�  � 	Resources  	  Abrir �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime	 O� Value
 R� KeyTime  System.Windows.Visibility   Visible R� Value   Hidden 
 Fechar��%|
  &	        &	 �    �� .��U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�$ 	rectangle��.\�  $ 0��$	 1Q�  $ 0:0:0.3��$		 9.6Q�U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�$ 	rectangle��.\�  $ 0��$	 1Q�  $ 0:0:0.3��$	 4Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ 	rectangle��.\�  $ 0��$	 0Q�  $ 0:0:0.3��$	 -107.501Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�$ 	rectangle��.\�  $ 0��$	 0Q�  $ 0:0:0.3��$	 -37.5Q�U� $ (Rectangle.RadiusX)�$ 	rectangle��.\�  $ 0��$	 10Q�  $ 0:0:0.3��$
	 1.01Q�U� $ (Rectangle.RadiusY)�$ 	rectangle��.\�  $ 0��$	 10Q�  $ 0:0:0.3��$
	 1.01Q�T� $ (UIElement.Visibility)�$ txt_secundaria��..�i� $
 0:0:0.3��# Z T� $ (UIElement.Visibility)�$
 grid��..�i� $
 0:0:0.3��# Z T� $ (UIElement.Visibility)�$ grid1��..�i� $
 0:0:0.3��# Z T� $ (UIElement.Visibility)�$ textBlock_Copy��..�i� $
 0:0:0.1��# Z T� $ (UIElement.Visibility)�$ 	txt_fecha��..�i� $
 0:0:0.1��# Z �� .��U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�$ 	rectangle��.\�  $ 0:0:0.0��$		 9.6Q�  $ 0:0:0.3��$	 1Q�U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�$ 	rectangle��.\�  $ 0:0:0.0��$	 4Q�  $ 0:0:0.3��$	 1Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ 	rectangle��.\�  $ 0:0:0.0��$	 -107.501Q�  $ 0:0:0.3��$	 0Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�$ 	rectangle��.\�  $ 0:0:0.0��$	 -37.5Q�  $ 0:0:0.3��$	 0Q�U� $ (Rectangle.RadiusX)�$ 	rectangle��.\�  $ 0:0:0.0��$
	 1.01Q�  $ 0:0:0.3��$	 10Q�U� $ (Rectangle.RadiusY)�$ 	rectangle��.\�  $ 0:0:0.0��$
	 1.01Q�  $ 0:0:0.3��$	 10Q�T� $ (UIElement.Visibility)�$ txt_secundaria��..�i� $
 0:0:0.0��# Z i� $
 0:0:0.1��# Z T� $ (UIElement.Visibility)�$
 grid��..�i� $
 0:0:0.0��# Z i� $
 0:0:0.2��# Z T� $ (UIElement.Visibility)�$ grid1��..�i� $
 0:0:0.0��# Z i� $
 0:0:0.2��# Z T� $ (UIElement.Visibility)�$ 	txt_fecha��..�i� $
 0��# Z i� $
 0:0:0.2��# Z T� $ (UIElement.Visibility)�$ textBlock_Copy��..�i� $
 0��# Z i� $
 0:0:0.2��# Z  � Triggers :�  :� RoutedEvent$# UIElement.MouseLeftButtonDown�� :� 
SourceName$ textBlock_Copy��.[��� #��[  :� $# UIElement.MouseLeftButtonDown��$ 	txt_fecha��.[��� -    ��Name$ Fechar_BeginStoryboard��#��[ .���  � ColumnDefinitions �� .+���   primeiraCor#��[ $��
10,10,10,0q�  
SegundaCor#��[  �� RadiusY$ 10�� �� RadiusX$ 10���� -    ��Name$ txt_principal��$��20,20,20,44q�$
��Wrap=�$��	TextBlock�� J� RenderTransformOrigin$ 0.5,0.5&�#���  z�V� .~��� �� �� T� � -    �Name$ grid_explica��$��Right=�$��25��$��	0,0,15,10q�$��Bottom=�$��25��.+��� -    ��Name$ 	rectangle��#��[ $ 10��$ 10��$ 0.5,0.5&�z�V� .~��� �� �� T� �� -   $ textBlock_Copy��$
��Left=�$
��Wrap=�$��25��$��25��#��[  �� TextAlignment$ Center=�$
��Bold"�$��?��$��18(��� -   $ txt_secundaria��$��20,20,20,44q�$
��Wrap=�$��	TextBlock��$ 0.5,0.5&�$y�Hidden=�#���  z�V� .~��� �� �� T� � -   $
 grid��$��30��$��
85,0,86,10q�$��Bottom=�� -   $ grid1��$��26��$��
85,0,86,14q�$��Bottom=�$y�Hidden=�.+���   TerceiraCor#���  $
��Left=�$��25��$��0,0.667,0,0q�$ 10��$ 10��
������ $	��Top=�$��99���� -	   $ btn_ok_segundo��#��[ $
��Wrap=�$��Entrar��$	��Top=�$��25��$ Center=�$
��Bold"�$��18(�$
��Left=�$��99���� -
   $ 	txt_fecha��$
��Left=�$��230,90,0,15q�$
��Wrap=�$��25��$��25��#��[ $ Center=�$
��Bold"�$��x��$��18(�$y�Hidden=��� -    ��Name$ btn_ok��$��Ok��  	BotaoRosa#��[ $��98,95,97,10q�