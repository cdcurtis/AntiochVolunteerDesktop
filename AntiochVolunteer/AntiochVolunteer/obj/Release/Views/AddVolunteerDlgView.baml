   M S B A M L   `   `   `  ���� K  GAntiochVolunteer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:AntiochVolunteer.Resources.Strings"AntiochVolunteer.Resources.Strings  0    *AntiochVolunteer.Views.AddVolunteerDlgView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Dstrings0clr-namespace:AntiochVolunteer.Resources.Strings     .��� $	��500��  � RowDefinitions  �� $
��Auto ��� $
��Auto �.+��� $��0��$��10q�7   1AntiochVolunteer.Resources.Strings.GenericStrings   CREATE_NEW_VOLUNTEER#��Z .��� $��10q�  �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� ���� *ErrorMessage+� $��1��  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $��5 ��� $��* �.+��� $��0��$��0��   
FIRST_NAME#��Z $��10q��� $��0��$��2��$��	10,5,10,5q����� *UserFirstName+���� *FirstNameBrush+�� $��1��$��0��   	LAST_NAME#��Z $��10q��� $��1��$��2��$��	10,5,10,5q����� *UserLastName+���� *LastNameBrush+�� $��2��$��0��   EMAIL#��Z $��10q��� $��2��$��2��$��	10,5,10,5q����� *	UserEmail+���� *
EmailBrush+�� $��3��$��0��   PHONE#��Z $��10q��� $��3��$��2��$��	10,5,10,5q����� *	UserPhone+���� *
PhoneBrush+� $��2��  �� $
��Auto ��� $
��Auto �.+��� $��0��$7��1Select the jobs below that volenteer can preform.�� �� TextAlignment$ Center=�&   System.Windows.Controls.DataGrid  $��1��   HeadersVisibility$
 None=�	   AutoGenerateColumns	 .  
   SelectionMode$
 Extended=����� *
JobsList+� $��1�� �� $��* ��� $��* ��� $��* ��� $��* �.+��� $��2��	   OK#��Z ���� *OnOK+�� $��3��   CANCEL#��Z ���� *
OnCancel+