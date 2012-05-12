using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BounceAngle
{
    interface GameEngine
    { 
        SoundManager getSoundManager();
        UIManager getUIManager();
        MenuManager getMenuManager();
        void Draw(SpriteBatch spriteBatch);
        void Init();
        void Update(GameTime gameTime);
        
    }
}
