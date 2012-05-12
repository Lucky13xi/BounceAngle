using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BounceAngle
{
    class DaySimMgrImpl : DaySimMgr
    {
        List<BuildingData> buildingsToScavenge;
        int food;
        int ammo;
        int aliveSurvivors;


        public DaySimMgrImpl() {
            buildingsToScavenge = new List<BuildingData>();
            aliveSurvivors = 1;
        }

        public void queueBuildingToScavenge(BuildingData data)
        {
            // keep track of all the buildings that we will be scavenging
            buildingsToScavenge.Add(data);

            if (getNumAvailableSurvivorsToScavenge() <= 0)
            {
                runSim();
            }
        }

        public void runSim()
        {
            // pop up the ui with items scavenged, update all stats, get ready to go to night mode
            foreach(BuildingData data in buildingsToScavenge){
                ammo += data.getAmmo();
                food += data.getFood();
                aliveSurvivors += data.getSurvivors();
                ammo -= data.getZombies();
            }
            //pop up window


            //clear the buildings scavenged this turn
            buildingsToScavenge = new List<BuildingData>();
        }

        public int getNumAvailableSurvivorsToScavenge()
        {
            return aliveSurvivors - buildingsToScavenge.Count;
        }
    }
}
