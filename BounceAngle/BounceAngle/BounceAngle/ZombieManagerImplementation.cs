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
        private float rotation { get; set; }

        public ZombieManagerImplementation()
        {
            Zombies = new List<ZombieData>();
            zombieTextures = new List<Texture2D>();
            //rotation = 0f;
        }

        public void addZombie(ZombieData zombie)
        {
            NightGameEngineImp.getGameEngine().getSoundManager().playZombieSound();
            zombie.setCurrentLocation(new Vector2(random.Next(-50, 1330), random.Next(-50, 770)));
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
        }
        public void update(GameTime gameTime)
        {
            SurvivorManager survivors = NightGameEngineImp.getGameEngine().getSurvivorManager();
            for (int i = 0; i < Zombies.Count; i++)
            {
                for (int j = 0; j < survivors.getAllSurvivors().Count; j++){
                    if ((Zombies[i].getCurrentLocation() - survivors.getSurvivorById(j).getCurrentLocation()).Length() < 150
                        && (Zombies[i].getCurrentLocation() - survivors.getSurvivorById(j).getCurrentLocation()).Length() > 30)
                    {
                        Zombies[i].setDestination(survivors.getSurvivorById(j).getCurrentLocation());
                    }    
                }
                List<Building> buildings = NightGameEngineImp.getGameEngine().getMapManager().getAllBuildings();
               
                if (Zombies[i].getDestination() != null)
                {
                    Vector2 zombieToMove = Zombies[i].getDestination() - Zombies[i].getCurrentLocation();
                    zombieToMove.Normalize();
                    Zombies[i].setCurrentLocation(Zombies[i].getCurrentLocation() + zombieToMove * Zombies[i].getMoveSpeed());
                    rotation = (float)Math.Atan2(Zombies[i].getDestination().Y - Zombies[i].getCurrentLocation().Y, Zombies[i].getDestination().X - Zombies[i].getCurrentLocation().X);
                    return;
                }
                for (int j = 0; j < buildings.Count; j++)
                {
                    if (buildings[j].getBuildingData().getTexture().Bounds.Intersects(Zombies[i].getTexture().Bounds))
                    {
                        float number = (float)Math.Atan2(Zombies[i].getDestination().Y - Zombies[i].getCurrentLocation().Y, Zombies[i].getDestination().X - Zombies[i].getCurrentLocation().X);
                        number = MathHelper.ToDegrees(number);
                        if (number % 45 > 22)
                        {
                            float zombieToMove = (Zombies[i].getDestination() - Zombies[i].getCurrentLocation()).Length();
                            Zombies[i].setCurrentLocation(Zombies[i].getCurrentLocation() * new Vector2(-1,1));
                        }

                    }
                }
            }
        }
        public void draw(SpriteBatch spriteBatch)
        {
            foreach (ZombieData zombie in Zombies)
            {
                spriteBatch.Draw(zombie.getTexture(), zombie.getCurrentLocation(), null, Color.White, rotation, new Vector2(zombie.getTexture().Width / 2, zombie.getTexture().Height / 2),1f, SpriteEffects.None, 0f);
                //spriteBatch.Draw(zombie.getTexture(), zombie.getCurrentLocation(), Color.White);
            }
        }
    }       
}
