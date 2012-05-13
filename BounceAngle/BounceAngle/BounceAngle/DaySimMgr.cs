using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BounceAngle
{
    interface DaySimMgr
    {
        void init();
        void resetMode();
        void queueBuildingToScavenge(BuildingData data);
        void runSim();
        int getNumAvailableSurvivorsToScavenge();
        void onSummaryPopupOkay();
    }
}
