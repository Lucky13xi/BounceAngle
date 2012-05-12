using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BounceAngle
{
    class UIManagerIMP : UIManager
    {
        private List<BuildingData> buildingsForQue = new List<BuildingData>();
        private MouseState preMouseState;
        private BuildingData lastHoveredBuildingData;
        public void ProcessMouse(MouseState mouseState) {

            processBuildingHover(new Vector2(mouseState.X, mouseState.Y));
            processClick(mouseState);
            preMouseState = mouseState;

        }
        

        private void processClick(MouseState mouseState) {
            if (mouseState.LeftButton == ButtonState.Released && preMouseState.LeftButton == ButtonState.Pressed) {
                // 1. check if any menu was pressed.
                BuildingData buildingPopup = DayGameEngineImp.getGameEngine().getMenuManager().getClickCollision(mouseState.X, mouseState.Y);

                if (buildingPopup != null)
                {
                    buildingsForQue.Add(buildingPopup);
                    Console.WriteLine("We queued the building " + buildingPopup.getID());
                    return;
                }

                DayGameEngineImp.getGameEngine().getMenuManager().hidePopUp();
                Console.WriteLine("closing all popups ");

                int buildingId = DayGameEngineImp.getGameEngine().getMapManager().getCollision(new Vector2(mouseState.X, mouseState.Y));
            
                // 2. check if any building was pressed 
                if (buildingId >= 0)
                {
                    Building b = DayGameEngineImp.getGameEngine().getMapManager().getBuildingByID(buildingId);
                    BuildingData d = b.getBuildingData();
                    //  2a. pop up the building summary
                    DayGameEngineImp.getGameEngine().getMenuManager().displayPopUp(d);
                    Console.WriteLine("We popped up the info for building " + d.getID());
                }
            }
        
        }
        private void processBuildingHover(Vector2 mousePos)
        {

            int buildingId = DayGameEngineImp.getGameEngine().getMapManager().getCollision(mousePos);

            if (buildingId >= 0)
            {
                if ((null != lastHoveredBuildingData) && (lastHoveredBuildingData.getID() != buildingId))
                {
                    // remove the hover from the last building
                    lastHoveredBuildingData.setOver(false);
                    lastHoveredBuildingData = null;
                }
                // add the hover to the next hover
                Building b = DayGameEngineImp.getGameEngine().getMapManager().getBuildingByID(buildingId);
                lastHoveredBuildingData = b.getBuildingData();
                lastHoveredBuildingData.setOver(true);
            }
            else
            {
                // removing the hover
                if (null != lastHoveredBuildingData)
                {
                    lastHoveredBuildingData.setOver(false); 
                    lastHoveredBuildingData = null;
                }
            }
        }
    }
}
