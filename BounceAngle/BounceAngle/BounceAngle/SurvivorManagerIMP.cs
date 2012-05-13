using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace BounceAngle
{
    class SurvivorManagerIMP : SurvivorManager
    {
        //use this when creating new survivorID's
        public static int survivorCounter = 0;
        private List<SurvivorData> survivorsData;
        private List<int> removeFromListQueue;
        private SurvivorData activeSurvivor;
        public Texture2D survivorTexture1, survivorTexture2;

        public SurvivorManagerIMP() {
            survivorsData = new List<SurvivorData>();
            removeFromListQueue = new List<int>();
        }

        public void addSurvivor(SurvivorData survivor) {
            survivorsData.Add(survivor);
            setActiveSurvivor(survivor.getId());
        }

        public List<SurvivorData> getAllSurvivors(){
            return survivorsData;
            
        }

        public Texture2D getTexture()
        {
            return survivorTexture1;
        }

        public SurvivorData getSurvivorById(int id) {
            foreach (SurvivorData survivor in survivorsData) {
                if (survivor.getId() == id) {
                    return survivor;
                }
            }
            return null;
        }

        public void init(ContentManager content) {
            survivorTexture1 = content.Load<Texture2D>("Images//survivor0");
            survivorTexture2 = content.Load<Texture2D>("Images//survivor1");
        }

        public void update(GameTime gameTime) { 
            // loop through each survivor
            //  - if you have a destination and you reach it then reset it
            //  - if you hit the safehouse, you're finished
            //  - if it has a destination, move the survivor closer to that destination
            //    - else if it has no destination, set the destination to the safehouse go to the get the safe house location
            //  - if there is a zombie near it, then shoot or die or some AI
            //  - check if i collide into any walls and move around it
            //    - if it is colliding with the safe house though, it is okay
            int safehouseBuildingId = NightGameEngineImp.getGameEngine().getMapManager().getSafehouseBuildingId();

            foreach (SurvivorData survivor in survivorsData)
            {
                Vector2 toDest = survivor.getDestination() - survivor.getCurrentLocation();
                if (toDest.LengthSquared() <= 3)
                {
                    // the survivor practically reached its destination
                    survivor.setDestination(Vector2.Zero);
                }

                if (Vector2.Zero == survivor.getDestination())
                {
                    Vector2 safehouseLocation = NightGameEngineImp.getGameEngine().getMapManager().getBuildingByID(safehouseBuildingId).getBuildingData().getLocation();
                    // offset the safehouse location to the middle of the building
                    safehouseLocation += new Vector2(50, 50);
                    survivor.setDestination(safehouseLocation);
                }

                checkIfZombiesNearMe(survivor);

                Vector2 nextDirectionVector = survivor.getDestination() - survivor.getCurrentLocation();
                nextDirectionVector.Normalize();     // scale direction into a unit vector
                float refreshRateFactor = 1.0f;//(float)(gameTime.ElapsedGameTime.TotalMilliseconds / 1500.0);    // TODO: fudged this scale factor for now
                Vector2 nextLocation = survivor.getCurrentLocation() + (nextDirectionVector * survivor.getMoveSpeed() * refreshRateFactor);

                Vector2 newNextLocation = checkBuildingCollission(survivor, nextLocation, safehouseBuildingId);

                survivor.setCurrentLocation(newNextLocation);
                //Console.WriteLine("Survivor: " + survivor.getId() + " at position: (" + newNextLocation.X + "," + newNextLocation.Y + ")");
            }

            // if something reached the safe house, remove it here
            foreach (int removeSurvivorId in removeFromListQueue)
            {
                killSurvivor(removeSurvivorId, false);
            }
            removeFromListQueue.Clear();
        }

        public float VectorToAngle(Vector2 vector)
        {
            return (float)Math.Atan2(vector.Y, vector.X);
        }

        public void draw(SpriteBatch spriteBatch) {
            foreach (SurvivorData survivor in survivorsData) {

                //  spriteBatch.Draw(survivor.getTexture(), survivor.getCurrentLocation(), Color.White);
                float facing = VectorToAngle(survivor.getDestination()- survivor.getCurrentLocation());
                
                spriteBatch.Draw(survivor.getTexture(), survivor.getCurrentLocation() + getOffset(), null,
                    Color.White, facing, new Vector2(survivor.getTexture().Width/2,survivor.getTexture().Height/2), new Vector2(0.5f, 0.5f), SpriteEffects.None, 1);
            }
        }

        private Vector2 checkBuildingCollission(SurvivorData survivor, Vector2 wantToGoHereLocation, int safehouseId)
        {
            int buildingCollision = NightGameEngineImp.getGameEngine().getMapManager().getCollision(wantToGoHereLocation, survivor.getOffset());
            if (buildingCollision == safehouseId)
            {
                survivorReachedSafehouse(survivor);
                return survivor.getCurrentLocation();
            }

            if (buildingCollision >= 0)
            {
                // we collided into this building
                Console.WriteLine("Survivor: " + survivor.getId() + " collided with building: " + buildingCollision);

                Boolean isWantToLeftOfCurrLocation = wantToGoHereLocation.X <= survivor.getCurrentLocation().X;
                Boolean isWantToAboveOfCurrLocation = wantToGoHereLocation.Y <= survivor.getCurrentLocation().Y;
                float magnitudeScalar = Math.Max((wantToGoHereLocation - survivor.getCurrentLocation()).Length(), 1.0f);
                Vector2 anotherPossibleLocation1 = survivor.getCurrentLocation();
                Vector2 anotherPossibleLocation2 = survivor.getCurrentLocation();

                if (isWantToLeftOfCurrLocation)
                {
                    if (isWantToAboveOfCurrLocation)
                    {
                        // we wanted to go up and to the left, but there is something in the way
                        anotherPossibleLocation1 += new Vector2(0, -1) * magnitudeScalar;    // up
                        anotherPossibleLocation2 += new Vector2(-1, 0) * magnitudeScalar;   // left
                    }
                    else
                    {
                        // we wanted to go down and to the left, but there is something in the way, so just go left
                        anotherPossibleLocation1 += new Vector2(0, 1) * magnitudeScalar;   // down
                        anotherPossibleLocation2 += new Vector2(-1, 0) * magnitudeScalar;   // left
                    }
                }
                else
                {
                    if (isWantToAboveOfCurrLocation)
                    {
                        // we want to go up and to the right
                        anotherPossibleLocation1 += new Vector2(0, -1) * magnitudeScalar;   // up
                        anotherPossibleLocation2 += new Vector2(1, 0) * magnitudeScalar;   // right
                    }
                    else
                    {
                        // we want to go down and to the right
                        anotherPossibleLocation1 += new Vector2(0, 1) * magnitudeScalar;   // down
                        anotherPossibleLocation2 += new Vector2(1, 0) * magnitudeScalar;   // right
                    }
                }

                int collission1 = NightGameEngineImp.getGameEngine().getMapManager().getCollision(anotherPossibleLocation1);
                int collission2 = NightGameEngineImp.getGameEngine().getMapManager().getCollision(anotherPossibleLocation2);
                /*
                Console.WriteLine("Survivor: " + survivor.getId()
                    + " currLoc=" + survivor.getCurrentLocation()
                    + " wantToGo=" + wantToGoHereLocation
                    + " possible1=" + (anotherPossibleLocation1)
                    + " possible2=" + (anotherPossibleLocation2)
                    + " collission1=" + collission1
                    + " collission2=" + collission2);
                */
                BuildingData bd = NightGameEngineImp.getGameEngine().getMapManager().getBuildingByID(buildingCollision).getBuildingData();
                if (collission1 < 0)
                {
                    float newMagOnCollision = 1.1f * (bd.getTexture().Height);
                    survivor.setDestination(((anotherPossibleLocation1 - survivor.getCurrentLocation()) * newMagOnCollision) + survivor.getCurrentLocation());
                    return anotherPossibleLocation1;
                }

                if (collission2 < 0)
                {
                    float newMagOnCollision = 1.1f * (bd.getTexture().Width);
                    survivor.setDestination(((anotherPossibleLocation2 - survivor.getCurrentLocation()) * newMagOnCollision) + survivor.getCurrentLocation());
                    return anotherPossibleLocation2;
                }

            }
            
            // we did not collide into any building, so the input location is safe
            return wantToGoHereLocation;
        }

        private void checkIfZombiesNearMe(SurvivorData survivor)
        {
            List<ZombieData> zombies = NightGameEngineImp.getGameEngine().getZombieManager().getAllZombies();
            foreach (ZombieData zombie in zombies) {
                Vector2 zombieVector = zombie.getCurrentLocation() - survivor.getCurrentLocation();
                if (zombieVector.Length() < survivor.getCollisionRadius())
                {
                    zombieTooCloseDoSomething(survivor.getId(), zombie.getId());
                    return;
                }
            }
        }

        private void zombieTooCloseDoSomething(int survivorId, int zombieId)
        {
            // TODO:
            Console.WriteLine("Survivor: " + survivorId + " got swarmed by zombie: " + zombieId);
        }

        private void survivorReachedSafehouse(SurvivorData survivor)
        {
            Console.WriteLine("Survivor: " + survivor.getId() + " reached safehouse.");
            removeFromListQueue.Add(survivor.getId());
        }

        public void killSurvivor(int survivorDataId, Boolean isViolentDeath)
        {
            for (int i = 0; i < survivorsData.Count; ++i)
            {
                if (survivorsData[i].getId() == survivorDataId)
                {
                    if (null != activeSurvivor)
                    {
                        if (survivorsData[i].getId() == activeSurvivor.getId())
                        {
                            // the activeSurvivor just died, find another survivor
                            if (i > 0)
                            {
                                // just set the previous survivor in the list as active since we know it exists
                                setActiveSurvivor(survivorsData[i - 1].getId());
                            }
                            else
                            {
                                setActiveSurvivor(-1);
                            }
                        }
                    }

                    survivorsData.RemoveAt(i);
                    break;
                }
            }
            if (isViolentDeath)
            {
                NightGameEngineImp.getGameEngine().getSoundManager().playSurvivorDeathSound();
            }
        }

        public SurvivorData getActiveSurvivor()
        {
            return activeSurvivor;
        }

        public void setActiveSurvivor(int survivorDataId)
        {
            for (int i = 0; i < survivorsData.Count; ++i)
            {
                if (survivorsData[i].getId() == survivorDataId)
                {
                    activeSurvivor = survivorsData[i];
                    break;
                }
            }
            activeSurvivor = null;
        }

        private Vector2 getOffset()
        {
            return NightGameEngineImp.getGameEngine().getMapManager().getScreenWorldOffset();
        }
    }
}
