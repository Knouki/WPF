   M S B A M L   `   `   `  ����    WpfGestionMagasinFrontOffice.    (WpfGestionMagasinFrontOffice.FrontOffice   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  FrontOffice��$	��556��$	��702�� � DataContext ��  �� RelativeSource �� *Self+.��� 
�������.+��� -   $��commandTitle��$��Commander des produits��$��DemiBold"�$��40��$��18(�
������$
��Left=�$��	34,12,0,0q�$	��Top=�$	��617���� -   $��productListView��$	��194��$
��Left=�$��	12,58,0,0q�$	��Top=�$	��656������ *ProduitCollection+ �� View �� .P���  �� Width$	 140��$	��Nom�� �� DisplayMemberBinding �� *Nom+�� $	 180��$��	Reference�� �� *	Reference+�� $	 180��$��Description�� �� *Description+�� $ 60��$
��Prix�� �� *Prix+�� $ 60��$��Stock�� �� *Stock+����  �� 
TargetType" ��.�-   �� -   $��commandeListView��$	��194��$
��Left=�$��200,286,0,0q�$	��Top=�$	��299������ *CommandeCollection+ �� .P��� $	 160��$	��Nom�� �� *Nom+�� $ 60��$
��Prix�� �� *Prix+�� $ 60��$��Stock�� �� *Stock+�� -   $	��100��$��30��$��	Commander��$��14(�
�������
�������$��0q�$��4,4,4,4q�$��551,356,29,131q��� -   $��label1��$��Commande en cours :��
������$��15(�$��28��$
��Left=�$��
12,358,0,0q�$	��Top=�