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
        int time;
        Random random = new Random();


        public DaySimMgrImpl() {
            buildingsToScavenge = new List<BuildingData>();
            time = 8 *60;
        }

        public void queueBuildingToScavenge(BuildingData data)
        {
            // keep track of all the buildings that we will be scavenging
            buildingsToScavenge.Add(data);

        }

        public void runSim()
        {
            int _ammo =0;
            int _food = 0;
            int _aliveSurvivors = 0;
            int _time = 0;
            int _zombies = 0;
            // pop up the ui with items scavenged, update all stats, get ready to go to night mode
            foreach(BuildingData data in buildingsToScavenge){
                _ammo += data.getAmmo();
                _food += data.getFood();
                _aliveSurvivors += data.getSurvivors();
                _ammo -= data.getZombies();
                _zombies += data.getZombies();
                if (data.getScavengeTime() > _time) {
                    //the time is always the building that took the longest to scavenge.
                    //for our simple implementation.
                    _time = data.getScavengeTime();
                }

                ammo += _ammo;
                food += _food;
                aliveSurvivors += _aliveSurvivors;

                DayGameEngineImp.getGameEngine().getMenuManager().SetUIAmmo = ammo;
                DayGameEngineImp.getGameEngine().getMenuManager().SetUIFood = food;
                DayGameEngineImp.getGameEngine().getMenuManager().SetUITime = time + 12 * 60;
        
                data.setAmmo((int)data.getAmmo() / 2 + random.Next(1));
                data.setFood((int)data.getFood() / 2 + random.Next(1));
                data.setSurvivors((int)data.getSurvivors() / 2 + random.Next(1));
                data.setZombies((int)data.getZombies() / 2 + random.Next(1));
            
            }
             // use _ammo & _food & _aliveSurvivors for the sub total of the day
            Console.WriteLine("Food gathered: " + _food + " Ammo gathered: " + _ammo + " Survivors Found: " + _aliveSurvivors);
            DayGameEngineImp.getGameEngine().getMenuManager().displaySummary(_food, _ammo, _zombies, _aliveSurvivors);

            //clear the buildings scavenged this turn
            buildingsToScavenge = new List<BuildingData>();
        }
    }
}
