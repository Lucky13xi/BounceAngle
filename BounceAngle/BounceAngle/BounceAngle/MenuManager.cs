using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace BounceAngle
{
    interface MenuManager
    {

        void setTime(int time);
        void setAmmo(int ammo);
        void setFood(int food);
        void setResource(int[] resource);
        void Draw(SpriteBatch spriteBatch);
        void Show();
        void Hide();
        void Init();
        bool getClickCollision(int x, int y);
    }
}
