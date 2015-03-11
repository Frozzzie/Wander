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
using Wanderer.Creatures.Powers;

namespace WandererDevelopmentTools.CreatureCreation
{
    /// <summary>
    /// Interaction logic for PowerCreature.xaml
    /// </summary>
    public partial class PowerCreator : Window
    {
        private Power workingPower_;

        public PowerCreator()
        {
            InitializeComponent();
            workingPower_ = new Power();
        }

        private void NewPowerButton_Click(object sender, RoutedEventArgs e)
        {
            // are you sure you want to discard the current power? Ohkay, go for your life
            // Clear the fields, create a new power.
        }

        private void NewCommand_Click(object sender, RoutedEventArgs e)
        {
            Button me = sender as Button;

            CommandsList.Children.Remove(me);
            StackPanel newCommand = new StackPanel();
            newCommand.Orientation = Orientation.Horizontal;
            Button setHealth = new Button();
            setHealth.Content = "Set Health";
            setHealth.Click += setHealth_Click;
            setHealth.Margin = new Thickness(2);
            newCommand.Children.Add(setHealth);

            Button setCounter = new Button();
            setCounter.Content = "Set Counter";
            setCounter.Click += setCounter_Click;
            setCounter.Margin = new Thickness(2);
            newCommand.Children.Add(setCounter);

            Button setStat = new Button();
            setStat.Content = "Set Stat";
            setStat.Click += setStat_Click;
            setStat.Margin = new Thickness(2);
            newCommand.Children.Add(setStat);

            Button math = new Button();
            math.Content = "Math";
            math.Click += math_Click;
            math.Margin = new Thickness(2);
            newCommand.Children.Add(math);

            Button cancel = new Button();
            cancel.Content = "x";
            cancel.Click += cancel_Click;
            cancel.Margin = new Thickness(2);
            newCommand.Children.Add(cancel);

            CommandsList.Children.Add(newCommand);
            CommandsList.Children.Add(me);
        }

        void cancel_Click(object sender, RoutedEventArgs e)
        {
            var me = sender as Button;
            var parent = me.Parent as StackPanel;
            CommandsList.Children.Remove(parent);
        }

        void math_Click(object sender, RoutedEventArgs e)
        {
            
        }

        void setStat_Click(object sender, RoutedEventArgs e)
        {
            
        }

        void setCounter_Click(object sender, RoutedEventArgs e)
        {
            
        }

        void setHealth_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
