using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
            TextAbout();
        }

        private void btnMinimalize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            
        }
        private void btnGithub_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = $"/c start https://github.com/LynnDelaere",
                CreateNoWindow = true,
                UseShellExecute = false
            });
        }
        private void TextAbout()
        {
            txtAbout.Text = "This application is a questionnaire game. \n" +
                "The user can answer questions and get a score at the end. \n" +
                "The user can also see the correct answers. \n" +
                "The application is made by Lynn Delaere. \n" +
                "Student at VIVES University Of Applied Sciences. \n" +
                "A project for the course Object Oriented Programming. \n" +
                "2023-2024";
        }

    }
}
