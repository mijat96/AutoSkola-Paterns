   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClientClient  5   	       Client.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Client     5   	     � Title$  Prijava��5   	   $	��450��6   $	��800��6&    � 	Resources 5	         TextBoxBaseControlTemplate �� 
TargetType ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value	 �� Value
 �� 
TargetName �� Property��%�  &	        �� 5   
   " ��6=   .R�5      �� $ Bd��5      #��z��5      ���	#FF252323#��z��5      $ 5��6E   ._�5      �� $ PART_ContentHost��6   5       5      P� 5       � {� .  . �5      �� #	 � ��63   $
 Bd��6u    � ���� 5      #	 � ��63    � ��5      P� 5       � ��$
 Auto��6+   . �5      ��  � ��$		 100��61   5      P� 5       � ��$
 Auto��6,   . �5      ��  � ��$	 20��62   5      5      5      .��5       � ��5!   
   �� 5"       j� Viewport$ 0,0,1,1�6    �� ImageSource$% /Client;component/autoskola.jpg��6/   .+�5$   
   �� $��Prijava��6   $��Center=�6"   $
��Left=�6F   $��66��6a   $��
136,10,0,0q�6m   $	��Top=�6�   $	��299��6�   $��Kozuka Mincho Pr6N EL)�6�   $��26(�6�   
�������6�   �� 5%   
   $��Korisnicko ime:��6   $
��Left=�6*   $
��Left=�6L   $��34��6g   $��
116,95,0,0q�6s   $	��Top=�6�   $	��102��6�   $��Khmer UI)�6�   $��20(�6�   
�������6�   �� 5&   
   $��Sifra:��6   $
��Left=�6!   $
��Left=�6C   $��38��6^   $��121,148,0,0q�6j   $	��Top=�6   $��97��6�   $��Khmer UI)�6�   $��20(�6�   
�������6�   �� 5'   
   #��[  6   $��Center=�6I   $
��Left=�6f   $��Center=�6�   $��Khmer UI)�6�   $��20(�6   $��39��6   �� TextWrapping$
 Wrap=�6  $	��Top=�6/  $	��243��6G  $��216,90,83,0q�6S  ���	#FF282829���	#FFA7A9A8��6�   �� *
UserName+ �� UpdateSourceTrigger$ PropertyChanged=�6�  �� 5(   
   #��[  6   $��Center=�6I   $
��Left=�6g   $��Center=�6�   $��Khmer UI)�6�   $��20(�6   $��39��6  $
 Wrap=�6  $	��Top=�6/  $	��243��6G  $��216,147,83,0q�6S  ���	#FF282829���	#FFA7A9A8��6�   �� *
Password+$ PropertyChanged=�6�  �� 5)   
   $��
Prijavi se��6   $
��Left=�6J   $��Khmer UI)�6e   $��19(�6{   $	��Top=�6�   $��90��6�   $��128,222,0,0q�6�   $��30��6�    J� RenderTransformOrigin$ 0.769,0.381&�6�   ���	#FFCBC7C7��6'   �� *PrijavaKomanda+��6�   Z� 6  5+      5,      