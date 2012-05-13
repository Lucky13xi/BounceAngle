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
                    try
                    {
                        if ((Zombies[i].getCurrentLocation() - survivors.getAllSurvivors()[j].getCurrentLocation()).Length() < 350
                            && (Zombies[i].getCurrentLocation() - survivors.getAllSurvivors()[j].getCurrentLocation()).Length() > 30)
                        {
                            Zombies[i].setDestination(survivors.getAllSurvivors()[j].getCurrentLocation());
                        }
                        //TODO: "Hit" detection
                        if ((Zombies[i].getCurrentLocation() - survivors.getAllSurvivors()[j].getCurrentLocation()).Length() < 20)
                        {
                            Zombies.RemoveAt(i);
                        }
                    }
                    catch (Exception e) {
                        break;
                    }
                }
                try
                {
                    Vector2 zombieToMove = Zombies[i].getDestination() - Zombies[i].getCurrentLocation();
                    zombieToMove.Normalize();

                    if (Zombies[i].getDestination() != Vector2.Zero)
                    {

                        Zombies[i].setCurrentLocation(Zombies[i].getCurrentLocation() + zombieToMove * Zombies[i].getMoveSpeed());
                        Zombies[i].setRotation((float)Math.Atan2(Zombies[i].getDestination().Y - Zombies[i].getCurrentLocation().Y, Zombies[i].getDestination().X - Zombies[i].getCurrentLocation().X));
                    }
                    else
                    {
                        //TODO: BEHAVIOUR WHEN THEY HAVE NOT SEEN THE SURVIVORS
                    }
                }
                catch (ArgumentOutOfRangeException) {/*it's because i delete the zombie and then reference...bad coding i know...but you can die in a fire.*/ }
            }
        }
        public void draw(SpriteBatch spriteBatch)
        {
            foreach (ZombieData zombie in Zombies)
            {
                spriteBatch.Draw(zombie.getTexture(), zombie.getCurrentLocation(), null, Color.White, zombie.getRotation(), new Vector2(zombie.getTexture().Width / 2, zombie.getTexture().Height / 2),1f, SpriteEffects.None, 0f);
                //spriteBatch.Draw(zombie.getTexture(), zombie.getCurrentLocation(), Color.White);
            }
        }
    }       
}
