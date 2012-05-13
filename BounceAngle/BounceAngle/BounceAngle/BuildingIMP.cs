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
        BuildingData buildingData;
        Vector2 offset;

        public BuildingIMP(BuildingDataIMP _buildingData)
        {   
            buildingData = _buildingData;
            offset = Vector2.Zero;
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
                spriteBatch.Draw(buildingData.getTexture(), buildingData.getLocation() + offset, Color.Red);
            }
            else
            {
                spriteBatch.Draw(buildingData.getTexture(), buildingData.getLocation() + offset, Color.White);
            }
        }

    }
}
