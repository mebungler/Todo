   M S B A M L   `   `   `  ����?  ;ToDo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ToDoToDo  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType   	Hoverless �� Property �� Value  MainTextBrush �� 
TargetType �� Padding  SystemIconButton �� BasedOn'   !System.Windows.Shell.WindowChrome  ControlButton  FontAwesome �� Triggers P� Property P� Value  ActiveControlBrush  CloseButton  TabbedButton  AppBackgroundBrush 	 AnimatedButton	 �� 	Resources 
 Key
 �� TargetProperty W� From	 W� To g� Duration �� 	Converter+   %ToDo.BooleanToVisibiltyValueConvertor �� ConverterParameter �� Binding �� RelativeSource �� Value N� EnterActions  SpinAndSlideToRight N� ExitActions  SpinAndSlideToLeft  RoundButton �� CornerRadius�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      localclr-namespace:ToDo  5      %,  &	        7  &	 F    7   &	 �    7  7  7  &	      7  &	 �    7  7  &		 g    7  7  7  &	 �    7  7  7  �� 5	      "  ��6   .�5
   
   ��  � ��
 ���� 6=   �� 5   
    � ��8   6P   �� 5   
    � ��$ 0q�6,   68   �� 5   
    � �� 5      �� 5      " ��6"   .R�5      �� # z��6   #��z��6A   ._�5      �� $��Center=�6+   $��Center=�6F   5      5      5      5      �� 5      "  ��6   8   .�5   
   ��   �@  IsHitTestVisibleInChrome . 6Q   �� 5   
    � ��$ 10q�6$   61   5      �� 5      "  ��6   .�5    
   ��  � ��
 ���� 6=   �� 5!   
     �@  IsHitTestVisibleInChrome . 6Q   �� 5"   
    � ��8   6P   �� 5#   
    � ��$
 Bold"�6'   66   �� 5$   
    � ��$ Stretch=�6.   6@   �� 5%   
    � ��$ 8q�6$   �� 5&   
    � �� 5'      �� 5(      " ��6"   .R�5)      �� # z��6   #��z��6A   ._�5*      �� #��z��6$   $��Center=�6E   $��Center=�6b   8�� 6�   5+      5,      5.       5/   
   P� 50       �@J�IsMouseOver . . �51      ��  � ��8  6]   52      54      �� 57      "  ��6    8   .�58   
   ��  � ��$ 15(�6%    59   
   P� 5:       �@J�IsMouseOver . . �5;      ��  � ��
 �  ��6/   5<      5>      �� 5@      "  ��6!   .�5A   
   ��  � ��8   6U   �� 5B   
    � ��$ 2 2 2 0q�6,   6>   �� 5C   
    � ��8  6V   5D      �� 5G      "  ��6   8   	 5H   
   ���� 5I      SpinAndSlideToLeft
 .��5J      W� $9
 3(UIElement.RenderTransform).(RotateTransform.Angle)�5K      $ 0X�5L      $	 360X�5M      $ 0:0:2D�5N      5O      W� 5P      $
 (Canvas.Left)�6"   $ 0:0:2D�5Q   "   $	 -30X�5R   "   $ 0X�5S   "   6+   5T      �� 5U      SpinAndSlideToRight
 .��5V      W� $9
 3(UIElement.RenderTransform).(RotateTransform.Angle)�5W      $ 0X�5X      $	 360X�5Y      $ 0:0:2D�5Z      5[      W� 5\      $
 (Canvas.Left)�6"   $ 0X�5]   "   $ 30X�5^   "   6,   5_      5`      .�5a   
   ��  � y� 6'   �� *	IsEditing+   $
 smth�� 5b   
   �� 5c       6   �� *
Visibility+ �� *TemplatedParent+ Visible6i    5d      �� 5e      8�� 6Z    5g      �� 5h      8�� 6&   5j      5l      �� 5n      "  ��6   .�5o   
   ��  � ��
 �  ��65   �� 5p   
     �@  IsHitTestVisibleInChrome . 6Q   �� 5q   
    � ��8   6P   �� 5r   
    � ��$
 Bold"�6'   66   �� 5s   
    � ��$ Stretch=�6.   6@   �� 5t   
    � ��$ 8q�6$   �� 5u   
    � ��$ 20q�6#   �� 5v   
    � ��$ 50��6#   �� 5w   
    � ��$ 50��6"   �� 5x   
    � �� 5y      �� 5z      " ��6"   .R�5{      �� # z��6   $ 50��6A   #��z��6S   ._�5|      �� #��z��6$   $��Center=�6E   $��Center=�6b   8�� 6�   5}      5~      5�       5�   
   P� 5�       �@J�IsMouseOver . . �5�      ��  � ��8  6]   5�      5�      5�      