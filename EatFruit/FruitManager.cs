using System;
using System.Collections;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using System.Text;

namespace EatFruit
{
    class FruitManager : Sprite
    {
        LevelManager levelManager;
        ArrayList fruits;

        public FruitManager(Vector2 screenSize, LevelManager levelManager) : base(null, new Vector2(0,0), screenSize)
        {
            this.levelManager = levelManager;
        }

        public ArrayList getFruits()
        {
            return fruits;
        }

        public void CollectFruit(int fruitNumber)
        {
            (fruits[fruitNumber] as Fruit).getGameAction().Invoke();
            fruits.RemoveAt(fruitNumber);
        }
    }
}
