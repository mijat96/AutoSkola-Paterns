   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Client.ViewClient.View  5   	       Client.View.Pocetna   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Client.View     5   	     � Title$  Pocetna��5   	   $	��450��6   $	��800��6&   .��5      � ��5   
   �� 5       j� Viewport$ 0,0,1,1�6    �� ImageSource$% /Client;component/autoskola.jpg��6/   .+�5   
   �� $��Khmer UI)�6c   $��16(�6y   $
��Left=�6�   $��36��6�   $��
10,373,0,0q�6�   $	��Top=�6�   $	��148��6�   ���	#FF1B98D2��6   �� *ButtonContent+��64   �� *DodajNovogKorisnikaKomanda+6�   �� 5   
   $��Izmeni profil��6   $��Khmer UI)�6V   $��14(�6l   $
��Left=�6|   $��36��6�   $��183,373,0,0q�6�   $	��Top=�6�   $	��100��6�    J� RenderTransformOrigin$ 0.378,0.636&�6�   ��6*   �� *PregledKorisnikaKomanda+6�   �� 5   
   $�� ��6   $��Khmer UI)�6B   $
��Left=�6X   $��41��6s   $��686,185,-26,0q�6   $	��Top=�6�   $	��132��6�   $ 	0.5,0.573&�6�   ��6   �� *OsveziListKomanda+��6�   Z� ��5      �� 5      $# /Client;component/refresh.jpg��6    j� Stretch$ Uniform=�6I   5      �� 5   
   $��Dodaj skolu��6   $
��Left=�6X   $��23��6s   $��
94,314,0,0q�6�   $	��Top=�6�   $��83��6�   ��6(   �� *DodajProzorNoveSkoleKomanda+6�   �� 5   
   $��Izmeni skolu��6   $
��Left=�6U   $��23��6p   $��200,314,0,0q�6|   $	��Top=�6�   $��83��6�   ��6(   �� *IzmeniSkoluProzorKomanda+6�   �� 5   
   $�� ��6   $��Khmer UI)�6>   $��16(�6T   $
��Left=�6d   $��52��6   $��
706,10,0,0q�6�   $	��Top=�6�   $��76��6�   $ 1.011,0.456&�6�   ��6   �� *OdjavaKomanda+��6�   Z� ��5      �� 5      $&  /Client;component/logoutIcon.jpg��6   $ Uniform=�6L   5      �� 5   
   $��Instruktori��6   $
��Left=�6'   $��23��6B   $��
367,65,0,0q�6N   $	��Top=�6�   $	��148��6�   ��6b   �� *!PrikaziInstruktoreProzorKomanda+6�   �� 5   
   $��Dozvole��6   $
��Left=�6#   $��23��6>   $��
553,65,0,0q�6J   $	��Top=�6�   $	��148��6�   ��6^   �� *ProzorPrikazaDozvolaKomanda+6�   &   System.Windows.Controls.DataGrid  5   
      AutoGenerateColumns .     
IsReadOnly . $
��Left=�6�   $	��189��6�   $��
91,117,0,0q�6�   $	��Top=�6�   $	��610��6�   ��60   �� *BindingSkola+ �� SelectedItem 6U   �� *ChoosedList+   Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Skola��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 400 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *naziv+6O     5"      $	 	MBR skole��6%   $
 * 6Q    69   �� *MBR+6Q   5$      �� 5%   
   $��Dupliraj��6   $
��Left=�6M   $��301,314,0,0q�6h   $	��Top=�6}   $��88��6�   $��27��6�   ��6$   �� *DuplirajSkoluKomanda+6�   �� 5&   
   $��	Pretraži��6   $
��Left=�6K   $��686,340,0,0q�6f   $	��Top=�6{   $��82��6�   $��27��6�   ��6%   �� *TraziSkoluKomanda+6�   �� 5'   
   $
��Left=�6   $��27��6m   $��450,340,0,0q�6y    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��210��6�   ��6-   �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5(   
   $	��Ime��6   
�������$
��Left=�6}   $��16��6�   $��450,400,0,0q�6�   $	��Top=�6�   $	��151��6�   $ -2.666,0.868&�6�    d� 	IsChecked 64   �� *CheckBoxes[0]+$ PropertyChanged=�6�   �� 5)   
   $	��MBR��6   
�������$
��Left=�6}   $��16��6�   $��450,384,0,0q�6�   $	��Top=�6�   $	��151��6�   $ -2.666,0.868&�6�    64   �� *CheckBoxes[1]+$ PropertyChanged=�6�   5*      5,      