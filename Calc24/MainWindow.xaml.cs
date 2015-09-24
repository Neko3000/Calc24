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

namespace Calc24
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void RandomModeButton_Click(object sender, RoutedEventArgs e)
        {
            var RandomModeWindow = new RandomCardWindow();
            RandomModeWindow.Show();
            this.Close();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void title_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ChallengeModeButton_Click(object sender, RoutedEventArgs e)
        {
            var LevelSelectionWindow= new LeveLSelection();
            LevelSelectionWindow.Show();
            this.Close();
        }
    }
}
