using System;
using System.Collections.Generic;
using System.IO;
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
using Wanderer.Creatures;
using Newtonsoft.Json;

namespace WandererDevelopmentTools.CreatureCreation
{
    /// <summary>
    /// Interaction logic for CreatureEditor.xaml
    /// </summary>
    partial class CreatureEditor : Window
    {
        Creature workingCreature_;

        public CreatureEditor()
        {
            InitializeComponent();
            workingCreature_ = new Creature(10, 10, 10, 10, 10, 10);
        }

        private void SaveButton_click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog fd = new Microsoft.Win32.SaveFileDialog();
            fd.AddExtension = true;
            fd.Filter = "Creature Files | *.crea";
            fd.DefaultExt = ".crea";
            fd.ShowDialog();

            workingCreature_.WriteName(NameTextBox.Text);

            if( !string.IsNullOrEmpty(fd.FileName) )
            {
                workingCreature_.WriteToJson(fd.FileName);
            }
        }
        private bool loadingFile = false;
        private void StatControl_Changed(object sender, XAMLExtensions.IntUpDownControl.ChangedEventArgs e)
        {
            if (workingCreature_ == null || loadingFile) return;
            workingCreature_.WriteBaseStats(StrengthControl.Number, ConstControl.Number, DexControl.Number,
                                            PerceptionControl.Number, IntControl.Number, WisControl.Number);
            StrModLabel.Content = String.Format("{0}{1}", workingCreature_.StrengthMod >= 0 ? "+" : "" ,workingCreature_.StrengthMod);
            ConModLabel.Content = String.Format("{0}{1}", workingCreature_.ConstitutionMod >= 0 ? "+" : "", workingCreature_.ConstitutionMod);
            DexModLabel.Content = String.Format("{0}{1}", workingCreature_.DexterityMod >= 0 ? "+" : "", workingCreature_.DexterityMod);
            PerModLabel.Content = String.Format("{0}{1}", workingCreature_.PerceptionMod >= 0 ? "+" : "", workingCreature_.PerceptionMod);
            IntModLabel.Content = String.Format("{0}{1}", workingCreature_.IntelligenceMod >= 0 ? "+" : "", workingCreature_.IntelligenceMod);
            WisModLabel.Content = String.Format("{0}{1}", workingCreature_.WisdomMod >= 0 ? "+" : "", workingCreature_.WisdomMod);
        }

        private void NameBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                workingCreature_.WriteName(NameTextBox.Text);
            }
        }

        private void LoadButton_click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fd = new Microsoft.Win32.OpenFileDialog();
            fd.AddExtension = true;
            fd.Filter = "Creature Files | *.crea";
            fd.DefaultExt = ".crea";
            fd.ShowDialog();
            if (!string.IsNullOrEmpty(fd.FileName))
            {
                loadingFile = true;
                workingCreature_.ReadFromJson(fd.FileName);
                // change the stat boxes
                StrengthControl.Number = workingCreature_.BaseStr;
                ConstControl.Number = workingCreature_.BaseCon;
                DexControl.Number = workingCreature_.BaseDex;
                PerceptionControl.Number = workingCreature_.BasePer;
                IntControl.Number = workingCreature_.BaseInt;
                loadingFile = false;
                WisControl.Number = workingCreature_.BaseWis;
                NameTextBox.Text = workingCreature_.Name;
            }
        }



    }
}
