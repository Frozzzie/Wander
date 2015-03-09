using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderer.UserInfaceManagement
{
    class SelectableListUIElement : UIElement
    {

        public class SelectedEventArgs : EventArgs
        {
            public UIElement Selected { get; private set; }
            public int SelectedIndex { get; private set; }

            public SelectedEventArgs(UIElement selected, int selectedIndex)
            {
                Selected = selected;
                SelectedIndex = selectedIndex;
            }
        }

        public delegate void SelectedEventHandler(object sender, SelectedEventArgs e);
        public event SelectedEventHandler Selected;
        public event SelectedEventHandler SelectionChanged;

        private Size _size;
        private UIElement _selector;
        private int selectedIndex_;
        private UIElement _selectorPointsTo;
        public SelectableListUIElement(Point pos, Size size) : base()
        {
            _drawPos = pos;
            _size = size;
        }

        public void LoadElements(List<UIElement> elements)
        {
            int maxWidth = int.MinValue;
            foreach (UIElement ui in elements)
            {
                maxWidth = Math.Max(ui.Size.Width, maxWidth);
            }
            
            if (maxWidth > _size.Width)
            {
                // Truncate somehow. Or throw an error.
            }
            maxWidth += _selector.Size.Width + 10;
            int currentHeight = 10;
            int widthAlong = 0;
            foreach (UIElement ui in elements)
            {
                ui.SetPosition(new Point(_drawPos.X + widthAlong, _drawPos.Y + currentHeight));
                currentHeight += ui.Size.Height + 10;
                if (currentHeight > _size.Height)
                {
                    currentHeight = 10;
                    widthAlong += maxWidth;
                    if (widthAlong > _size.Width)
                    {
                        // I'd be concerned.
                    }
                }
            }
            children = elements;
            _selectorPointsTo = children[0];
            selectedIndex_ = 0;
        }

        public void SetSelector(UIElement selector)
        {
            _selector = selector;
            selectedIndex_ = children.FindIndex(x => x == _selector);
        }

        public void SelectPrevious()
        {
            if (_selector == null) return;
            if (selectedIndex_ <= 0) selectedIndex_ = children.Count - 1;
            else selectedIndex_ = selectedIndex_ - 1;
            _selectorPointsTo = children[selectedIndex_];
            if (SelectionChanged != null)
                SelectionChanged.Invoke(this, new SelectedEventArgs(_selectorPointsTo, selectedIndex_));
        }

        public void SelectNext()
        {
            if (_selector == null) return;
            selectedIndex_ = (selectedIndex_ + 1) % children.Count;
            _selectorPointsTo = children[selectedIndex_];
            if (SelectionChanged != null)
                SelectionChanged.Invoke(this, new SelectedEventArgs(_selectorPointsTo, selectedIndex_));
        }

        public void Select()
        {
            if (Selected != null)
                Selected.Invoke(this, new SelectedEventArgs(_selectorPointsTo, selectedIndex_));
        }

        public override void Draw(SdlDotNet.Graphics.Surface drawTo, Point pos)
        {
            base.Draw(drawTo, pos);
            _selector.Draw(drawTo, new Point(_selectorPointsTo.Position.X + _selector.Position.X + pos.X,
                    _selectorPointsTo.Position.Y + _selector.Position.Y + pos.Y));
        }

    }
}
