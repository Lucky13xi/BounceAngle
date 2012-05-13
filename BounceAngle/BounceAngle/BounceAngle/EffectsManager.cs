using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace BounceAngle
{
   
    interface EffectsManager
    {
        
        void Init(ContentManager Content);
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        
        
    }
}
