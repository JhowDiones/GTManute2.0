   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem   GTManute+   %GTManute.Views.Lançamento.View_Manut   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6sys&clr-namespace:System;assembly=mscorlib       � 
ResizeMode$  NoResize=� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� � AllowsTransparency .  � Title$ Abastecimento��$	��620��$	��800��
������  � 	Resources    abrir_pesquisa W�Name �� 
TargetName �� TargetProperty	 g� Duration
 W� From	 W� To R� KeyTime  System.Windows.Visibility   Visible R� Value  fechar_pesquisa   Hidden��%�  &	        &	 �     �� .��W� $ abrir_pesquisa��$ gridferramenta��$ Height�$	 0:0:00.3D�$
 30X�$	 480X�T� $ (UIElement.Visibility)�$
 grid��..�i� $ 0��# Z �� .��W� $ fechar_pesquisa��$ gridferramenta��$ Height�$	 0:0:00.3D�$	
 480X�$ 30X�T� $ (UIElement.Visibility)�$
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
��Wrap=�$ ��Lançamento de manuteção��$	��Top=�$	��537��#��[ $��36(�$
��Bold"� �� 
LineHeight$ 11��� $��35,105,35,65q�.+��� #��[ $��5��$ 10��$ 10��� $��0,0,0,0q� � RowDefinitions �� $
��.45* ��� $
��.55* � � ColumnDefinitions �� $	��.5* ��� $	��.5* �.+�� $��0��$��0��.+��� $��5q�#��[ $ 10��$ 10���� -    ��Name$ groupBox��$��Dados do cupom��#��[ $��10q�.��� $��0q�.+��� -    ��Name$ label1��$��Nº Doc.��$
��Left=�$	��Top=�$��80���� -    ��Name$ txt_doc��#��[ $
��Left=�$��23��$��0,25,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$��99�� �� TextAlignment$ Right=��� -	   $ label1_Copy��$��Veículo��$
��Left=�$	��Top=�$��98��$��
235,49,0,0q��� -
   $ txt_data��#��[ $��23��$��
118,25,0,0q�$
 Wrap=�$	��Top=�$ Right=�$
��Left=�$��98���� -   $ txt_km��#��[ $
��Left=�$��23��$��
235,25,0,0q�$
 Wrap=�$	��Top=�$��98��$ Right=��� -     ��Name$  cmb_fornecedor��! �� 
IsEditable! . #��[ $
��Left=�$��0,74,0,0q�$	��Top=�$	��216���� -   $  cmb_veiculo��! . #��[ $
��Left=�$��
235,74,0,0q�$	��Top=�$��98���� -   $ label1_Copy4��$��
Fornecedor��$
��Left=�$	��Top=�$	��216��$��0,48,0,0q��� -   $ label1_Copy2��$
��Data��$
��Left=�$	��Top=�$��98��$��	120,0,0,0q��� -   $ label1_Copy6��$��Km Manutenção��$
��Left=�$	��Top=�$��98��$��	235,0,0,0q��� -   $ label1_Copy1��$��	Motorista��$
��Left=�$	��Top=�$��98��$��1,96,0,0q��� -   $  cmb_motorista��! . #��[ $
��Left=�$��	1,121,0,0q�$	��Top=�$	��151���� -   $ label1_Copy8��$��Valor Total��$
��Left=�$	��Top=�$��83��$��
250,96,0,0q��� -   $ txt_calcDesconto��{�.  #��[ $
��Left=�$��23��$��157,121,0,0q�$
 Wrap=�$	��Top=�$��88��$ Right=��� -   $ txt_calcTotal��{�.  #��[ $
��Left=�$��23��$��250,121,0,0q�$
 Wrap=�$	��Top=�$��83��$ Right=��� -   $ label1_Copy9��$��Valor Desconto��$
��Left=�$	��Top=�$��93��$��
157,96,0,0q�� $��2��$��1��.+��� $��5q�#��[ $ 10��$ 10���� -   $ 	groupBox2��$��Controle de itens��#��[ $��
10,0,10,10q�$	��228��$��Bottom=�.��� $��0q�.+��� -   $ label1_Copy14��$��Descrição��$
��Left=�$	��Top=�$	��189���� -   $  cmb_ItemDesc��! . #��[ $
��Left=�$��23��$��0,26,0,0q�$	��Top=�$	��297���� -   $ label1_Copy16��$��Quant.��$	��Top=�$��	302,0,0,0q�$
��Left=�$��74���� -   $ txt_itemQuant��#��[ $��23��$��
302,26,0,0q�$
 Wrap=�$	��Top=�$ Right=�$
��Left=�$��74���� -   $ label1_Copy18��$��Desconto��$��Right=�$	��Top=�$��89��$��	0,0,218,0q��� -   $ label1_Copy3��$��Valor��$��Right=�$	��Top=�$��87��$��	0,0,116,0q��� -   $ txt_itemDesconto��#��[ $��23��$��
391,26,0,0q�$
 Wrap=�$	��Top=�$ Right=�$
��Left=�$��89���� -   $ txt_itemValor��#��[ $��Right=�$��23��$��
0,26,116,0q�$
 Wrap=�$	��Top=�$��87��$ Right=��� -    " ��Name$" chq_programada��$$��Proxima manuteção programada��$
��Left=�$��0,54,0,0q�$	��Top=�� -!   # �Name$# _manutprogramada��$��0,69,0,0q�$y�Hidden=�.+��� -"   $ txt_progrmadoKm��#��[ $��23��$
 Wrap=�$	��Top=�$ Right=�$��Right=�$	��100���� -#   $ txt_ProgrmadoObs��#��[ $	��100��$��0,26,0,0q�$
 Wrap=�$	��Top=�$ Right=�$��Right=�$	��698���� -$   $ label1_Copy5��$��KM Programado��$	��Top=�$��	0,0,105,0q�$��Right=�$	��100���� -%   $ label1_Copy7��$
��Obs:��$	��Top=�$
��Left=�$	��307���� -&   $ ��Name$$ 	btn_mais1��  	BotaoRosa#��[ $y�Hidden=�$��	Adicionar��$
��Bold"�$��Center=�$��18(�$��587,0,0,156q�$��10��$��Bottom=�$
��Left=�$	��111��� $��0��$��1��.+��� $��5q�#��[ $ 10��$ 10���� -'   $ groupBox2_Copy��$��Itens da Nota��#��[ $��
10,10,10,0q�$	��182��$	��Top=�.��� $��0q�.+�&   System.Windows.Controls.DataGrid  -(   %  Name$% 
grid_itens��� -)   $# gridferramenta��$��
35,70,35,0q�$��30��$	��Top=�.+��� $��0,0,0,0q�#��[ $ 10��$ 10����   
Buscar_ico#��[ $
��Left=�$��5,0,0,0q�$��28��$	��Top=��� -*   $ txt_pesquisa_Copy��$��20(�$ Center=�$
��Bold"�#��[ $��0,0,0,0q�$
��Wrap=�$	��Top=��� $� ���� -+   $ txt_pesquisa��$��20(�$ Center=�$
��Bold"�#��[ $��0,0,0,0q�$
��Wrap=�$	��Top=��� $�Ferramenta de pesquisa���� #��[ $��0,1,5,0q�$��Right=�$��28��$��28��$	��Top=�� -,   $
# grid��$��10,51,10,10q�$y�Hidden=� �� .+�  --   $% dt_pesquisa��$	��344��$��0,75,0,0q�$	��Top=�	� -.   & 	�Name$& 
rad_contem��' d� 	IsChecked$
' TrueY�$��Contem��#��[ $��14(�$��	570,0,0,0q�$	��Top=�	� -/   $& 	rad_exata��$��Pesquisa exata��$��
570,23,0,0q�#��[ $��14(�$	��Top=�$y�Hidden=��� -0   $ txt_registros��$��Nº de Registros: ��#��[ $ Right=�$��14(�$��
570,46,0,0q�$	��Top=��� -1   $ txt_pes_data��$
��Left=�$��23��$
 Wrap=�$	��Top=�$	��120���� -2   $ txt_pes_placa��$
��Left=�$��23��$��	140,0,0,0q�$
 Wrap=�$	��Top=�$	��120���� -3   $ txt_pes_motorista��$
��Left=�$��23��$��	280,0,0,0q�$
 Wrap=�$	��Top=�$	��120���� -4   $ txt_pes_fornecedor��$
��Left=�$��23��$��	420,0,0,0q�$
 Wrap=�$	��Top=�$	��120���� -5   $ txt_pes_doc��$
��Left=�$��23��$��0,42,0,0q�$
 Wrap=�$	��Top=�$	��120���� -6   $ txt_pes_pecaservico��$
��Left=�$��23��$��
140,42,0,0q�$
 Wrap=�$	��Top=�$	��120���� #��[ $
��Left=�$��25��$��
441,40,0,0q�$ 10��$ 10��
������ $	��Top=�$��99���� -7   $ btn_pesquisar��#��[ $
��Left=�$��
441,40,0,0q�$
��Wrap=�$��	Pesquisar��$	��Top=�$��25��$��99��$ Center=�$
��Bold"�$��18(��� -8   $ txt_pes_kmmanute��$
��Left=�$��23��$��
280,42,0,0q�$
 Wrap=�$	��Top=�$	��120���� -9   $ textBlock_Copy��$
��Left=�$��1,27,0,0q�$
��Wrap=�#��[ $��Número documento��$	��Top=�$	��119���� -:   $ textBlock_Copy1��$
��Left=�$��
141,27,0,0q�$
��Wrap=�#��[ $��Peça/Serviço��$	��Top=�$	��119���� -;   $ textBlock_Copy2��$
��Left=�$��
281,27,0,0q�$
��Wrap=�#��[ $��KM Manutenção��$	��Top=�$	��119���� -<   $ 	textBlock��$
��Left=�$��	1,-16,0,0q�$
��Wrap=�#��[ $
��Data��$	��Top=�$	��119���� -=   $ textBlock10��$
��Left=�$��141,-16,0,0q�$
��Wrap=�#��[ $��Veículo��$	��Top=�$	��119���� ->   $ textBlock12��$
��Left=�$��281,-16,0,0q�$
��Wrap=�#��[ $��	Motorista��$	��Top=�$	��119���� -?   $ textBlock12_Copy��$
��Left=�$��421,-16,0,0q�$
��Wrap=�#��[ $��
Fornecedor��$	��Top=�$	��119���� #��[ $��0��$��Right=�$��30��
���   �$	��Top=�$��30��$ 5��$ 5���� -@   $ btn_Fechar_Copy��$��Right=�$
��Wrap=�$��x��$��28��$��20(�$ Center=�$
��Bold"�$��	0,0,0,389q�� $��50��$��
35,0,35,10q�$��Bottom=�.+��� -A   $$ btn_alterar��#��[ $
��Left=�$��Alterar��$��99��$
��Bold"�$��18(�$��316,10,0,15q��� -B   $$ btn_novo��#��[ $
��Left=�$
��Novo��$��99��$
��Bold"�$��18(�$��212,10,0,15q��� -C   $$ 
btn_delete��#��[ $
��Left=�$��Excluir��$��99��$
��Bold"�$��18(�$��420,10,0,15q�