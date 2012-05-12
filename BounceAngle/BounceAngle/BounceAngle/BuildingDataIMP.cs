using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BounceAngle
{
    class BuildingDataIMP : BuildingData
    {
        int ammo;
        int food;
        int zombies;
        string description;
        int id;

        public BuildingDataIMP(int _ammo, int _food, int _zombies, string _description, int _id)
        {
            ammo = _ammo;
            food = _food;
            zombies = _zombies;
            description = _description;
            id = _id;
        }

        public int getAmmo()
        {
            return ammo;
        }

        public int getFood()
        {
            return food;
        }

        public int getZombies()
        {
            return zombies;
        }

        public string getBuildingDescription()
        {
            return description;
        }

        public int getID()
        {
            return id;
        }
    }
}
