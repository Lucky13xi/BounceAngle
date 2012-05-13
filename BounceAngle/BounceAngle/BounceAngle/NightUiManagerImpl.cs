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
        private int screenHeight;
        private int screenWidth;
        private Vector2 worldToScreenOffset;
        private Vector2 previousOffsetChange;
        private Vector2 lastActiveSurvivorLocation;

        public void init()
        {
            screenHeight = 720;
            screenWidth= 1280;
            worldToScreenOffset = Vector2.Zero;
            previousOffsetChange = Vector2.Zero;
            lastActiveSurvivorLocation = Vector2.Zero;
        }

        public Vector2 getCurrentWorldToScreenOffset()
        {
            return worldToScreenOffset;
        }

        public Vector2 getPreviousWorldToScreenOffsetDifference()
        {
            return previousOffsetChange;
        }

        public void ProcessMouse(Microsoft.Xna.Framework.Input.MouseState mouseState)
        {
            processMenuClicks(mouseState);
            processScrolling();

            // update the final offset
            worldToScreenOffset += previousOffsetChange;
            worldToScreenOffset.X = MathHelper.Clamp(worldToScreenOffset.X, -1500, 1500);
            worldToScreenOffset.Y = MathHelper.Clamp(worldToScreenOffset.Y, -900, 500);
        }

        private void processScrolling()
        {
            previousOffsetChange = Vector2.Zero;

            SurvivorData sd = NightGameEngineImp.getGameEngine().getSurvivorManager().getActiveSurvivor();
            if (null != sd)
            {
                // update the screen offsets to follow the active survivor
                Vector2 centeredLocation = sd.getCurrentLocation() + new Vector2(-screenWidth / 2, -screenHeight / 2);
                previousOffsetChange = sd.getCurrentLocation() - lastActiveSurvivorLocation;
                //NightGameEngineImp.getGameEngine().getMapManager().setOffsetChange(previousOffsetChange);

                lastActiveSurvivorLocation = sd.getCurrentLocation();
            }
        }

        private Boolean processMenuClicks(MouseState mouseState)
        {
            // 1. check if any menu was pressed.
            MenuClickResult clickResult = DayGameEngineImp.getGameEngine().getMenuManager().getClickCollision(mouseState.X, mouseState.Y);
            // if its a building popup, then do this
            if (clickResult != null)
            {
                if (MenuClickResult.clickType.player == clickResult.type)
                {
                    SurvivorData sd = (SurvivorData)clickResult.payLoad;
                    NightGameEngineImp.getGameEngine().getSurvivorManager().setActiveSurvivor(sd.getId());
                }
                return true;
            }

            return false;
        }
    }
}
