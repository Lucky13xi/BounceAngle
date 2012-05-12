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
        Texture2D backgroundTile;

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
            backgroundTile = Content.Load<Texture2D>("Images//tile");
            addBuilding(new BuildingIMP(new Vector2(950, 200), false, new BuildingDataIMP(buildingCounter++, Content.Load<Texture2D>("Images//factory0"), 0, 4, 1, "ACME Industrial", 0, 6, false)));
            addBuilding(new BuildingIMP(new Vector2(600, 200), false, new BuildingDataIMP(buildingCounter++, Content.Load<Texture2D>("Images//hospital0"), 2, 3, 5, "Special H Hospital", 1, 8, false)));
            addBuilding(new BuildingIMP(new Vector2(200, 300), false, new BuildingDataIMP(buildingCounter++, Content.Load<Texture2D>("Images//mainStreet0"), 5, 0, 1, "Main Street Strip Mall", 2, 4, false)));
            addBuilding(new BuildingIMP(new Vector2(0, 600), false, new BuildingDataIMP(buildingCounter++, Content.Load<Texture2D>("Images//apartments0"), 2, 2, 1, "Out to Lunch Apartments", 1, 10, false)));
            addBuilding(new BuildingIMP(new Vector2(50, 300), false, new BuildingDataIMP(buildingCounter++, Content.Load<Texture2D>("Images//church0"), 0, 0, 0, "Church of the Flying Spagetti Monster", 1, 2, false)));
            addBuilding(new BuildingIMP(new Vector2(600, 600), false, new BuildingDataIMP(buildingCounter++, Content.Load<Texture2D>("Images//factory1"), 0, 0, 2, "Pins & Pillows Factory", 7, 6, false)));
            addBuilding(new BuildingIMP(new Vector2(-300, 600), false, new BuildingDataIMP(buildingCounter++, Content.Load<Texture2D>("Images//groceryStore0"), 2, 5, 0, "Grey Matter Grocery Store", 0, 3, false)));
            addBuilding(new BuildingIMP(new Vector2(1000, 600), false, new BuildingDataIMP(buildingCounter++, Content.Load<Texture2D>("Images//warehouse0"), 3, 0, 1, "Warehouse 52", 0, 4, false)));
            addBuilding(new BuildingIMP(new Vector2(-600, 600), false, new BuildingDataIMP(buildingCounter++, Content.Load<Texture2D>("Images//arena0"), 10, 1, 7, "Air Canada Center", 0, 7, false)));
            addBuilding(new BuildingIMP(new Vector2(-300, 250), false, new BuildingDataIMP(buildingCounter++, Content.Load<Texture2D>("Images//apartments3"), 0, 1, 4, "Dirty End Motel", 0, 5, false)));
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
            offset.X = MathHelper.Clamp(offset.X, -2500, 2500);
            offset.Y = MathHelper.Clamp(offset.Y, -2500, 2500);
            
        }


        public int getCollision(Vector2 cord)
        {

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
            for (int i = -1; i * 60 < 1340; i++)
            {
                for (int j = -1; j * 60 < 780; j++)
                {
                    spriteBatch.Draw(backgroundTile, new Vector2(i * 60 + (offset.X % 60), j * 60 + (offset.Y % 60)), Color.White);
                }
            }

            foreach (BuildingIMP building in buildings)
            {
                building.Draw(spriteBatch);
            }

            
        }

    }
}
