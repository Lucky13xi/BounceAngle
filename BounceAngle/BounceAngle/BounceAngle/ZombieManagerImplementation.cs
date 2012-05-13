using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace BounceAngle
{
    class ZombieManagerImplementation : ZombieManager
    {
        public List<ZombieData> Zombies { get; set; }
        public List<Texture2D> zombieTextures { get; set; }
        private Random random = new Random();
        //private float rotation { get; set; }

        public ZombieManagerImplementation()
        {
            Zombies = new List<ZombieData>();
            zombieTextures = new List<Texture2D>();
            //rotation = 0f;
        }

        public void addZombie(ZombieData zombie)
        {
            if (random.Next(1,11) > 9)
                NightGameEngineImp.getGameEngine().getSoundManager().playZombieSound();
            Vector2 spawnLocation = new Vector2(random.Next(-500, 1600), random.Next(-300, 1000));
            while(NightGameEngineImp.getGameEngine().getMapManager().getWorldCollision(spawnLocation) >= 0){
                spawnLocation = new Vector2(random.Next(-500, 1600), random.Next(-300, 1000));
            }
            zombie.setCurrentLocation(spawnLocation);
            Zombies.Add(zombie);
        }

        public void clearList()
        {
            Zombies = new List<ZombieData>();
        }

        public void addZombie(ZombieData zombie, Vector2 _spawnLocation)
        {
            NightGameEngineImp.getGameEngine().getSoundManager().playZombieSound();
            Vector2 spawnLocation = _spawnLocation;
            while (NightGameEngineImp.getGameEngine().getMapManager().getWorldCollision(spawnLocation) >= 0)
            {
                spawnLocation = new Vector2(random.Next(-500, 1600), random.Next(-300, 1000));
            }
            zombie.setCurrentLocation(spawnLocation);
            Zombies.Add(zombie);
        }

        public List<ZombieData> getAllZombies(){
            return Zombies;
        }

        public List<Texture2D> getZombieTextures()
        {
            return zombieTextures;
        }

        public ZombieData getZombieById(int id)
        {
            return Zombies[id];
        }

        public void init(ContentManager content)
        {
            zombieTextures.Add(content.Load<Texture2D>("Images//zombie0"));
            zombieTextures.Add(content.Load<Texture2D>("Images//zombie1"));
            zombieTextures.Add(content.Load<Texture2D>("Images//zombie2"));
            zombieTextures.Add(content.Load<Texture2D>("Images//zombie3"));
            zombieTextures.Add(content.Load<Texture2D>("Images//zombie4"));
        }
        public void update(GameTime gameTime)
        {
            SurvivorManager survivors = NightGameEngineImp.getGameEngine().getSurvivorManager();

            for (int i = 0; i < Zombies.Count; i++)
            {

                for (int j = 0; j < survivors.getAllSurvivors().Count; j++){
                    try
                    {
                        if ((Zombies[i].getCurrentLocation() - survivors.getAllSurvivors()[j].getCurrentLocation()).Length() < 500
                            && (Zombies[i].getCurrentLocation() - survivors.getAllSurvivors()[j].getCurrentLocation()).Length() > 30)
                        {
                            Zombies[i].setDestination(survivors.getAllSurvivors()[j].getCurrentLocation());
                        }
                        //TODO: "Hit" detection
                        if (!Zombies[i].getDead() && (Zombies[i].getCurrentLocation() - survivors.getAllSurvivors()[j].getCurrentLocation()).Length() < 20)
                        {
                            if (NightGameEngineImp.getGameEngine().getMenuManager().SetUIAmmo > 0)
                            {
                                Zombies[i].setDead(true);
                                NightGameEngineImp.getGameEngine().getMenuManager().SetUIAmmo--;
                                NightGameEngineImp.getGameEngine().getSoundManager().playGunFire();
                            }
                            else
                            {
                                if (random.Next(1, 11) > 5)
                                {
                                    NightGameEngineImp.getGameEngine().getSurvivorManager().removeSurvivor(survivors.getAllSurvivors()[j].getId(), true);
                                    this.addZombie(new ZombieDataImp(zombieTextures[0]), survivors.getAllSurvivors()[j].getCurrentLocation());
                                }
                                else
                                {
                                    NightGameEngineImp.getGameEngine().getSurvivorManager().removeSurvivor(survivors.getAllSurvivors()[j].getId(), true);
                                }
                            }//Zombies.RemoveAt(i);                            
                        }
                    }
                    catch (Exception) {
                        break;
                    }
                }
                try
                {
                    Vector2 zombieToMove = Zombies[i].getDestination() - Zombies[i].getCurrentLocation();
                    zombieToMove.Normalize();

                    if (Zombies[i].getDestination() != Vector2.Zero && !Zombies[i].getDead())
                    {

                        Zombies[i].setCurrentLocation(Zombies[i].getCurrentLocation() + zombieToMove * Zombies[i].getMoveSpeed());
                        Zombies[i].setRotation((float)Math.Atan2(Zombies[i].getDestination().Y - Zombies[i].getCurrentLocation().Y, Zombies[i].getDestination().X - Zombies[i].getCurrentLocation().X));

                        foreach (Building building in NightGameEngineImp.getGameEngine().getMapManager().getAllBuildings())
                        {
                            Vector2 zomCollisionPoint = Zombies[i].getCurrentLocation() + new Vector2(Zombies[i].getTexture().Width/2,Zombies[i].getTexture().Height/2); 
                            int bId = NightGameEngineImp.getGameEngine().getMapManager().getWorldCollision(zomCollisionPoint);

                            if( bId >= 0){
                                Zombies[i].setCurrentLocation(Zombies[i].getCurrentLocation() - zombieToMove * Zombies[i].getMoveSpeed());
                                Rectangle buildingBounds = NightGameEngineImp.getGameEngine().getMapManager().getBuildingByID(bId).getBuildingData().getTexture().Bounds;
                                if (zomCollisionPoint.X > buildingBounds.Left
                                    && zomCollisionPoint.X < buildingBounds.Right)
                                {
                                    if (zomCollisionPoint.Y < buildingBounds.Top)
                                    {
                                        Zombies[i].setCurrentLocation(Zombies[i].getCurrentLocation() + new Vector2(0, -10));
                                    }
                                    else Zombies[i].setCurrentLocation(Zombies[i].getCurrentLocation() + new Vector2(0, 10));
                                }
                                else if (zomCollisionPoint.Y > buildingBounds.Top
                                    && zomCollisionPoint.Y < buildingBounds.Bottom)
                                {
                                    //Zombies[i].setCurrentLocation(Zombies[i].getCurrentLocation() + zombieToMove * Zombies[i].getMoveSpeed()  * -2f);
                                    if (zomCollisionPoint.X < buildingBounds.Left)
                                    {
                                        Zombies[i].setCurrentLocation(Zombies[i].getCurrentLocation() + new Vector2(-10, 0));
                                    }
                                    else Zombies[i].setCurrentLocation(Zombies[i].getCurrentLocation() + new Vector2(10, 0));
                                }
                                else { Zombies[i].setCurrentLocation(Zombies[i].getCurrentLocation() - zombieToMove * Zombies[i].getMoveSpeed()); }

                            }
                        }
                    }
                    else
                    {
                        //TODO: BEHAVIOUR WHEN THEY HAVE NOT SEEN THE SURVIVORS
                    }
                }
                catch (ArgumentOutOfRangeException) {/*it's because i delete the zombie and then reference...bad coding i know...but you can die in a fire.*/ }
            }

            for (int i =0;i< Zombies.Count;i++)
            {
                Zombies[i].updateAnimation();
            }
        }
        public void draw(SpriteBatch spriteBatch)
        {
            Vector2 screenOffset = NightGameEngineImp.getGameEngine().getMapManager().getScreenWorldOffset();
            foreach (ZombieData zombie in Zombies)
            {
                if (zombie.getDead())
                    spriteBatch.Draw(zombie.getTexture(), zombie.getCurrentLocation() + screenOffset, null, Color.White, zombie.getRotation(), new Vector2(zombie.getTexture().Width / 2, zombie.getTexture().Height / 2), 1f, SpriteEffects.None, 0f);
                else spriteBatch.Draw(zombie.getTexture(), zombie.getCurrentLocation() + screenOffset, null, Color.White, zombie.getRotation(), new Vector2(zombie.getTexture().Width / 2, zombie.getTexture().Height / 2), 0.5f, SpriteEffects.None, 0f);
                //spriteBatch.Draw(zombie.getTexture(), zombie.getCurrentLocation(), Color.White);
            }
        }
    }       
}
