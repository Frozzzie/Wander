using SdlDotNet.Graphics;
using SdlDotNet.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.Screens;
using Wanderer.Creatures;
using Wanderer.GameComponents;
using Wanderer.Creatures.Powers;
using Wanderer.GameComponents.BattleComponents;

namespace Wanderer
{
    class Program
    {
        private Screen _currentScreen;
        private BattleInterfaces.BattleInterface battleInterface;
        static void Main(string[] args)
        {
            Program Game = new Program();
            //Game.Run();
        }

        private Program()
        {
            //Test.TestCreatures.LuaTesting();
            /*
            Battle b = new Battle();
            battleInterface = new BattleInterfaces.ConsoleInterface();
            battleInterface.Begin(b);*/
            var engine = new EntityEngine.EntityEngine(new EntityEngine.ConsoleInterface());
            if (false)
            {
                Video.SetVideoMode(640, 480);
                Video.WindowCaption = "Wanderer";
                _currentScreen = new BattleScreen();
            }
        }

        protected void Run()
        {
            Events.Quit += this.QuitGame;
            Events.Tick += this.OnTick;
            Events.KeyboardDown += _currentScreen.OnKeyPressed;
            Events.Run();
        }

        private void QuitGame(object sender, QuitEventArgs e)
        {
            Events.QuitApplication();
        }

        private void OnTick(object sender, TickEventArgs e)
        {
            _currentScreen.Update(e);
            Video.Screen.Fill(Color.Black);
            _currentScreen.Draw(Video.Screen);
            Video.Screen.Update();
        }

        private void SwitchScreen(Screen to)
        {
            _currentScreen.Exit();
            _currentScreen = to;
            to.Enter();
        }
    }
}
