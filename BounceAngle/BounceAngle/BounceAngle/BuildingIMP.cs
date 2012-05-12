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
        BuildingData buildingData;
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

        public void setOffset(Vector2 _offset)
        {
            offset = _offset;
        }

        public void Draw(SpriteBatch spriteBatch) {
            if (buildingData.isOver())
            {
                spriteBatch.Draw(texture, location + offset, Color.Red);
            }
            else
            {
                spriteBatch.Draw(texture, location + offset, Color.White);
            }
        }

    }
}
