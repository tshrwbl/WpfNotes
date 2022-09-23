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
    /// Interaction logic for CustomControl.xaml
    /// </summary>
    public partial class CustomControl : UserControl 
    {
        //To define dependency property, Class Must derived from DependencyObject
        public readonly static DependencyProperty CustomPropProperty = DependencyProperty.Register(nameof(CustomProp), typeof(Double), typeof(CustomControl), new PropertyMetadata(0.0 , PropertyChanged));

        public Double CustomProp
        {
            get => (double) this.GetValue(CustomPropProperty); 
            set => this.SetValue(CustomPropProperty, value); 
        }


        private static void PropertyChanged(object sender , DependencyPropertyChangedEventArgs e)
        {
            if(sender is CustomControl control)
            {
                control.OnCustomPropChanged(sender, e);
            }
            
        }

        private void OnCustomPropChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            NewProp.Content = "New Value : " + ((double)e.NewValue).ToString();
            OldProp.Content = "Old Value : " + ((double)e.OldValue).ToString();
        }

        public CustomControl()
        {
            InitializeComponent();
        }
    }
}
