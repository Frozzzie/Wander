using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.Creatures;
using Wanderer.Creatures.Powers;
using Wanderer.GameComponents;
using Wanderer.GameComponents.BattleComponents;
using Wanderer.UserInfaceManagement;

namespace Wanderer.Screens
{
    public class BattleScreen : Screen
    {
        UserInterface _battleUI;

        AnimatedSprite[] sprites_;

        private Surface[] surfaces_;
        private int numSurfaces;

        SelectableListUIElement menuUI;

        private Battle battle_;

        private PowerVM powerProcessor_;

        public BattleScreen()
        {
            powerProcessor_ = new PowerVM(this);
            _battleUI = new UserInterface();
            battle_ = new Battle();
            battle_.AddCreature(Test.TestCreatures.TestPlayer(), 1);
            battle_.AddCreature(Test.TestCreatures.GardenSnake(), 2);
            menuUI = _battleUI.ConstructSelectableElement(new List<UIElement>() { 
                new TextUIElement("Attack", Point.Empty), new TextUIElement("Skills", Point.Empty),
                new TextUIElement("Flee", Point.Empty)}, 
                new TextUIElement(">", new Point(-7, 0)), new Point(20, 380), new Size(300, 80));
            menuUI.Selected += menuUI_Selected;
        }

        private void menuUI_Selected(object sender, SelectableListUIElement.SelectedEventArgs e)
        {
            if (e.Selected is TextUIElement)
            {
                var text = e.Selected as TextUIElement;
                if (text.Content == "Attack")
                {
                }
            }
        }


        public override void Update(SdlDotNet.Core.TickEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public override void Enter()
        {
            throw new NotImplementedException();
        }

        public override void Exit()
        {
            throw new NotImplementedException();
        }

        public override void Draw(SdlDotNet.Graphics.Surface drawTo)
        {
            menuUI.Draw(drawTo, Point.Empty);
            //throw new NotImplementedException();
        }

        public override void OnKeyPressed(object sender, SdlDotNet.Input.KeyboardEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
