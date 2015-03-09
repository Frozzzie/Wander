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

namespace WandererDevelopmentTools.XAMLExtensions
{
    /// <summary>
    /// Interaction logic for IntUpDownControl.xaml
    /// </summary>
    public partial class IntUpDownControl : UserControl
    {
        public int MaxNumber {
            get { return _maxNumber; }
            set { _maxNumber = value; }
        }
        public int MinNumber
        {
            get { return _minNumber; }
            set { _minNumber = value; }
        }

        private int _maxNumber = int.MaxValue;
        private int _minNumber = int.MinValue;

        public int Number
        {
            get { return _number; }
            set { if (value > _maxNumber || value < _minNumber ) return;
                _number = value;
                NumberLabel.Content = _number.ToString();
                if (Changed != null)
                    Changed.Invoke(this, new ChangedEventArgs(value));
            } 
        }
        private int _number = 0;

        public class ChangedEventArgs
        {
            public object ChangedValue { get; private set; }
            public ChangedEventArgs(object changedValue)
            {
                ChangedValue = changedValue;
            }
        }

        public delegate void ChangedEventHandler(object sender, ChangedEventArgs e);
        public event ChangedEventHandler Changed;

        public IntUpDownControl()
        {
            InitializeComponent();
            NumberLabel.Content = Number.ToString();
        }

        public void IncreaseNumber(object sender, System.Windows.RoutedEventArgs e)
        {
            Number++;
            
        }

        public void DecreaseNumber(object sender, System.Windows.RoutedEventArgs e)
        {
            Number--;
        }
    }
}
