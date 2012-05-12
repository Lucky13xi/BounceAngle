using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BounceAngle
{
    class MapManagerIMP : MapManager
    {


        private static int buildingCounter = 0;

        List<BuildingIMP> buildings;
        Vector2 offset;

        public MapManagerIMP()
        {
            buildings = new List<BuildingIMP>();
            offset = Vector2.Zero;
        }

        public void addBuilding(BuildingIMP building)
        {
            buildings.Add(building);
        }

        public void LoadMap(ContentManager Content)
        {

            addBuilding(new BuildingIMP(new Vector2(950, 200), false, new BuildingDataIMP(buildingCounter++, Content.Load<Texture2D>("Images//factory0"), 0, 4, 1, "factory", 0, false)));
            addBuilding(new BuildingIMP(new Vector2(600, 200), false, new BuildingDataIMP(buildingCounter++, Content.Load<Texture2D>("Images//hospital0"), 2, 3, 5, "Hospital", 1, false)));
            addBuilding(new BuildingIMP(new Vector2(200, 300), false, new BuildingDataIMP(buildingCounter++, Content.Load<Texture2D>("Images//mainStreet0"), 5, 0, 1, "Main Street", 2, false)));
            addBuilding(new BuildingIMP(new Vector2(0, 600), false, new BuildingDataIMP(buildingCounter++, Content.Load<Texture2D>("Images//apartments0"), 2, 2, 1, "Apartments", 1, false)));
            addBuilding(new BuildingIMP(new Vector2(50, 300), false, new BuildingDataIMP(buildingCounter++, Content.Load<Texture2D>("Images//church0"), 0, 0, 0, "Church", 1, false)));
            addBuilding(new BuildingIMP(new Vector2(600, 600), false, new BuildingDataIMP(buildingCounter++, Content.Load<Texture2D>("Images//factory1"), 0, 0, 2, "factory", 0, false)));

        }

        public List<Building> getAllBuildings()
        {
            List<Building> aList = new List<Building>();
            foreach (BuildingIMP building in buildings) {
                aList.Add(building);
            }
            return aList;
        }

        public Building getBuildingByID(int id)
        {

            foreach (BuildingIMP building in buildings)
            {
                if (building.getBuildingData().getID() == id)
                {
                    return building;
                }
            }
            return null;
        }

       

        public void setOffset(Vector2 _offset)
        {
            offset += _offset;
        }

        public int getCollision(Vector2 cord) {

            for (int i = 0; i < buildings.Count; i++)
            {

                Rectangle hitRect = new Rectangle((int)buildings[i].location.X + (int)offset.X, (int)buildings[i].location.Y + (int)offset.Y, buildings[i].getBuildingData().getTexture().Width, buildings[i].getBuildingData().getTexture().Height);

                if (hitRect.Contains(new Point((int)cord.X, (int)cord.Y)))
                {
                    //Console.WriteLine("hit"+i);

                    return i;

                }
            }
                
          
            return -1;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (BuildingIMP building in buildings)
            {
                building.Draw(spriteBatch);
            }
        }

    }
}
