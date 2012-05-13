using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BounceAngle
{
    interface Building
    {
        Boolean isCollision();
        BuildingData getBuildingData();
        void Draw(SpriteBatch spriteBatch, Vector2 offset);
    }
}
