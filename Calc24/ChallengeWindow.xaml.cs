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
using System.Xml;
using System.Windows.Threading;
using Week04;

namespace Calc24
{
    /// <summary>
    /// ChallengeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ChallengeWindow : Window
    {
        private DispatcherTimer MainCounter;
        private Time MainClock;
        private List<double> ColorStep;
        private List<double> ColorNow;

        public ChallengeWindow(string level)
        {
            InitializeComponent();
            XmlDocument doc = new XmlDocument();
            doc.Load("Problems.xml");
            XmlNode levelNode = doc.SelectSingleNode("/Levels/SingleLevel[LevelName='"+level+"']");
            XmlNodeList problemList = levelNode.SelectNodes("ProblemList/Problem");

            int currentRow = 0;
            foreach(XmlNode singleProblem in problemList)
            {
                Label tempLabel = new Label();
                tempLabel.Content = singleProblem.InnerText.Replace("A", " ");
                tempLabel.FontSize = 14.0;
                tempLabel.Margin= new Thickness(20,0,35,10);


                TextBox tempTextBox = new TextBox();
                tempTextBox.Width = 120;
                tempTextBox.Height = 20;
                tempTextBox.Margin= new Thickness(20, 0, 35, 10);
                tempTextBox.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE6E6E6"));
                tempTextBox.FontSize = 13.0;
                tempTextBox.LostFocus += TextBox_LostFocus;

                MainGrid.RowDefinitions.Add(new RowDefinition());

                MainGrid.Children.Add(tempLabel);
                MainGrid.Children.Add(tempTextBox);

                Grid.SetRow(tempLabel, currentRow);
                Grid.SetColumn(tempLabel, 0);

                Grid.SetRow(tempTextBox, currentRow);
                Grid.SetColumn(tempTextBox, 1);

                currentRow++;
            }
            //MessageBox.Show(levelNode["ProblemCount"].InnerText);
            Grid.SetRow(AllDoneButton, currentRow);

            MainClock = new Time();

            if(MainCounter!=null)
            {
                MainCounter.Stop();
            }
            MainCounter = new DispatcherTimer();
            MainCounter.Interval = TimeSpan.FromMilliseconds(50);
            MainCounter.Tick += new EventHandler(ChangeTheValueOfClockAndProgressBar);

            int[] OrgRGB = { 6, 176, 37 };
            int[] ToRGB = { 255, 61, 30 };

            ColorStep = new List<double>();
            ColorStep.Add(((double)ToRGB[0] - OrgRGB[0]) / (1 * 60 * 20));
            ColorStep.Add(((double)ToRGB[1] - OrgRGB[1]) / (1 * 60 * 20));
            ColorStep.Add(((double)ToRGB[2] - OrgRGB[2]) / (1 * 60 * 20));

            ColorNow= new List<double>();
            ColorNow.Add(OrgRGB[0]);
            ColorNow.Add(OrgRGB[1]);
            ColorNow.Add(OrgRGB[2]);
            // double[] ColorStep={ ((double)ToRGB[0] - OrgRGB[0])/(1 * 60 * 20), ((double)ToRGB[1] - OrgRGB[1]) / (1 * 60 * 20), ((double)ToRGB[2] - OrgRGB[2]) / (1 * 60 * 20) };
            //  double[] ColorNow ={ OrgRGB[0],OrgRGB[1],OrgRGB[2] };

            MainCounter.Start();
        }

        private void ChangeTheValueOfClockAndProgressBar(object sender, EventArgs e)
        {
            MainClock.NowTimeAdd(50);
            clock.Content = MainClock.GetStringTime();

            timeRemainer.Value += 100.0 / (1 * 60 * 20);  //1minute

            //color 6,176,37 -> 255,61,30
            ColorNow[0] += ColorStep[0];
            ColorNow[1] += ColorStep[1];
            ColorNow[2] += ColorStep[2];

            timeRemainer.Foreground = new SolidColorBrush(Color.FromRgb((byte)((int)ColorNow[0]), (byte)((int)ColorNow[1]), (byte)((int)ColorNow[2])));
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tempTextBox = sender as TextBox;
            var target =MainGrid.Children.Cast<UIElement>().OfType<Label>().Where(c => Grid.GetRow(c) == Grid.GetRow(tempTextBox));
            string[] splitedNumbers= target.Single().Content.ToString().Split(' ');
            int[] tempNumbers = {Convert.ToInt32(splitedNumbers[0]), Convert.ToInt32(splitedNumbers[1]) , Convert.ToInt32(splitedNumbers[2]) , Convert.ToInt32(splitedNumbers[3])};

            ConfirmNumbers tempConfirmer = new ConfirmNumbers(tempNumbers);
            if (tempConfirmer.ConfirmIt(tempTextBox.Text) == true)
            {
                if (Calculater.SimpleAlgebra.Deal(tempTextBox.Text) == 24)
                {
                    tempTextBox.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC0FFBA"));
                    tempTextBox.Uid = "passed";
                }
                else
                {
                    tempTextBox.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFBABA"));
                    tempTextBox.Uid = "";
                }
            }
            else
            {
                tempTextBox.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFBABA"));
                tempTextBox.Uid = "";
            }
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void title_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void allDone_Click(object sender, RoutedEventArgs e)
        {
            bool allPassed = true;
            var target = MainGrid.Children.Cast<UIElement>().OfType<TextBox>();
            foreach (TextBox tempTextBox in target)
            {
                if(tempTextBox.Uid!="passed")
                {
                    allPassed = false;
                    break;
                }
            }
            if(allPassed==true)
            {
                MainCounter.Stop();
                MessageBox.Show("通过了所有试题\n用时:"+clock.Content.ToString());
            }
            else
            {
                MessageBox.Show("还未完成所有试题");
            }
        }
    }
}
