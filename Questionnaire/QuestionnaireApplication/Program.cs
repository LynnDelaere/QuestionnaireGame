using System;
using QuestionnaireLibrary;
using ScoreboardLibrary;

namespace QuestionnaireApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Question> questions = new List<Question>();
            {
                Console.WriteLine("Welcome to the Quiz Application!");
                Console.WriteLine("Let me introduce you our players:\n");
                // Initialize players
                PlayerScore player1 = new PlayerScore("Meriadoc", 0);
                PlayerScore player2 = new PlayerScore("Frodo", 0);
                PlayerScore player3 = new PlayerScore("Samwise", 0);
                PlayerScore player4 = new PlayerScore("Peregrin", 0);
                // Display players
                Console.WriteLine(player1.Name);
                Console.WriteLine(player2.Name);
                Console.WriteLine(player3.Name);
                Console.WriteLine(player4.Name);
                // Initialize scoreboard
                Scoreboard scoreboard = new Scoreboard();
                scoreboard.AddPlayer(player1.Name, player1.Score);
                scoreboard.AddPlayer(player2.Name, player2.Score);
                scoreboard.AddPlayer(player3.Name, player3.Score);
                scoreboard.AddPlayer(player4.Name, player4.Score);
                Console.WriteLine();
                // Sample questions
                Question question1 = new Question("What two items does Bilbo give to Frodo in Rivendell?");
                question1.Add(new Answer("Sting and Mithril vest", true));
                question1.Add(new Answer("The One Ring", false));
                question1.Add(new Answer("Mithril vest and Andúril", false));
                Question question2 = new Question("What´s the elvish word for friend? ");
                question2.Add(new Answer("Fellon", false));
                question2.Add(new Answer("Mellon", true));
                question2.Add(new Answer("Papallon", false));
                // Make a list of questions
                questions.Add(question1);
                questions.Add(question2);
                // Start quiz
                Console.WriteLine("Let's start the quiz!\n");
                // Loop through players
                foreach (var player in scoreboard.GetScoreList())
                {
                    Console.WriteLine($"Player: {player.Name}");
                    // Loop through questions
                    foreach (var question in questions)
                    {
                        Console.WriteLine(question.Text);
                        // Loop through possible answers and display them 
                        for (int i = 0; i < question.PossibleAnswers.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {question.PossibleAnswers[i].Text}");
                        }
                        Console.Write("Your answer: ");
                        // Generator for random answers
                        Random randomAnswer = new Random();
                        // Randomly choose an answer between 0 and the number of possible answers
                        int playerAnswerRandom = randomAnswer.Next(0, question.PossibleAnswers.Count);
                        // Get the answer based on the randomly chosen index
                        Answer playerAnswer = question.GetAnswer(playerAnswerRandom);
                        // Check if the answer is correct
                        // If the answer is correct, update the player's score
                        if (playerAnswer.IsCorrect)
                        {
                            Console.WriteLine("Correct Answer!\n");
                            scoreboard.UpdatePlayerScore(player.Name, 1);
                        }
                        // If the answer is incorrect, display the correct answer
                        else
                        {
                            Console.WriteLine($"Incorrect Answer! The correct answer is: {question.CorrectAnswer()}\n");
                        }
                    }
                }
                // Display scoreboard
                Console.WriteLine("\n *** Scoreboard: ***");
                Console.WriteLine(scoreboard.ToString());
            }
        }
    }
}