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
    class NightGameEngineImp : GameEngine
    {
        private Boolean isRunning;
        private SoundManager soundMgr;
        private UIManager uiMgr;
        private MenuManager menuMgr;
        private MapManager mapMgr;
        private ZombieManager zombieMgr;
        private SurvivorManager survivorMgr;

        private const int SPAWN_DELAY = 1000;
        private float spawnCounter;

        public SoundManager getSoundManager()       { return soundMgr; }
        public UIManager getUIManager()             { return uiMgr; }
        public MenuManager getMenuManager()         { return menuMgr; }
        public MapManager getMapManager()           { return mapMgr; }
        public DaySimMgr getSimMgr()                { return null; } // no day simulator in the night
        public ZombieManager getZombieManager()     { return zombieMgr; }
        public SurvivorManager getSurvivorManager() { return survivorMgr; }
        public void Init(ContentManager content)
        {
            isRunning = false;
            soundMgr = DayGameEngineImp.getGameEngine().getSoundManager();
            soundMgr.playNightMusic();
            uiMgr = new NightUiManagerImpl();
            menuMgr = null;
            mapMgr = DayGameEngineImp.getGameEngine().getMapManager();
            spawnCounter = 0;
            zombieMgr = new ZombieManagerImplementation();
            survivorMgr = new SurvivorManagerIMP();

            
            //uiMgr.init();
            //menuMgr.Init(content);
            //mapMgr.Init();
            zombieMgr.init(content);
            survivorMgr.init(content);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (isRunning)
            {
                //menuMgr.draw(spriteBatch);
                mapMgr.Draw(spriteBatch);
                zombieMgr.draw(spriteBatch);
                survivorMgr.draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {

            if (isRunning)
            {
                spawnCounter += gameTime.ElapsedGameTime.Milliseconds;
                if (spawnCounter > SPAWN_DELAY)
                {
                    zombieMgr.addZombie(new ZombieDataImp(getZombieManager().getZombieTextures()[0]));
                    spawnCounter = 0;
                }

                MouseState mouseState = Mouse.GetState();
                uiMgr.ProcessMouse(mouseState);
                //menuMgr.update(gameTime);
                //mapMgr.update(gameTime);
                zombieMgr.update(gameTime);
                survivorMgr.update(gameTime);
            }
        }

        public void stop()
        {
            isRunning = false;
        }
        
        public void start()
        {
            isRunning = true;
            // TODO: may need some special reset code here
        }

        private static GameEngine instance = null;
        private NightGameEngineImp() { }

        public static GameEngine getGameEngine()
        {
            if (null == instance)
            {
                instance = new NightGameEngineImp();
            }
            return instance;
        }
    }
}
