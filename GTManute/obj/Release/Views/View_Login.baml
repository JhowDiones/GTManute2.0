   M S B A M L   `   `   `  ���� C  ?GTManute, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GTManute.ViewsGTManute.Views      GTManute.Views.View_Login   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:GTManute.Views     -     �Name$  
view_login�� � AllowsTransparency .  � Title$ Login��$	��500��$	��500�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=���Z�  � 	Resources    Abrir_Registro �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame	 O� KeyTime
 O� Value R� KeyTime  System.Windows.Visibility   Hidden R� Value   Visible  Fechar_Registro��%L	  &	        &	     �� .��U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�$ 	rectangle��.\�  $	 0:0:0.3��$
 5.237Q�U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�$ 	rectangle��.\�  $	 0:0:0.3��$
 5.872Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ 	rectangle��.\�  $	 0:0:0.3��$

 -125Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�$ 	rectangle��.\�  $	 0:0:0.3��$
 96.973Q�U� $ (Rectangle.RadiusY)�$ 	rectangle��.\�  $	 0:0:0.3��$
 2Q�U� $ (Rectangle.RadiusX)�$ 	rectangle��.\�  $	 0:0:0.3��$
 2Q�T� $ (UIElement.Visibility)�$ Login��..�i� $ 0:0:0.3��# Z T� $ (UIElement.Visibility)�$ 	NovoLogin��..�i� $ 0:0:0.3��# Z T� $ (UIElement.Visibility)�$ 	textBlock��..�i� $ 0:0:0.1��# Z T� $ (UIElement.Visibility)�$ textBlockfechar��..�i� $ 0:0:0.1��# Z �� .��U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�$ 	rectangle��.\�  $	 0:0:0.0��$
 5.239Q�  $	 0:0:0.3��$
 1Q�U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�$ 	rectangle��.\�  $	 0:0:0.0��$
 5.872Q�  $	 0:0:0.3��$
 1Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ 	rectangle��.\�  $	 0:0:0.0��$
 -125.061Q�  $	 0:0:0.3��$
 0Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�$ 	rectangle��.\�  $	 0:0:0.0��$
 96.973Q�  $	 0:0:0.3��$
 0Q�U� $ (Rectangle.RadiusY)�$ 	rectangle��.\�  $	 0:0:0.0��$
 2.607Q�  $	 0:0:0.3��$
 10Q�U� $ (Rectangle.RadiusX)�$ 	rectangle��.\�  $	 0:0:0.0��$
 2.607Q�  $	 0:0:0.3��$
 10Q�T� $ (UIElement.Visibility)�$ Login��..�i� $ 0:0:0.0��# Z i� $ 0:0:0.3��# Z T� $ (UIElement.Visibility)�$ 	NovoLogin��..�i� $ 0:0:0.0��# Z i� $ 0:0:0.3��# Z T� $ (UIElement.Visibility)�$ 	textBlock��..�i� $ 0��# Z i� $ 0:0:0.1��# Z T� $ (UIElement.Visibility)�$ textBlockfechar��..�i� $ 0��# Z i� $ 0:0:0.1��# Z  � Triggers :�  :� RoutedEvent$ UIElement.MouseDown�� :� 
SourceName$ 	textBlock��.[��� #��[  :� $ UIElement.MouseDown��$ textBlock3_Copy��.[��� -    ��Name$% Fechar_Registro_BeginStoryboard��#��[ :� $# UIElement.MouseLeftButtonDown��$ textBlockfechar��.[��� -   $&  Fechar_Registro_BeginStoryboard1��#��[ .��� -   .+��� 
������� �� RadiusY$ 10�� �� RadiusX$ 10��$��130,81,130,90q���   primeiraCor#��[   
SegundaCor#��[ $ 10��$ 10��$	��280��$	��320��$��110,90q��� -    ��Name$ 	rectangle��#��[ $��Center=�$��55��$��360,125,81,0q�$ 10��$ 10��$	��Top=�$��59�� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� �� T� �� -    ��Name$ 	textBlock��$
��Left=�$��360,125,0,0q�$
��Wrap=�$��+��$��55��$��59��#��[  �� TextAlignment$ Center=�$
��Bold"�$	��Top=�$��36(��� -   $ textBlockfechar��$
��Left=�$��360,125,0,0q�$
��Wrap=�$��x��$��55��$��59��#��[ $ Center=�$
��Bold"�$	��Top=�$��36(�$y�Hidden=�� -    �Name$ Login��$��110,118,155,104q�.+��� #��[ $��Center=�$��41��$	��Top=�$��10��$��	0,7,225,0q��� -	   $ 
textBlock1��$
��Left=�$��15,0,0,0q�$
��Wrap=�$��Login��$	��Top=�$��55��$	��183��#��[ $��36(�$
��Bold"� �� 
LineHeight$ 11���� #��[ $��2��$��
45,124,0,0q�
������ $	��Top=��� -
    ��Name$ txt_usuario��$
��Left=�$��Usuário��$��24��$��
45,100,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��190�����	#FF747171��Z� ��Z�  �� SelectionBrush Z� �� #��[ $��2��$��
45,174,0,0q�
������ $	��Top=�G� -    G�Name$ 	txt_senha��$
��Left=� G� Password$ ********��$��24��$��
45,150,0,0q�$	��Top=�$	��190�����	#FF747171��Z� ��Z�   G� SelectionBrush  Z� �� -   $ 
textBlock2��$
��Left=�$��
45,262,0,0q�$
��Wrap=�$��Esqueceu a senha?��$	��Top=�$	��190��$ Center=����	#FF747171�� -   ! ��Name$! 
btn_entrar��  	BotaoRosa#��[ $��
88,232,0,0q�$��Entrar��$	��Top=�$��25��$
��Bold"�$��18(�$
��Left=�$��99��� -   $ 	NovoLogin��$��110,118,155,104q�$y�Hidden=�.+��� #��[ $��Center=�$��41��$	��Top=�$��10��$��	0,7,225,0q��� -   $ textBlock1_Copy��$
��Left=�$��15,0,0,0q�$
��Wrap=�$��
Novo Login��$	��Top=�$��55��$	��210��#��[ $��36(�$
��Bold"�$ 11���� #��[ $��2��$��
45,119,0,0q�
������ $	��Top=��� -   $ txt_Novo_Usuario��$
��Left=�$��24��$��	45,95,0,0q�$
 Wrap=�$��Usuário��$	��Top=�$	��190�����	#FF747171��Z� ��Z�  Z� �� #��[ $��2��$��
45,159,0,0q�
������ $	��Top=�G� -   $ txt_Novo_Senha��$
��Left=�$ ********��$��24��$��
45,135,0,0q�$	��Top=�$	��190�����	#FF747171��Z� ��Z�   Z� �� #��[ $
��Left=�$��25��$��
88,232,0,0q�$ 10��$ 10��
������ $	��Top=�$��99���� -   $ textBlock3_Copy��#��[ $
��Left=�$��
94,232,0,0q�$
��Wrap=�$��	Cadastrar��$	��Top=�$��25��$��87��$ Center=�$
��Bold"�$��18(��� #��[ $��2��$��
45,200,0,0q�
������ $	��Top=�G� -   $ txt_Novo_ConfirmaSenha��$
��Left=�$ ********��$��24��$��
45,176,0,0q�$	��Top=�$	��190�����	#FF747171��Z� ��Z�   Z� ��   TerceiraCor#���  $��0��$��Right=�$��30��$��	0,75,95,0q�
���   �$	��Top=�$��30��$ 10��$ 10���� -   $ 
btn_Fechar��$��Right=�$��30��$��	0,74,96,0q�$
��Wrap=�$��x��$	��Top=�$��29��$��20(�$ Center=�$
��Bold"��� -   " ��Name$" 
btn_config��  config_banco#��[ $
��Left=�$��59��$��326,341,0,0q�$	��Top=�$��59���� -   $" image��$
��Left=�  logo_JW#��[ $��78��$��110,332,0,0q�$	��Top=�$��85��