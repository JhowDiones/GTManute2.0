   M S B A M L   `   `   `  ���� C  ?GTManute, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:GTManute.Views.CadastroGTManute.Views.Cadastro  (    "GTManute.Views.Cadastro.View_Rotas   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7local%clr-namespace:GTManute.Views.Cadastro       � 
ResizeMode$  NoResize=� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� � AllowsTransparency .  � Title$ Veículo��$	��500��$	��800��
������  � 	Resources    abrir_pesquisa W�Name �� 
TargetName �� TargetProperty	 g� Duration
 W� From	 W� To R� KeyTime  System.Windows.Visibility   Visible R� Value  fechar_pesquisa   Hidden��%�  &	        &	 �     �� .��W� $ abrir_pesquisa��$ gridferramenta��$ Height�$	 0:0:00.3D�$
 30X�$	 365X�T� $ (UIElement.Visibility)�$
 grid��..�i� $ 0��# Z �� .��W� $ fechar_pesquisa��$ gridferramenta��$ Height�$	 0:0:00.3D�$	
 365X�$ 30X�T� $ (UIElement.Visibility)�$
 grid��..�i� $ 0��# Z i� $ 0:0:0.3��# Z  � Triggers :�  :� RoutedEvent$ Control.MouseDoubleClick�� :� 
SourceName$ dt_pesquisa��.[��� -    ��Name$% fechar_pesquisa_BeginStoryboard��#��[ :� $# UIElement.MouseLeftButtonDown��$ txt_pesquisa��.[��� #��[  :� $# UIElement.MouseLeftButtonDown��$ btn_Fechar_Copy��.[��� -   $&  fechar_pesquisa_BeginStoryboard1��#��[ .��� -   .+��� $��10q� �� RadiusY$ 10�� �� RadiusX$ 10��  primeiraCor#��[   
SegundaCor#��[ ��   TerceiraCor#��[ $��0��$��Right=�$��30��
���   �$	��Top=�$��30��$ 5��$ 5��$��0,0,0,0q��� -    ��Name$ 
btn_Fechar��$��Right=�$��30��$
��Wrap=�$��x��$	��Top=�$��28��$��20(� �� TextAlignment$ Center=�$
��Bold"�$��0,0,0,0q��� #��[ $
��Left=�$��41��$	��Top=�$��7.332��$��10.47,21.216,0,0q��� -   $ 
textBlock1��$
��Left=�$��	23,14,0,0q�$
��Wrap=�$��Cadastro - Veículo��$	��Top=�$	��537��#��[ $��36(�$
��Bold"� �� 
LineHeight$ 11��� $��35,105,35,65q�.+��� #��[ $��5��$ 10��$ 10��� $��0,0,0,0q� � RowDefinitions �� $��* � � ColumnDefinitions �� $	��.5* ��� $	��.5* �.+�� $��0��$��0��.+��� $��5q�#��[ $ 10��$ 10���� -    ��Name$ groupBox��$
��Rota��$
��Left=�#��[ $��	10,9,0,11q�$	��345��.��� $��0q�.+��� -    ��Name$ label1��$��Partida��$
��Left=�$	��Top=�$	��259��$��0,5,0,0q��� -    ��Name$ txt_partida��#��[ $
��Left=�$��23��$��0,31,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��259�� �� TextAlignment$ Right=�  J� RenderTransformOrigin$  0.5,0.5&��� -	   $ label1_Copy7��$��UF��$
��Left=�$	��Top=�$��55��$��	278,6,0,0q��� -
   ! ��Name$! cmb_ufpartida��" �� 
IsEditable" . #��[ $
��Left=�$��23��$��
278,31,0,0q�$	��Top=�$��55��$  0.5,0.5&��� -   $ label1_Copy��$��Destino��$
��Left=�$	��Top=�$	��259��$��0,59,0,0q��� -   $ txt_destino��#��[ $
��Left=�$��23��$��0,85,0,0q�$
 Wrap=�$	��Top=�$	��259��$ Right=�$  0.5,0.5&��� -   $ label1_Copy2��$��UF��$
��Left=�$	��Top=�$��55��$��
278,59,0,0q��� -   $! cmb_ufdestino��" . #��[ $
��Left=�$��23��$��
278,85,0,0q�$	��Top=�$��55��$  0.5,0.5&��� -   # ��Name$# btn_calcular��  	BotaoRosa#��[ $��Ver distância��$��129,139,129,0q�$	��Top=��� -   $ label1_Copy1��$��
Distância��$
��Left=�$	��Top=�$	��259��$��	0,113,0,0q��� -   $ txt_distancia��#��[ $
��Left=�$��23��$��	0,139,0,0q�$
 Wrap=�$	��Top=�$	��110��$ Right=�$  0.5,0.5&�� $��0��$��1��� $��1��$��2��.+��� $��5q�#��[ $ 10��$ 10���� -   $ groupBox2_Copy��$��Ultimos viagens na rota��#��[ $��10q�.��� $��0q�.+�&   System.Windows.Controls.DataGrid  -   $  Name$$ grid_ultimas��$��0,0,0,10q�� -   % �Name$% gridferramenta��$��
35,70,35,0q�$��30��$	��Top=�.+��� $��0,0,0,0q�#��[ $ 10��$ 10����   
Buscar_ico#��[ $
��Left=�$��5,0,0,0q�$��28��$	��Top=��� -   $ txt_pesquisa_Copy��$��20(�$ Center=�$
��Bold"�#��[ $��0,0,0,0q�$
��Wrap=�$	��Top=��� $� ���� -   $ txt_pesquisa��$��20(�$ Center=�$
��Bold"�#��[ $��0,0,0,0q�$
��Wrap=�$	��Top=��� $�Ferramenta de pesquisa���� #��[ $��0,1,5,0q�$��Right=�$��28��$��28��$	��Top=�� -   $
% grid��$��10,51,10,10q�$y�Hidden=� �� .+�  -   $$ dt_pesquisa��$	��229��$��0,75,0,0q�$	��Top=�	� -   & 	�Name$& 
rad_contem��' d� 	IsChecked$
' TrueY�$��Contem��#��[ $��14(�$��	570,0,0,0q�$	��Top=�	� -   $& 	rad_exata��$��Pesquisa exata��$��
570,23,0,0q�#��[ $��14(�$	��Top=�$y�Hidden=��� -   $ txt_registros��$��Nº de Registros: ��#��[ $ Right=�$��14(�$��
570,46,0,0q�$	��Top=��� -   $ txt_pes_placa��$
��Left=�$��23��$
 Wrap=�$	��Top=�$	��260���� -   $ txt_pes_modelo��$
��Left=�$��23��$��	280,0,0,0q�$
 Wrap=�$	��Top=�$	��260���� #��[ $
��Left=�$��25��$��
441,40,0,0q�$ 10��$ 10��
������ $	��Top=�$��99���� -   $ btn_pesquisar��#��[ $
��Left=�$��
441,40,0,0q�$
��Wrap=�$��	Pesquisar��$	��Top=�$��25��$��99��$ Center=�$
��Bold"�$��18(��� -   $ 	textBlock��$
��Left=�$��	1,-16,0,0q�$
��Wrap=�#��[ $��Partida��$	��Top=�$	��119���� -    $ textBlock12��$
��Left=�$��281,-16,0,0q�$
��Wrap=�#��[ $��Destino��$	��Top=�$	��119���� #��[ $��0��$��Right=�$��30��
���   �$	��Top=�$��30��$ 5��$ 5���� -!   $ btn_Fechar_Copy��$��Right=�$
��Wrap=�$��x��$��28��$��20(�$ Center=�$
��Bold"�$��	0,0,0,274q�� $��50��$��
35,0,35,10q�$��Bottom=�.+��� -"   $# btn_alterar��#��[ $
��Left=�$��Alterar��$��99��$
��Bold"�$��18(�$��316,10,0,15q��� -#   $# btn_novo��#��[ $
��Left=�$
��Novo��$��99��$
��Bold"�$��18(�$��212,10,0,15q��� -$   $# 
btn_delete��#��[ $
��Left=�$��Excluir��$��99��$
��Bold"�$��18(�$��420,10,0,15q�