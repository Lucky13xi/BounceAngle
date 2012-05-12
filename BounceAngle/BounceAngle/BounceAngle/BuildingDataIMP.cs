using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BounceAngle
{
    class BuildingDataIMP : BuildingData
    {
        private static int buildingCounter = 0;

        int ammo;
        int food;
        int zombies;
        string description;
        int id;
        int survivors;

        public BuildingDataIMP(int _ammo, int _food, int _zombies, string _description, int _survivors)
        {
            id = ++buildingCounter;
            ammo = _ammo;
            food = _food;
            zombies = _zombies;
            description = _description;
            survivors = _survivors;
        }

        public int getAmmo()
        {
            return ammo;
        }

        public int getSurvivors() {
            return survivors;
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
