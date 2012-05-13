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

        public BuildingIMP(BuildingDataIMP _buildingData)
        {   
            buildingData = _buildingData;
        }

        public Boolean isCollision()
        {
            return true;
        }

        public BuildingData getBuildingData()
        {
            return buildingData;

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 offset) {
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
