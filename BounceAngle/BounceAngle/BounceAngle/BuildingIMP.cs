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
        
        public Boolean safeHouse;
        BuildingData buildingData;
        Vector2 offset;


        public BuildingIMP(Vector2 _location, Boolean isSafeHouse, BuildingDataIMP _buildingData)
        {
            location = _location;
            
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
            offset += _offset;
            offset.X = MathHelper.Clamp(offset.X, -1500, 1500);
            offset.Y = MathHelper.Clamp(offset.Y, -900, 500);
        }

        public void Draw(SpriteBatch spriteBatch) {
            if (buildingData.isOver())
            {
                spriteBatch.Draw(buildingData.getTexture(), location + offset, Color.Red);
            }
            else
            {
                spriteBatch.Draw(buildingData.getTexture(), location + offset, Color.White);
            }
        }

    }
}
