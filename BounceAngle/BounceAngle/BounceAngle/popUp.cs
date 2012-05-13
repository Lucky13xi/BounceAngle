using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BounceAngle
{
    class popUp : MenuItem
    {

        //bool alive;

        public popUp(Texture2D _box, SpriteFont _font, Vector2 _position, string[] _text, Color _fontColor, bool _alive)
            : base(_box, _font, _position, _text, _fontColor, _alive)
        {
        }

        //public void Draw(SpriteBatch spriteBatch)
        //{

        //}
    }
}
