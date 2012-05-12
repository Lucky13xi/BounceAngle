using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BounceAngle
{
    interface Building
    {
        Boolean isSafeHouse();
        Boolean isCollision();
        BuildingData getBuildingData();
        void setBuildingData(int _ammo, int _food, int _zombies, string _description, int _id);
        void Draw();
        void setOffset(Vector2 offset);
    }
}
