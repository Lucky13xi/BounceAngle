using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BounceAngle
{
    class UIManagerIMP : UIManager
    {

        private BuildingData lastHoveredBuildingData;
        public void ProcessMouse(Vector2 mousePos) {

            processBuildingHover(mousePos);
        }

        private void processBuildingHover(Vector2 mousePos)
        {

            int building = DayGameEngineImp.getGameEngine().getMapManager().getCollision(mousePos);

            if (building >= 0)
            {
                Building b = DayGameEngineImp.getGameEngine().getMapManager().getBuildingByID(building);
                if ((null != lastHoveredBuildingData) && (lastHoveredBuildingData.getID() != b.getBuildingData().getID()))
                {
                    // remove the hover from the last building
                    Building c = DayGameEngineImp.getGameEngine().getMapManager().getBuildingByID(lastHoveredBuildingData.getID());
                    BuildingData d = lastHoveredBuildingData;
                    c.setBuildingData(new BuildingDataIMP(d.getID(), d.getAmmo(), d.getFood(), d.getZombies(), d.getBuildingDescription(), d.getSurvivors(), false));
                    lastHoveredBuildingData = null;
                }
                // add the hover to the next hover
                BuildingData e = b.getBuildingData();
                b.setBuildingData(new BuildingDataIMP(e.getID(), e.getAmmo(), e.getFood(), e.getZombies(), e.getBuildingDescription(), e.getSurvivors(), true));
                lastHoveredBuildingData = b.getBuildingData();
            }
            else
            {
                // removing the hover
                if (null != lastHoveredBuildingData)
                {
                    Building b = DayGameEngineImp.getGameEngine().getMapManager().getBuildingByID(lastHoveredBuildingData.getID());
                    BuildingData d = lastHoveredBuildingData;
                    b.setBuildingData(new BuildingDataIMP(d.getID(), d.getAmmo(), d.getFood(), d.getZombies(), d.getBuildingDescription(), d.getSurvivors(), false));
                    lastHoveredBuildingData = null;
                }
            }
        }
    }
}
