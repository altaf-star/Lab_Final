   M S B A M L   `   `   `  ����  CLO1    CLO1.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Quiz Application��5   	   $	��450��6"   $	��800��6/   .��5      � .+�5   
   � -   5         �Name$ progressBar��5      $��20��6+   $
��Left=�67   $��	10,10,0,0q�6R   $	��Top=�6e   $	��760��6}   $y�	Collapsed=�6�   �� 5
   
    �� Orientation$ 
Horizontal=�6   $
��Left=�6.   $��	10,40,0,0q�6I   $	��Top=�6\   $��40��6t   .+�5      �� -   5         ��Name$ topicComboBox��5      $	��200��6.   $��0,0,10,0q�6:   $	��Top=�6L    �� Text 5      �� 5       �� Path$ SelectedTopic�6    �� UpdateSourceTrigger$ PropertyChanged=�63   .@�5      �� $��Select Topic��6    �� 
IsReadOnly$
 True��6.   
�������6@   5      �� 5      -   5        $ difficultyComboBox��5      $	��200��63   $	��Top=�6?    5      �� 5      $ SelectedDifficulty�6   $ PropertyChanged=�68   .@�5      �� $��Select Difficulty��6   $
 True��63   
�������6E   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ questionsDataGrid��5      	   AutoGenerateColumns$	 False��6.   $��10,90,10,10q�6J   ��6_   �� *QuizQuestions+
 �� Mode$
 TwoWay=�$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Question Text��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6]   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *QuestionText+6]     5      $ Options��6%   $ * 6R    66   �� *	Options+6R     5      $ Correct Answer��6%   $ * 6_    6=   �� *CorrectAnswer+6_     5      $ Assigned Marks��6%   $ * 6_    6=   �� *AssignedMarks+6_     5       $ 
Time Limit��6%   $ * 6W    69   �� *	TimeLimit+6W   5"      �� 5%   
   $ 
Horizontal=�6   $��Right=�6.   $��	0,40,10,0q�6J   $	��Top=�6]   $��40��6u   .+�5&      �� -   5         ��Name$ 	addButton��5&      $��Add Question��6(   $	��100��6?   $��10,0,0,0q�6K   �� 5'      -   5        $ 
editButton��5'      $��Edit Question��6)   $	��100��6A   $��10,0,0,0q�6M   �� 5(      -   5        $ deleteButton��5(      $��Delete Question��6+   $	��100��6E   $��10,0,0,0q�6Q   5)      5*      5+      