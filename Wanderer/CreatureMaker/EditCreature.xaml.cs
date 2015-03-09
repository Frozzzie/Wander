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
using Wanderer.Creatures;

namespace Wanderer.CreatureMaker
{
    /// <summary>
    /// Interaction logic for EditCreature.xaml
    /// </summary>
    public partial class EditCreature : UserControl
    {
        private Creature currentCreature_;

        public EditCreature()
        {
            InitializeComponent();
        }
    }
}
