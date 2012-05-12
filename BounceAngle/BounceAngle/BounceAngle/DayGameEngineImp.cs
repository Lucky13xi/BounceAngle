using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace BounceAngle
{
    class DayGameEngineImp : GameEngine
    {
        public static GameEngine instance = null;

        private MenuManager menuManager;

        public MapManager mapMan;

        public SoundManager getSoundManager()
        {
            throw new NotImplementedException();
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
            mapMan.Draw(spriteBatch);
            menuManager.Draw(spriteBatch);
        }

        public void Init(ContentManager Content)
        {
            menuManager = new MenuManagerImp();
            menuManager.Init();
            mapMan = new MapManagerIMP();
            mapMan.LoadMap(Content);
        }

        public void Update(GameTime gameTime)
        {
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
