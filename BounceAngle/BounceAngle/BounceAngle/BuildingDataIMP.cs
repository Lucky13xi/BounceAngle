using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace BounceAngle
{
    class BuildingDataIMP : BuildingData
    {
        private Boolean isSafe;
        private Vector2 location;
        private Texture2D texture;
        private int ammo;
        private int food;
        private int zombies;
        private string description;
        private int id;
        private int survivors;
        private Boolean isOn;
        private int scavengeTime;
        private Vector2 spawnLoc;

        public BuildingDataIMP(int _id, Vector2 loc, Boolean _isSafe,  Texture2D _texture, int _ammo, int _food, int _zombies, string _description, int _survivors, int _scavengeTime, Boolean _isOn, Vector2 spawnLocFactors)
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
            isSafe = _isSafe;
            location = loc;
            spawnLoc = loc + new Vector2(texture.Width * spawnLocFactors.X, texture.Height * spawnLocFactors.Y);
        }

        /*    List<Vector2> nSLoc = new List<Vector2>();
            foreach (BuildingData data in buildingsPreScavenged) {
                //Vector2 loca = data.getLocation() + DayGameEngineImp.getGameEngine().getMapManager().getOffset();
                Vector2 loca = data.getLocation() + DayGameEngineImp.getGameEngine().getMapManager().getOffset();
                switch (data.getID()) { 
                    case 0:
                        loca += ;
                        break;
                    case 1:
                        l
                        break;
                    case 5:
                        
                        break;
                    case 6:
                    
                        break;
                    case 7:
                        loca += new Vector2(data.getTexture().Width / 2, 0);
                        break;
                    case 8:
                        loca += new Vector2(data.getTexture().Width/2, data.getTexture().Height);
                        break;
                    case 9:
                        loca += new Vector2(0, data.getTexture().Height / 2);
                        break;
                    case 10:
                        loca += new Vector2(data.getTexture().Width / 2, data.getTexture().Height / 2);
                        break;
                    
                   
                
                  
                 

                    
                   
     
                    default:
                        break;
                }
                nSLoc.Add(loca);
            }
            return nSLoc;
             */ 
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
        public int getScavengeTime()
        {
            return scavengeTime;
        }

        public Microsoft.Xna.Framework.Graphics.Texture2D getTexture()
        {
            return texture;
        }

        public Vector2 getLocation() { return location; }
        public Boolean isSafehouse() { return isSafe; }
        public Vector2 getSpawnLocation() {
            return spawnLoc;
        }
        public void setAmmo(int a) { ammo = a; }
        public void setFood(int f) { food = f; }
        public void setZombies(int z) { zombies = z;  }
        public void setSurvivors(int surv) { survivors = surv;  }
        public void setBuildingDescription(string desc) { description = desc; }
        public void setOver(Boolean over) { isOn = over;  }
        public void setLocation(Vector2 loc) { location = loc; }
        public void setTexture(Texture2D img) { texture = img; }
    }
}
