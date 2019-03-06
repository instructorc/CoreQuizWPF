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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoreQuiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int count = 0;
        string[] questions = { "When was .NET core released", "What is the current version of .NET core" };
        string[,] qOptions = {
                                    {"A) 2019", "B) 2014", "C) 2003", "D)1990"},
                                    {"A) 1.0", "B) 2.2", "C) 10.0", "D)3.0" }
                              };
        string[] storedAnswers = { "B) 2014", "B) 2.2" };

        string[] holdUserAnwsers = new string[2];

        List<string> wrong = new List<string>();
        List<string> correct = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            Prev_btn.Visibility = Visibility.Hidden;
            question_txt.Text = questions[count].ToString();
            var radioButtonList = panel_one.Children.OfType<RadioButton>();

            //Iterate through the child radio buttons and assign them values within the array
            for(var x = 0; x < radioButtonList.Count<RadioButton>(); x++)
            {
                radioButtonList.ElementAt<RadioButton>(x).Content = qOptions[count, x];

            }

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            for(var w = 0; w < holdUserAnwsers.Length; w++)
            {
                if(holdUserAnwsers[w] == storedAnswers[w])
                {
                    correct.Add(holdUserAnwsers[w]);
                }
            }

            if(correct.Count > 1)
            {
                MessageBox.Show("You passed!!");
            }
            else
            {
                MessageBox.Show("You Failed");
            }

        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {


            
            Prev_btn.Visibility = Visibility.Visible;
            count++;
            if (quizStatus.Value < quizStatus.Maximum)

            {

                quizStatus.Value++;

            }
            var radioButtonList = panel_one.Children.OfType<RadioButton>();
            foreach(var p in radioButtonList)
            {
                if(p.IsChecked == true)
                {
                    holdUserAnwsers[count-1] = p.Content.ToString();
                }
            }
            MessageBox.Show(holdUserAnwsers[count - 1]);
            if (count < questions.Length)
            {
                question_txt.Text = questions[count].ToString();
               

                //Iterate through the child radio buttons and assign them values within the array
                for (var x = 0; x < radioButtonList.Count<RadioButton>(); x++)
                {
                    radioButtonList.ElementAt<RadioButton>(x).Content = qOptions[count, x];

                }
            }
            //Results aWindow = new Results();
            //aWindow.Show();
            //this.Close();

        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {

            count--;
            if (quizStatus.Value > quizStatus.Minimum)

            {

                quizStatus.Value--;

            }
            if (count == 0)
            {
                Prev_btn.Visibility = Visibility.Hidden;
            }
           
            if (count < questions.Length )
            {
                question_txt.Text = questions[count].ToString();
                var radioButtonList = panel_one.Children.OfType<RadioButton>();

                //Iterate through the child radio buttons and assign them values within the array
                for (var x = 0; x < radioButtonList.Count<RadioButton>(); x++)
                {
                    radioButtonList.ElementAt<RadioButton>(x).Content = qOptions[count, x];

                }
            }
        }
    }
}
