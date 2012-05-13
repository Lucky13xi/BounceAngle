using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BounceAngle
{
    interface Effect
    {

        void addTextureToAnimation(Texture2D _texture);
        Vector2 getVelocity();
        void setVelocity(Vector2 _vel);
        Vector2 getAcceleration();
        void setAcceleration(Vector2 _acc);
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);


        
    }
}
