   M S B A M L   `   `   `  ���� C  ?GTManute, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GTManute.ViewsGTManute.Views  g cMicrosoft.ReportViewer.WinForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3atSclr-namespace:Microsoft.Reporting.WinForms;assembly=Microsoft.ReportViewer.WinFormsMicrosoft.Reporting.WinForms     GTManute.Views.View_Menu   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:GTManute.Views     brvSclr-namespace:Microsoft.Reporting.WinForms;assembly=Microsoft.ReportViewer.WinForms       � 
ResizeMode$  NoResize=� � AllowsTransparency .  � WindowState$ Normal=� � WindowStyle$
 None=�
������  � Title$ 	View_Menu��$	��450��$	��800��.��� -   .+��� $��10q� �� RadiusY$ 10�� �� RadiusX$ 10��   primeiraCor#��[    
SegundaCor#��[ �� #��[ $	��100��$��
19,10,10,0q�$	��Top=�� $
��Left=�$��9.5,10,0,10q�$��109.901��.+���   TerceiraCor#��[ #��[ $��0��$��-0.917,0,10.818,0q�$ 10��$ 10���� #��[ #��[ $��0��$��10,0,0,0q�$
��Left=�$��99.901���� -   
������ $��
-1,390,0,0q�$
��Left=�$��11��$��40��$	��Top=��� -    ��Name$ label��$��Validade licença��$��Center=�
�������$
��Left=�$��10,372,-0.099,0q�$	��Top=�$	��100���� -   $ txt_validade��$��
01/01/2020��$��Center=�
�������$��10,398,-0.099,0q�$	��Top=��� -   $ txt_empresa��$�� ��$��Center=�
�������$��10,346,-0.099,0q�$	��Top=�� $
��Left=�$��20��$��
19,110,0,0q�$	��Top=�$��100.401��.+��� #��[ #��[ $	��0.1��$��0.401,0.016,0,0q��� -    ��Name$ image1��$
��Left=�$��0,0,0,0.016q�$��20���� -   	 ��Name$	 btn_home��$��0.401,0.016,0,0q�$
��Wrap=�
 �� TextAlignment$
 Right=�$
��Home��$
��Bold"�#��[  � $
��Left=�$��20��$��
19,130,0,0q�$	��Top=�$��100.401��.+��� #��[ #��[ $	��0.1��$��0.401,0.016,0,0q��� -   $ image2��$
��Left=�$��0,0,0,0.016q�$��20���� -	   $	 btn_cadastro��$��0.401,0.016,0,0q�$
��Wrap=�$
 Right=�$��	Cadastros��$
��Bold"�#��[  � $
��Left=�$��20��$��
19,150,0,0q�$	��Top=�$��100.401��.+��� #��[ #��[ $	��0.1��$��0.401,0.016,0,0q��� -
   $ image3��$
��Left=�$��0,0,0,0.016q�$��20���� -   $	 	btn_Lanca��$��0.401,0.016,0,0q�$
��Wrap=�$
 Right=�$��Lançamentos��$
��Bold"�#��[  � $
��Left=�$��20��$��
19,170,0,0q�$	��Top=�$��100.401�� � ColumnDefinitions �� $	��77* ��� $	��23* �.+��� #��[ #��[ $	��0.1��$��0,0,0.401,0q�$��2���� -   $ image��$
��Left=�$��20���� -   $	 
btn_Config��$��0,0,0.401,0q�$
��Wrap=�$
 Right=�$��Configurações��$
��Bold"�#��[  $��2��� $��Right=�$
��30.5��$��
0,0,-0.5,0q�$	��Top=�$��30��.+��� #���  $��0��
���   �$ 5��$ 5��$��	0,0.5,0,0q��� -   $	 
btn_Fechar��$
��Wrap=�$��x��$��20(�$
 Center=�$
��Bold"�$��0.5,0,0.5,0.5q�� -    �Name$ grid_cadastro��$
��Left=�$	��330��$y�Hidden=�$��119,110,0,0q�$	��Top=�$	��671��#��[  � RowDefinitions �� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 � �� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 �.+�� -   #��[  $��1��$��1��.+��� $	��120��$	��120��$��5q�  veiculos#��[ $	��Top=��� $��Frota��#��[ $��20(�$
 Center=�$��Bottom=�� -   #��[  $��1��$��3��.+��� $	��120��$	��120��$��5q�  
Fornecedor#��[ $	��Top=��� $��Fornecedores��#��[ $��20(�$
 Center=�$��Bottom=�� -   #��[  $��1��$��5��.+��� $	��120��$	��120��$��5q�  Funcionario#��[ $	��Top=��� $��Colaboradores��#��[ $��20(�$
 Center=�$��Bottom=�� -   #��[  $��1��$��7��.+��� $	��120��$	��120��$��5q� 	 Rotas#��[ $	��Top=��� $��Rotas��#��[ $��20(�$
 Center=�$��Bottom=�� -   $ 	grid_lanc��$
��Left=�#��[ $y�Hidden=�$	��330��$��119,110,0,0q�$	��Top=�$	��671�� �� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 � �� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 �.+�� -   #��[  $��1��$��1��.+��� $	��120��$	��120��$��5q�  Abastecimento#��[ $	��Top=��� $��Abastecimento��#��[ $��20(�$
 Center=�$��Bottom=�� -   #��[  $��1��$��3��.+��� $	��120��$	��120��$��5q�  
Manutencao#��[ $	��Top=��� $��Manutenção��#��[ $��20(�$
 Center=�$��Bottom=��� -    ��Name$ btn_atualizar��$y�Hidden=�$��	Atualizar�� 	 BotaoBranco#��[	 $
��Left=�$��
667,75,0,0q�$	��Top=�$	��116���� -   $ btn_upvalores��$y�Hidden=�$��Atualizar valores��#��[	 $
��Left=�$��
514,75,0,0q�$	��Top=�$	��116��