using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BounceAngle
{
    class DaySimMgrImpl : DaySimMgr
    {
        List<BuildingData> buildingsToScavenge;
        int food;
        int ammo;
        int aliveSurvivors;
        //time int;
        Random random = new Random();


        public void init() {
            buildingsToScavenge = new List<BuildingData>();
            aliveSurvivors = 1;
            //time = 8 *60;

            DayGameEngineImp.getGameEngine().getMenuManager().SetUIAmmo = ammo;
            DayGameEngineImp.getGameEngine().getMenuManager().SetUIFood = food;
            DayGameEngineImp.getGameEngine().getMenuManager().SetUITime = 12; // time + 12 * 60;
            DayGameEngineImp.getGameEngine().getMenuManager().SetUISurvivors = aliveSurvivors;
            DayGameEngineImp.getGameEngine().getMenuManager().SetUIScavenges = aliveSurvivors;
        }

        public void queueBuildingToScavenge(BuildingData data)
        {
            //Console.WriteLine("We queued the building " + data.getID());

            // keep track of all the buildings that we will be scavenging
            buildingsToScavenge.Add(data);

            if (getNumAvailableSurvivorsToScavenge() <= 0)
            {
                runSim();
            }
        }

        public List<BuildingData> getQueuedBuildings()
        {
            return buildingsToScavenge;
        }

        public void runSim()
        {
            int _ammo = 0;
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

                //DayGameEngineImp.getGameEngine().getMenuManager().SetUIAmmo = ammo;
                //DayGameEngineImp.getGameEngine().getMenuManager().SetUIFood = food;
                //DayGameEngineImp.getGameEngine().getMenuManager().SetUITime = time + 12 * 60;
                //DayGameEngineImp.getGameEngine().getMenuManager().SetUISurvivors = aliveSurvivors;
        
                data.setAmmo((int)data.getAmmo() / 2 + random.Next(1));
                data.setFood((int)data.getFood() / 2 + random.Next(1));
                data.setSurvivors((int)data.getSurvivors() / 2 + random.Next(1));
                data.setZombies(0);
            
            }
             // use _ammo & _food & _aliveSurvivors for the sub total of the day
            //Console.WriteLine("Food gathered: " + _food + " Ammo gathered: " + _ammo + " Survivors Found: " + _aliveSurvivors);
            //DayGameEngineImp.getGameEngine().getMenuManager().displaySummary(_food, _ammo, _zombies, _aliveSurvivors);
            DayGameEngineImp.getGameEngine().getMenuManager().displaySummary(_food, _ammo, _aliveSurvivors, _time);
            
        }

        public int getNumAvailableSurvivorsToScavenge()
        {
            return aliveSurvivors - buildingsToScavenge.Count;
        }

        public void onSummaryPopupOkay()
        {
            Console.WriteLine("Summary popup submitted");
            DayGameEngineImp.getGameEngine().stop();
            NightGameEngineImp.getGameEngine().start();
        }

        public void resetMode()
        {
            // clear our building list
            buildingsToScavenge.Clear();

            // clear survivor icons
            DayGameEngineImp.getGameEngine().getMenuManager().hideSurvivorIcon();
        }
    }
}
