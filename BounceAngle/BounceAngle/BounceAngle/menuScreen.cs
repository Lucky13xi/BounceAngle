using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace BounceAngle
{
    class MenuScreen
    {
        string[] menuItems;
        int selectedIndex;

        Color normal = Color.White;
        Color selected = Color.Red;

        KeyboardState preKeyState;
        KeyboardState keyState;

        SpriteFont spriteFont;

        int itemSelected = 0;

        Vector2 position;
        float width = 0f;
        float height = 0f;

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                if (selectedIndex < 0)
                    selectedIndex = 0;
                if (selectedIndex >= menuItems.Length)
                    selectedIndex = menuItems.Length - 1;
            }
        }

        public int ItemSelected
        {
            get { return itemSelected; }
            set { itemSelected = value; }
        }

        public MenuScreen(GraphicsDeviceManager graphics, SpriteFont _spriteFont, string[] _menuItems)
        {

            spriteFont = _spriteFont;
            menuItems = _menuItems;
            MeasureMenu(graphics);
        }

        public void MeasureMenu(GraphicsDeviceManager graphics)
        {
            height = 0;
            width = 0;
            foreach (string item in menuItems)
            {
                Vector2 size = spriteFont.MeasureString(item);
                if (size.X > width)
                    width = size.X;
                height += spriteFont.LineSpacing + 5;
            }

            position = new Vector2(200, (graphics.GraphicsDevice.Viewport.Height - height) / 2);
        }


        private bool CheckKey(Keys theKey)
        {
            if (keyState.IsKeyUp(theKey) && preKeyState.IsKeyDown(theKey))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void menuSelect()
        {
            //keyState = Keyboard.GetState();

            //if (CheckKey(Keys.Down))
            //{
            //    SelectedIndex++;
            //    if (selectedIndex == menuItems.Length)
            //    {
            //        SelectedIndex = 0;
            //    }
            //}
            //if (CheckKey(Keys.Up))
            //{
            //    SelectedIndex--;
            //    if (SelectedIndex < 0)
            //    {
            //        SelectedIndex = menuItems.Length - 1;
            //    }
            //}

            //if (keyState.IsKeyDown(Keys.Enter) && SelectedIndex == menuItems.Length - 1)
            //{
            //    ItemSelected = 4;
            //}
            //if (keyState.IsKeyDown(Keys.Enter) && SelectedIndex == menuItems.Length - 3)
            //{
            //    ItemSelected = 2;
            //}
            //if (keyState.IsKeyDown(Keys.Enter) && SelectedIndex == menuItems.Length - 2)
            //{
            //    ItemSelected = 3;
            //}
            //if (keyState.IsKeyDown(Keys.Enter) && SelectedIndex == menuItems.Length - 4)
            //{
            //    ItemSelected = 1;
            //}

            //preKeyState = keyState;
        }

        public void Update()
        {
            menuSelect();
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            Vector2 location = position;
            Color hilight;

            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == SelectedIndex)
                {
                    hilight = selected;
                }
                else
                {
                    hilight = normal;
                }
                spriteBatch.DrawString(spriteFont, menuItems[i], location + new Vector2(0, 15 * i), hilight);
                location.Y += spriteFont.LineSpacing + 5;
            }

        }
    }
}

