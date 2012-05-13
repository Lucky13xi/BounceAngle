using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace BounceAngle
{
    interface SurvivorManager
    {
        void addSurvivor(SurvivorData survivor);
        List<SurvivorData> getAllSurvivors();
        SurvivorData getSurvivorById(int id);
        Texture2D getTexture();
        void reset();
        void init(ContentManager content);
        void update(GameTime gameTime);
        void draw(SpriteBatch spriteBatch);
        
    }
}
