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

        private MenuManager menuManager = new MenuManagerImp();
        private SoundManager soundManager = new SoundManager();

        public MapManager mapMan;
        public UIManagerIMP uiMan;

        public SoundManager getSoundManager()
        {
            return soundManager;
        }

        public UIManager getUIManager()
        {
            throw new NotImplementedException();
        }

        public MenuManager getMenuManager()
        {
            throw new NotImplementedException();
        }

        public MapManager getMapManager() {
            return mapMan;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            menuManager.Draw(spriteBatch);
            mapMan.Draw(spriteBatch);
        }

        public void Init(ContentManager content)
        {
            soundManager.initializeSounds(content);
            menuManager.Init(content);
            mapMan = new MapManagerIMP();
            mapMan.LoadMap(content);
            soundManager.playDayMusic();
            uiMan = new UIManagerIMP();
        }

        public void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            uiMan.ProcessMouse(new Vector2(mouseState.X, mouseState.Y));
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
