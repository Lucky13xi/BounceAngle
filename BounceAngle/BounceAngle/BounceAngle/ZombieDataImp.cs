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

        public ZombieDataImp(Texture2D _texture)
        {
            texture = _texture;
        }
        public int getId()
        {
            return -1;
        }
        public Vector2 getCurrentLocation()
        {
            return Vector2.Zero;
        }
        public Vector2 getDestination()
        {
            return Vector2.Zero;
        }
        public Texture2D getTexture()
        {
            return texture;
        }
        public float getMoveSpeed()
        {
            return -1f;
        }

        public void setCurrentLocation(Vector2 loc)
        {
        }
        public void setDestination(Vector2 loc)
        {
        }
    }
}
