using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BounceAngle
{
    class EffectImp:Effect
    {


        List<Texture2D> animation;
        int index;
        Vector2 position;
        Vector2 velocity;
        Vector2 acceleration;

        public EffectImp() {
            index = 0;
            animation = new List<Texture2D>();
        }
        public void addTextureToAnimation(Texture2D _texture) {
            animation.Add(_texture);
        }
        public Vector2 getVelocity() {

            return velocity;
        }

        public void setVelocity(Vector2 _velocity) {

            velocity = _velocity;
        }

        public Vector2 getAcceleration() {

            return acceleration;
        }

        public void setAcceleration(Vector2 _acceleration) {

            acceleration = _acceleration;
        }

        public void Update(GameTime gameTime) {

            float deltaT = gameTime.ElapsedGameTime.Milliseconds;
            position += velocity * deltaT + 0.5f * acceleration * deltaT * deltaT;

            index++;
            if (index >= animation.Count) {
                index = 0;
            }
            
        }

        public void Draw(SpriteBatch spriteBatch) {

            spriteBatch.Draw(animation.ElementAt<Texture2D>(index), position, Color.White);

            
        }

    }
}
