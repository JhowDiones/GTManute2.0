   M S B A M L   `   `   `  ���� C  ?GTManute, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:GTManute.Views.CompanyControlGTManute.Views.CompanyControl  3    -GTManute.Views.CompanyControl.Company_Control   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     =local+clr-namespace:GTManute.Views.CompanyControl       � 
ResizeMode$  NoResize=� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� � AllowsTransparency .  � Title$ Controle das Empresas��$	��500��$	��800��
������ .��� .+��� $��10q� �� RadiusY$ 10�� �� RadiusX$ 10��   primeiraCor#��[    
SegundaCor#��[ ��   TerceiraCor#��[ $��0��$��Right=�$��30��
���   �$	��Top=�$��30��$ 5��$ 5��$��0,0,0,0q��� -    ��Name$ 
btn_Fechar��$��Right=�$��30��$
��Wrap=�$��x��$	��Top=�$��28��$��20(� �� TextAlignment$ Center=�$
��Bold"�$��0,0,0,0q��� #��[ $
��Left=�$��41��$	��Top=�$��7.332��$��10.47,21.216,0,0q��� -   $ 
textBlock1��$
��Left=�$��	23,14,0,0q�$
��Wrap=�$��Controle de Empresas��$	��Top=�$	��537��#��[ $��36(�$
��Bold"�	 �� 
LineHeight$	 11��� $��23,90,23,23q�.+�&   System.Windows.Controls.DataGrid  -   
  Name$
 dataGrid��$
��Left=�$	��268��$��	10,10,0,0q�$	��Top=�$	��734���� -    ��Name$ label��$��Cod Empresa��$
��Left=�$��
36,382,0,0q�$	��Top=�$	��120���� -    ��Name$ txt_Cod_empresa��$
��Left=�$��23��$��
36,408,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��120���� -   $ 
label_Copy��$��Empresa��$
��Left=�$��161,382,0,0q�$	��Top=�$	��174���� -   $ txt_empresa��$
��Left=�$��23��$��161,408,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��142���� -   $ label_Copy1��$��Validade��$
��Left=�$��340,377,0,0q�$	��Top=�$	��121��(  "System.Windows.Controls.DatePicker  -	     Name$ txt_validade��$
��Left=�$��23��$��308,408,0,0q�   Text$  ��$	��Top=�$	��153���� -
   $ 	txt_senha��$
��Left=�$��23��$��466,408,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��140���� -    ��Name$ btn_alterar��$��Alterar��$
��Left=�$��611,408,0,0q�$	��Top=�$��75��$��23���� -   $ 
btn_gravar��$��Gravar��$
��Left=�$��691,408,0,0q�$	��Top=�$��75��$��23���� -   $ label_Copy2��$��Senha��$
��Left=�$��466,382,0,0q�$	��Top=�$	��140���� -    ��Name$ 
btn_config��  config_banco#��[ $
��Left=�$��40��$��744,444,0,0q�$	��Top=�$��40��