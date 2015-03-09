using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Font = SdlDotNet.Graphics.Font;

namespace Wanderer.UserInfaceManagement
{
    class TextUIElement : UIElement
    {
        private readonly static string FontsFolder = "C:\\Users\\SHAYNE\\Documents\\Visual Studio 2013\\Projects\\Wanderer\\Wanderer\\Fonts";
        public string Content { get { return _content; } set { _content = value; UpdateFont(); } }
        private string _content;

        public int FontSize { get { return _fontSize; } set { _fontSize = value; UpdateFont(); } }
        private int _fontSize;
        private Font _currentFont;


        public TextUIElement(string content, Point pos)
        {
            _content = content;
            _fontSize = 16;
            _drawPos = pos;

            _currentFont = new Font(System.IO.Path.Combine(FontsFolder, "ARIAL.TTF"), _fontSize);
            drawable = _currentFont.Render(Content, System.Drawing.Color.White);   
        }

        private void UpdateFont()
        {
            _currentFont = new Font(@"Arial.tff", _fontSize);
        }

        private void UpdateText()
        {
            drawable = _currentFont.Render(_content, System.Drawing.Color.White);
        }
    }
}
