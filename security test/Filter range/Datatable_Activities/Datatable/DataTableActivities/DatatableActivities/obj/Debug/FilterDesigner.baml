   M S B A M L   `   `   `  ����e  aSystem.Activities.Presentation, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35wTclr-namespace:System.Activities.Presentation;assembly=System.Activities.PresentationSystem.Activities.Presentation  5      �Yclr-namespace:System.Activities.Presentation.View;assembly=System.Activities.Presentation#System.Activities.Presentation.View  5      �_clr-namespace:System.Activities.Presentation.Converters;assembly=System.Activities.Presentation)System.Activities.Presentation.Converters  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections 5      1&clr-namespace:System;assembly=mscorlibSystem 5       DatatableActivities2   ,DatatableActivities.Designers.FilterDesigner   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      dsapTclr-namespace:System.Activities.Presentation;assembly=System.Activities.Presentation     5      jsapvYclr-namespace:System.Activities.Presentation.View;assembly=System.Activities.Presentation     5      v
converters_clr-namespace:System.Activities.Presentation.Converters;assembly=System.Activities.Presentation     5      Jcollections2clr-namespace:System.Collections;assembly=mscorlib     5      9system&clr-namespace:System;assembly=mscorlib     5      -   5          � 	Resources  5	      M   GSystem.Activities.Presentation.Converters.ArgumentToExpressionConverter   ArgConv"  System.Collections.Hashtable 
 opList  Key;   5System.Activities.Presentation.View.ExpressionTextBox �� 
TargetType �� Property �� Value��%(  &	        &	      '  G    '��       5
   
   63     5   
   ��5      
Equals 1��6.   ��5      Does Not Equal 2��66   ��5      Is Greater Than 3��67   ��5      Is Greater Than Or Equal To 4��6C   ��5      Is Less Than 5��64   ��5      Is Less Than Or Equal To 6��6@   ��5      Begins With 7��63   ��5      Does Not Begin With 8��6;   ��5      	Ends With 9��61   ��5      Does Not End With 10��6:   ��5      Contains 11��61   ��5      Does Not Contain 12��69   5      �� 5   
   "  6   .�5      ��  � ��$ 25��6'   �� 5       � ��$ 1q�60   �� 5       � ��
 �   �6,   �� 5       �@ HintText$ Mention Header Name��6)   �� 5       �@ ExpressionType$ system:StringL�6/   �� 5       �@ OwnerActivity 6.   �� *	ModelItem+�� 5        � ��$ 0q�6(   �� 5!       � ��$ 0q�6'   �� 5"       �@ MaxLines$ 1��6@   5#      �� 5$   
   " ��6   .�5%      ��  � ��$ 25��6'   �� 5&       � ��
 �   �6,   �� 5'       � ��$ 1q�6'   �� 5(       � ��$ 1q�60   �� 5)       � ��$ 0q�6(   �� 5*       � ��$ 0q�6'   5+      5,      .��5-      �  � RowDefinitions 5.   
   �� 5/      $
��AUTO �6   �� 50      $��* �6   �� 51      $
��AUTO �6   .+�53   
   ��  �� Orientation$ 
Horizontal=�6   .+�54      �� $��Header Name��6   $	��100��6+   $
��Bold"�67   �� 55      $��	Operators��6   $	��100��6)   $
��Bold"�65   �� 56      $��Values to filter��6   $	��250��60   $
��Bold"�6<   57      �� 58   
   $��1��6   .+�59      �� $	��100��6   .��5:      �� -   5         ��Name$ pnlBoxes��5:      $ Vertical=�6/   .+�5;      �� $ 
Horizontal=�6!   .+�5<           ExpressionType" ��5=      $	��100��5>         HintText$ Ex. "Region"��5?      	   OwnerActivity	 5@      �� *	ModelItem+
   
Expression
 5A      �� *ModelItem.HeaderExpression0+ �� Mode$ TwoWay=� �� 	Converter# [   �� ConverterParameter$ In���� 5B      $	��100��5C       �� DisplayMemberPath$	 Key��5D       �� SelectedValuePath$ Value��5E      #��[ 5F       �� SelectedValue 5G      �� *ModelItem.FilterOperator0+  5H        System.Array"  5I      $	��250��5J      $ Ex. {"Asia", Europe}��5K      	 5L      �� *	ModelItem+
 5M      �� *ModelItem.ValueExpression0+$ TwoWay=�# [  $ In��5N      �� 5O      $ 
Horizontal=�6!   $��1��6:   .+�5P        " ��5Q      $	��100��5R      $ Ex. "Region"��5S      	 5T      �� *	ModelItem+
 5U      �� *ModelItem.HeaderExpression1+$ TwoWay=�# [  $ In���� 5V      $	��100��5W      $	 Key��5X      $ Value��5Y      #��[ 5Z       5[      �� *ModelItem.FilterOperator1+  5\      "  61   $	��250��5]      $ Ex. {"Asia", Europe}��5^      	 5_      �� *	ModelItem+
 5`      �� *ModelItem.ValueExpression1+$ TwoWay=�# [  $ In��5a      �� 5b      $ 
Horizontal=�6!   $��2��6:   .+�5c        " ��5d      $	��100��5e      $ Ex. "Region"��5f      	 5g      �� *	ModelItem+
 5h      �� *ModelItem.HeaderExpression2+$ TwoWay=�# [  $ In���� 5i      $	��100��5j      $	 Key��5k      $ Value��5l      #��[ 5m       5n      �� *ModelItem.FilterOperator2+  5o      "  61   $	��250��5p      $ Ex. {"Asia", Europe}��5q      	 5r      �� *	ModelItem+
 5s      �� *ModelItem.ValueExpression2+$ TwoWay=�# [  $ In��5t      �� 5u      $ 
Horizontal=�6!   $��3��6:   .+�5v        " ��5w      $	��100��5x      $ Ex. "Region"��5y      	 5z      �� *	ModelItem+
 5{      �� *ModelItem.HeaderExpression3+$ TwoWay=�# [  $ In���� 5|      $	��100��5}      $	 Key��5~      $ Value��5      #��[ 5�       5�      �� *ModelItem.FilterOperator3+  5�      "  61   $	��250��5�      $ Ex. {"Asia", Europe}��5�      	 5�      �� *	ModelItem+
 5�      �� *ModelItem.ValueExpression3+$ TwoWay=�# [  $ In��5�      �� 5�      $ 
Horizontal=�6!   $��4��6:   .+�5�        " ��5�      $	��100��5�      $ Ex. "Region"��5�      	 5�      �� *	ModelItem+
 5�      �� *ModelItem.HeaderExpression4+$ TwoWay=�# [  $ In���� 5�      $	��100��5�      $	 Key��5�      $ Value��5�      #��[ 5�       5�      �� *ModelItem.FilterOperator4+  5�      "  61   $	��250��5�      $ Ex. {"Asia", Europe}��5�      	 5�      �� *	ModelItem+
 5�      �� *ModelItem.ValueExpression4+$ TwoWay=�# [  $ In��5�      �� 5�      $ 
Horizontal=�6!   $��5��6:   .+�5�        " ��5�      $	��100��5�      $ Ex. "Region"��5�      	 5�      �� *	ModelItem+
 5�      �� *ModelItem.HeaderExpression5+$ TwoWay=�# [  $ In���� 5�      $	��100��5�      $	 Key��5�      $ Value��5�      #��[ 5�       5�      �� *ModelItem.FilterOperator5+  5�      "  61   $	��250��5�      $ Ex. {"Asia", Europe}��5�      	 5�      �� *	ModelItem+
 5�      �� *ModelItem.ValueExpression5+$ TwoWay=�# [  $ In��5�      �� 5�      $ 
Horizontal=�6!   $��6��6:   .+�5�        " ��5�      $	��100��5�      $ Ex. "Region"��5�      	 5�      �� *	ModelItem+
 5�      �� *ModelItem.HeaderExpression6+$ TwoWay=�# [  $ In���� 5�      $	��100��5�      $	 Key��5�      $ Value��5�      #��[ 5�       5�      �� *ModelItem.FilterOperator6+  5�      "  61   $	��250��5�      $ Ex. {"Asia", Europe}��5�      	 5�      �� *	ModelItem+
 5�      �� *ModelItem.ValueExpression6+$ TwoWay=�# [  $ In��5�      �� 5�      $ 
Horizontal=�6!   $��7��6:   .+�5�        " ��5�      $	��100��5�      $ Ex. "Region"��5�      	 5�      �� *	ModelItem+
 5�      �� *ModelItem.HeaderExpression7+$ TwoWay=�# [  $ In���� 5�      $	��100��5�      $	 Key��5�      $ Value��5�      #��[ 5�       5�      �� *ModelItem.FilterOperator7+  5�      "  61   $	��250��5�      $ Ex. {"Asia", Europe}��5�      	 5�      �� *	ModelItem+
 5�      �� *ModelItem.ValueExpression7+$ TwoWay=�# [  $ In��5�      �� 5�      $ 
Horizontal=�6!   $��8��6:   .+�5�        " ��5�      $	��100��5�      $ Ex. "Region"��5�      	 5�      �� *	ModelItem+
 5�      �� *ModelItem.HeaderExpression8+$ TwoWay=�# [  $ In���� 5�      $	��100��5�      $	 Key��5�      $ Value��5�      #��[ 5�       5�      �� *ModelItem.FilterOperator8+  5�      "  61   $	��250��5�      $ Ex. {"Asia", Europe}��5�      	 5�      �� *	ModelItem+
 5�      �� *ModelItem.ValueExpression8+$ TwoWay=�# [  $ In��5�      �� 5�      $ 
Horizontal=�6!   $��9��6:   .+�5�        " ��5�      $	��100��5�      $ Ex. "Region"��5�      	 5�      �� *	ModelItem+
 5�      �� *ModelItem.HeaderExpression9+$ TwoWay=�# [  $ In���� 5�      $	��100��5�      $	 Key��5�      $ Value��5�      #��[ 5�       5�      �� *ModelItem.FilterOperator9+  5�      "  61   $	��250��5�      $ Ex. {"Asia", Europe}��5�      	 5�      �� *	ModelItem+
 5�      �� *ModelItem.ValueExpression9+$ TwoWay=�# [  $ In��5�      �� 5�      $ 
Horizontal=�6!   $��10��6:   .+�5�        " ��5�      $	��100��5�      $ Ex. "Region"��5�      	 5�      �� *	ModelItem+
 5      �� *ModelItem.HeaderExpression10+$ TwoWay=�# [  $ In���� 5     $	��100��5     $	 Key��5     $ Value��5     #��[ 5      5     �� *ModelItem.FilterOperator10+  5     "  61   $	��250��5     $ Ex. {"Asia", Europe}��5	     	 5
     �� *	ModelItem+
 5     �� *ModelItem.ValueExpression10+$ TwoWay=�# [  $ In��5     �� 5     $ 
Horizontal=�6!   $��11��6:   .+�5       " ��5     $	��100��5     $ Ex. "Region"��5     	 5     �� *	ModelItem+
 5     �� *ModelItem.HeaderExpression11+$ TwoWay=�# [  $ In���� 5     $	��100��5     $	 Key��5     $ Value��5     #��[ 5      5     �� *ModelItem.FilterOperator11+  5     "  61   $	��250��5     $ Ex. {"Asia", Europe}��5     	 5     �� *	ModelItem+
 5     �� *ModelItem.ValueExpression11+$ TwoWay=�# [  $ In��5     �� 5      $ 
Horizontal=�6!   $��12��6:   .+�5!       " ��5"     $	��100��5#     $ Ex. "Region"��5$     	 5%     �� *	ModelItem+
 5&     �� *ModelItem.HeaderExpression12+$ TwoWay=�# [  $ In���� 5'     $	��100��5(     $	 Key��5)     $ Value��5*     #��[ 5+      5,     �� *ModelItem.FilterOperator12+  5-     "  61   $	��250��5.     $ Ex. {"Asia", Europe}��5/     	 50     �� *	ModelItem+
 51     �� *ModelItem.ValueExpression12+$ TwoWay=�# [  $ In��52     �� 53     $ 
Horizontal=�6!   $��13��6:   .+�54       " ��55     $	��100��56     $ Ex. "Region"��57     	 58     �� *	ModelItem+
 59     �� *ModelItem.HeaderExpression13+$ TwoWay=�# [  $ In���� 5:     $	��100��5;     $	 Key��5<     $ Value��5=     #��[ 5>      5?     �� *ModelItem.FilterOperator13+  5@     "  61   $	��250��5A     $ Ex. {"Asia", Europe}��5B     	 5C     �� *	ModelItem+
 5D     �� *ModelItem.ValueExpression13+$ TwoWay=�# [  $ In��5E     �� 5F     $ 
Horizontal=�6!   $��14��6:   .+�5G       " ��5H     $	��100��5I     $ Ex. "Region"��5J     	 5K     �� *	ModelItem+
 5L     �� *ModelItem.HeaderExpression14+$ TwoWay=�# [  $ In���� 5M     $	��100��5N     $	 Key��5O     $ Value��5P     #��[ 5Q      5R     �� *ModelItem.FilterOperator14+  5S     "  61   $	��250��5T     $ Ex. {"Asia", Europe}��5U     	 5V     �� *	ModelItem+
 5W     �� *ModelItem.ValueExpression14+$ TwoWay=�# [  $ In��5X     �� 5Y     $ 
Horizontal=�6!   $��15��6:   .+�5Z       " ��5[     $	��100��5\     $ Ex. "Region"��5]     	 5^     �� *	ModelItem+
 5_     �� *ModelItem.HeaderExpression15+$ TwoWay=�# [  $ In���� 5`     $	��100��5a     $	 Key��5b     $ Value��5c     #��[ 5d      5e     �� *ModelItem.FilterOperator15+  5f     "  61   $	��250��5g     $ Ex. {"Asia", Europe}��5h     	 5i     �� *	ModelItem+
 5j     �� *ModelItem.ValueExpression15+$ TwoWay=�# [  $ In��5k     �� 5l     $ 
Horizontal=�6!   $��16��6:   .+�5m       " ��5n     $	��100��5o     $ Ex. "Region"��5p     	 5q     �� *	ModelItem+
 5r     �� *ModelItem.HeaderExpression16+$ TwoWay=�# [  $ In���� 5s     $	��100��5t     $	 Key��5u     $ Value��5v     #��[ 5w      5x     �� *ModelItem.FilterOperator16+  5y     "  61   $	��250��5z     $ Ex. {"Asia", Europe}��5{     	 5|     �� *	ModelItem+
 5}     �� *ModelItem.ValueExpression16+$ TwoWay=�# [  $ In��5~     �� 5     $ 
Horizontal=�6!   $��17��6:   .+�5�       " ��5�     $	��100��5�     $ Ex. "Region"��5�     	 5�     �� *	ModelItem+
 5�     �� *ModelItem.HeaderExpression17+$ TwoWay=�# [  $ In���� 5�     $	��100��5�     $	 Key��5�     $ Value��5�     #��[ 5�      5�     �� *ModelItem.FilterOperator17+  5�     "  61   $	��250��5�     $ Ex. {"Asia", Europe}��5�     	 5�     �� *	ModelItem+
 5�     �� *ModelItem.ValueExpression17+$ TwoWay=�# [  $ In��5�     �� 5�     $ 
Horizontal=�6!   $��18��6:   .+�5�       " ��5�     $	��100��5�     $ Ex. "Region"��5�     	 5�     �� *	ModelItem+
 5�     �� *ModelItem.HeaderExpression18+$ TwoWay=�# [  $ In���� 5�     $	��100��5�     $	 Key��5�     $ Value��5�     #��[ 5�      5�     �� *ModelItem.FilterOperator18+  5�     "  61   $	��250��5�     $ Ex. {"Asia", Europe}��5�     	 5�     �� *	ModelItem+
 5�     �� *ModelItem.ValueExpression18+$ TwoWay=�# [  $ In��5�     �� 5�     $ 
Horizontal=�6!   $��19��6:   .+�5�       " ��5�     $	��100��5�     $ Ex. "Region"��5�     	 5�     �� *	ModelItem+
 5�     �� *ModelItem.HeaderExpression19+$ TwoWay=�# [  $ In���� 5�     $	��100��5�     $	 Key��5�     $ Value��5�     #��[ 5�      5�     �� *ModelItem.FilterOperator19+  5�     "  61   $	��250��5�     $ Ex. {"Asia", Europe}��5�     	 5�     �� *	ModelItem+
 5�     �� *ModelItem.ValueExpression19+$ TwoWay=�# [  $ In��5�     5�     5�     5�     �� 5�  
   $��2��6   $ 
Horizontal=�6#   $��Right=�6<   .+�5�     �� -   5        $��Remove��5�     $��2q�69   6F   �� 5�     -   5        $	��Add��5�     $��2q�64   6A   5�     5�     5�     