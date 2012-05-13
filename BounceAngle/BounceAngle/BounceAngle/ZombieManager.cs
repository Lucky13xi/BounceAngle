using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace BounceAngle
{
    interface ZombieManager
    {
        void addZombie(ZombieData zombie);
        List<ZombieData> getAllZombies();
        ZombieData getZombieById(int id);
        List<Texture2D> getZombieTextures();

        void clearList();
        void init(ContentManager content);
        void update(GameTime gameTime);
        void draw(SpriteBatch spriteBatch);
    }
}
