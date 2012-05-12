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

        public ZombieManagerImplementation()
        {
            Zombies = new List<ZombieData>();
            zombieTextures = new List<Texture2D>();
        }

        public void addZombie(ZombieData zombie)
        {
            NightGameEngineImp.getGameEngine().getSoundManager().playZombieSound();
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
            zombieTextures.Add(content.Load<Texture2D>("Images//zombie"));
        }
        public void update(GameTime gameTime)
        {
            SurvivorManager survivors = NightGameEngineImp.getGameEngine().getSurvivorManager();
            /*for (int i = 0; i < Zombies.Count; i++)
            {
                for (int j = 0; j < survivors.getAllSurvivors().Count; j++){
                    if ((Zombies[i].getCurrentLocation() - survivors.getSurvivorsById(j).getCurrentLocation()).Length() < 250)
                    {
                        Zombies[i].setDestination(survivors.getSurvivorsById(j).getCurrentLocation());
                    }
                    
                }

            }*/
        }
        public void draw(SpriteBatch spriteBatch)
        {
            foreach (ZombieData zombie in Zombies)
            {
                spriteBatch.Draw(zombie.getTexture(), zombie.getCurrentLocation(), Color.White);
            }
        }
    }       
}
