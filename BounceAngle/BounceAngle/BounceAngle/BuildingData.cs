using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

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
        Texture2D getTexture();
        int getScavengeTime();
        Vector2 getLocation();
        Boolean isSafehouse();
        Vector2 getSpawnLocation();
        
        void setAmmo(int ammo);
        void setFood(int food);
        void setZombies(int zombies);
        void setSurvivors(int surv);
        void setBuildingDescription(string desc);
        void setOver(Boolean over);
        void setTexture(Texture2D img);
        void setLocation(Vector2 loc);
    }
}
