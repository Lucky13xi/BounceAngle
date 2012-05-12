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

        static List<MenuItem> menuItems = new List<MenuItem>();
        Texture2D popUpBox;
        SpriteFont popUpHeader;
        SpriteFont popUpSubText;
        Texture2D scavenge;
        Texture2D cancle;
        BuildingData tempBuilding;

        public int Survivors { get; set; }

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
            Texture2D timeBox = content.Load<Texture2D>("MenuItems\\timeBox");
            Texture2D leftUIBox = content.Load<Texture2D>("MenuItems\\leftUI");
            Texture2D rightUIBox = content.Load<Texture2D>("MenuItems\\rightUI");
            scavenge = content.Load<Texture2D>("MenuItems\\scavenge");
            cancle = content.Load<Texture2D>("MenuItems\\cancle");
            popUpBox = content.Load<Texture2D>("MenuItems\\popUp");
            SpriteFont UIFont = content.Load<SpriteFont>("MenuItems\\UIFont");
            SpriteFont subUIFont = content.Load<SpriteFont>("MenuItems\\UIFont");
            popUpHeader = content.Load<SpriteFont>("MenuItems\\popUpHeader");
            popUpSubText = content.Load<SpriteFont>("MenuItems\\popUpSubText");
            string[] timeText = { "Daylight Time Remaining: 10:00" };
            string[] leftUIText = { "Food: " };
            string[] rightUIText = { "Survivors: " };
            string[] popUpText = { "", "" };
            string[] blank = { "" };

            menuItems.Add(new MenuItem(leftUIBox, subUIFont, new Vector2(640 - (timeBox.Width / 2) - leftUIBox.Width *0.9f + 1, 0), leftUIText, new Color(0f, 0f, 0f), true));
            menuItems.Add(new MenuItem(rightUIBox, subUIFont, new Vector2(640 - (timeBox.Width / 2) + rightUIBox.Width, 0), rightUIText, new Color(0f, 0f, 0f), true));
            menuItems.Add(new MenuItem(timeBox, UIFont, new Vector2(640 - (timeBox.Width / 2), 0), timeText, new Color(255f, 0f, 0f), true));
            menuItems.Add(new MenuItem(popUpBox, UIFont, new Vector2(640 - (popUpBox.Width / 2), 360 - (popUpBox.Height / 2)), popUpText, new Color(100f, 100f, 100f), false));
            menuItems.Add(new MenuItem(scavenge, UIFont, new Vector2(popUpBox.Width - scavenge.Width, popUpBox.Height + 80f), blank, new Color(0f, 0f, 0f), false));
            menuItems.Add(new MenuItem(cancle, UIFont, new Vector2(popUpBox.Width + cancle.Width - 50f, popUpBox.Height + 80f), blank, new Color(0f, 0f, 0f), false));
        }

        public MenuManagerImp()
        {

        }

        public void setResource(int[] resource)
        {
            throw new NotImplementedException();
        }

        BuildingData MenuManager.getClickCollision(int x, int y)
        {
            Rectangle checkClick = new Rectangle((int)menuItems[4].Position.X, (int)menuItems[4].Position.Y, scavenge.Width, scavenge.Height);
            Rectangle checkCancle = new Rectangle((int)menuItems[5].Position.X, (int)menuItems[5].Position.Y, cancle.Width, cancle.Height);

            if (checkClick.Contains(new Point(x, y)))
            {
                Console.WriteLine("GO!");
                hidePopUp();
                return tempBuilding;
            }
            if (checkCancle.Contains(new Point(x, y)))
            {
                Console.WriteLine("NO!");
                hidePopUp();
                return null;
            }
            else
            {
                Console.WriteLine("NOTHING!");
                return null;
            }
        }

        public void displayPopUp(BuildingData data)
        {
            tempBuilding = data;
            menuItems[3].Alive = true;
            menuItems[4].Alive = true;
            menuItems[5].Alive = true;
            menuItems[3].Font = popUpHeader;
            menuItems[3].Text[0] = data.getBuildingDescription();
            menuItems[3].popUpHeader();
            menuItems[3].PopUpImg = data.getTexture();
            string[] subText = {"Suvivors: " + data.getSurvivors(), "Food: " +data.getFood(), "Ammo: " +data.getAmmo(), "Scavenge Time: " +data.getScavengeTime()};
            menuItems[3].popUpSub(popUpSubText, subText);
        }

        public void hidePopUp()
        {
            menuItems[3].Alive = false;
            menuItems[3].PopUpImg = null;
            menuItems[4].Alive = false;
            menuItems[5].Alive = false;
        }

        public void displayScavenge(BuildingData data)
        {
            string[] scavText = { "Suvivors Rescued: " + data.getSurvivors(), "Food Found: " + data.getFood(), "Ammo Found: " + data.getAmmo(), "Scavenge Time: " + data.getScavengeTime() };
        }

    }
}
