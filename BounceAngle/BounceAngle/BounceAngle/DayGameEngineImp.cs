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

        public NightSimMgr getNightSimMgr()
        {
            return null;
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

        public EffectsManager getEffectsMgr() {
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
            mapMan = new MapManagerIMP();
            menuManager = new MenuManagerImp();
            uiMan = new UIManagerIMP();
            simMgr = new DaySimMgrImpl();
            
            soundManager.initializeSounds(content);
            mapMan.LoadMap(content);
            menuManager.Init(content);
            //uiMan.init();
            simMgr.init();

            //soundManager.playDayMusic();
        }

        public void Update(GameTime gameTime)
        {
            if (isRunning)
            {
                MouseState mouseState = Mouse.GetState();
                uiMan.ProcessMouse(mouseState);
                menuManager.Update(gameTime);
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
            soundManager.playDayMusic();
            simMgr.resetMode();
        }
    }
}
