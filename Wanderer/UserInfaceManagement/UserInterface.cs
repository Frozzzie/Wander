using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.Utility;

namespace Wanderer.UserInfaceManagement
{
    class UserInterface
    {
        private List<UIElement> _uiElements;

        public UserInterface()
        {
            _uiElements = new List<UIElement>();
        }


        public TextUIElement ConstructTextElement(string content, Point position)
        {
            TextUIElement element = new TextUIElement(content, position);
            _uiElements.Add(element);
            return element;
        }

        public SelectableListUIElement ConstructSelectableElement(List<UIElement> elements, UIElement selector, Point position, Size size)
        {
            SelectableListUIElement selectable = new SelectableListUIElement(position, size);
            selectable.SetSelector(selector);
            selectable.LoadElements(elements);
            _uiElements.Add(selectable);
            return selectable;
        }

        public void Draw(Surface drawTo, Point pos)
        {
            foreach (UIElement ui in _uiElements)
                ui.Draw(drawTo, pos);
        }
    }
}
