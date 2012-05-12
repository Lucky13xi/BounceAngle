using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BounceAngle
{
    interface SurvivorData
    {
        int getId();
        Vector2 getCurrentLocation();
        Vector2 getDestination();
        Texture2D getTexture();
        float getMoveSpeed();

        void setCurrentLocation(Vector2 loc);
        void setDestination(Vector2 loc);
    }
}
