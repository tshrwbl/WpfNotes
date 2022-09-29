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
using System.Windows.Media;
using System.ComponentModel;
using System.Globalization;

namespace WpfNotes
{
    /// <summary>
    /// Interaction logic for ConverterPract.xaml
    /// </summary>
    public partial class ConverterPract : UserControl
    {
        public ConverterPract()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty StarBorderLineProperty;

        //TypeConverter at method level takes precedence over class level attribute
        [TypeConverter(typeof(BorderlineConverterCopy))]
        public Borderline StarBorderLine 
        {
            get => (Borderline)this.GetValue(StarBorderLineProperty);
            set => this.SetValue(StarBorderLineProperty, value);
        }

        static ConverterPract()
        {
            StarBorderLineProperty = DependencyProperty.Register(nameof(StarBorderLine), 
                                                                 typeof(Borderline),
                                                                 typeof(ConverterPract),
                                                                 new PropertyMetadata(null,
                                                                                       (sender, e) => ((ConverterPract)sender).OnStarBorderLineChanged(sender, e) ) ); 
        }

        public void OnStarBorderLineChanged(object sender , DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is Borderline a)
            {
                ResultTextBlock.Text = a.ToString();
            }
        }
    }

    [TypeConverter(typeof(BorderlineConverter))]
    public class Borderline
    {
        public Borderline(int value)
        {
            Top = value;
            Bottom = value;
            Right = value;
            Left = value;
        }

        public Borderline(int LRvalue, int TBvalue)
        {
            Top = TBvalue;
            Bottom = TBvalue;
            Right = LRvalue;
            Left = LRvalue;
        }

        public Borderline(int L, int T, int R , int B)
        {
            Top = T;
            Bottom = B;
            Right = R;
            Left = L;
        }

        public double Top { get; set; }
        public double Bottom { get; set; }
        public double Left { get; set; }
        public double Right { get; set; }
        public override string ToString()
        {
            return $"{Left}-{Top}-{Right}-{Bottom}";
        }
    }

    public class BorderlineConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        {
            var result = false;
            if(sourceType == typeof(string))
            {
                result = true;
            }
            return result; 
        }

        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            if(value is string s)
            {
                s.RemoveAllWhiteSpace();
                var arr = s.Split(',');
                if(arr.Length == 1)
                {
                    return new Borderline(int.Parse(arr[0]));
                }
                else if(arr.Length == 2)
                {
                    return new Borderline(LRvalue: int.Parse(arr[0]), TBvalue: int.Parse(arr[1]));
                }
                else if(arr.Length == 4)
                {
                    return new Borderline(int.Parse(arr[0]), int.Parse(arr[1]), int.Parse(arr[2]), int.Parse(arr[3]));
                }
                else
                {
                    throw new ArgumentException("invalid no of argument");
                }
            }
            return null;
        }

        public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
        {
            var result = false; 
            if(destinationType == typeof(string))
            {
                result = true;
            }
            return true;
        }

        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {            
            return ((Borderline)value).ToString();
        }
    }

    //Made this copy for attaching converter directly to property
    public class BorderlineConverterCopy : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        {
            var result = false;
            if (sourceType == typeof(string))
            {
                result = true;
            }
            return result;
        }

        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            if (value is string s)
            {
                //some changes to identify which class is being used
                //s.RemoveAllWhiteSpace();
                var arr = s.Split(',');
                if (arr.Length == 1)
                {
                    return new Borderline(int.Parse(arr[0]) + 100); // added 100
                }
                else if (arr.Length == 2)
                {
                    return new Borderline(LRvalue: int.Parse(arr[0]) + 100, TBvalue: int.Parse(arr[1]) + 100);
                }
                else if (arr.Length == 4)
                {
                    return new Borderline(int.Parse(arr[0]) , int.Parse(arr[1]), int.Parse(arr[2]), int.Parse(arr[3]));
                }
                else
                {
                    throw new ArgumentException("invalid no of arguments");
                }
            }
            return null;
        }

        public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
        {
            var result = false;
            if (destinationType == typeof(string))
            {
                result = true;
            }
            return true;
        }

        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            return ((Borderline)value).ToString();
        }
    }

    public static class stringHelper
    {
        public static string RemoveAllWhiteSpace(this string str)
        {
            return str.Replace(" ", string.Empty);
        }
    }
}
