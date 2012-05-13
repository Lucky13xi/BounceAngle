using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BounceAngle
{
    interface UIManager
    {
        void init();
        void ProcessMouse(MouseState mouseState);
    }
}
