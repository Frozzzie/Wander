using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderer.Screens
{
    public abstract class Screen
    {
        public abstract void Update(SdlDotNet.Core.TickEventArgs e);
        public abstract void Enter();
        public abstract void Exit();
        public abstract void Draw(Surface drawTo);
        public abstract void OnKeyPressed(object sender, SdlDotNet.Input.KeyboardEventArgs e);
    }
}
