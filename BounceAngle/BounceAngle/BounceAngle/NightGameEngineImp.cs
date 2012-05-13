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
        private EffectsManager effectsMgr;
        private NightSimMgr nightSimMgr;

        public SoundManager getSoundManager()       { return soundMgr; }
        public UIManager getUIManager()             { return uiMgr; }
        public MenuManager getMenuManager()         { return menuMgr; }
        public MapManager getMapManager()           { return mapMgr; }
        public DaySimMgr getSimMgr()                { return null; } // no day simulator in the night
        public ZombieManager getZombieManager()     { return zombieMgr; }
        public SurvivorManager getSurvivorManager() { return survivorMgr; }
        public EffectsManager getEffectsMgr()       { return effectsMgr; }
        public NightSimMgr getNightSimMgr()         { return nightSimMgr; }

        public void Init(ContentManager content)
        {
            isRunning = false;
            soundMgr = DayGameEngineImp.getGameEngine().getSoundManager();
            soundMgr.playNightMusic();
            uiMgr = new NightUiManagerImpl();
            menuMgr = DayGameEngineImp.getGameEngine().getMenuManager();
            mapMgr = DayGameEngineImp.getGameEngine().getMapManager();
            zombieMgr = new ZombieManagerImplementation();
            effectsMgr = new EffectsManagerImp();
            survivorMgr = new SurvivorManagerIMP();
            nightSimMgr = new NightSimMgrImpl();

            nightSimMgr.init();
            effectsMgr.Init(content);
            uiMgr.init();
            //menuMgr.Init(content);    // gets init in the daygameengine
            //mapMgr.Init();
            zombieMgr.init(content);
            survivorMgr.init(content);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (isRunning)
            {
                menuMgr.Draw(spriteBatch);
                mapMgr.Draw(spriteBatch);
                zombieMgr.draw(spriteBatch);
                effectsMgr.Draw(spriteBatch);
                survivorMgr.draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {

            if (isRunning)
            {
                MouseState mouseState = Mouse.GetState();
                uiMgr.ProcessMouse(mouseState);
                menuMgr.Update(gameTime);
                //mapMgr.update(gameTime);
                zombieMgr.update(gameTime);
                effectsMgr.Update(gameTime);
                survivorMgr.update(gameTime);
                nightSimMgr.update(gameTime);
            }
        }

        public void stop()
        {
            isRunning = false;
        }
        
        public void start()
        {
            isRunning = true;
            nightSimMgr.resetMode();
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
