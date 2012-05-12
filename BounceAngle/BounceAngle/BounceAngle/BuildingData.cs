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
        int getSurvivors();
        string getBuildingDescription();
        int getID();
        Boolean isOver();
        
        void setAmmo(int ammo);
        void setFood(int food);
        void setZombies(int zombies);
        void setSurvivors(int surv);
        void setBuildingDescription(string desc);
        void setOver(Boolean over);
    }
}
