using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BounceAngle
{
    interface MapManager
    {
        void LoadMap(ContentManager Content);
        void Draw(SpriteBatch spriteBatch);
        void setOffset(Vector2 offset);
        ArrayList getAllBuildings();
        Building getBuildingByID(int id);
        int findClosestBuildingID(Vector2 cord);
    }
}