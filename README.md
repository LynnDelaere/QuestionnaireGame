# Questionnaire App

## Author

This application has been developed by Lynn Delaere, a student enrolled in the Electronics- ICT course at VIVES University Of Applied Sciences, Bruges.

## Project description

In the entire solution, you'll discover five distinct components: a library called "Questionnaire", "Scoreboard" and "TriviaLibrary", a console application called "QuestionnaireApplication" and a Windows Presentation Foundation application called "QuestionnaireGame"

### QuestionnaireLibrary

This library contains two classes, a 'Question' class and a 'Answer' class.

The 'Question' class represents a question in a questionnaire. It contains three attributes,
'Text': which stores the test of the question, 'PossibleAnswers': a list of 'Answer' objects that represtents the possible answers to the question and an 'ImageUrl' string property holding the URL of an image associated with the question.
There is a constructor that initializes the 'Text'. The class also includes methods for adding answers to a list of 'PossibleAnswers', retrieving an answer by its index, determing the correct answer and a override 'ToString()' method to provide a string representation of the question.

The 'Answer' class represents an answer option for a question. It contains two attributes, 'Text': which stores the text of the answer and a boolean 'IsCorrect' indicating whether the answer is correct or not.
 The class has a constructor to initialize these attributes and an  overridden ToString() method to return the answer text.

### ScoreboardLibrary

This library contains two classes, a 'PlayerScore' class and a 'ScoreBoard' class.

The 'PlayerScore' class represents a player's score in a game. It contains two attirbutes, 'name': to store the player's name and 'score': to hold the player's score.
The two attibutes both have properties to access and modify the attibutes.
The constructor initializes the properties with a given values. There is a 'ToString()' overrride methode to generate a string representation of the player's name and score.

### QuestionnaireApplication

The Console Application utilizes the custom libraries 'QuestionnaireLibrary' and 'ScoreboardLibrary' to represent a simple quiz application. It initializes a list of questions, adds some sample questions and corresponding answers to it and then stats the quiz.

During the quiz the application iterates through each player and asks each question to them. For each question in the list it displays the question and the possible answers. Then it randomly selects an answer for the player and checks if it's correct. If the answer is correct it updates the player's score, otherwise it displays the correct answer.

After all players have answered all the questions a scoreboard is displayed showing each player's score, the player with the highest score first.

### QuestionnaireGame

The code in 'QuestionnaireGame' is designed to engage users with a series of multiple-choice questions. Utilizing the WPF framework, it provides a visually appealing interface for an interactive quiz experience.

Upon launching the application, the main window (MainWindow) is initialized. This window serves as the primary interface for users to interact with the quiz. It implements the IQuestionHandler interface to handle incoming trivia questions.

When the application starts, it sends a request to a trivia API to fetch a random question. Upon receiving the question, the 'ProcessQuestion' method is invoked. This converts the object TriviaMultipleChoiceQuestion to a Question object. Then the method populates the UI with the question text and multiple-choice answers. To ensure that the first answer isn't the correct answer, the answers are shuffled before being displayed to the user.

Once the user selects an answer, the 'CheckAnswer' method verifies its correctness. If the chosen answer matches the correct one, a message indicating "Correct" is displayed. Otherwise, it reveals the correct answer to the user.

The application includes intuitive controls for user navigation. The "Next Question" button allows users to proceed to the next question in the quiz. In case there are no more questions remaining, a message informs the user that the quiz is ended. Additionally, standard window controls like "Minimize" and "Close" provide familiar functionality.

For user convenience, an "About" button is included, which opens a separate window providing information about the application.

## Screenshots

![Main window with first question](/Images/FirstQuestion.png "Main window displaying first question")

![Main window answer first question](/Images/FirstQuestionAnswer.png "Main window displaying if answer is correct")

![Main window with second question](/Images/SecondQuestion.png "Main window displaying if answer is correct")

![About window](/Images/AboutWindow.png "About window")

![Scoreboard window](/Images/Scoreboard.png "Scoreboard window")

![No questions to load](/Images/MessageboxNoInternet.png)

## Setup and Usage

To effectively run the solution and conduct unit tests, certain applications and tools are required. The application is developed using Microsoft Visual Studio, specifically tailored for C# development. Therefore, it's essential to install Visual Studio to facilitate the development environment. You can follow this link for a step-by-step guide on installing Visual Studio Community edition.

Once installed open the project solution called 'Questionnaire.sln' in Visual Studio and build the solution to ensure all dependencies are resolved. Right-click on 'QuestionnaireApplication' and go to 'Configure Startup Projects'. Select single startup project to run the Console Application or the Windows Application, or select multiple startup projects to start both the Console Application and the Windows Application.

## UML Class Diagram

![UML Questionnaire](/Images/UMLQuestionnaire.png "UML diagram")

## Future Improvements

* Enhance user interface design and interactivity in the WPF application.
* Include buttons for category and difficulty so the user can choose the desired questions
* Include buttons so the amount of questions can be increased or decreased
* Making sure that regardless the length of the incoming text it all fits the template
* Make a full scoreboard at the end of the quiz that stores the highscore of players
* Implement own questions when there is no internet connection
