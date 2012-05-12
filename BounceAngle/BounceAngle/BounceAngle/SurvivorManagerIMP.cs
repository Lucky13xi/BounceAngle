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
        List<SurvivorDataIMP> survivorsData;

        public SurvivorManagerIMP() {
            survivorsData = new List<SurvivorDataIMP>();
        }

        public void addSurvivor(SurvivorDataIMP survivor) {
            survivorsData.Add(survivor);
        }

        public List<SurvivorDataIMP> getAllSurvivors(){
            return survivorsData;
            
        }

        public SurvivorDataIMP getSurvivorById(int id) {
            foreach (SurvivorDataIMP survivor in survivorsData) {
                if (survivor.getId() == id) {
                    return survivor;
                }
            }
            return null;
        }

        public void init(ContentManager content) { 
        
        }

        public void update(GameTime gameTime) { 
            //ai
        }

        public void draw(SpriteBatch spriteBatch) {
            foreach (SurvivorData survivor in survivorsData) {

                spriteBatch.Draw(survivor.getTexture(), survivor.getCurrentLocation(), Color.White);

            }
        }
    }
}
