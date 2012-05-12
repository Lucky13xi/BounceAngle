using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BounceAngle
{
    public class popUpItem : MenuItem
    {

        private bool open;

        public popUpItem() : base(_box, _font, _position, _text, _fontColor)
        {

        }

        public override void Draw(SpriteBatch spritebatch)
        {
            if (open)
            {
                
            }
        }

    }
}
