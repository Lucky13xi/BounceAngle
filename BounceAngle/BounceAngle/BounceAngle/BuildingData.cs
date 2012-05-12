using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BounceAngle
{
    interface BuildingData
    {
        int getAmmo();
        int getFood();
        int getZombies();
        string getBuildingDescription();
        int getID();
    }
}
