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
        Texture2D cancel;
        Texture2D summary;
        Texture2D playerIcon;
        BuildingData tempBuilding;
        List<SurvivorData> tempSurvivor = new List<SurvivorData>();
        private int setUITime;
        private int setUIAmmo;
        private int setUIFood;
        private int setUISurvivors;
        private int setUIScavenges;

        public int SetUITime
        {
            get { return setUITime; }
            set { setUITime = value; }
        }

        public int SetUIAmmo
        {
            get { return setUIAmmo; }
            set { setUIAmmo = value; }
        }

        public int SetUIFood
        {
            get { return setUIFood; }
            set { setUIFood = value; }
        }

        public int SetUISurvivors
        {
            get { return setUISurvivors; }
            set { setUISurvivors = value; }
        }

        public int SetUIScavenges
        {
            get { return setUIScavenges; }
            set { setUIScavenges = value; }
        }


        public void Update(GameTime gameTime)
        {
            menuItems[2].Text = new string[] { "Daylight Hours Remaining: " + SetUITime };
            menuItems[0].Text = new string[] { "Food: " + SetUIFood, "Ammo: " + SetUIAmmo };
            menuItems[1].Text = new string[] { "Survivors Remaining: " + SetUISurvivors };
            menuItems[8].Text = new string[] { "Scavenges Left: " +SetUIScavenges };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (MenuItem item in menuItems)
            {
                if (item == menuItems[0])
                {
                    menuItems[0].leftUIText(spriteBatch);
                }
                else
                {
                    item.Draw(spriteBatch);
                }
            }

        }


        public void Init(ContentManager content)
        {
            Texture2D timeBox = content.Load<Texture2D>("MenuItems\\timeBox");
            Texture2D leftUIBox = content.Load<Texture2D>("MenuItems\\leftUI");
            Texture2D rightUIBox = content.Load<Texture2D>("MenuItems\\rightUI");
            Texture2D underBox = content.Load<Texture2D>("MenuItems\\scavengeLeft");
            scavenge = content.Load<Texture2D>("MenuItems\\scavenge");
            cancel = content.Load<Texture2D>("MenuItems\\cancel");
            popUpBox = content.Load<Texture2D>("MenuItems\\popUp");
            summary = content.Load<Texture2D>("MenuItems\\summary");
            playerIcon = content.Load<Texture2D>("MenuItems\\playerIcon");
            SpriteFont UIFont = content.Load<SpriteFont>("MenuItems\\UIFont");
            SpriteFont subUIFont = content.Load<SpriteFont>("MenuItems\\subUIFont");
            popUpHeader = content.Load<SpriteFont>("MenuItems\\popUpHeader");
            popUpSubText = content.Load<SpriteFont>("MenuItems\\popUpSubText");
            string[] timeText = { "Daylight Hours Remaining: " +SetUITime };
            string[] leftUIText = { "Food: " +SetUIFood, "Ammo: " +SetUIAmmo };
            string[] rightUIText = { "Survivors Remaining: " +SetUISurvivors };
            string[] popUpText = { "", "" };
            string[] blank = { "" };
            string[] underUIText = { "Scavenges Left: " +SetUIScavenges };

            menuItems.Add(new MenuItem(leftUIBox, subUIFont, new Vector2(640 - (timeBox.Width / 2) - leftUIBox.Width *0.9f + 1, 0), leftUIText, new Color(0f, 0f, 0f), true));
            menuItems.Add(new MenuItem(rightUIBox, subUIFont, new Vector2(640 - (timeBox.Width / 2) + rightUIBox.Width, 0), rightUIText, new Color(0f, 0f, 0f), true));
            menuItems.Add(new MenuItem(timeBox, UIFont, new Vector2(640 - (timeBox.Width / 2), 0), timeText, new Color(255f, 0f, 0f), true));
            menuItems.Add(new MenuItem(popUpBox, UIFont, new Vector2(640 - (popUpBox.Width / 2), 360 - (popUpBox.Height / 2)), popUpText, new Color(100f, 100f, 100f), false));
            menuItems.Add(new MenuItem(scavenge, UIFont, new Vector2(popUpBox.Width - scavenge.Width, popUpBox.Height + 80f), blank, new Color(0f, 0f, 0f), false));
            menuItems.Add(new MenuItem(cancel, UIFont, new Vector2(popUpBox.Width + cancel.Width - 50f, popUpBox.Height + 80f), blank, new Color(0f, 0f, 0f), false));
            menuItems.Add(new MenuItem(popUpBox, UIFont, new Vector2(640 - (popUpBox.Width / 2), 360 - (popUpBox.Height / 2)), popUpText, new Color(100f, 100f, 100f), false));
            menuItems.Add(new MenuItem(summary, UIFont, new Vector2(popUpBox.Width + summary.Width - 185, popUpBox.Height + 80f), blank, new Color(0f, 0f, 0f), false));
            menuItems.Add(new MenuItem(underBox, subUIFont, new Vector2(640 - (timeBox.Width / 2) + 38, timeBox.Bounds.Bottom), underUIText, new Color(0f, 0f, 0f), true));
            menuItems.Add(new MenuItem(playerIcon, UIFont, new Vector2(25, 200), blank, new Color(0f, 0f, 0f), false));
            menuItems.Add(new MenuItem(playerIcon, UIFont, new Vector2(25, 300), blank, new Color(0f, 0f, 0f), false));
            menuItems.Add(new MenuItem(playerIcon, UIFont, new Vector2(25, 400), blank, new Color(0f, 0f, 0f), false));
            menuItems.Add(new MenuItem(playerIcon, UIFont, new Vector2(25, 500), blank, new Color(0f, 0f, 0f), false));
        }

        public MenuManagerImp()
        {

        }

        MenuClickResult MenuManager.getClickCollision(int x, int y)
        {
            Rectangle checkClick = new Rectangle((int)menuItems[4].Position.X, (int)menuItems[4].Position.Y, scavenge.Width, scavenge.Height);
            Rectangle checkCancle = new Rectangle((int)menuItems[5].Position.X, (int)menuItems[5].Position.Y, cancel.Width, cancel.Height);
            Rectangle checkSummary = new Rectangle((int)menuItems[7].Position.X, (int)menuItems[7].Position.Y, summary.Width, summary.Height);
            Rectangle playerCheck = new Rectangle((int)menuItems[9].Position.X, (int)menuItems[9].Position.Y, playerIcon.Width, playerIcon.Height);

            if (checkClick.Contains(new Point(x, y)) && menuItems[4].Alive)
            {
                hidePopUp();
                SetUIScavenges--;
                return new MenuClickResult(MenuClickResult.clickType.submit, tempBuilding);
            }
            if (checkCancle.Contains(new Point(x, y)) && menuItems[5].Alive)
            {
                hidePopUp();
                return new MenuClickResult(MenuClickResult.clickType.cancel, null);
            }
            if (checkSummary.Contains(new Point(x, y)) && menuItems[7].Alive)
            {
                hideSummary();
                return new MenuClickResult(MenuClickResult.clickType.summary, null);
            }
            if (playerCheck.Contains(new Point(x, y)) && menuItems[9].Alive)
            {
                menuItems[9].Alive = false;
                return new MenuClickResult(MenuClickResult.clickType.player, tempSurvivor[0]);
            }
            if (playerCheck.Contains(new Point(x, y)) && menuItems[10].Alive)
            {
                menuItems[10].Alive = false;
                return new MenuClickResult(MenuClickResult.clickType.player, tempSurvivor[1]);
            }
            if (playerCheck.Contains(new Point(x, y)) && menuItems[11].Alive)
            {
                menuItems[11].Alive = false;
                return new MenuClickResult(MenuClickResult.clickType.player, tempSurvivor[2]);
            }
            if (playerCheck.Contains(new Point(x, y)) && menuItems[12].Alive)
            {
                menuItems[12].Alive = false;
                return new MenuClickResult(MenuClickResult.clickType.player, tempSurvivor[3]);
            }
            else
            {
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

        public void displaySummary(int _food, int _ammo, int _survivors, int _time)
        {
            menuItems[6].Alive = true;
            menuItems[7].Alive = true;
            menuItems[6].Text[0] = tempBuilding.getBuildingDescription();
            menuItems[6].popUpHeader();
            menuItems[6].PopUpImg = tempBuilding.getTexture();
            string[] scavText = { "Suvivors Rescued: " +_survivors, "Food Found: " +_food, "Ammo Found: " +_ammo };
            SetUISurvivors += _survivors;
            SetUIAmmo += _ammo;
            SetUIFood += _food;
            SetUITime -= _time;
            if (SetUITime <= 0)
            {
                SetUITime = 0;
            }
            menuItems[6].popUpSub(popUpSubText, scavText);
        }

        public void hideSummary()
        {
            menuItems[7].Alive = false;
            menuItems[6].PopUpImg = null;
            menuItems[6].Alive = false;
        }



        public void displaySurvivorIcons(List<SurvivorData> data)
        {
            tempSurvivor = data;
            menuItems[9].Alive = true;
            menuItems[10].Alive = true;
            menuItems[11].Alive = true;
            menuItems[12].Alive = true;
        }

        public void hideSurvivorIcon()
        {
            menuItems[9].Alive = false;
            menuItems[10].Alive = false;
            menuItems[11].Alive = false;
            menuItems[12].Alive = false;
        }
    }
}
