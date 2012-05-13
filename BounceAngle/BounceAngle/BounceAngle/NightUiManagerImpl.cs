using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace BounceAngle
{
    class NightUiManagerImpl : UIManager
    {
        private MouseState preMouseState;
        public void init()
        {
        }

        public void ProcessMouse(Microsoft.Xna.Framework.Input.MouseState mouseState)
        {
            processMenuClicks(mouseState);
            preMouseState = mouseState;
        }

        private void processMenuClicks(MouseState mouseState)
        {
            if (mouseState.LeftButton == ButtonState.Released && preMouseState.LeftButton == ButtonState.Pressed)
            {
                if (handleMenus(mouseState))
                {
                    // don't process anything else if any menu was clicked
                    return;
                }

                handleMapClick(mouseState);
            }
        }

        private Boolean handleMenus(MouseState mouseState)
        {
            // check if any menu was pressed.
            MenuClickResult clickResult = DayGameEngineImp.getGameEngine().getMenuManager().getClickCollision(mouseState.X, mouseState.Y);
            // if its a building popup, then do this
            if (clickResult != null)
            {
                if (MenuClickResult.clickType.player == clickResult.type)
                {
                    SurvivorData sd = (SurvivorData)clickResult.payLoad;
                    if (null != sd)
                    {
                        NightGameEngineImp.getGameEngine().getSurvivorManager().setActiveSurvivor(sd.getId());
                    }
                }
                return true;
            }

            return false;
        }

        private void handleMapClick(MouseState mouseState)
        {
            SurvivorData sd = NightGameEngineImp.getGameEngine().getSurvivorManager().getActiveSurvivor();
            if (null != sd)
            {
                Vector2 screenWorldOffset = NightGameEngineImp.getGameEngine().getMapManager().getScreenWorldOffset();
                Vector2 mouseClickScreenCoord = new Vector2(mouseState.X, mouseState.Y);
                Vector2 mouseClickWorldCoord = mouseClickScreenCoord - screenWorldOffset;

                sd.setDestination(mouseClickWorldCoord);
            }
        }
    }
}
