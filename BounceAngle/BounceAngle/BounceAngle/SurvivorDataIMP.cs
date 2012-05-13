using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BounceAngle
{
    class SurvivorDataIMP : SurvivorData
    {
        int id;
        Vector2 location;
        Vector2 destination;
        Texture2D texture;
        Vector2 offset;
        //TODO: animations! 

        float moveSpeed;

        public SurvivorDataIMP( int _id, Vector2 _loc, Vector2 _des, Texture2D _tex, float _moveSpeed) {
            id = _id;
            location = _loc;
            destination = _des;
            texture = _tex;
            moveSpeed = _moveSpeed;
        }

        public int getId(){
            return id;
        }

        public Vector2 getCurrentLocation() {
            return location;
        }

        public Vector2 getDestination(){
            return destination;
        }

        public Texture2D getTexture() {
            return texture;
        }

        public void setOffset(Vector2 _offset)
        {
            offset += _offset;
            offset.X = MathHelper.Clamp(offset.X, -1500, 1500);
            offset.Y = MathHelper.Clamp(offset.Y, -900, 500);
        }
        public Vector2 getOffset()
        {
            return offset;
        }

        public float getMoveSpeed() {
            return moveSpeed;   
        }

        public float getCollisionRadius()
        {
            return 25;
        }

        public void setCurrentLocation(Vector2 loc) {
            location = loc;
        }

        public void setDestination(Vector2 loc) {
            destination = loc;
        }

        public void setMoveSpeed(float speed)
        {
            moveSpeed = speed;
        }
    }
}
