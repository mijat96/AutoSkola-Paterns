   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Client.ViewClient.View  5   	       Client.View.ProzorSkola   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Client.View     5   	     � Title$  ProzorSkola��5   	   $	��450��6   $	��800��6*   .��5	      � $��0,0,2,2q�6    � ColumnDefinitions 5
   
   �� 5      $	��23* �6   �� 5      $
��372* �6   ��5   
   �� 5       j� Viewport$ 0,0,1,1�6    �� ImageSource$% /Client;component/autoskola.jpg��6/   .+�5   
   �� $��Dodaj��6   $
��Left=�6G   $��27��6b   $��248,325,0,0q�6n   $	��Top=�6�   $��97��6�   $��1��6�   ��6!   �� *DodajSkoluKomanda+6�   �� 5   
   $
��Left=�6   $��57��6-   $��
205,73,0,0q�69    �� TextWrapping$
 Wrap=�6M   $	��Top=�6�   $	��268��6�   $��1��6�   ��6a   �� *NovaSkola.naziv+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $
��Left=�6   $��56��6-   $��205,153,0,0q�69   $
 Wrap=�6N   $	��Top=�6�   $	��268��6�   $��1��6�   ��6b   �� *NovaSkola.PIB+$ PropertyChanged=�6�   �� 5   
   $
��Left=�6   $��56��6-   $��205,236,0,0q�69   $
 Wrap=�6N   $	��Top=�6�   $	��268��6�   $��1��6�   ��6b   �� *NovaSkola.MBR+$ PropertyChanged=�6�   �� 5   
   $��Naziv��6   
�������$
��Left=�63   $��44��6N   $��	23,86,0,0q�6Z   $	��Top=�6m   $	��134��6�    J� RenderTransformOrigin$ 
0.31,0.392&�6�   $��1��6�   �� 5   
   $	��PIB��6   
�������$
��Left=�61   $��46��6L   $��
23,153,0,0q�6X   $	��Top=�6l   $	��134��6�   $��1��6�   �� 5   
   $	��MBR��6   
�������$
��Left=�61   $��46��6L   $��
23,246,0,0q�6X   $	��Top=�6l   $	��134��6�   $��1��6�   5      5      