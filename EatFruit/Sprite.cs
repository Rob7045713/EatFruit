using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;


namespace EatFruit
{
    class Sprite
    {
        internal Texture2D texture;
        internal Vector2 position;
        internal Vector2 velocity;
        internal State state;
        internal Vector2 screenSize;

        public Sprite(Texture2D texture, Vector2 position, Vector2 screenSize)
        {
            this.texture = texture;
            this.position = position;
            this.screenSize = screenSize;
        }

        public bool isInside(Sprite sprite)
        {
            if (Math.Abs(this.Center().X - sprite.Center().X) < texture.Width / 2 + sprite.getTexture().Width / 2
                && Math.Abs(this.Center().Y - sprite.Center().Y) < texture.Height / 2 + sprite.getTexture().Height / 2)
            {
                return true;
            }
            return false;
        }


        public Vector2 Center()
        {
            return new Vector2(position.X + texture.Width / 2, position.Y + texture.Height / 2);
        }

        public Vector2 getVelocity()
        {
            return velocity;
        }

        public Vector2 getPosition()
        {
            return position;
        }

        public Texture2D getTexture()
        {
            return texture;
        }

        public void setVelocity(Vector2 velocity)
        {
            this.velocity = velocity;
        }

        public virtual void Update(double elapsedTime)
        {
            position += velocity;

            WrapAround();

            if (state != null)
            {
                state.Update(elapsedTime, this);
            }
        }

        public void WrapAround()
        {
            if (Center().X > screenSize.X)
            {
                position.X = texture.Width / 2;
            }
            if (Center().X < 0)
            {
                position.X = screenSize.X - texture.Width / 2;
            }
            if (Center().Y > screenSize.Y)
            {
                position.Y = texture.Height / 2;
            }
            if (Center().Y < 0)
            {
                position.Y = screenSize.Y - texture.Height / 2;
            }
        }

    }
}
