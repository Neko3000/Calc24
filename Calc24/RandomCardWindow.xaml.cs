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
using System.Timers;
using System.Windows.Threading;
using Week04;
using System.Windows.Media.Animation;

namespace Calc24
{
    /// <summary>
    /// RandomCardWindow.xaml 的交互逻辑
    /// </summary>
    public partial class RandomCardWindow : Window
    {
        private RandomNumbersBuilder RandomNumbersHub;
        private DispatcherTimer MainCounter;
        private Time MainClock;
        private bool KeyboardIsShowing=false;
        private Keyboard MainKeyBoard;
        private ConfirmNumbers MainConfirmNumbers;

        public RandomCardWindow()
        {
            InitializeComponent();
            RandomNumbersHub = new RandomNumbersBuilder();         
        }

        private void Reflash_Click(object sender, RoutedEventArgs e)
        {
            answer.Clear();
            RandomNumbersHub.RenderRandomNumbers();
            string imagePathFrontPart = "image/poker.cards_";
            card1.Source = new BitmapImage(new Uri(imagePathFrontPart+  RandomNumbersHub.PickupRandomNumber(0).ToString().PadLeft(2,'0')+".png",UriKind.Relative));
            card2.Source = new BitmapImage(new Uri(imagePathFrontPart + RandomNumbersHub.PickupRandomNumber(1).ToString().PadLeft(2, '0') + ".png", UriKind.Relative));
            card3.Source = new BitmapImage(new Uri(imagePathFrontPart + RandomNumbersHub.PickupRandomNumber(2).ToString().PadLeft(2, '0') + ".png", UriKind.Relative));
            card4.Source = new BitmapImage(new Uri(imagePathFrontPart + RandomNumbersHub.PickupRandomNumber(3).ToString().PadLeft(2, '0') + ".png", UriKind.Relative));

            
            int[] tempArray = { RandomNumbersHub.NumberA,RandomNumbersHub.NumberB,RandomNumbersHub.NumberC,RandomNumbersHub.NumberD };
            MainConfirmNumbers = new ConfirmNumbers(tempArray);

            MainClock = new Time();

            if (MainCounter != null)
            {
                MainCounter.Stop();
            }
            MainCounter = new DispatcherTimer();
            MainCounter.Interval = TimeSpan.FromMilliseconds(50);
            MainCounter.Tick += new EventHandler(ChangeTheValueOfClock);


            MainCounter.Start();
        }

        private void ChangeTheValueOfClock(object sender,EventArgs e)
        {
            MainClock.NowTimeAdd(50);
            clock.Content = MainClock.GetStringTime();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void title_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }


        private void ShowKeyboard_Click(object sender, RoutedEventArgs e)
        {
            if(KeyboardIsShowing==false)
            {
                MainKeyBoard = new Keyboard(this.Left-160,this.Top+this.Height-200);
                MainKeyBoard.Owner = this;

                MainKeyBoard.Show();
                KeyboardIsShowing = true;

                Button tempButton = (Button)sender;
                tempButton.Content = ">";
            }
            else
            {
                MainKeyBoard.Close();
                KeyboardIsShowing = false;

                Button tempButton = (Button)sender;
                tempButton.Content = "<";
            }
        }

        private void WindowMove(object sender, EventArgs e)
        {
            if(KeyboardIsShowing==true)
            {
                MainKeyBoard.ChangePosition(this.Left - 160, this.Top + this.Height - 200);
            }

        }

        private void done_Click(object sender, RoutedEventArgs e)
        {
            if (MainConfirmNumbers.ConfirmIt(answer.Text)==true)
            {
                if(Calculater.SimpleAlgebra.Deal(answer.Text)==24)
                {
                    MainCounter.Stop();
                    MessageBox.Show("完成答案\n用时:"+clock.Content.ToString());
                }
            }
            else
            {
                MessageBox.Show("并没有遵循题目中的数字");
            }
        }

        private void tint_Click(object sender, RoutedEventArgs e)
        {
            SoluationMethodFor24 tempSolutionFinder = new SoluationMethodFor24(RandomNumbersHub.NumberA, RandomNumbersHub.NumberB, RandomNumbersHub.NumberC, RandomNumbersHub.NumberD);
            MessageBox.Show(tempSolutionFinder.FindSolution());
        }
    }
}
