using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BounceAngle
{
    class NightSimMgrImpl : NightSimMgr
    {
        private const int SPAWN_DELAY = 1000;
        private float spawnCounter;
        private int screenHeight;
        private int screenWidth;
        private int currentActiveSurvivorId;

        public void init()
        {
            spawnCounter = 0;
            screenHeight = 720;
            screenWidth = 1280;
            currentActiveSurvivorId = -1;
        }

        public void resetMode()
        {
            // clear all the stuff from last round
            NightGameEngineImp.getGameEngine().getSurvivorManager().resetRound();

            // reset hover effect
            foreach (Building b in NightGameEngineImp.getGameEngine().getMapManager().getAllBuildings())
            {
                b.getBuildingData().setOver(false);
            }

            // add all the survivors to the proper start locations from the DaySimMgr
            List<BuildingData> spawnLocs = DayGameEngineImp.getGameEngine().getSimMgr().getQueuedBuildings();
            for (int i = 0; i < spawnLocs.Count; i++)
            {
                NightGameEngineImp.getGameEngine().getSurvivorManager().addSurvivor(
                    new SurvivorDataIMP(
                        SurvivorManagerIMP.survivorCounter++,
                        spawnLocs[i].getSpawnLocation(),
                        Vector2.Zero,
                        NightGameEngineImp.getGameEngine().getSurvivorManager().getTextures()[0],
                        2.5f));
            }
        }

        public void update(GameTime gameTime)
        {
            // 1. handle spawning zombies
            // 2. handle end game state when all the suvivors are gone from the survivor manager
            //     - flip back into the day mode
 
            spawnCounter += gameTime.ElapsedGameTime.Milliseconds;
            if (spawnCounter > SPAWN_DELAY)
            {
                NightGameEngineImp.getGameEngine().getZombieManager().addZombie(new ZombieDataImp(NightGameEngineImp.getGameEngine().getZombieManager().getZombieTextures()[0]));
                spawnCounter = 0;
            }

            if (0 == NightGameEngineImp.getGameEngine().getSurvivorManager().getAllSurvivors().Count)
            {
                NightGameEngineImp.getGameEngine().stop();
                DayGameEngineImp.getGameEngine().getMenuManager().SetUIScavenges = DayGameEngineImp.getGameEngine().getMenuManager().SetUISurvivors;
                DayGameEngineImp.getGameEngine().start();
            }

            // display all the survivor icons
            NightGameEngineImp.getGameEngine().getMenuManager().displaySurvivorIcons(NightGameEngineImp.getGameEngine().getSurvivorManager().getAllSurvivors());

            updateScreenLocation();
        }

        private void updateScreenLocation()
        {
            SurvivorData sd = NightGameEngineImp.getGameEngine().getSurvivorManager().getActiveSurvivor();
            if (null != sd)
            {
                // update the screen offsets to follow the active survivor
                Vector2 centeringOffset = new Vector2(screenWidth / 2, screenHeight / 2);
                Vector2 worldToScreenOffset = -sd.getCurrentLocation() + centeringOffset;
                //Console.WriteLine("Screen worldToScreenOffset:" + worldToScreenOffset + " survivor:" + sd.getCurrentLocation() + " centering=" + centeringOffset);
                NightGameEngineImp.getGameEngine().getMapManager().setScreenWorldOffset(worldToScreenOffset);

                if (currentActiveSurvivorId != sd.getId())
                {
                    Console.WriteLine("Survivor focus from: " + currentActiveSurvivorId + " to " + sd.getId());
                }
                currentActiveSurvivorId = sd.getId();
            }
            else
            {
                if (currentActiveSurvivorId != -1)
                {
                    Console.WriteLine("Survivor focus from: " + currentActiveSurvivorId + " to none");
                }
                currentActiveSurvivorId = -1;
            }
        }
    }
}
