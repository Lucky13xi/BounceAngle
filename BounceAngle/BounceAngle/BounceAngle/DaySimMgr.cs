using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BounceAngle
{
    interface DaySimMgr
    {
        void init();
        void resetMode();
        void queueBuildingToScavenge(BuildingData data);
        List<BuildingData> getQueuedBuildings();
        void runSim();
        int getNumAvailableSurvivorsToScavenge();
        void onSummaryPopupOkay();
    }
}
