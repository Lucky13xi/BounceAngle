using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;


namespace BounceAngle
{
    class BuildingDataIMP : BuildingData
    {
        private Texture2D texture;
        private int ammo;
        private int food;
        private int zombies;
        private string description;
        private int id;
        private int survivors;
        private Boolean isOn;
        private int scavengeTime;

        public BuildingDataIMP(int _id, Texture2D _texture, int _ammo, int _food, int _zombies, string _description, int _survivors, int _scavengeTime, Boolean _isOn)
        {
            id = _id;
            texture = _texture;
            ammo = _ammo;
            food = _food;
            zombies = _zombies;
            description = _description;
            survivors = _survivors;
            isOn = _isOn;
            scavengeTime = _scavengeTime;
        }
        public Boolean isOver() {
            return isOn;
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

        public void setAmmo(int a) { ammo = a; }
        public void setFood(int f) { food = f; }
        public void setZombies(int z) { zombies = z;  }
        public void setSurvivors(int surv) { survivors = surv;  }
        public void setBuildingDescription(string desc) { description = desc; }
        public void setOver(Boolean over) { isOn = over;  }

        public int getScavengeTime() {
            return scavengeTime;
        }

        public Microsoft.Xna.Framework.Graphics.Texture2D getTexture()
        {
            return texture;
        }

        public void setTexture(Microsoft.Xna.Framework.Graphics.Texture2D img)
        {

        }
    }
}
