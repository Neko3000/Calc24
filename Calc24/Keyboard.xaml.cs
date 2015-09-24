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

namespace Calc24
{
    /// <summary>
    /// Keyboard.xaml 的交互逻辑
    /// </summary>
    public partial class Keyboard : Window
    {
        public Keyboard()
        {
            InitializeComponent();
        }
        public Keyboard(double x, double y)
        {
            InitializeComponent();
            this.Left = x;
            this.Top = y;
        }
        public void ChangePosition(double x, double y)
        {
            this.Left = x;
            this.Top = y;
        }
        private void InputData(object sender, RoutedEventArgs e)
        {
            RandomCardWindow owner = (RandomCardWindow)this.Owner;
            Button tempButton = (Button)sender;
            if((string)tempButton.Content!="Del")
            {
                string data=(string)(tempButton.Content);
                owner.answer.Text += data;
            }
            else
            {
                owner.answer.Text = owner.answer.Text.Substring(0, owner.answer.Text.Length - 1);
            }
        }

    }
}
