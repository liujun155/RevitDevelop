   M S B A M L   `   `   `  ����G  CRevitDevelop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:RevitDevelop.ViewsRevitDevelop.Views  5      G CBasicProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA0clr-namespace:BasicProject;assembly=BasicProjectBasicProject 5      E AAdWindows, Version=6.3.0.21, Culture=neutral, PublicKeyToken=nullF1clr-namespace:Autodesk.Windows;assembly=AdWindowsAutodesk.Windows 5      &     RevitDevelop.Views.EditParamView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:RevitDevelop.Views     5      Bbasic0clr-namespace:BasicProject;assembly=BasicProject     5      @aw1clr-namespace:Autodesk.Windows;assembly=AdWindows     5        � Title$  编辑参数��5	       � WindowStartupLocation$ CenterScreen=�6%   $	��230��5
      $	��300��6    � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType �� RadiusX �� RadiusY	 ��Name��%�  '��       '�� �     '��      �� 5   
   " ��6   .�5      ��  � ��$ Center=�64   6E   �� 5       � ��$ Center=�62   6C   �� 5       � ��$ 16(�6)   66   5      �� 5   
   " ��6   .�5      ��  � ��$	 160��6&   64   �� 5       � ��$ 30��6'   64   �� 5       � ��$ Center=�64   6E   �� 5       � ��$ Center=�62   6C   �� 5       � ��$ 16(�6)   66   �� 5       � ��$ Center=�69   6J   �� 5       � �� 5      �� 5      " ��6&   .R�5      � .+�5      �� $ 5��6(   $ 5��64   #��z��6@   ���#808080$	��1.3��6v   �� 5      $	 PART_ContentHost��6+   $��Hidden=�5      $��Hidden=�5      #��z��5       |�.  5"      5#      5$      5&      50      �� 51   
   " ��6   .�52      ��  � ��$ 60��6&   63   �� 53       � ��$ 25��6'   64   54      55      .��56      � 
 � RowDefinitions
 57   
   �� 58      $��* �6   �� 59      $��* �6   �� 5:      $��* �6   �� 5;      $��* �6    � ColumnDefinitions 5=   
   �� 5>      $��80 �6   �� 5?      .+�5A   
   �� 长：6   �� 5B   
   $��1��6   宽：6%   �� 5C   
   $��2��6   高：6%   �� 5D   
   $��1��6   ��6"   �� *Length+6<   �� 5E   
   $��1��6   $��1��6   ��6/   �� *Width+6H   �� 5F   
   $��2��6   $��1��6   ��6/   �� *Height+6I   �� 5G   
   $��3��6   $��2��6"    �� Orientation$ 
Horizontal=�66   $��Center=�6O   $��Center=�6l   .+�5H      �� -   5        $��btnOk��5H      $��0 0 20 0q�6"   .��6H   确定6L   �� 5I      -   5        $��	btnCancel��5I      .��6>   取消6B   5J      5K      5L      