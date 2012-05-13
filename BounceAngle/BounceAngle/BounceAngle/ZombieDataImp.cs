using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BounceAngle
{
    class ZombieDataImp : ZombieData
    {
        Texture2D texture;
        Vector2 destination;
        Vector2 location;
        int id;
        float speed;
        float rotation;
        Random random = new Random();
        private float animationStep;
        public bool dead;

        public ZombieDataImp(Texture2D _texture)
        {
            texture = _texture;
            speed = (float)random.NextDouble();
            rotation = 0f;
            setDestination(Vector2.Zero);
            animationStep = 0;
            dead = false;
        }
        public void setDead(bool value)
        {
            dead = value;
        }
        public bool getDead()
        {
            return dead;
        }
        public void setRotation(float rot)
        {
            rotation = rot;
        }

        public float getRotation()
        {
            return rotation;
        }
        public int getId()
        {
            return id;
        }
        public Vector2 getCurrentLocation()
        {
            return location;
        }
        public Vector2 getDestination()
        {
            return destination;
        }
        public Texture2D getTexture()
        {
            return texture;
        }
        public float getMoveSpeed()
        {
            return speed;
        }
        public void updateAnimation()
        {
            if (!dead && getDestination() != Vector2.Zero)
            {
                animationStep += speed;
                if (animationStep > 15)
                {
                    if (getTexture().Equals(NightGameEngineImp.getGameEngine().getZombieManager().getZombieTextures()[0]))
                    {
                        setTexture(NightGameEngineImp.getGameEngine().getZombieManager().getZombieTextures()[1]);
                    }
                    else
                    {
                        setTexture(NightGameEngineImp.getGameEngine().getZombieManager().getZombieTextures()[0]);
                    }
                    animationStep = 0;
                }
            }
            else if(dead)
            {
                animationStep += 1;
                if (animationStep > 200)
                {
                    NightGameEngineImp.getGameEngine().getZombieManager().getAllZombies().Remove(this);
                }else if (animationStep > 50){
                    setTexture(NightGameEngineImp.getGameEngine().getZombieManager().getZombieTextures()[4]);
                }else if (animationStep > 25){
                    setTexture(NightGameEngineImp.getGameEngine().getZombieManager().getZombieTextures()[3]);
                }else setTexture(NightGameEngineImp.getGameEngine().getZombieManager().getZombieTextures()[2]);                    
            }
        }
        public void setTexture(Texture2D _tex)
        {
            texture = _tex;
        }
        public void setCurrentLocation(Vector2 loc)
        {
            location = loc;
        }
        public void setDestination(Vector2 loc)
        {
            destination = loc;
        }
    }
}
