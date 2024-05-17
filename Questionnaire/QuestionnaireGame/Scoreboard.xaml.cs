using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuestionnaireGame
{
    public partial class Scoreboard : Window
    {
        public Scoreboard(int score, int numberOfQuestions)
        {
            InitializeComponent();
            ShowScore(score, numberOfQuestions);
        }

        private void btnMinimalize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void ShowScore(int score, int numberOfQuestions)
        {
            txtScore.Text = "Your score is: " + score + " out of " + numberOfQuestions;
        }
    }
}
