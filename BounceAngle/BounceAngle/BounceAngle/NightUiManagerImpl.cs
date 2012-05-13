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
            // process in night mode
            processScrolling(mouseState);
        }

        private void processScrolling(MouseState mouseState)
        {
            if (mouseState.X < 20)
            {
                NightGameEngineImp.getGameEngine().getMapManager().setOffset(new Vector2(10, 0));
            }
            if (mouseState.X > 1060)
            {
                NightGameEngineImp.getGameEngine().getMapManager().setOffset(new Vector2(-10, 0));
            }
            if (mouseState.Y < 20)
            {
                NightGameEngineImp.getGameEngine().getMapManager().setOffset(new Vector2(0, 10));
            }
            if (mouseState.Y > 700)
            {
                NightGameEngineImp.getGameEngine().getMapManager().setOffset(new Vector2(0, -10));
            }
            foreach (BuildingIMP building in NightGameEngineImp.getGameEngine().getMapManager().getAllBuildings())
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
            foreach (ZombieData zom in NightGameEngineImp.getGameEngine().getZombieManager().getAllZombies())
            {
                if (mouseState.X < 20)
                {
                    zom.setOffset(new Vector2(10, 0));
                }
                if (mouseState.X > 1060)
                {
                    zom.setOffset(new Vector2(-10, 0));
                }
                if (mouseState.Y < 20)
                {
                    zom.setOffset(new Vector2(0, 10));
                }
                if (mouseState.Y > 700)
                {
                    zom.setOffset(new Vector2(0, -10));
                }
            }

        }
    }
}
