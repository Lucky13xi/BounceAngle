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
            addSurvivor(new SurvivorDataIMP(survivorCounter++,
                                    new Vector2(70, 70), new Vector2(250, 275),
                                    content.Load<Texture2D>("Images//survivor"), 1.0f));
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
