   M S B A M L   `   `   `  ���� C  ?GTManute, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:GTManute.Views.CadastroGTManute.Views.Cadastro  (    "GTManute.Views.Cadastro.View_Frota   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7local%clr-namespace:GTManute.Views.Cadastro       � 
ResizeMode$  NoResize=� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� � AllowsTransparency .  � Title$ Veículo��$	��560��$	��800��
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
LineHeight$ 11��� $��35,105,35,65q�.+��� #��[ $��5��$ 10��$ 10��� $��0,0,0,0q� � RowDefinitions �� $��* � � ColumnDefinitions �� $	��.5* ��� $	��.5* �.+�� $��0��$��0��.+��� $��5q�#��[ $ 10��$ 10���� -    ��Name$ groupBox��$��Dados fornecedor��#��[ $��10q�.��� $��0q�.+��� -    ��Name$ label1��$��Placa��$
��Left=�$	��Top=�$��90���� -    ��Name$ 	txt_placa��#��[ $
��Left=�$��23��$��0,26,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$��90�� �� TextAlignment$ Right=�  J� RenderTransformOrigin$  0.5,0.5&��� -	   $ label1_Copy4��$��Marca��$	��Top=�$��Right=�$	��108��$��	0,0,118,0q��� -
   $ 	txt_marca��#��[ $��23��$��
0,26,120,0q�$
 Wrap=�$	��Top=�$ Right=�$��Right=�$	��108���� -   $ label1_Copy1��$��Modelo��$	��Top=�$��Right=�$	��108���� -   $ 
txt_modelo��#��[ $��23��$��0,26,0,0q�$
 Wrap=�$	��Top=�$ Right=�$��Right=�$	��108���� -   $ label1_Copy2��$	��Cor��$
��Left=�$	��Top=�$��90��$��0,98,0,0q��� -   $ label1_Copy3��$��Renavan��$
��Left=�$	��Top=�$	��160��$��0,49,0,0q��� -   $ txt_renavan��#��[ $
��Left=�$��23��$��0,75,0,0q�$
 Wrap=�$	��Top=�$	��130��$ Right=��� -   $ label1_Copy5��$��Chassis��$	��Top=�$��	0,49,34,0q�$��Right=�$	��160���� -   $ txt_chassis��#��[ $��23��$��	0,75,64,0q�$
 Wrap=�$	��Top=�$ Right=�$��Right=�$	��130���� -   $ txt_tag��#��[ $
��Left=�$��23��$��
279,75,0,0q�$
 Wrap=�$	��Top=�$��54��$ Right=��� -   $ txt_cor��#��[ $
��Left=�$��23��$��	0,125,0,0q�$
 Wrap=�$	��Top=�$��90��$ Right=��� -   $ label1_Copy6��$	��Ano��$
��Left=�$	��Top=�$��75��$��
103,99,0,0q��� -   $ txt_ano��#��[ $
��Left=�$��23��$��103,125,0,0q�$
 Wrap=�$	��Top=�$��75��$ Right=��� -   $ label1_Copy7��$��Transmissão��$
��Left=�$	��Top=�$	��140��$��
193,98,0,0q��� -   ! ��Name$! cmb_transmissao��" �� 
IsEditable" . #��[ $
��Left=�$��23��$��193,125,0,0q�$	��Top=�$	��140��$  0.5,0.5&��� -   $ label1_Copy8��$��	Potência��$	��Top=�$��0,148,263,0q��� -   $ txt_potencia��#��[ $��23��$��	0,174,0,0q�$
 Wrap=�$	��Top=�$ Right=�$
��Left=�$	��107���� -   $ label1_Copy9��$��Tipo Véículo��$
��Left=�$	��Top=�$	��100��$��126,148,0,0q��� -   $! cmb_tipoVeiculo��" . #��[ $
��Left=�$��23��$��126,174,0,0q�$	��Top=�$	��100��$  0.5,0.5&��� -   $ label1_Copy��$��
Qtd. Eixos��$
��Left=�$	��Top=�$��91��$��242,148,0,0q��� -   $ 	txt_eixos��#��[ $
��Left=�$��23��$��242,174,0,0q�$
 Wrap=�$	��Top=�$��91��$ Right=��� -   $ txt_obs��#��[ $��45��$��
44,212,0,0q�$
 Wrap=�$	��Top=�$ Right=�$
��Left=�$	��289���� -   $ 	groupBox1��$"��Quantidade de Pneus por eixo��$
��Left=�#��[ $��	0,262,0,0q�$	��333��.��� -    # �Name$# 
grid_eixos��$y�Hidden=�.+��� -!   $ labeleixoestepe��$��Estepe��$	��Top=�$
��Left=�$��51��$��10,3,0,0q��� -"   $ txt_p_estepe��#��[ $��23��$��	10,29,0,0q�$
 Wrap=�$	��Top=�$ Right=�$
��Left=�$��51��$  0.5,0.5&��� -#   $ 
labeleixo1��$	��1º��$	��Top=�$
��Left=�$��30��$��66,3,0,0q��� -$   $ txt_p_1��#��[ $��23��$��	66,29,0,0q�$
 Wrap=�$	��Top=�$ Right=�$
��Left=�$��30��$  0.5,0.5&��� -%   $ 
labeleixo2��$	��2º��$	��Top=�$
��Left=�$��30��$��	101,3,0,0q��� -&   $ txt_p_2��#��[ $��23��$��
101,29,0,0q�$
 Wrap=�$	��Top=�$ Right=�$
��Left=�$��30��$  0.5,0.5&��� -'   $ 
labeleixo3��$	��3º��$	��Top=�$
��Left=�$��30��$��	136,3,0,0q��� -(   $ txt_p_3��#��[ $��23��$��
136,29,0,0q�$
 Wrap=�$	��Top=�$ Right=�$
��Left=�$��30��$  0.5,0.5&��� -)   $ 
labeleixo4��$	��4º��$	��Top=�$
��Left=�$��30��$��	171,3,0,0q��� -*   $ txt_p_4��#��[ $��23��$��
171,29,0,0q�$
 Wrap=�$	��Top=�$ Right=�$
��Left=�$��30��$  0.5,0.5&��� -+   $ 
labeleixo5��$	��5º��$	��Top=�$
��Left=�$��30��$��	206,3,0,0q��� -,   $ txt_p_5��#��[ $��23��$��
206,29,0,0q�$
 Wrap=�$	��Top=�$ Right=�$
��Left=�$��30��$  0.5,0.5&��� --   $ 
labeleixo6��$	��6º��$	��Top=�$
��Left=�$��30��$��	241,3,0,0q��� -.   $ txt_p_6��#��[ $��23��$��
241,29,0,0q�$
 Wrap=�$	��Top=�$ Right=�$
��Left=�$��30��$  0.5,0.5&��� -/   $ label1_Copy10��$	��Tag��$
��Left=�$	��Top=�$��41��$��
279,49,0,0q��� -0   $ label1_Copy11��$
��Obs:��$	��Top=�$��0,212,294,0q�� $��0��$��1��� $��1��$��2��.+��� $��5q�#��[ $ 10��$ 10���� -1   $ groupBox2_Copy��$!��Ultimas médias do veículo��#��[ $��10q�.��� $��0q�.+�&   System.Windows.Controls.DataGrid  -2   $  Name$$ grid_ultimas��$��0,0,0,10q�� -3   $# gridferramenta��$��
35,70,35,0q�$��30��$	��Top=�.+��� $��0,0,0,0q�#��[ $ 10��$ 10����   
Buscar_ico#��[ $
��Left=�$��5,0,0,0q�$��28��$	��Top=��� -4   $ txt_pesquisa_Copy��$��20(�$ Center=�$
��Bold"�#��[ $��0,0,0,0q�$
��Wrap=�$	��Top=��� $� ���� -5   $ txt_pesquisa��$��20(�$ Center=�$
��Bold"�#��[ $��0,0,0,0q�$
��Wrap=�$	��Top=��� $�Ferramenta de pesquisa���� #��[ $��0,1,5,0q�$��Right=�$��28��$��28��$	��Top=�� -6   $
# grid��$��10,51,10,10q�$y�Hidden=� �� .+�  -7   $$ dt_pesquisa��$	��229��$��0,75,0,0q�$	��Top=�	� -8   % 	�Name$% 
rad_contem��& d� 	IsChecked$
& TrueY�$��Contem��#��[ $��14(�$��	570,0,0,0q�$	��Top=�	� -9   $% 	rad_exata��$��Pesquisa exata��$��
570,23,0,0q�#��[ $��14(�$	��Top=�$y�Hidden=��� -:   $ txt_registros��$��Nº de Registros: ��#��[ $ Right=�$��14(�$��
570,46,0,0q�$	��Top=��� -;   $ txt_pes_placa��$
��Left=�$��23��$
 Wrap=�$	��Top=�$	��120���� -<   $ txt_pes_marca��$
��Left=�$��23��$��	140,0,0,0q�$
 Wrap=�$	��Top=�$	��120���� -=   $ txt_pes_modelo��$
��Left=�$��23��$��	280,0,0,0q�$
 Wrap=�$	��Top=�$	��120���� ->   $ txt_pes_cor��$
��Left=�$��23��$��	420,0,0,0q�$
 Wrap=�$	��Top=�$	��120���� -?   $ txt_pes_renavan��$
��Left=�$��23��$��0,42,0,0q�$
 Wrap=�$	��Top=�$	��120���� -@   $ txt_pes_chassis��$
��Left=�$��23��$��
140,42,0,0q�$
 Wrap=�$	��Top=�$	��120���� #��[ $
��Left=�$��25��$��
441,40,0,0q�$ 10��$ 10��
������ $	��Top=�$��99���� -A   $ btn_pesquisar��#��[ $
��Left=�$��
441,40,0,0q�$
��Wrap=�$��	Pesquisar��$	��Top=�$��25��$��99��$ Center=�$
��Bold"�$��18(��� -B   $ textBlock_Copy��$
��Left=�$��1,27,0,0q�$
��Wrap=�#��[ $��Renavan��$	��Top=�$	��119���� -C   $ textBlock_Copy1��$
��Left=�$��
141,27,0,0q�$
��Wrap=�#��[ $��Chassis��$	��Top=�$	��119���� -D   $ 	textBlock��$
��Left=�$��	1,-16,0,0q�$
��Wrap=�#��[ $��Placa��$	��Top=�$	��119���� -E   $ textBlock10��$
��Left=�$��141,-16,0,0q�$
��Wrap=�#��[ $��Marca��$	��Top=�$	��119���� -F   $ textBlock12��$
��Left=�$��281,-16,0,0q�$
��Wrap=�#��[ $��Modelo��$	��Top=�$	��119���� -G   $ textBlock12_Copy��$
��Left=�$��421,-16,0,0q�$
��Wrap=�#��[ $	��Cor��$	��Top=�$	��119���� #��[ $��0��$��Right=�$��30��
���   �$	��Top=�$��30��$ 5��$ 5���� -H   $ btn_Fechar_Copy��$��Right=�$
��Wrap=�$��x��$��28��$��20(�$ Center=�$
��Bold"�$��	0,0,0,274q�� $��50��$��
35,0,35,10q�$��Bottom=�.+��� -I   ' ��Name$' btn_novo��  	BotaoRosa#��[ $
��Left=�$
��Novo��$��99��$
��Bold"�$��18(�$��212,10,0,15q��� -J   $' btn_alterar��#��[ $
��Left=�$��Alterar��$��99��$
��Bold"�$��18(�$��316,10,0,15q��� -K   $' 
btn_delete��#��[ $
��Left=�$��Excluir��$��99��$
��Bold"�$��18(�$��420,10,0,15q�