using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.Utility;

namespace Wanderer.UserInfaceManagement
{
    abstract class UIElement
    {
        protected Surface drawable;
        protected Point _drawPos;


        public Size Size { get { return drawable.Size; } }
        public Point Position { get { return _drawPos; } }


        public UIElement()
        {
            children = new List<UIElement>();
            // that's a-drawable!
            drawable = new Surface(0, 0);
        }

        public UIElement(Point pos)
        {
            children = new List<UIElement>();
            drawable = new Surface(0, 0);
            _drawPos = pos;
        }

        public UIElement(UIElement element)
        {
            children = element.children;
            drawable = element.drawable;
            _drawPos = element._drawPos;
        }

        protected List<UIElement> children;

        public virtual void Draw(Surface drawTo, Point pos)
        {
            foreach (UIElement ui in children)
            {
                //ui.Draw(drawTo, new Point(_drawPos.X + pos.X, _drawPos.Y + pos.Y));
                ui.Draw(drawTo, pos);
            }
            drawTo.Blit(drawable, new Point(_drawPos.X + pos.X , _drawPos.Y + pos.Y));
        }

        public void SetPosition(Point newPos)
        {
            _drawPos = newPos;
        }
    }
}
