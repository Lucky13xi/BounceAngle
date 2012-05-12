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

        ArrayList buildings;

        Vector2 offset;

        public MapManagerIMP()
        {
            buildings = new ArrayList();
            offset = Vector2.Zero;
        }

        public void addBuilding(BuildingIMP building)
        {
            buildings.Add(building);
        }

        public void LoadMap(ContentManager Content)
        {

            addBuilding(new BuildingIMP(new Vector2(200, 200), Content.Load<Texture2D>("Images//factory0"), false, new BuildingDataIMP(0, 4, 1, "factory", 0)));
        }

        public ArrayList getAllBuildings()
        {
            return buildings;
        }

        public Building getBuildingByID(int id)
        {

            return (Building)buildings[id];
        }

        public int findClosestBuildingID(Vector2 cord)
        {
            //TODO: find the closest building to the point.
            return 0;
        }

        public void setOffset(Vector2 _offset)
        {
            offset = _offset;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (BuildingIMP building in buildings)
            {
                spriteBatch.Draw(building.texture, building.location + offset, Color.White);
            }
        }
    }
}
