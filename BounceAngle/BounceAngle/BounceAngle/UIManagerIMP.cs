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
            processScrolling(mouseState);
            preMouseState = mouseState;

        }

        private void processScrolling(MouseState mouseState)
        {
            if (mouseState.X < 20)
            {
                DayGameEngineImp.getGameEngine().getMapManager().setOffset(new Vector2(10, 0));
            }
            if (mouseState.X > 1060)
            {
                DayGameEngineImp.getGameEngine().getMapManager().setOffset(new Vector2(-10, 0));
            }
            if (mouseState.Y < 20)
            {
                DayGameEngineImp.getGameEngine().getMapManager().setOffset(new Vector2(0, 10));
            }
            if (mouseState.Y > 700)
            {
                DayGameEngineImp.getGameEngine().getMapManager().setOffset(new Vector2(0, -10));
            }
            foreach (BuildingIMP building in DayGameEngineImp.getGameEngine().getMapManager().getAllBuildings())
            {
                if (mouseState.X < 20)
                {
                    building.setOffset(new Vector2(10, 0));
                }
                if (mouseState.X > 1060)
                {
                    building.setOffset(new Vector2(-10, 0));
                }
                if (mouseState.Y < 20)
                {
                    building.setOffset(new Vector2(0, 10));
                }
                if (mouseState.Y > 700)
                {
                    building.setOffset(new Vector2(0, -10));
                }
            }
        }

        private void processClick(MouseState mouseState) {
            if (mouseState.LeftButton == ButtonState.Released && preMouseState.LeftButton == ButtonState.Pressed) {
                // 1. check if the building go button was clicked
                BuildingData buildingPopup = DayGameEngineImp.getGameEngine().getMenuManager().getClickCollision(mouseState.X, mouseState.Y);
                // if its a building popup, then do this
                if (buildingPopup != null)
                {
                    // if go button clicked. add it to our queue
                    buildingsForQue.Add(buildingPopup);
                    Console.WriteLine("We queued the building " + buildingPopup.getID());
                    // do not process anything else if the button was clicked
                    return;
                }

                // at this point no buttons or a cancel button was clicked

                // hide all popups
                DayGameEngineImp.getGameEngine().getMenuManager().hidePopUp();
                Console.WriteLine("closing all popups ");

                // check if we clicked a building
                int buildingId = DayGameEngineImp.getGameEngine().getMapManager().getCollision(new Vector2(mouseState.X, mouseState.Y));
            
                // 2. check if any building was pressed 
                if (buildingId >= 0)
                {
                    Building b = DayGameEngineImp.getGameEngine().getMapManager().getBuildingByID(buildingId);

                    //  pop up the building summary
                    DayGameEngineImp.getGameEngine().getMenuManager().displayPopUp(b.getBuildingData());

                    //Console.WriteLine("We popped up the info for building " + d.getID());

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
