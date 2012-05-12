using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BounceAngle
{
    class BuildingIMP : Building
    {

        public Vector2 location;
        public Texture2D texture;
        public Boolean safeHouse;
        BuildingDataIMP buildingData;
        Vector2 offset;


        public BuildingIMP(Vector2 _location, Texture2D _texture, Boolean isSafeHouse, BuildingDataIMP _buildingData)
        {
            location = _location;
            texture = _texture;
            safeHouse = isSafeHouse;
            buildingData = _buildingData;
            offset = Vector2.Zero;
        }

        public Boolean isSafeHouse()
        {
            return safeHouse;
        }

        public Boolean isCollision()
        {
            return true;
        }

        public BuildingData getBuildingData()
        {
            return buildingData;

        }
        public void setBuildingData(int _ammo, int _food, int _zombies, string _description, int _id)
        {
            buildingData = new BuildingDataIMP(_ammo, _food, _zombies, _description, _id);
        }

        public void setOffset(Vector2 _offset)
        {
            offset = _offset;
        }

        public void Draw() { }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

            spriteBatch.Draw(texture, location + offset, Color.White);
        }

    }
}
