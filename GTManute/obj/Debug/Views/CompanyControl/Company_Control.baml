   M S B A M L   `   `   `  ����C  ?GTManute, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:GTManute.Views.CompanyControlGTManute.Views.CompanyControl  5   	   3    -GTManute.Views.CompanyControl.Company_Control   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:GTManute.Views.CompanyControl     5   	     � 
ResizeMode$  NoResize=�5       � WindowStyle$
 None=�60    � WindowStartupLocation$ CenterScreen=�6C    � AllowsTransparency .  � Title$ Controle das Empresas��5   	   $	��500��6'   $	��800��64   
������ .��5	      � .+�5
   
   �� $��10q�6    �� RadiusY$ 10��6     �� RadiusX$ 10��6-      primeiraCor#��[  6:     
SegundaCor#��[ 6^   �� 5   
     TerceiraCor#��[ 6   $��0��68   $��Right=�6L   $��30��6h   
���   �$	��Top=�6�   $��30��6�   $ 5��6�   $ 5��6�   $��0,0,0,0q�6�   �� 5   
   -   5         ��Name$ 
btn_Fechar��5      $��Right=�6(   $��30��6D   $
��Wrap=�6P   $��x��6d   $	��Top=�6m   $��28��6�   $��20(�6�    �� TextAlignment$ Center=�6�   $
��Bold"�6�   $��0,0,0,0q�6�   6�   �� 5   
   #��[ 6   $
��Left=�67   $��41��6R   $	��Top=�5      $��7.332��6%   $��10.47,21.216,0,0q�63   �� 5   
   -   5        $ 
textBlock1��5      $
��Left=�6(   $��	23,14,0,0q�6C   $
��Wrap=�5      $��Controle de Empresas��6!   $	��Top=�6=   $	��537��6U   #��[ 5      $��36(�66   $
��Bold"�6D   	 �� 
LineHeight$	 11��6V   � 5   
   $��23,90,23,23q�6   .+�5      &   System.Windows.Controls.DataGrid  -   5        
  Name$
 dataGrid��5      $
��Left=�6)   $	��268��6D   $��	10,10,0,0q�6Q   $	��Top=�6d   $	��734��6|   5      �� 5   
   -   5         ��Name$ label��5      $��Cod Empresa��6   $
��Left=�65   $��
36,382,0,0q�6P   $	��Top=�6d   $	��120��6|   �� 5   
   -   5         ��Name$ txt_Cod_empresa��5      $
��Left=�6+   $��23��6F   $��
36,408,0,0q�6R    �� TextWrapping$
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ 
label_Copy��5      $��Empresa��6$   $
��Left=�66   $��161,382,0,0q�6Q   $	��Top=�6f   $	��174��6~   �� 5   
   -   5        $ txt_empresa��5      $
��Left=�6'   $��23��6B   $��161,408,0,0q�6N   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��142��6�   �� 5   
   -   5        $ label_Copy1��5      $��Validade��6%   $
��Left=�68   $��340,377,0,0q�6S   $	��Top=�6h   $	��121��6�   (  "System.Windows.Controls.DatePicker  5   
   -	   5          Name$ txt_validade��5      $
��Left=�6+   $��23��6F   $��308,408,0,0q�6R      Text$  ��6h   $	��Top=�6p   $	��153��6�   �� 5   
   -
   5        $ 	txt_senha��5      $
��Left=�6%   $��23��6@   $��466,408,0,0q�6L   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��140��6�   �� 5   
   -   5         ��Name$ btn_alterar��5      $��Alterar��6&   $
��Left=�68   $��611,408,0,0q�6S   $	��Top=�6h   $��75��6�   $��23��6�   6�   �� 5   
   -   5        $ 
btn_gravar��5      $��Gravar��6%   $
��Left=�66   $��691,408,0,0q�6Q   $	��Top=�6f   $��75��6~   $��23��6�   6�   �� 5   
   -   5        $ label_Copy2��5      $��Senha��6%   $
��Left=�65   $��466,382,0,0q�6P   $	��Top=�6e   $	��140��6}   �� 5    
   -   5         ��Name$ 
btn_config��5         config_banco#��[ 6$   $
��Left=�6K   $��40��6f   $��744,444,0,0q�6r   $	��Top=�6�   $��40��6�   6�   5!      5"      