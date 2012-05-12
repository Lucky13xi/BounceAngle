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
        private Texture2D popUpImg;
        private SpriteFont font;
        private SpriteFont subFont;
        private Vector2 position;
        private Vector2 textPos;
        private Vector2 subTextPos;
        private float height = 0f;
        private float width = 0f;
        private string[] text;
        private string[] subText;
        private Color fontColor;
        private bool alive;

        public bool Alive
        {
            get { return alive; }
            set { alive = value; }
        }

        public string[] Text
        {
            get { return text; }
            set { text = value; }
        }

        public SpriteFont Font
        {
            get { return font; }
            set { font = value; }
        }

        public Texture2D PopUpImg
        {
            get { return popUpImg; }
            set { popUpImg = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public MenuItem(Texture2D _box, SpriteFont _font, Vector2 _position, string[] _text, Color _fontColor, bool _alive)
        {
            box = _box;
            font = _font;
            position = _position;
            text = _text;
            fontColor = _fontColor;
            alive = _alive;
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

        public void popUpHeader()
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

            textPos = new Vector2(position.X + ((box.Bounds.Width - width) / 2), position.Y + 25);
        }

        public void popUpSub(SpriteFont font, string[] _subText)
        {
            height = 0;
            width = 0;
            subText = _subText;
            subFont = font;
            foreach (string item in subText)
            {
                Vector2 size = font.MeasureString(item);
                if (size.X > width)
                    width = size.X;
                height += font.LineSpacing + 15;
            }

            subTextPos = new Vector2(box.Bounds.Width + 125, position.Y + 120);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            if (alive)
            {

                spriteBatch.Draw(box, position, Color.White);
                Vector2 location = textPos;
                for (int i = 0; i < text.Length; i++)
                {
                    spriteBatch.DrawString(font, text[i], location + new Vector2(0, 15 * i), fontColor);
                }
            }
            if (popUpImg != null)
            {
                spriteBatch.Draw(popUpImg, new Vector2(box.Bounds.Width - (popUpImg.Width / 2), box.Bounds.Height - (popUpImg.Height / 2)), null, Color.White, 0f, Vector2.Zero, 0.25f, SpriteEffects.None, 0f);
                Vector2 location = subTextPos;
                for (int i = 0; i < subText.Length; i++)
                {
                    spriteBatch.DrawString(subFont, subText[i], location + new Vector2(0, 55 * i), fontColor);
                }
            }
        }



    }
}
