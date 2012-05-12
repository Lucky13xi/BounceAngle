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
        Boolean isSafeHouse();
        Boolean isCollision();
        BuildingData getBuildingData();
        void setBuildingData(BuildingData data);
        void Draw(SpriteBatch spriteBatch);
        void setOffset(Vector2 offset);
    }
}
