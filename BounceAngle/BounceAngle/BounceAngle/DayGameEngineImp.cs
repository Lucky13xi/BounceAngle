using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace BounceAngle
{
    class DayGameEngineImp : GameEngine
    {
        public static GameEngine instance = null;

        private MenuManager menuManager;
        private SoundManager soundManager = new SoundManager();
        public MapManager mapMan;
        public UIManagerIMP uiMan;
        public DaySimMgr simMgr;
        private Boolean isRunning;

        public SoundManager getSoundManager()
        {
            return soundManager;
        }

        public UIManager getUIManager()
        {
            return uiMan;
        }

        public MenuManager getMenuManager()
        {
            return menuManager;
        }

        public MapManager getMapManager() {
            return mapMan;
        }

        public DaySimMgr getSimMgr()
        {
            return simMgr;
        }

        public ZombieManager getZombieManager()
        {
            // we don't have zombies during the day
            return null;
        }

        public SurvivorManager getSurvivorManager()
        {
            // we don't have survivors during the day
            return null;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isRunning)
            {
                //draw the buildings before the menu
                mapMan.Draw(spriteBatch);
                menuManager.Draw(spriteBatch);
            }
        }

        public void Init(ContentManager content)
        {
            isRunning = false;
            soundManager.initializeSounds(content);
            mapMan = new MapManagerIMP();
            mapMan.LoadMap(content);
            menuManager = new MenuManagerImp();
            menuManager.Init(content);
            soundManager.playDayMusic();
            uiMan = new UIManagerIMP();
            simMgr = new DaySimMgrImpl();
        }

        public void Update(GameTime gameTime)
        {
            if (isRunning)
            {
                MouseState mouseState = Mouse.GetState();
                uiMan.ProcessMouse(mouseState);
            }
        }

        private DayGameEngineImp() {}

        public static GameEngine getGameEngine()
        {
            if (null == instance)
            {
                instance = new DayGameEngineImp();
            }
            return instance;
        }

        public void stop()
        {
            isRunning = false;
        }

        public void start()
        {
            isRunning = true;
        }
    }
}
