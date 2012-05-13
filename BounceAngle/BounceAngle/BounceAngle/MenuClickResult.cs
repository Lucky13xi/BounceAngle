using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BounceAngle
{
    class MenuClickResult
    {

        public Object payLoad;
        public clickType type;    

        public enum clickType
        {
            submit,
            cancel,
            summary,
            player
        }
        public MenuClickResult(clickType button, Object p)
        {
            payLoad = p;
            type = button;
        }
    }
}
