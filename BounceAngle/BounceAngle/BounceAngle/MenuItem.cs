using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BounceAngle
{
    public class MenuItem
    {
        private Texture2D box;
        private SpriteFont font;
        private Vector2 position;
        private Vector2 textPos;
        private float height = 0f;
        private float width = 0f;
        private string[] text;
        private Color fontColor;


        public MenuItem(Texture2D _box, SpriteFont _font, Vector2 _position, string[] _text, Color _fontColor)
        {
            box = _box;
            font = _font;
            position = _position;
            text = _text;
            fontColor = _fontColor;
            MeasureText();
        }

        public void MeasureText()
        {
            height = -5;
            width = 0;
            foreach (string item in text)
            {
                Vector2 size = font.MeasureString(item);
                if (size.X > width)
                    width = size.X;
                height += font.LineSpacing + 5;
            }

            textPos = new Vector2(position.X + ((box.Bounds.Width - width) / 2), position.Y + ((box.Bounds.Height - height) / 2));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(box, position, Color.White);
            Vector2 location = textPos;
            for (int i = 0; i < text.Length; i++)
            {
                spriteBatch.DrawString(font, text[i], location + new Vector2(0, 15 * i), fontColor);
                //spriteBatch.DrawString(font, text[i], location + new Vector2(0, 15 * i), Color.Red, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
        }

    }
}
