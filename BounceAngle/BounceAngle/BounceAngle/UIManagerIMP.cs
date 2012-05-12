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
        private BuildingData lastBuildingDataClicked;
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
               // Boolean isSmack = DayGameEngineImp.getGameEngine().getMenuManager().getClickCollision(mouseState.X, mouseState.Y);
                Boolean isSmack = false;
                if (isSmack)
                {
                    //TODO: updatePlayState
                    if (lastBuildingDataClicked != null)
                    {
                        buildingsForQue.Add(lastBuildingDataClicked);
                        Console.WriteLine("We queued the building " + lastBuildingDataClicked.getID());
                        lastBuildingDataClicked = null;
                        return;
                    }
                }
                else
                {
                    // TODO: close pop up
                   
                    //Console.WriteLine("We close the info for building " + lastBuildingDataClicked.getID());
                    lastBuildingDataClicked = null;
                }
                int buildingId = DayGameEngineImp.getGameEngine().getMapManager().getCollision(new Vector2(mouseState.X, mouseState.Y));
            
                // 2. check if any building was pressed 
                if (buildingId >= 0)
                {
                    Building b = DayGameEngineImp.getGameEngine().getMapManager().getBuildingByID(buildingId);
                    lastBuildingDataClicked = b.getBuildingData();
                    //  2a. pop up the building summary
                    //TODO: the popup window
                    DayGameEngineImp.getGameEngine().getMenuManager().displayPopUp(b.getBuildingData());
                    Console.WriteLine("We popped up the info for building " + lastBuildingDataClicked.getID());
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
