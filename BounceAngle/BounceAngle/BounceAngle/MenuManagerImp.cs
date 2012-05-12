using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections;

namespace BounceAngle
{
    class MenuManagerImp : MenuManager
    {

        ArrayList menuItems;

        public void setTime(int time)
        {

        }

        public void setAmmo(int ammo)
        {
        }

        public void setFood(int food)
        {
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (MenuItem item in menuItems)
            {
                item.Draw(spriteBatch);
            }

        }


        public void Init(ContentManager content)
        {
            menuItems = new ArrayList();
            Texture2D timeBox = content.Load<Texture2D>("MenuItems\\timeBox");
            Texture2D leftUIBox = content.Load<Texture2D>("MenuItems\\leftUI");
            Texture2D rightUIBox = content.Load<Texture2D>("MenuItems\\rightUI");
            SpriteFont UIFont = content.Load<SpriteFont>("MenuItems\\UIFont");
            SpriteFont subUIFont = content.Load<SpriteFont>("MenuItems\\UIFont");
            string[] timeText = { "Daylight Time Remaining: 10:00" };
            string[] leftUIText = { "Food: " };
            string[] rightUIText = { "Survivors: " };


            menuItems.Add(new MenuItem(leftUIBox, subUIFont, new Vector2(640 - (timeBox.Width / 2) - leftUIBox.Width *0.9f + 1, 0), leftUIText, new Color(0f, 0f, 0f)));
            menuItems.Add(new MenuItem(rightUIBox, subUIFont, new Vector2(640 - (timeBox.Width / 2) + rightUIBox.Width, 0), rightUIText, new Color(0f, 0f, 0f)));
            menuItems.Add(new MenuItem(timeBox, UIFont, new Vector2(640 - (timeBox.Width / 2), 0), timeText, new Color(255f, 0f, 0f)));
        }

        public MenuManagerImp()
        {

        }

        public void setResource(int[] resource)
        {
            throw new NotImplementedException();
        }


        public bool getClickCollision(int x, int y)
        {
            return false;
        }


        BuildingData MenuManager.getClickCollision(int x, int y)
        {
            return null;
        }

        public void displayPopUp(BuildingData data)
        {

        }

        public void hidePopUp()
        {

        }
    }
}
