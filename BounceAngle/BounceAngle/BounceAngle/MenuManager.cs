using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace BounceAngle
{
    interface MenuManager
    {

        int SetUITime { get; set; }
        int SetUIAmmo { get; set; }
        int SetUIFood { get; set; }
        int SetUISurvivors { get; set; }
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
        void Init(ContentManager content);
        MenuClickResult getClickCollision(int x, int y);
        void displayPopUp(BuildingData data);
        void displaySummary(int _food, int _ammo, int _survivors, int _time);
        void hidePopUp();
    }
}
