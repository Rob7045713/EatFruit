using System;
using System.Collections;
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
    class Snake : Sprite
    {
        internal ArrayList sections;
        internal Splash splash;
        internal LevelManager levelManager;
        internal FruitManager fruitManager;
        internal Score score;
        internal int speed;
        static int HEAD = 0;
        static int NO_COLLISION = -1;

        public Snake(Texture2D texture, Vector2 position, Vector2 screenSize, LevelManager levelManager, FruitManager fruitManager, Splash splash, Score score) 
            : base(texture, position, screenSize)
        {
            sections.Add(this);
            speed = 1;
            state = new UpState(this);
            this.levelManager = levelManager;
            this.fruitManager = fruitManager;
            this.splash = splash;
            this.score = score;
        }

        public void Grow(int growBy)
        {

        }
        public void Shrink(int shrinkBy)
        {

        }

        public void SpeedUp(int speedUpBy)
        {

        }

        public void SlowDown(int slowDownBy)
        {

        }

        public int Collide(ArrayList sprites)
        {

            for (int i = 1; i < sprites.Count; i++)
            {
                if ((sections[HEAD] as Sprite).isInside(sections[i] as Sprite))
                {
                    return i;
                }
            }
            return -1;
        }

        public override void Update(double elapsedTime)
        {
            // update section velocitied
            for (int i = 1; i < sections.Count; i++)
            {
                (sections[i] as Sprite).setVelocity((sections[i-1] as Sprite).getVelocity());
                (sections[i] as Sprite).Update(elapsedTime);
            }

            // check for collisions with snake and barriers
            if (Collide(sections.GetRange(1, sections.Count - 1)) != NO_COLLISION
                || Collide(levelManager.getBarriers()) != NO_COLLISION)
            {
                state = new DeadState(this);
            }

            // check for collisions with fruits
            int fruitHit = Collide(fruitManager.getFruits());
            if (fruitHit != NO_COLLISION)
            {
                fruitManager.CollectFruit(fruitHit);
            }

            base.Update(elapsedTime);
        }

        class StartState : State
        {
            public StartState(Snake snake)
            {

            }

            public void Update(double elapsedTime, Snake snake)
            {

            }

            public void Draw(Snake snake, SpriteBatch spriteBatch)
            {

            }
        }

        class RightState : State
        {
            public RightState(Snake snake)
            {
                snake.velocity = new Vector2(snake.speed, 0);
            }

            public void Update(double elapsedTime, Snake snake)
            {

            }

            public void Draw(Snake snake, SpriteBatch spriteBatch)
            {

            }
        }

        class UpState : State
        {
            public UpState(Snake snake)
            {
                snake.velocity = new Vector2(0, -1*snake.speed);
            }

            public void Update(double elapsedTime, Snake snake)
            {

            }

            public void Draw(Snake snake, SpriteBatch spriteBatch)
            {
                
            }
        }

        class LeftState : State
        {
            public LeftState(Snake snake)
            {
                snake.velocity = new Vector2(-1*snake.speed, 0);
            }

            public void Update(double elapsedTime, Snake snake)
            {

            }

            public void Draw(Snake snake, SpriteBatch spriteBatch)
            {

            }
        }

        class DownState : State
        {
            public DownState(Snake snake)
            {
                snake.velocity = new Vector2(0,snake.speed);
            }

            public void Update(double elapsedTime, Snake snake)
            {

            }

            public void Draw(Snake snake, SpriteBatch spriteBatch)
            {

            }
        }

        class DeadState : State
        {
            public DeadState(Snake snake)
            {
                snake.velocity = new Vector2(0, 0);
            }

            public void Update(double elapsedTime, Snake snake)
            {

            }

            public void Draw(Snake snake, SpriteBatch spriteBatch)
            {

            }
        }

    }
}
