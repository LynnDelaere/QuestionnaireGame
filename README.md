# Questionnaire App

## Author

This application has been developed by Lynn Delaere, a student enrolled in the Electronics- ICT 
course at VIVES University Of Applied Sciences, Bruges.

## Project description

In the entire solution, you'll discover five distinct components: a library called "Questionnaire", 
"Scoreboard" and "TriviaLibrary", a console application called "QuestionnaireApplication" and a 
Windows Presentation Foundation application called "QuestionnaireGame"

### Questionnaire Library

This library contains two classes, a 'Question' class and a 'Answer' class. 

The 'Question' class represents a question in a questionnaire. It contains three attributes,
'Text': which stores the test of the question, 
'PossibleAnswers': a list of 'Answer' objects that represtents the possible answers to the question 
and an 'ImageUrl' string property holding the URL of an image associated with the question.
There is a constructor that initializes the 'Text'. The class also includes methods for adding answers 
to a list of 'PossibleAnswers', retrieving an answer by its index, determing the correct answer and 
a override 'ToString()' method to provide a string representation of the question.

The 'Answer' class represents an answer option for a question. It contains two attributes, 'Text': 
which stores the text of the answer and a boolean 'IsCorrect' indicating whether the answer is 
correct or not. 
 The class has a constructor to initialize these attributes and an 
 overridden ToString() method to return the answer text.

 ### Scoreboard Library

This library contains two classes, a 'PlayerScore' class and a 'ScoreBoard' class.

The 'PlayerScore' class represents a player's score in a game. It contains two attirbutes, 
'name': to store the player's name and 'score': to hold the player's score. 
The two attibutes both have properties to access and modify the attibutes. 
The constructor initializes the properties with a given values. There is a 'ToString()' overrride 
methode to generate a string representation of the player's name and score.

### QuestionnaireApplication Console Application
