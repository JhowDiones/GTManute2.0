   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem   GTManute+   %GTManute.Views.Lançamento.View_Abast   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6sys&clr-namespace:System;assembly=mscorlib       � 
ResizeMode$  NoResize=� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� � AllowsTransparency .  � Title$ Abastecimento��$	��500��$	��800��
������  � 	Resources    abrir_pesquisa W�Name �� 
TargetName �� TargetProperty	 g� Duration
 W� From	 W� To R� KeyTime  System.Windows.Visibility   Visible R� Value  fechar_pesquisa   Hidden��%�  &	        &	 �     �� .��W� $ abrir_pesquisa��$ gridferramenta��$ Height�$	 0:0:00.3D�$
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
��Wrap=�$"��Lançamento de abastecimento��$	��Top=�$	��537��#��[ $��36(�$
��Bold"� �� 
LineHeight$ 11��� $��35,105,35,65q�.+��� #��[ $��5��$ 10��$ 10��� $��0,0,0,0q� � RowDefinitions �� $
��.45* ��� $
��.55* � � ColumnDefinitions �� $	��.6* ��� $	��.4* �.+�� $��0��$��0��.+��� $��5q�#��[ $ 10��$ 10���� -    ��Name$ groupBox��$��Dados do cupom��$
��Left=�#��[ $��
10,10,0,10q�$	��418��.��� $��0q�.+��� -    ��Name$ label1��$��Nº Doc.��$
��Left=�$	��Top=�$��80���� -    ��Name$ txt_doc��#��[ $
��Left=�$��23��$��0,25,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$��80�� �� TextAlignment$ Right=��� -	   $ label1_Copy��$��Veículo��$
��Left=�$	��Top=�$��80��$��85,0,0,0q��� -
     ��Name$  cmb_veiculo��! �� 
IsEditable! . #��[ $
��Left=�$��	85,25,0,0q�$	��Top=�$	��120���� -   $ label1_Copy1��$��
Total ltrs��$
��Left=�$	��Top=�$��61��$��
210,-1,0,0q��� -   $ txt_litragem��#��[ $
��Left=�$��23��$��
210,25,0,0q�$
 Wrap=�$	��Top=�$��61��$ Right=��� -   $ label1_Copy2��$��Total valor��$
��Left=�$	��Top=�$��65��$��	276,0,0,0q��� -   $ 	txt_valor��#��[ $
��Left=�$��23��$��
276,25,0,0q�$
 Wrap=�$	��Top=�$��65��$ Right=��� -   $ label1_Copy3��$��
Valor unit��$
��Left=�$	��Top=�$��65��$��	341,0,0,0q��� -   $ txt_res_unitario��{�.  #��[ $
��Left=�$��23��$��
346,25,0,0q�$
 Wrap=�$	��Top=�$��60��$ Right=��� -   $ label1_Copy4��$��
Fornecedor��$
��Left=�$	��Top=�$	��120��$��0,48,0,0q��� -   $  cmb_fornecedor��! . #��[ $
��Left=�$��0,74,0,0q�$	��Top=�$	��120���� -   $ label1_Copy19��$��Combustivel��$
��Left=�$	��Top=�$	��111��$��
125,47,0,0q��� -   $  cmb_combustivel��! . #��[ $
��Left=�$��
125,74,0,0q�$	��Top=�$	��111���� -   $ label1_Copy5��$��Total Km��$
��Left=�$	��Top=�$��80��$��
241,48,0,0q��� -   $ 
txt_res_km��{�.  #��[ $
��Left=�$��23��$��
241,74,0,0q�$
 Wrap=�$	��Top=�$��80��$ Right=��� -   $ label1_Copy6��$��Média KM/L��$
��Left=�$	��Top=�$��80��$��
326,48,0,0q��� -   $ txt_res_media��{�.  #��[ $
��Left=�$��23��$��
326,74,0,0q�$
 Wrap=�$	��Top=�$��80��$ Right=�� -   $��0��$��1��.+��� $��5q�#��[ $ 10��$ 10���� -   $ 	groupBox1��$��Partida��#��[ $
��Left=�$	��162��$��	10,10,0,0q�$	��Top=�$	��206��.��� $��0q�.+��� -   $ label1_Copy7��$��
Km inicial��$
��Left=�$	��Top=�$��89��$��0,7,0,0q��� -   $ txt_km_inicial��#��[ $
��Left=�$��23��$��	94,10,0,0q�$
 Wrap=�$	��Top=�$��90��$ Right=��� -   $ label1_Copy8��$��Hora partida��$
��Left=�$	��Top=�$��89��$��0,35,0,0q��� -   $ txt_hr_partida��#��[ $
��Left=�$��23��$��	94,38,0,0q�$
 Wrap=�$	��Top=�$��90��$ Right=��� -   $ label1_Copy9��$��Data partida��$
��Left=�$	��Top=�$��89��$��0,63,0,0q��� -    $ txt_dt_partida��#��[ $
��Left=�$��23��$��	94,66,0,0q�$
 Wrap=�$	��Top=�$��90��$ Right=��� -!   $ Local��$��Partida��$
��Left=�$	��Top=�$��89��$��0,91,0,0q��� -"   $  cmb_partida��! . #��[ $
��Left=�$��94,0,0,22.08q�$��Bottom=�$��90���� -#   $ groupBox1_Copy��$��Destino��#��[ $��Right=�$	��162��$��	0,10,10,0q�$	��Top=�$	��206��.��� $��0q�.+��� -$   $ label1_Copy10��$��Km final��$
��Left=�$	��Top=�$��89��$��0,7,0,0q��� -%   $ txt_km_destino��#��[ $
��Left=�$��23��$��	94,10,0,0q�$
 Wrap=�$	��Top=�$��90��$ Right=��� -&   $ label1_Copy11��$��Hora chegada��$
��Left=�$	��Top=�$��89��$��0,35,0,0q��� -'   $ txt_hr_destino��#��[ $
��Left=�$��23��$��	94,38,0,0q�$
 Wrap=�$	��Top=�$��90��$ Right=��� -(   $ label1_Copy12��$��Data chegada��$
��Left=�$	��Top=�$��89��$��0,63,0,0q��� -)   $ txt_dt_destino��#��[ $
��Left=�$��23��$��	94,66,0,0q�$
 Wrap=�$	��Top=�$��90��$ Right=��� -*   $ 
Local_Copy��$��Destino��$
��Left=�$	��Top=�$��89��$��0,91,0,0q��� -+   $  cmb_destino��! . #��[ $
��Left=�$��94,0,0,22.08q�$��Bottom=�$��90��� $��1��$��2��.+��� $��5q�#��[ $ 10��$ 10���� -,   $ 	groupBox2��$��Equipe/Despesas��#��[ $��
10,0,10,10q�$	��150��$��Bottom=�.��� $��0q�.+��� --   $  cmb_motorista��! . #��[ $
��Left=�$��23.04��$��0,25.96,0,0q�$	��Top=�$��80���� -.   $  cmb_1ajudante��! . #��[ $��23.04��$��85,25.96,95,0q�$	��Top=��� -/   $  cmb_2ajudante��! . #��[ $��Right=�$��23.04��$��0,25.96,10,0q�$	��Top=�$��80���� -0   $ label1_Copy13��$��	Motorista��$
��Left=�$	��Top=�$��80���� -1   $ label1_Copy14��$��Desp. Alimen��$
��Left=�$	��Top=�$��80��$��0,49,0,0q��� -2   $ txt_desp_alimentacao��#��[ $
��Left=�$��23��$��0,75,0,0q�$
 Wrap=�$	��Top=�$��80��$ Right=��� -3   $ label1_Copy15��$��1º Ajudante��$	��Top=�$��	85,0,95,0q��� -4   $ label1_Copy16��$��Desp. Pernoite��$	��Top=�$��
85,49,95,0q��� -5   $ txt_desp_pernoite��#��[ $��23��$��
85,75,95,0q�$
 Wrap=�$	��Top=�$ Right=��� -6   $ label1_Copy17��$��2º Ajudante��$��Right=�$	��Top=�$��80��$��0,0,10,0q��� -7   $ label1_Copy18��$��Outras Desp.��$��Right=�$	��Top=�$��80��$��	0,49,10,0q��� -8   $ txt_outras_desp��#��[ $��Right=�$��23��$��	0,75,10,0q�$
 Wrap=�$	��Top=�$��80��$ Right=��� -9   $ groupBox2_Copy��$ ��Ultimas viagens ao destino��#��[ $��
10,10,10,0q�$	��160��$	��Top=�.��� $��0q�.+�&   System.Windows.Controls.DataGrid  -:   "  Name$" grid_ultimas��� -;   # �Name$# gridferramenta��$��
35,70,35,0q�$��30��$	��Top=�.+��� $��0,0,0,0q�#��[ $ 10��$ 10����   
Buscar_ico#��[ $
��Left=�$��5,0,0,0q�$��28��$	��Top=��� -<   $ txt_pesquisa_Copy��$��20(�$ Center=�$
��Bold"�#��[ $��0,0,0,0q�$
��Wrap=�$	��Top=��� $� ���� -=   $ txt_pesquisa��$��20(�$ Center=�$
��Bold"�#��[ $��0,0,0,0q�$
��Wrap=�$	��Top=��� $�Ferramenta de pesquisa���� #��[ $��0,1,5,0q�$��Right=�$��28��$��28��$	��Top=�� ->   $
# grid��$��10,51,10,10q�$y�Hidden=� �� .+�  -?   $" dt_pesquisa��$	��229��$��0,75,0,0q�$	��Top=�	� -@   $ 	�Name$$ 
rad_contem��% d� 	IsChecked$
% TrueY�$��Contem��#��[ $��14(�$��	570,0,0,0q�$	��Top=�	� -A   $$ 	rad_exata��$��Pesquisa exata��$��
570,23,0,0q�#��[ $��14(�$	��Top=�$y�Hidden=��� -B   $ txt_registros��$��Nº de Registros: ��#��[ $ Right=�$��14(�$��
570,46,0,0q�$	��Top=��� -C   $ txt_pes_datapartida��$
��Left=�$��23��$
 Wrap=�$	��Top=�$	��120���� -D   $ txt_pes_datachegada��$
��Left=�$��23��$��	140,0,0,0q�$
 Wrap=�$	��Top=�$	��120���� -E   $ txt_pes_veiculo��$
��Left=�$��23��$��	280,0,0,0q�$
 Wrap=�$	��Top=�$	��120���� -F   $ txt_pes_motorista��$
��Left=�$��23��$��	420,0,0,0q�$
 Wrap=�$	��Top=�$	��120���� -G   $ txt_pes_Locpartida��$
��Left=�$��23��$��0,42,0,0q�$
 Wrap=�$	��Top=�$	��120���� -H   $ txt_pes_locdestino��$
��Left=�$��23��$��
140,42,0,0q�$
 Wrap=�$	��Top=�$	��120���� #��[ $
��Left=�$��25��$��
441,40,0,0q�$ 10��$ 10��
������ $	��Top=�$��99���� -I   $ btn_pesquisar��#��[ $
��Left=�$��
441,40,0,0q�$
��Wrap=�$��	Pesquisar��$	��Top=�$��25��$��99��$ Center=�$
��Bold"�$��18(��� -J   $ txt_pes_fornecedor��$
��Left=�$��23��$��
280,42,0,0q�$
 Wrap=�$	��Top=�$	��120���� -K   $ textBlock_Copy��$
��Left=�$��1,27,0,0q�$
��Wrap=�#��[ $��Local partida��$	��Top=�$	��119���� -L   $ textBlock_Copy1��$
��Left=�$��
141,27,0,0q�$
��Wrap=�#��[ $��Local destino��$	��Top=�$	��119���� -M   $ textBlock_Copy2��$
��Left=�$��
281,27,0,0q�$
��Wrap=�#��[ $��
Fornecedor��$	��Top=�$	��119���� -N   $ 	textBlock��$
��Left=�$��	1,-16,0,0q�$
��Wrap=�#��[ $��Data partida��$	��Top=�$	��119���� -O   $ textBlock10��$
��Left=�$��141,-16,0,0q�$
��Wrap=�#��[ $��Data chegada��$	��Top=�$	��119���� -P   $ textBlock12��$
��Left=�$��281,-16,0,0q�$
��Wrap=�#��[ $��Placa veículo��$	��Top=�$	��119���� -Q   $ textBlock12_Copy��$
��Left=�$��421,-16,0,0q�$
��Wrap=�#��[ $��	Motorista��$	��Top=�$	��119���� #��[ $��0��$��Right=�$��30��
���   �$	��Top=�$��30��$ 5��$ 5���� -R   $ btn_Fechar_Copy��$��Right=�$
��Wrap=�$��x��$��28��$��20(�$ Center=�$
��Bold"�$��	0,0,0,274q�� $��50��$��
35,0,35,10q�$��Bottom=�.+��� -S   & ��Name$& btn_alterar��  	BotaoRosa#��[ $
��Left=�$��Alterar��$��99��$
��Bold"�$��18(�$��316,10,0,15q��� -T   $& btn_novo��#��[ $
��Left=�$
��Novo��$��99��$
��Bold"�$��18(�$��212,10,0,15q��� -U   $& 
btn_delete��#��[ $
��Left=�$��Excluir��$��99��$
��Bold"�$��18(�$��420,10,0,15q�