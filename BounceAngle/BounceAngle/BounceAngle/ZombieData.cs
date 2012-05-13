using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BounceAngle
{
    interface ZombieData
    {
        int getId();
        Vector2 getCurrentLocation();
        Vector2 getDestination();
        Texture2D getTexture();
        float getMoveSpeed();
        float getRotation();
        void setRotation(float rot);
        void setTexture(Texture2D _tex);
        void setDead(bool value);
        bool getDead();

        void updateAnimation();
        void setCurrentLocation(Vector2 loc);
        void setDestination(Vector2 loc);
    }
}
