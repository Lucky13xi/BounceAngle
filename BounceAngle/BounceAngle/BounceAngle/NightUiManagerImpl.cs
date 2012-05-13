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
        public void init()
        {
        }

        public void ProcessMouse(Microsoft.Xna.Framework.Input.MouseState mouseState)
        {
            processMenuClicks(mouseState);
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
                    //NightGameEngineImp.getGameEngine().getSurvivorManager().setActiveSurvivor(sd.getId());
                }
                return true;
            }

            return false;
        }
    }
}
