using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BounceAngle
{
    class ZombieDataImp : ZombieData
    {
        Texture2D texture;
        Vector2 destination;
        Vector2 location;
        int id;
        float speed;
        float rotation;
        Random random = new Random();

        public ZombieDataImp(Texture2D _texture)
        {
            texture = _texture;
            speed = (float)random.NextDouble();
            rotation = 0f;
            setDestination(Vector2.Zero);
        }
        public void setRotation(float rot)
        {
            rotation = rot;
        }
        public float getRotation()
        {
            return rotation;
        }
        public int getId()
        {
            return id;
        }
        public Vector2 getCurrentLocation()
        {
            return location;
        }
        public Vector2 getDestination()
        {
            return destination;
        }
        public Texture2D getTexture()
        {
            return texture;
        }
        public float getMoveSpeed()
        {
            return speed;
        }

        public void setCurrentLocation(Vector2 loc)
        {
            location = loc;
        }
        public void setDestination(Vector2 loc)
        {
            destination = loc;
        }
    }
}
