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
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode2023
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RiddleAnswerService answerService;

        public MainWindow()
        {
            InitializeComponent();
            answerService = new RiddleAnswerService();
        }

        private void DayOnePartOneButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeTbAnswerText(answerService.DayOnePartOne().ToString());
        }
        private void DayOnePartTwoButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeTbAnswerText(answerService.DayOnePartTwo().ToString());
        }


        private void ChangeTbAnswerText(string text)
        {
            tbAnswer.Text = text;
        }

        private void HelloWorldButton_Click(object sender, RoutedEventArgs e)
        {
            tbAnswer.Text = "Hello";
        }
    }
}
