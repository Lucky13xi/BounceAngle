using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BounceAngle
{
    interface NightSimMgr
    {
        void init();
        void resetMode();
        void update(GameTime gameTime);
    }
}
