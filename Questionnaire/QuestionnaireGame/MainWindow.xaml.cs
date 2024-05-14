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
        const int answerAmount = 4;
        const int numberOfQuestions = 10;
        int currentQuestionIndex = 0;

        Question ConvertQuestion = new Question(null);
        Button[] answerButtons = new Button[answerAmount];
        public MainWindow()
        {
            InitializeComponent();
            TriviaApiRequester.RequestRandomQuestion(this);
        }
        public void ProcessQuestion(TriviaMultipleChoiceQuestion question)
        {
            ConvertQuestion.Text = question.Question.Text;
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
            txtQuestion.Text = ConvertQuestion.Text;
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
                this.answerButtons[i].FontSize = 20;
                this.answerButtons[i].Width = Double.NaN;
                btbAnswers.Children.Add(answerButtons[i]);
            }
        }
        public async void CheckAnswer(int answerIndex, List<Answer> answers)
        {
            if (answers[answerIndex].IsCorrect)
            {
                txtCorrectAnswer.Text = "Correct";
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
            currentQuestionIndex++;
            if (currentQuestionIndex < numberOfQuestions)
            {
                btbAnswers.Children.Clear();
                txtCorrectAnswer.Text = "";
                TriviaApiRequester.RequestRandomQuestion(this);
            }
            else
            {
                MessageBox.Show("There are no more questions");
                Application.Current.Shutdown();
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