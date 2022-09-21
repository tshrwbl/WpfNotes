using ObjectElements;
using System;
using System.Collections;
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

            var rect = new Rectangle() { Margin = new Thickness(10, 0, 10, 0), Width = 30, Height = 20 };

            rect.Fill = (Brush)Application.Current.FindResource("RadialCol1");            //Adding resource from App resource dictionary

            rect.Fill = (Brush)this.FindResource("RadialCol1");            //Adding resource from Window resource dictionary


            var pnl = new WrapPanel();


            //add Rect
            //You can also add content from code too
            //this.Content = stackpnl;  commented for now
            pnl.Children.Add(rect);
            pnl.Children.Add(new TextBlock() { Text = "Rectange UI" });

            //Adding itemCollection from code
            ListBoxExm.Items.Add("ADDED FORM CODE");
            ListBoxExm.Items.Add(new Tour() { City = "Pune", TourName = "added from code" });
            ListBoxExm.Items.Add(pnl);
         
        

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
