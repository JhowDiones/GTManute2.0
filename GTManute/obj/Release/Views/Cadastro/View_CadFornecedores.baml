   M S B A M L   `   `   `  ���� C  ?GTManute, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:GTManute.Views.CadastroGTManute.Views.Cadastro  2    ,GTManute.Views.Cadastro.View_CadFornecedores   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7local%clr-namespace:GTManute.Views.Cadastro       � 
ResizeMode$  NoResize=� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� � AllowsTransparency .  � Title$ 
Fornecedor��$	��500��$	��800��
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
��Wrap=�$��Cadastro - Fornecedor��$	��Top=�$	��537��#��[ $��36(�$
��Bold"� �� 
LineHeight$ 11��� $��35,105,35,65q�.+��� #��[ $��5��$ 10��$ 10��� $��0,0,0,0q� � RowDefinitions �� $��* � � ColumnDefinitions �� $	��.5* ��� $	��.5* �.+�� $��0��$��0��.+��� $��5q�#��[ $ 10��$ 10���� -    ��Name$ groupBox��$��Dados fornecedor��$
��Left=�#��[ $��
10,10,0,10q�$	��345��.��� $��0q�.+��� -    ��Name$ label1��$��Razão Social��$
��Left=�$	��Top=�$	��160���� -    ��Name$ 	txt_razao��#��[ $
��Left=�$��23��$��0,26,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��160�� �� TextAlignment$ Right=�  J� RenderTransformOrigin$  0.5,0.5&��� -	   $ label1_Copy1��$��Nome Fantasia��$	��Top=�$��0,-1,0,0q�$��Right=�$	��160���� -
   $ txt_fantasia��#��[ $��23��$��0,25,0,0q�$
 Wrap=�$	��Top=�$ Right=�$��Right=�$	��160���� -   $ label1_Copy2��$��	Endereço��$
��Left=�$	��Top=�$	��140��$��0,98,0,0q��� -   $ txt_endereco��#��[ $
��Left=�$��23��$��	0,125,0,0q�$
 Wrap=�$	��Top=�$	��140��$ Right=��� -   $ label1_Copy3��$��CNPJ/CPF��$
��Left=�$	��Top=�$	��160��$��0,49,0,0q��� -   $ txt_cnpj��#��[ $
��Left=�$��23��$��0,75,0,0q�$
 Wrap=�$	��Top=�$	��160��$ Right=��� -   $ label1_Copy5��$��Inscrição Estadual��$	��Top=�$��0,49,0,0q�$��Right=�$	��160���� -   $ txt_inscricao��#��[ $��23��$��0,75,0,0q�$
 Wrap=�$	��Top=�$ Right=�$��Right=�$	��160���� -   $ label1_Copy6��$��Cidade��$
��Left=�$	��Top=�$	��102��$��
158,99,0,0q��� -   $ 
txt_cidade��#��[ $
��Left=�$��23��$��158,125,0,0q�$
 Wrap=�$	��Top=�$	��102��$ Right=��� -   $ label1_Copy��$��UF��$
��Left=�$	��Top=�$��55��$��
278,99,0,0q��� -   ! ��Name$! cmb_uf��" �� 
IsEditable" . #��[ $
��Left=�$��23��$��278,125,0,0q�$	��Top=�$��55���� -   $ label1_Copy7��$��Telefone��$
��Left=�$	��Top=�$	��160��$��	0,148,0,0q��� -   $ txt_telefone��#��[ $
��Left=�$��23��$��	0,174,0,0q�$
 Wrap=�$	��Top=�$	��160��$ Right=�$  0.5,0.5&��� -   $ label1_Copy8��$��Telefone��$	��Top=�$��	0,148,0,0q�$��Right=�$	��160���� -   $ txt_telefone2��#��[ $��23��$��	0,174,0,0q�$
 Wrap=�$	��Top=�$ Right=�$��Right=�$	��160���� -   $ label1_Copy9��$��E-mail��$
��Left=�$	��Top=�$	��178��$��	0,197,0,0q��� -   $ 	txt_email��#��[ $
��Left=�$��23��$��	0,223,0,0q�$
 Wrap=�$	��Top=�$	��178��$ Right=�$  0.5,0.5&��� -   $ label1_Copy10��$��Forma Pagamento��$
��Left=�$	��Top=�$	��140��$��193,197,0,0q��� -   $! cmb_pagamento��" . #��[ $
��Left=�$��23��$��193,223,0,0q�$	��Top=�$	��140��� $��0��$��1��� $��1��$��2��.+��� $��5q�#��[ $ 10��$ 10���� -   $ groupBox2_Copy��$#��Ultimas compras no fornecedor��#��[ $��10q�.��� $��0q�.+�&   System.Windows.Controls.DataGrid  -   #  Name$# grid_ultimas��$��0,0,0,10q�� -   $ �Name$$ gridferramenta��$��
35,70,35,0q�$��30��$	��Top=�.+��� $��0,0,0,0q�#��[ $ 10��$ 10����   
Buscar_ico#��[ $
��Left=�$��5,0,0,0q�$��28��$	��Top=��� -    $ txt_pesquisa_Copy��$��20(�$ Center=�$
��Bold"�#��[ $��0,0,0,0q�$
��Wrap=�$	��Top=��� $� ���� -!   $ txt_pesquisa��$��20(�$ Center=�$
��Bold"�#��[ $��0,0,0,0q�$
��Wrap=�$	��Top=��� $�Ferramenta de pesquisa���� #��[ $��0,1,5,0q�$��Right=�$��28��$��28��$	��Top=�� -"   $
$ grid��$��10,51,10,10q�$y�Hidden=� �� .+�  -#   $# dt_pesquisa��$	��229��$��0,75,0,0q�$	��Top=�	� -$   % 	�Name$% 
rad_contem��& d� 	IsChecked$
& TrueY�$��Contem��#��[ $��14(�$��	570,0,0,0q�$	��Top=�	� -%   $% 	rad_exata��$��Pesquisa exata��$��
570,23,0,0q�#��[ $��14(�$	��Top=�$y�Hidden=��� -&   $ txt_registros��$��Nº de Registros: ��#��[ $ Right=�$��14(�$��
570,46,0,0q�$	��Top=��� -'   $ txt_pes_razao��$
��Left=�$��23��$
 Wrap=�$	��Top=�$	��120���� -(   $ txt_pes_fantasia��$
��Left=�$��23��$��	140,0,0,0q�$
 Wrap=�$	��Top=�$	��120���� -)   $ txt_pes_cnpj��$
��Left=�$��23��$��	280,0,0,0q�$
 Wrap=�$	��Top=�$	��120���� -*   $ txt_pes_inscricao��$
��Left=�$��23��$��	420,0,0,0q�$
 Wrap=�$	��Top=�$	��120���� -+   $ txt_pes_endereco��$
��Left=�$��23��$��0,42,0,0q�$
 Wrap=�$	��Top=�$	��120���� -,   $ txt_pes_cidade��$
��Left=�$��23��$��
140,42,0,0q�$
 Wrap=�$	��Top=�$	��120���� #��[ $
��Left=�$��25��$��
441,40,0,0q�$ 10��$ 10��
������ $	��Top=�$��99���� --   ' ��Name$' btn_pesquisar��#��[ $
��Left=�$��
441,40,0,0q�$��	Pesquisar��$	��Top=�$��25��$��99��$
��Bold"�$��18(��� -.   $ txt_pes_teltefone��$
��Left=�$��23��$��
280,42,0,0q�$
 Wrap=�$	��Top=�$	��120���� -/   $ textBlock_Copy��$
��Left=�$��1,27,0,0q�$
��Wrap=�#��[ $��	Endereço��$	��Top=�$	��119���� -0   $ textBlock_Copy1��$
��Left=�$��
141,27,0,0q�$
��Wrap=�#��[ $��Cidade��$	��Top=�$	��119���� -1   $ textBlock_Copy2��$
��Left=�$��
281,27,0,0q�$
��Wrap=�#��[ $��Telefone��$	��Top=�$	��119���� -2   $ 	textBlock��$
��Left=�$��	1,-16,0,0q�$
��Wrap=�#��[ $��Razão Social��$	��Top=�$	��119���� -3   $ textBlock10��$
��Left=�$��141,-16,0,0q�$
��Wrap=�#��[ $��Fantasia��$	��Top=�$	��119���� -4   $ textBlock12��$
��Left=�$��281,-16,0,0q�$
��Wrap=�#��[ $
��CNPJ��$	��Top=�$	��119���� -5   $ textBlock12_Copy��$
��Left=�$��421,-16,0,0q�$
��Wrap=�#��[ $��Inscrição Estadual��$	��Top=�$	��119���� #��[ $��0��$��Right=�$��30��
���   �$	��Top=�$��30��$ 5��$ 5���� -6   $ btn_Fechar_Copy��$��Right=�$
��Wrap=�$��x��$��28��$��20(�$ Center=�$
��Bold"�$��	0,0,0,274q�� $��50��$��
35,0,35,10q�$��Bottom=�.+��� -7   $' btn_novo��$
��Left=�  	BotaoRosa#��[ $
��Novo��$��99��$
��Bold"�$��18(�$��212,10,0,15q��� -8   $' btn_alterar��#��[ $
��Left=�$��Alterar��$��99��$
��Bold"�$��18(�$��316,10,0,15q��� -9   $' 
btn_delete��#��[ $
��Left=�$��Excluir��$��99��$
��Bold"�$��18(�$��420,10,0,15q�