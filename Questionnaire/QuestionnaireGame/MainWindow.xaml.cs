using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QuestionnaireLibrary;
using ScoreboardLibrary;
using TriviaApiLibrary;

namespace QuestionnaireGame
{
    public partial class MainWindow : Window, IQuestionHandler
    {
        private const int answerAmount = 4;
        private const int numberOfQuestions = 10;
        private int questionAnswerd = 0;
        private int questionAnswerdCorrect = 0;

        private List<Question> ownQuestions = new List<Question>();
        private Question convertQuestion = new Question(null);
        private Button[] answerButtons = new Button[answerAmount];
        public MainWindow()
        {
            InitializeComponent();
            TriviaApiRequester.RequestRandomQuestion(this);

        }
        public void ProcessQuestion(TriviaMultipleChoiceQuestion question)
        {
            if (question != null)
            {
                convertQuestion.Text = question.Question.Text;
                Answer correctAnswer = new Answer(question.CorrectAnswer, true);
                Answer incorrectAnswer = new Answer(question.IncorrectAnswers[0], false);
                Answer incorrectAnswer2 = new Answer(question.IncorrectAnswers[1], false);
                Answer incorrectAnswer3 = new Answer(question.IncorrectAnswers[2], false);
                List<Answer> answers = new List<Answer>();
                answers.Add(correctAnswer);
                answers.Add(incorrectAnswer);
                answers.Add(incorrectAnswer2);
                answers.Add(incorrectAnswer3);
                Shuffle(answers);
                txtQuestion.Text = convertQuestion.Text;
                for (int i = 0; i < answerAmount; i++)
                {
                    int answerIndex = i;
                    this.answerButtons[i] = new Button();
                    this.answerButtons[i].Content = new TextBlock()
                    {
                        Text = answers[i].Text,
                        TextWrapping = TextWrapping.Wrap,

                    };
                    this.answerButtons[i].Click += (sender, e) => CheckAnswer(answerIndex, answers);
                    this.answerButtons[i].Margin = new Thickness(0, 10, 0, 0);
                    this.answerButtons[i].Padding = new Thickness(5, 5, 5, 5);
                    this.answerButtons[i].BorderBrush = Brushes.HotPink;
                    this.answerButtons[i].Background = Brushes.LightPink;
                    this.answerButtons[i].Foreground = Brushes.HotPink;
                    this.answerButtons[i].FontSize = 15;
                    this.answerButtons[i].Width = Double.NaN;
                    btbAnswers.Children.Add(answerButtons[i]);
                    btnNextQuestion.IsEnabled = false;
                }
            }
            else
            {
                MessageBox.Show("No question found");
            }

        }
        private async void CheckAnswer(int answerIndex, List<Answer> answers)
        {
            foreach (var button in answerButtons)
            {
                btnNextQuestion.IsEnabled = true;
                button.IsEnabled = false;
            }
            if (answers[answerIndex].IsCorrect)
            {
                txtCorrectAnswer.Text = "Correct";
                questionAnswerdCorrect++;
            }
            else
            {
                string correctAnswer = "";
                foreach (var answer in answers)
                {
                    if (answer.IsCorrect)
                    {
                        correctAnswer = answer.Text;
                        break;
                    }
                }
                txtCorrectAnswer.Text = $"Incorrect, the correct answer is {correctAnswer}";
            }
        }
        private async void btnNextQuestion_Click(object sender, RoutedEventArgs e)
        {
            questionAnswerd++;
            if (questionAnswerd < numberOfQuestions)
            {
                btbAnswers.Children.Clear();
                txtCorrectAnswer.Text = "";
                TriviaApiRequester.RequestRandomQuestion(this);
            }
            else
            {
                Scoreboard scoreboard = new Scoreboard(questionAnswerdCorrect, numberOfQuestions);
                scoreboard.Show();
                this.Close();
            }
        }
        private void btnMinimalize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            Window aboutWindow = new About();
            aboutWindow.Show();
        }

        public void Shuffle<T>(List<T> list)
        {
            Random random = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}