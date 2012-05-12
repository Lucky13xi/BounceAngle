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

        public void Draw(SpriteBatch spriteBatch)
        {
            //draw the buildings before the menu
            mapMan.Draw(spriteBatch);
            menuManager.Draw(spriteBatch);
        }

        public void Init(ContentManager content)
        {
            soundManager.initializeSounds(content);
            menuManager = new MenuManagerImp();
            menuManager.Init(content);
            mapMan = new MapManagerIMP();
            mapMan.LoadMap(content);
            soundManager.playDayMusic();
            uiMan = new UIManagerIMP();
            simMgr = new DaySimMgrImpl();
        }

        public void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            uiMan.ProcessMouse(mouseState);
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
    }
}
