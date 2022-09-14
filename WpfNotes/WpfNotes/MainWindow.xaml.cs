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

namespace WpfNotes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Brush? Brush;
        public MainWindow()
        {
            InitializeComponent();

            //DOing xaml init from code
            //init rect 

            var rect = new Rectangle() {Margin = new Thickness(10) ,Width= 10, Height = 10 , Fill = new SolidColorBrush(Colors.Black)};
            
            var stackpnl = new StackPanel();


            //add Rect
            //this.Content = stackpnl;  commented for now
            stackpnl.Children.Add(rect);

        }

        private void Ellipse_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Shape rect)
            {
                Brush = rect.Fill;
                rect.Fill = new SolidColorBrush(Colors.Black);

            }            
        }

        private void Ellipse_MouseLeave(object sender, MouseEventArgs e)
        {

            if (sender is Shape rect)
            {
                rect.Fill = Brush;

            }
        }
    }
}
