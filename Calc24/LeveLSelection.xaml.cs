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
using System.Windows.Media.Animation;

namespace Calc24
{
    /// <summary>
    /// LeveLSelection.xaml 的交互逻辑
    /// </summary>
    public partial class LeveLSelection : Window
    {
        private ChallengeWindow ChallengeModeWindow;
        public LeveLSelection()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void title_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void level_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard tempStoryboard= Resources["ExpandAnimation"] as Storyboard;
            Storyboard.SetTargetName(tempStoryboard, ((Button)sender).Name);
            tempStoryboard.Begin();
        }

        private void level_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard tempStoryboard = Resources["ReturnAnimation"] as Storyboard;
            Storyboard.SetTargetName(tempStoryboard, ((Button)sender).Name);
            tempStoryboard.Begin();
        }

        private void levelSelect_Click(object sender, RoutedEventArgs e)
        {
            Button tempButton = (Button)sender;
            ChallengeModeWindow = new ChallengeWindow(tempButton.Name.Replace("level", ""));
            ChallengeModeWindow.Show();
            this.Close();
        }
    }
}
