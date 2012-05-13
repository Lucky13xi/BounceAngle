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
        private static int survivorCounter = 0;
        List<SurvivorData> survivorsData;

        public SurvivorManagerIMP() {
            survivorsData = new List<SurvivorData>();
        }

        public void addSurvivor(SurvivorData survivor) {
            survivorsData.Add(survivor);
        }

        public List<SurvivorData> getAllSurvivors(){
            return survivorsData;
            
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
            // TODO: get the survivor start locations from the list of buildings visited in the day
            addSurvivor(new SurvivorDataIMP(survivorCounter++,
                                    new Vector2(70, 70), Vector2.Zero,
                                    content.Load<Texture2D>("Images//survivor"), 1.0f));
        }

        public void update(GameTime gameTime) { 
            // loop through each survivor
            //  - if it has a destination, move the survivor closer to that survivor
            //    - else if it has no destination, set the destination to the safehouse go to the get the safe house location
            //  - if there is a zombie near it, then shoot or die or some AI
            //  - check if i collide into any walls and move around it
            //    - if it is colliding with the safe house though, it is okay
            int safehouseBuildingId = NightGameEngineImp.getGameEngine().getMapManager().getSafehouseBuildingId();

            foreach (SurvivorData survivor in survivorsData)
            {
                if (Vector2.Zero == survivor.getDestination())
                {
                    Vector2 safehouseLocation = NightGameEngineImp.getGameEngine().getMapManager().getBuildingByID(safehouseBuildingId).getBuildingData().getLocation();
                    // TODO: offset the safehouse location to the middle of the building
                    survivor.setDestination(safehouseLocation);
                }

                checkIfZombiesNearMe(survivor);

                Vector2 nextDirectionVector = survivor.getDestination() - survivor.getCurrentLocation();
                nextDirectionVector.Normalize();     // scale direction into a unit vector
                float refreshRateFactor = 1.0f;//(float)(gameTime.ElapsedGameTime.TotalMilliseconds / 1500.0);    // TODO: fudged this scale factor for now
                Vector2 nextLocation = survivor.getCurrentLocation() + (nextDirectionVector * survivor.getMoveSpeed() * refreshRateFactor);

                Vector2 newNextLocation = checkBuildingCollission(survivor, nextLocation, safehouseBuildingId);

                survivor.setCurrentLocation(newNextLocation);
                Console.WriteLine("Survivor: " + survivor.getId() + " at position: (" + newNextLocation.X + "," + newNextLocation.Y + ")");
            }
        }

        public void draw(SpriteBatch spriteBatch) {
            foreach (SurvivorData survivor in survivorsData) {

                spriteBatch.Draw(survivor.getTexture(), survivor.getCurrentLocation(), Color.White);
            }
        }

        private Vector2 checkBuildingCollission(SurvivorData survivor, Vector2 wantToGoHereLocation, int safehouseId)
        {
            int buildingCollision = NightGameEngineImp.getGameEngine().getMapManager().getCollision(wantToGoHereLocation);
            if (buildingCollision == safehouseId)
            {
                survivorReachedSafehouse(survivor);
                return survivor.getCurrentLocation();
            }

            if (buildingCollision >= 0)
            {
                Console.WriteLine("Survivor: " + survivor.getId() + " collided with building: " + buildingCollision);
                
                /* THIS doesn't work yet
                // we collided into this building
                Vector2 direction = wantToGoHereLocation - survivor.getCurrentLocation();
                for (float angle = 15.0f; angle < 360; angle += 15.0f)
                {
                    Vector2 anotherPossibleDirection = Vector2.Transform(direction, Matrix.CreateRotationX(angle));
                    anotherPossibleDirection = anotherPossibleDirection * 2.0f;
                    Vector2 anotherPossibleLocation = anotherPossibleDirection + survivor.getCurrentLocation();
                    int buildingCollisionId = NightGameEngineImp.getGameEngine().getMapManager().getCollision(anotherPossibleLocation);
                    if (buildingCollision < 0) {
                        // yay, we found a non-colliding direction
                        return anotherPossibleLocation;
                    }
                }
                 */

                // we keep hitting a wall in every direction we go now, so just don't move anymore
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
            // TODO:
            Console.WriteLine("Survivor: " + survivor.getId() + " reached safehouse.");
        }
    }
}
