using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BounceAngle
{
    class MenuClickResult
    {

        Object payLoad;
        clickType type;    

        public enum clickType
        {
            submit,
            cancel,
            summary
        }
        public MenuClickResult(clickType button, Object p)
        {
            payLoad = p;
            type = button;
        }
    }
}
