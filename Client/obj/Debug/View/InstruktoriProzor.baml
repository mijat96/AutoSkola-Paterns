   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Client.ViewClient.View  5   	   #    Client.View.InstruktoriProzor   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Client.View     5   	     � Title$  InstruktoriProzor��5   	   $	��450��6#   $	��800��60   .��5	      � ��5
   
   �� 5       j� Viewport$ 0,0,1,1�6    �� ImageSource$% /Client;component/autoskola.jpg��6/   .+�5   
   �� $��Dodaj instruktora��6   $
��Left=�6b   $��28��6}   $��
39,354,0,0q�6�   $	��Top=�6�   $��96��6�    J� RenderTransformOrigin$ 0.301,0.988&�6�   ��6.   �� *DodajInstruktoraProzorKomanda+6�   &   System.Windows.Controls.DataGrid  5   
      AutoGenerateColumns .     
IsReadOnly . $
��Left=�6�   $	��273��6�   $��	39,60,0,0q�6�   $	��Top=�6�   $	��546��6�   ��6B   �� *	Binding+ �� SelectedItem 6b   �� *IzabraniIsntruktor+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Ime instruktora��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6W   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6?   �� *ime+6W     5      $ Ime instruktora��6%   $	 * 6[   
 6?   �� *	prezime+6[     5      $ Obrazovanje��6%   $	 * 6[   
 6;   �� *obrazovanje+6[     5      $ ID��6%   $	 * 6S   
 62   �� *IDInstruktor+6S   5      �� 5   
   $��Izmeni instruktora��6   $
��Left=�6d   $��28��6   $��248,354,0,0q�6�   $	��Top=�6�   $	��116��6�   ��60   �� *!IzmeniInstruktoraPorozorKomanda+6�   �� 5   
   $��Izbrisi instruktora��6   $
��Left=�6]   $��28��6x   $��481,354,0,0q�6�   $	��Top=�6�   $	��104��6�   ��6/   �� *IzbrisiInstruktoraKomanda+6�   �� 5   
   $
��Left=�6   $��32��6-   $��626,134,0,0q�69    �� TextWrapping$
 Wrap=�6N   $	��Top=�6�   $	��145��6�   ��6c   �� *Skola.naziv+6�   �� 5   
   $
��Left=�6   $��33��6-   $��
626,60,0,0q�69   $
 Wrap=�6M   $	��Top=�6�   $	��145��6�   ��6b   �� *Skola.IDSkole+6�   �� 5   
   $��
Ime skole:��6   
�������$
��Left=�68   $��32��6S   $��
626,98,0,0q�6_   $	��Top=�6s   $��62��6�   $ 0.475,0.969&�6�   �� 5   
   $��	ID skole:��6   
�������$
��Left=�67   $��32��6R   $��
626,28,0,0q�6^   $	��Top=�6r   $��85��6�   $ 0.475,0.969&�6�   �� 5   
   $�� ��6   $��Khmer UI)�6I   $
��Left=�6_   $��41��6z   $��626,221,0,0q�6�   $	��Top=�6�   $	��132��6�   $ -0.099,1.263&�6�   ��6   �� *OsveziInstruktoreKomanda+��6�   Z� ��5      �� 5      $# /Client;component/refresh.jpg��6    j� Stretch$ Uniform=�6I   5       5!      5"      