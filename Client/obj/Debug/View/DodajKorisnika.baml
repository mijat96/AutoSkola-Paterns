   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Client.ViewModelClient.ViewModel  5   	   %    Client.ViewModel.DodajKorisnika   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Client.ViewModel     5   	     � Title$  DodajKorisnika��5   	   $	��450��6    $	��800��6-    � 	Resources 5
         TextBoxBaseControlTemplate �� 
TargetType ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value	 �� Value
 �� 
TargetName �� Property��%�  &	        �� 5   
   " ��6=   .R�5      �� $ Bd��5      #��z��5      ���	#FF252323#��z��5      $ 5��6E   ._�5      �� $ PART_ContentHost��6   5       5      P� 5       � {� .  . �5      �� #	 � ��63   $
 Bd��6u    � ���� 5      #	 � ��63    � ��5      P� 5       � ��$
 Auto��6+   . �5      ��  � ��$		 100��61   5      P� 5       � ��$
 Auto��6,   . �5      ��  � ��$	 20��62   5      5      5      .��5!      � ��5"   
   �� 5#       j� Viewport$ 0,0,1,1�6    �� ImageSource$% /Client;component/autoskola.jpg��6/   .+�5%   
   �� $��Novi korisnik��6   
�������$��Center=�6;   $
��Left=�6_   $��66��6z   $��
235,10,0,0q�6�   $	��Top=�6�   $	��299��6�   $��Kozuka Mincho Pr6N EL)�6�   $��28(�6�   �� 5'   
   #��[  6   $
��Left=�6I   $��39��6d    �� TextWrapping$
 Wrap=�6p   $	��Top=�6�   $	��227��6�   $��
325,81,0,0q�6�   ���	#FFA7A9A8$��22(�6!  ��6�   �� *korisnik.KorisnickoIme+ �� UpdateSourceTrigger$ PropertyChanged=�6!  �� 5*   
   #��[  6   $
��Left=�6I   $��39��6d   $��325,178,0,0q�6p   $
 Wrap=�6�   $	��Top=�6�   $	��227��6�    J� RenderTransformOrigin$ 0.476,0.506&�6  ���	#FFA7A9A8$��22(�6=  ��6�   �� *korisnik.Sifra+$ PropertyChanged=�6=  �� 5+   
   
�������$
��Ime:��6#   $
��Left=�62   $��33��6M   $��
172,81,0,0q�6Y   $	��Top=�6m   $	��148��6�   $��Khmer UI)�6�   $��22(�6�   �� 5.   
   
�������$��Sifra:��6#   $
��Left=�64   $��33��6O   $��172,184,0,0q�6[   $	��Top=�6p   $	��148��6�   $��Khmer UI)�6�   $��22(�6�   �� 5/   
   $��Dodaj��6   $
��Left=�6R   $	��Top=�6m   $	��158��6�   $��599,350,0,0q�6�   $��45��6�   $��Khmer UI)�6�   $��22(�6�   ��6!   �� *RegistracijaKorisnikaKomanda+6�   �� 50   
   ���	#FFA7A9A8$��Admin��6*   $
��Left=�6{   $��45��6�   $��325,364,0,0q�6�   $	��Top=�6�   $��95��6�   $��Khmer UI)�6�   $��24(�6�   ���	#FF267EC2���	#FF1F5076 d� 	IsChecked 6:   �� *Admin+$ PropertyChanged=�6  52      53      