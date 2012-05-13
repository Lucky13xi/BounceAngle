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
        Vector2 getScreenWorldOffset();
        void setScreenWorldOffset(Vector2 offset);
        List<Building> getAllBuildings();
        Building getBuildingByID(int id);
        int getScreenCollision(Vector2 coord);
        int getWorldCollision(Vector2 coord);
        int getSafehouseBuildingId();
    }
}