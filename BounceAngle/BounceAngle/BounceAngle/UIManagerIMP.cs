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
        private MouseState preMouseState;
        private BuildingData lastHoveredBuildingData;
        private Vector2 worldToScreenOffset;
        
        public void init()
        {
            worldToScreenOffset = Vector2.Zero;
        }

        public void ProcessMouse(MouseState mouseState) {

            processBuildingHover(new Vector2(mouseState.X, mouseState.Y));
            processClick(mouseState);
            processScrolling(mouseState);
            preMouseState = mouseState;

        }

        private void processScrolling(MouseState mouseState)
        {
            Vector2 changeOffset = Vector2.Zero;
            if (mouseState.X < 20)
            {
                changeOffset = new Vector2(10, 0);  // right
            }
            if (mouseState.X > 1060)
            {
                changeOffset = new Vector2(-10, 0); // left
            }
            if (mouseState.Y < 20)
            {
                changeOffset = new Vector2(0, 10);  // down
            }
            if (mouseState.Y > 700)
            {
                changeOffset = new Vector2(0, -10); // up
            }

            // update the final offset
            worldToScreenOffset += changeOffset;
            worldToScreenOffset.X = MathHelper.Clamp(worldToScreenOffset.X, -1500, 1500);
            worldToScreenOffset.Y = MathHelper.Clamp(worldToScreenOffset.Y, -900, 500);

            DayGameEngineImp.getGameEngine().getMapManager().setScreenWorldOffset(worldToScreenOffset);
        }

        private void processClick(MouseState mouseState) {
            if (mouseState.LeftButton == ButtonState.Released && preMouseState.LeftButton == ButtonState.Pressed) {
                DayGameEngineImp.getGameEngine().getSoundManager().playClick();
                // 1. check if the building go button was clicked

                // at this point no buttons or a cancel button was clicked

                // hide all popups

                if (processMenuClicks(mouseState))
                {
                    // don't process anything else if any menu was clicked
                    return;
                }

                processBuildingClick(mouseState);
            }
        }

        private Boolean processMenuClicks(MouseState mouseState)
        {
            // 1. check if any menu was pressed.
            MenuClickResult clickResult = DayGameEngineImp.getGameEngine().getMenuManager().getClickCollision(mouseState.X, mouseState.Y);
            // if its a building popup, then do this
            if (clickResult != null)
            {
                if (MenuClickResult.clickType.submit == clickResult.type)
                {
                    BuildingData buildingPopup = (BuildingData)clickResult.payLoad;
                    DayGameEngineImp.getGameEngine().getSimMgr().queueBuildingToScavenge(buildingPopup);
                    DayGameEngineImp.getGameEngine().getMenuManager().hidePopUp();
                }
                else if (MenuClickResult.clickType.summary == clickResult.type)
                {
                    DayGameEngineImp.getGameEngine().getSimMgr().onSummaryPopupOkay();
                }
                else
                {
                    DayGameEngineImp.getGameEngine().getMenuManager().hidePopUp();
                    Console.WriteLine("closing all popups ");
                }
                return true;
            }

            return false;
        }


        private void processBuildingClick(MouseState mouseState)
        {
            int buildingId = DayGameEngineImp.getGameEngine().getMapManager().getScreenCollision(new Vector2(mouseState.X, mouseState.Y));

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

        private void processBuildingHover(Vector2 mousePos)
        {

            int buildingId = DayGameEngineImp.getGameEngine().getMapManager().getScreenCollision(mousePos);

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
