using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BounceAngle
{
    class DayGameEngineImp : GameEngine
    {

        private MenuManager menuManager;

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

        public void Draw(SpriteBatch spriteBatch)
        {
            menuManager.Draw(spriteBatch);
        }

        public void Init()
        {
            menuManager = new MenuManagerImp();
            menuManager.Init();
        }

        public void Update(GameTime gameTime)
        {
        }

        public DayGameEngineImp()
        {
  
        }
    }
}
