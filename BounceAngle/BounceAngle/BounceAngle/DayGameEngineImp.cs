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

        private List<MenuManager> menuManager = new List<MenuManager>();

        Texture2D ammoBox;
        SpriteFont UIFont;


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
            foreach (MenuManager item in menuManager)
            {
                item.Draw(spriteBatch);
            }
        }

        public void Init(ContentManager content)
        {
            ammoBox = content.Load<Texture2D>("MenuItems\\default");
            UIFont = content.Load<SpriteFont>("MenuItems\\UIFont");
            string[] ammoText = {"Ammo: ", "Food: "};
            menuManager.Add(new MenuManagerImp(ammoBox, UIFont, Vector2.Zero, ammoText));
            //menuManager.Init();
        }

        public void Update(GameTime gameTime)
        {
        }

        public DayGameEngineImp()
        {
  
        }

    }
}
