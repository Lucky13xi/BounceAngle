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

        private List<MenuManager> menuManager = new List<MenuManager>();
        private SoundManager soundManager = new SoundManager();

        Texture2D timeBox;
        Texture2D ammoBox;
        SpriteFont UIFont;


        public MapManager mapMan;

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
            foreach (MenuManager item in menuManager)
            {
                item.Draw(spriteBatch);
            }
            mapMan.Draw(spriteBatch);
        }

        public void Init(ContentManager content)
        {
            timeBox = content.Load<Texture2D>("MenuItems\\timeBox");
            soundManager.initializeSounds(content);
            ammoBox = content.Load<Texture2D>("MenuItems\\timeBox");
            UIFont = content.Load<SpriteFont>("MenuItems\\UIFont");
            string[] timeText = {"Daylight Time Remaining: 10:00"};
            menuManager.Add(new MenuManagerImp(timeBox, UIFont, new Vector2(640 - (timeBox.Width / 2), 0), timeText, new Color(255f, 0f, 0f)));
            //menuManager.Init();
            mapMan = new MapManagerIMP();
            mapMan.LoadMap(content);
            soundManager.playDayMusic();
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
